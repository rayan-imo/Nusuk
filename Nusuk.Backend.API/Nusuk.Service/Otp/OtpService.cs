using Microsoft.AspNetCore.Identity;
using Nusuk.Core.Interfaces;
using Nusuk.Services.AuthServices.Hasher;
using Nusuk.Services.Otp;

namespace Nusuk.Services.Otp;

public class OtpService(IUnitOfWork _uow, IPasswordHasher _passwordHasher,
    EmailService _emailService) :IOtpService
{
    public async Task<UserOtp> SendOtpAsync(string email)
    {
        var user = await _uow.UsersRepository.GetByItemAsync(u => u.Email == email);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var code = new Random().Next(100000, 999999).ToString();
        await _emailService.SendEmailAsync(email, "OTP Code", $"{code}");
        var hashcode = _passwordHasher.HashPassword(code);

        var result = new UserOtp
        {
            UserId = user.Id,
            Email = email,
            Code = hashcode,
            IsUSed = false,
            CreatedAt = DateTime.UtcNow,
            ExpireDate = DateTime.Now.AddMinutes(5)
        };
        await _uow.UserOtpRepository.UpdateAsync(result);
        await _uow.CompleteAsync();
        return result;
    }

    public async Task<bool> VerfiyCodeAsync(string email, string code)
    {
        var user = await _uow.UsersRepository.GetByItemAsync(u => u.Email == email);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var otps = await _uow.UserOtpRepository.FindAllAsync(o => o.UserId == user.Id
        && o.IsUSed == false);
        var otp = otps.OrderByDescending(o => o.CreatedAt).FirstOrDefault();



        if (otp == null || otp.Code != code || DateTime.Now > otp.ExpireDate)
        {
            return false;
        }
        otp.IsUSed = true;
        await _uow.UserOtpRepository.UpdateAsync(otp);
        await _uow.CompleteAsync();
        return true;
    }
    public async Task<bool> ChangePasswordAsync(string email, string newPassword)
    {
        var user = await _uow.UsersRepository.GetByItemAsync(u => u.Email == email);
        if (user == null)
        {
            return false;
        }
        user.Password = _passwordHasher.HashPassword(newPassword);
        await _uow.UsersRepository.UpdateAsync(user);
        await _uow.CompleteAsync();
        return true;
    }
}

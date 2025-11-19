using Nusuk.Services.Otp;

namespace Nusuk.Services.Otp;

public interface IOtpService
{
    Task<UserOtp> SendOtpAsync(string email);
    Task<bool> VerfiyCodeAsync(string email, string code);
    Task<bool> ChangePasswordAsync(string email, string newPassword);
}


using Microsoft.AspNetCore.Identity;
using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Services.AuthServices.GenerateToken;
using Nusuk.Services.AuthServices.Hasher;
using Nusuk.Services.AuthServices.Helper;
using Nusuk.Services.AuthServices.Services;
using Nusuk.Services.Otp;

namespace Nusuk.Services.AuthServices.Service;

public class AuthService(IUnitOfWork _uow, IPasswordHasher _passwordHasher,
    IGenerateTokenJwt _generateTokenJwt) : IAuthService
{

    public async Task<AuthModel> RegisterAsync(RegisterModel model)
    {
        if (await _uow.UsersRepository.GetByItemAsync(u => u.Email == model.Email) is not null)
        {
            return new AuthModel { Message = "Email is already Register " };
        }
        if (await _uow.UsersRepository.GetByItemAsync(u => u.Name == model.Name) is not null)

        {
            return new AuthModel { Message = "Name is already Register " };
        }
        var haspassword = _passwordHasher.HashPassword(model.Password);
        var user = new User
        {
            Email = model.Email,
            Name = model.Name,
            Password = model.Password,
        };
        await _uow.UsersRepository.AddAsync(user);

        var jwt = _generateTokenJwt.GenerateAccessToken(user.Id, user.RoleId, user.Name, user.Email); // add userame to the claim
                                                                                                      //  var role=await _uow.RoleRepository.GetByItemAsync(r=>r.Id==model.Role.Id);
        await _uow.CompleteAsync();

        return new AuthModel
        {
            Email = model.Email,
            Name = model.Name,
            IsAuthenticated = true,
            RoleId = user.RoleId,
            Token = jwt,
            Message = "Registration successful"
        };

    }
    public async Task<AuthModel> LogInAsync(LogInModel model)
    {
        var authmodel = new AuthModel();
        var user = await _uow.UsersRepository.GetByItemAsync(u => u.Name == model.Name);

        if (user == null)
        {
            authmodel.Message = "Name or Password is incorrect";
            return authmodel;

        }
        var IsValidPassword = _passwordHasher.VerifyHashedPassword(user.Password, model.Password);
        if (!IsValidPassword)
        {
            authmodel.Message = "Name or Password is incorrect";
            return authmodel;
        }
        var jwt = _generateTokenJwt.GenerateAccessToken(user.Id, user.RoleId, user.Name, user.Email);

        return new AuthModel
        {
            Email = user.Email,
            Name = user.Name,
            IsAuthenticated = true,
            RoleId = user.RoleId,
            Token = jwt,
            Message = "LogIn successful"
        };
    }
}
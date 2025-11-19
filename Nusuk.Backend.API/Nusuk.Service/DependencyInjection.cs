

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Nusuk.Core.Entities;
using Nusuk.Services.AuthServices.GenerateToken;
using Nusuk.Services.AuthServices.Hasher;
using Nusuk.Services.AuthServices.Helper;
using Nusuk.Services.AuthServices.Service;
using Nusuk.Services.AuthServices.Services;
using Nusuk.Services.IServices;
using Nusuk.Services.Otp;
using Nusuk.Services.Services;
using System.Collections;
using System.Text;

namespace Nusuk.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration config)
        {
            //
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IGenerateTokenJwt, GenerateTokenJwt>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<EmailService>();

            return services;
        }
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var jwt = config.GetSection("JWT").Get<JWT>();
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Secret))
                };
            });
            services.AddSingleton(jwt);
            return services;
        }
    }
}


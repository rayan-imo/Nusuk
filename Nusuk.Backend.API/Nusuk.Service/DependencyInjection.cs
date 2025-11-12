

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nusuk.Core.Entities;
using Nusuk.Service.IServices;
using Nusuk.Service.Services;

namespace Nusuk.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration config)
        {
           //
           services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nusuk.Core.Entities;
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure;
using Nusuk.Infrastructure.Repositories;
using Nusuk.Service.IServices;
using Nusuk.Service.Services;

namespace Nusuk.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration config)
        {
           //
           //services.AddScoped(typeof(IBaseRepository<User>), typeof(BaseRepository<User>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nusuk.Infrastructure.Data;

namespace Nusuk.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {

        // DbContext
        services.AddDbContext<NusukDbContext>(options =>
        options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
        b=>b.MigrationsAssembly(typeof(NusukDbContext).Assembly.FullName))
        );




        return services;
    }
}

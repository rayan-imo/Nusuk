using Microsoft.OpenApi.Models;
namespace Quizzy.Backend.API.Extensions;

public static class SwaggerServiceExtensions
{
    public static IServiceCollection AddSwaggerExtension(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            // ومعلوماتهاAPI تعريف نسخة الـ
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Nusuk API",
                Version = "v1",
                Description = "API for Nusuk Application"
            });

            //JWT إعدادات 
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter your JWT token"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });

        return services;
    }
}
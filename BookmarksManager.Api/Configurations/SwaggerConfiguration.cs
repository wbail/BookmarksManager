using Microsoft.OpenApi.Models;

namespace BookmarksManager.Api.Configurations;

public static class SwaggerConfiguration
{
    public static void Configure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(x =>
        {
            var version = configuration["OpenApiSettings:Version"];
            var title = configuration["OpenApiSettings:Title"];

            x.SwaggerDoc(version, new OpenApiInfo { Title = title, Version = version });
            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter the token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            x.AddSecurityRequirement(new OpenApiSecurityRequirement
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

                    new string[] { }
                }
            });
        });
    }
}

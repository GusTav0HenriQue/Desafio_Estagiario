using System.Reflection;
using Microsoft.OpenApi.Models;

namespace IMDb_api.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<BearerAthenticationFilter>();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In =  ParameterLocation.Header,
                    Scheme = "Bearer",
                    Type = SecuritySchemeType.Http
                });
            });
            return services;
        }
    }
}

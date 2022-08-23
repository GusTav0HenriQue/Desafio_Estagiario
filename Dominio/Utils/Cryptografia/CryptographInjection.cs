using Dominio.Interfaces.Cryptograph;
using Microsoft.Extensions.DependencyInjection;

namespace Dominio.Utils.Cryptografia
{
    public static class CryptographInjection
    {
        public static IServiceCollection AddCryptographInjection(this IServiceCollection services)
        {
            services.AddScoped<ICryptograph, Sha256Cryptograph>();
            services.AddScoped<ITokenService, ITokenService>();
            return services;
        }
    }
}

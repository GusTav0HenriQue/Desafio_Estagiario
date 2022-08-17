using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces.Cryptograph;
using Microsoft.Extensions.DependencyInjection;

namespace Service.Utils.Cripitografia
{
    public static class CryptographInjecton
    {
        public static IServiceCollection AddCryptographInjection(this IServiceCollection services)
        {
            services.AddScoped<ICryptograph, SHA256Cryptograph>();
            services.AddScoped<ITokenService, ITokenService>();
            return services;
        }
    }
}

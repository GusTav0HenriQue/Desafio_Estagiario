using Data.Repositories;
using Dominio.Interfaces.Cryptograph;
using Dominio.Interfaces.Data;
using Service.Interfaces;
using Service.Services;
using Service.Utils.Cripitografia;

namespace IMDb_api.Extensions
{
    public static class DependenceInjecttionEctensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICryptograph, Cryptograph>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddScoped<IElencoRepository, ElencoRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IElencoService, ElencoService>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IAvaliacaoService, AvaliacaoService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}

using BancoDeSangue.Core.Repositories;
using BancoDeSangue.Infrastructure.ExternalServices;
using BancoDeSangue.Infrastructure.ExternalServices.Interfaces;
using BancoDeSangue.Infrastructure.Persistence;
using BancoDeSangue.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BancoDeSangue.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories()
                .AddData(configuration)
                .AddExternalServices();

            return services;
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BancoDeDoacoesCs");
            services.AddDbContext<DoacoesDbContext>(o => o.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
             services.AddScoped<IDoadorRepository, DoadorRepository>();
             services.AddScoped<IDoacaoRepository, DoacaoRepository>();
             services.AddScoped<IEstoqueSangueRepository, EstoqueSangueRepository>();
             services.AddScoped<IHistoricoEstoqueAbaixoDoMinimoRepository, HistoricoEstoqueAbaixoDoMinimoRepository>();

            return services;
        }

        private static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            services.AddHttpClient<ICepService, CepService>(client =>
            {
                client.BaseAddress = new Uri("https://viacep.com.br/");
                client.Timeout = TimeSpan.FromSeconds(10);
            });

            return services;
        }

    }
}

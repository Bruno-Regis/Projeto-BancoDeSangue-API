using BancoDeSangue.Core.Repositories;
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
                .AddData(configuration);

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
            // services.AddScoped<IDoacaoRepository, DoacaoRepository>();
            // services.AddScoped<IEstoqueSangueRepository, EstoqueSangueRepository>();
            return services;
        }

    }
}

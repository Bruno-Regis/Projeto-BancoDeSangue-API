using BancoDeSangue.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BancoDeSangue.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            services.AddServices();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDoadorService, DoadorService>();
            services.AddScoped<IEstoqueSangueService, EstoqueSangueService>();
            return services;
        }
    }
}

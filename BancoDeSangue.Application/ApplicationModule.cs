using BancoDeSangue.Application.Services;
using BancoDeSangue.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BancoDeSangue.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            services
                .AddServices()
                .AddValidation();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDoadorService, DoadorService>();
            services.AddScoped<IEstoqueSangueService, EstoqueSangueService>();
            services.AddScoped<IDoacaoService, DoacaoService>();
            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateDoadorInputModelValidator>();
                

            return services;
        }

    }
}

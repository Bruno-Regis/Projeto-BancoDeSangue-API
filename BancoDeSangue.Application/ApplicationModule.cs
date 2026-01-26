using BancoDeSangue.Application.Events;
using BancoDeSangue.Application.Models.ViewModels;
using BancoDeSangue.Application.Services;
using BancoDeSangue.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BancoDeSangue.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            services
                .AddServices()
                .AddHandlers()
                .AddValidation();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDoadorService, DoadorService>();
            services.AddScoped<IEstoqueSangueService, EstoqueSangueService>();
            services.AddScoped<IDoacaoService, DoacaoService>();
            services.AddScoped<IRelatorioService, RelatorioService>();
            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<EstoqueAbaixoMinimoDomainEventHandler>());

            //services.AddTransient<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>, ValidateInsertProjectCommandBehavior>();
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

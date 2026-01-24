using BancoDeSangue.Core.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BancoDeSangue.Application.Events
{
    public class EstoqueAbaixoMinimoDomainEventHandler : INotificationHandler<EstoqueAbaixoMinimoDomainEvent>
    {
        private readonly ILogger<EstoqueAbaixoMinimoDomainEventHandler> _logger;
        // aqui você poderia injetar IEmailService, INotificationService etc.

        public EstoqueAbaixoMinimoDomainEventHandler(
            ILogger<EstoqueAbaixoMinimoDomainEventHandler> logger)
        {
            _logger = logger;
        } 
        public Task Handle(EstoqueAbaixoMinimoDomainEvent notification, CancellationToken cancellationToken)
        {
            var e = notification.EstoqueSangue;

            _logger.LogWarning(
                "ALERTA: Estoque baixo para {Tipo} | Atual: {Atual} ml | Mínimo: {Minimo} ml",
                e.TipoSanguineo, e.QuantidadeMl, e.QuantidadeMinimaMl);

            // aqui pode chamar um EmailService, SignalR, etc.
            return Task.CompletedTask;
        }
    }
}

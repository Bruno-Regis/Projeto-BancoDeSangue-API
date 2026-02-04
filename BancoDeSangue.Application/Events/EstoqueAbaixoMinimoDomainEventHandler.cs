using BancoDeSangue.Application.Models.InputModels;
using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Events;
using BancoDeSangue.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BancoDeSangue.Application.Events
{
    public class EstoqueAbaixoMinimoDomainEventHandler : INotificationHandler<EstoqueAbaixoMinimoDomainEvent>
    {
        private readonly ILogger<EstoqueAbaixoMinimoDomainEventHandler> _logger;    
        private readonly IHistoricoEstoqueAbaixoDoMinimoRepository _historicoRepository;
        public EstoqueAbaixoMinimoDomainEventHandler(
            ILogger<EstoqueAbaixoMinimoDomainEventHandler> logger,
            IHistoricoEstoqueAbaixoDoMinimoRepository historicoRepository)
        {
            _logger = logger;
            _historicoRepository = historicoRepository;
        } 
        public async Task Handle(EstoqueAbaixoMinimoDomainEvent notification, CancellationToken cancellationToken)
        {
            var e = notification.EstoqueSangue;

            _logger.LogWarning(
                $"ALERTA: Estoque baixo para {e.TipoSanguineo} | Atual: {e.QuantidadeMl} ml | Mínimo: {e.QuantidadeMinimaMl} ml");

            var historico = new HistoricoEstoqueAbaixoDoMinimo(
                e.TipoSanguineo,
                e.FatorRH,
                e.QuantidadeMl,
                e.QuantidadeMinimaMl);

            historico.SetStatus();

            await _historicoRepository.AddAsync(historico);

        }
    }
}

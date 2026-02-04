using BancoDeSangue.Core.Entities;
using BancoDeSangue.Infrastructure.Persistence.Configurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BancoDeSangue.Infrastructure.Persistence
{
    public class DoacoesDbContext : DbContext
    {
        private readonly IMediator _mediator;
        public DoacoesDbContext(DbContextOptions<DoacoesDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Doador> Doadores { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<EstoqueSangue> Estoques { get; set; }
        public DbSet<HistoricoEstoqueAbaixoDoMinimo> Historicos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DoadoresConfiguration());
            builder.ApplyConfiguration(new DoacoesConfiguration());
            builder.ApplyConfiguration(new EstoqueSanguesConfiguration());
            builder.ApplyConfiguration(new HistoricoEstoqueAbaixoDoMinimoConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {          
            await PublishDomainEventsAsync();

            return await base.SaveChangesAsync(cancellationToken);

        }

        private async Task PublishDomainEventsAsync()
        {
            var entitiesWithEvents = ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.Entity.DomainEvents != null &&
                            e.Entity.DomainEvents.Any())
                .Select(e => e.Entity)
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.DomainEvents!.ToArray();
                entity.ClearDomainEvents();

                foreach (var domainEvent in events)
                    await _mediator.Publish(domainEvent);
            }

        }
    }
}







using BancoDeSangue.Core.Entities;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Doador>(e =>
                {
                    e.HasKey(d => d.Id);

                    e.OwnsOne(d => d.Endereco, end =>
                    {
                        end.Property(e => e.Logradouro)
                            .HasMaxLength(200);
                        end.Property(e => e.Cidade)
                            .HasMaxLength(100);
                        end.Property(e => e.Estado)
                            .HasMaxLength(100);
                        end.Property(e => e.CEP)
                            .HasMaxLength(20);
                    });

                    // Configuração dos enums como string
                    e.Property(d => d.TipoSanguineo)
                        .HasConversion<string>()
                        .HasMaxLength(20)
                        .IsRequired();

                    e.Property(d => d.FatorRh)
                        .HasConversion<string>()
                        .HasMaxLength(10)
                        .IsRequired();

                    e.Property(d => d.Genero)
                        .HasConversion<string>()
                        .HasMaxLength(20)
                        .IsRequired();

                    // Configuração das propriedades
                    e.Property(d => d.Nome)
                       .HasMaxLength(200)
                       .IsRequired();

                    e.Property(d => d.Email)
                        .HasMaxLength(150)
                        .IsRequired();

                    e.Property(d => d.Peso)
                        .HasColumnType("decimal(5,2)")
                        .IsRequired();

                    // relacionamento 1:N com Doacao
                    e.HasMany(d => d.Doacoes)
                        .WithOne(doacao => doacao.Doador)
                        .HasForeignKey(o => o.DoadorId)
                        .OnDelete(DeleteBehavior.Cascade);

                });

            builder
                .Entity<Doacao>(e =>
                {
                    e.HasKey(d => d.Id);

                    e.Property(d => d.DataDoacao)
                        .IsRequired();
                    e.Property(d => d.QuantidadeMl)
                        .HasColumnType("int")
                        .IsRequired();
                });

            builder.Entity<EstoqueSangue>(e =>
            {
                e.HasKey(es => es.Id);

                e.Property(es => es.TipoSanguineo)
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .IsRequired();

                e.Property(es => es.FatorRH)
                    .HasConversion<string>()
                    .HasMaxLength(10)
                    .IsRequired();

                e.Property(es => es.QuantidadeMl)
                    .HasColumnType("int")
                    .IsRequired();

                e.Property(es => es.QuantidadeMinimaMl)
                    .HasDefaultValue(5000)
                    .IsRequired();


                // Índice único para garantir apenas um registro por tipo+fator
                e.HasIndex(es => new { es.TipoSanguineo, es.FatorRH })
                    .IsUnique();
            });
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







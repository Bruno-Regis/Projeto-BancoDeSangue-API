using BancoDeSangue.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancoDeSangue.Infrastructure.Persistence
{
    public class DoacoesDbContext : DbContext
    {
        public DoacoesDbContext(DbContextOptions<DoacoesDbContext> options)
            : base(options)
        {

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

                    e.OwnsOne(d => d.Endereco);

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

                });

            builder.Entity<EstoqueSangue>(e =>
            {
                e.HasKey(es => es.Id);
            });
        }
    }
}

using BancoDeSangue.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoDeSangue.Infrastructure.Persistence.Configurations
{
    public class DoacoesConfiguration : IEntityTypeConfiguration<Doacao>
    {
        public void Configure(EntityTypeBuilder<Doacao> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.DataDoacao)
                .IsRequired();
            builder
                .Property(d => d.QuantidadeMl)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}

using BancoDeSangue.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Infrastructure.Persistence.Configurations
{
    public class HistoricoEstoqueAbaixoDoMinimoConfiguration : IEntityTypeConfiguration<HistoricoEstoqueAbaixoDoMinimo>
    {
        public void Configure(EntityTypeBuilder<HistoricoEstoqueAbaixoDoMinimo> builder)
        {
            builder
                .HasKey(hist => hist.Id);

            builder
                .Property(hist => hist.TipoSanguineo)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(hist => hist.FatorRH)
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(hist => hist.QuantidadeMl)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(hist => hist.QuantidadeMinimaMl)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(hist => hist.Status)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}

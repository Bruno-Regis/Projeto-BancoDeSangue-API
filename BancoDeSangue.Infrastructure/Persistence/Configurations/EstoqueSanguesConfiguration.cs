using BancoDeSangue.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Infrastructure.Persistence.Configurations
{
    internal class EstoqueSanguesConfiguration : IEntityTypeConfiguration<EstoqueSangue>
    {
        public void Configure(EntityTypeBuilder<EstoqueSangue> builder)
        {
            builder
                .HasKey(es => es.Id);

            builder
                .Property(es => es.TipoSanguineo)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(es => es.FatorRH)
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property(es => es.QuantidadeMl)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(es => es.QuantidadeMinimaMl)
                .HasDefaultValue(5000)
                .IsRequired();


            // Índice único para garantir apenas um registro por tipo+fator
            builder
                .HasIndex(es => new { es.TipoSanguineo, es.FatorRH })
                .IsUnique();
        }
    }
}

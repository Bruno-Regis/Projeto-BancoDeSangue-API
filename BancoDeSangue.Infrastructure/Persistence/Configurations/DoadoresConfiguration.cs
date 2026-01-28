using BancoDeSangue.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Infrastructure.Persistence.Configurations
{
    public class DoadoresConfiguration : IEntityTypeConfiguration<Doador>
    {
        public void Configure(EntityTypeBuilder<Doador> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .OwnsOne(d => d.Endereco, end =>
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
                builder
                    .Property(d => d.TipoSanguineo)
                        .HasConversion<string>()
                        .HasMaxLength(20)
                        .IsRequired();

                builder
                    .Property(d => d.FatorRh)
                        .HasConversion<string>()
                        .HasMaxLength(10)
                        .IsRequired();

                builder
                    .Property(d => d.Genero)
                        .HasConversion<string>()
                        .HasMaxLength(20)
                        .IsRequired();

                // Configuração das propriedades
                builder
                    .Property(d => d.Nome)
                        .HasMaxLength(200)
                        .IsRequired();

                builder
                    .Property(d => d.Email)
                        .HasMaxLength(150)
                        .IsRequired();

                builder
                    .Property(d => d.Peso)
                        .HasColumnType("decimal(5,2)")
                        .IsRequired();

                // relacionamento 1:N com Doacao
                builder
                    .HasMany(d => d.Doacoes)
                        .WithOne(doacao => doacao.Doador)
                        .HasForeignKey(o => o.DoadorId)
                        .OnDelete(DeleteBehavior.Cascade);   
        }
    }
}

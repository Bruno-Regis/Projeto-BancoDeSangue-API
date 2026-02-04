using BancoDeSangue.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BancoDeSangue.Core.Entities
{
    public class HistoricoEstoqueAbaixoDoMinimo : BaseEntity
    {
        public HistoricoEstoqueAbaixoDoMinimo(TipoSanguineo tipoSanguineo, FatorRh fatorRH, int quantidadeMl, int quantidadeMinimaMl)
        {
            TipoSanguineo = tipoSanguineo;
            FatorRH = fatorRH;
            QuantidadeMl = quantidadeMl;
            QuantidadeMinimaMl = quantidadeMinimaMl;
        }

        public TipoSanguineo TipoSanguineo { get; private set; }
        public FatorRh FatorRH { get; private set; }
        public int QuantidadeMl { get; private set; }
        public int QuantidadeMinimaMl { get; private set; }
        public Status Status { get; private set; }


        public void SetStatus()
        {
            var percentual = (decimal)QuantidadeMl / QuantidadeMinimaMl * 100;

            switch (percentual)
            {
                case var _ when percentual > 100:
                    Status = Status.Ok;
                    break;
                case var _ when percentual > 80 && percentual <= 100:
                    Status = Status.AbaixoDoMinimo;
                    break;
                case var _ when percentual <= 80:
                    Status = Status.Critico;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Status), "Status inválido para o histórico de estoque.");
            }

        }
    }
}

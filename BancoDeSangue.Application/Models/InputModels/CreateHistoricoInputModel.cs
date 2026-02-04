using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Models.InputModels
{
    public class CreateHistoricoInputModel
    {
        public string Id { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public FatorRh FatorRH { get; set; }
        public int QuantidadeMl { get; set; }
        public int QuantidadeMinimaMl { get; set; }

        public HistoricoEstoqueAbaixoDoMinimo ToEntity()
            => new HistoricoEstoqueAbaixoDoMinimo(TipoSanguineo, FatorRH, QuantidadeMl, QuantidadeMinimaMl);           
    }
}

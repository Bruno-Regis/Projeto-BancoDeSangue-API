using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Models.ViewModels
{
    public class EstoqueSangueViewModel
    {
        public EstoqueSangueViewModel(int id, TipoSanguineo tipoSanguineo, FatorRh fatorRH, int quantidadeMl, int quantidadeMinimaMl)
        {
            Id = id;
            TipoSanguineo = tipoSanguineo;
            FatorRH = fatorRH;
            QuantidadeMl = quantidadeMl;
            QuantidadeMinimaMl = quantidadeMinimaMl;
        }

        public int Id { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public FatorRh FatorRH { get; set; }
        public int QuantidadeMl { get; set; }
        public int QuantidadeMinimaMl { get; set; }

        public static EstoqueSangueViewModel FromEntity(EstoqueSangue estoqueSangue)
        => new EstoqueSangueViewModel(estoqueSangue.Id, estoqueSangue.TipoSanguineo, estoqueSangue.FatorRH, estoqueSangue.QuantidadeMl, estoqueSangue.QuantidadeMinimaMl);

    }
}

using BancoDeSangue.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Models.ViewModels
{
    public class DoacaoItemViewModel
    {
        public DoacaoItemViewModel(DateTime dataDoacao, int quantidadeMl, TipoSanguineo tipoSanguineo, FatorRh fatorRh)
        {
            DataDoacao = dataDoacao;
            QuantidadeMl = quantidadeMl;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
        }

        public DateTime DataDoacao { get; set; }
        public int QuantidadeMl { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public FatorRh FatorRh { get; set; }


        public static DoacaoItemViewModel FromEntity(Core.Entities.Doacao doacao)
        {
            return new DoacaoItemViewModel(
                doacao.DataDoacao,
                doacao.QuantidadeMl,
                doacao.Doador.TipoSanguineo,
                doacao.Doador.FatorRh
            );
        }
    }
}

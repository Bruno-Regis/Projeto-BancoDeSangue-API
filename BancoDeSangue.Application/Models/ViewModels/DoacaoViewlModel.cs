using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Models.ViewModels
{
    public class DoacaoViewlModel
    {
        public DoacaoViewlModel(int doadorId, DateTime dataDoacao, int quantidadeMl, TipoSanguineo tipoSanguineo, FatorRh fatorRh)
        {
            DoadorId = doadorId;
            DataDoacao = dataDoacao;
            QuantidadeMl = quantidadeMl;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
        }

        public int DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeMl { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public FatorRh FatorRh { get; set; }

        public static DoacaoViewlModel FromEntity(Doacao doacao)
        {
            return new DoacaoViewlModel(
                doacao.DoadorId,
                doacao.DataDoacao,
                doacao.QuantidadeMl,
                doacao.Doador.TipoSanguineo,
                doacao.Doador.FatorRh
            );
        }
    }
}

using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Models.ViewModels
{
    public class DoacaoViewModel
    {
        public DoacaoViewModel( string nomeDoador, int doadorId, DateTime dataDoacao, int quantidadeMl, TipoSanguineo tipoSanguineo, FatorRh fatorRh)
        {
            NomeDoador = nomeDoador;
            DoadorId = doadorId;
            DataDoacao = dataDoacao;
            QuantidadeMl = quantidadeMl;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;

        }

        public string NomeDoador { get; set; }
        public int DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeMl { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public FatorRh FatorRh { get; set; }


        public static DoacaoViewModel FromEntity(Doacao doacao)
        {
            return new DoacaoViewModel(
                doacao.Doador.Nome,
                doacao.Doador.Id,
                doacao.DataDoacao,
                doacao.QuantidadeMl,
                doacao.Doador.TipoSanguineo,
                doacao.Doador.FatorRh
            );
        }
    }
}

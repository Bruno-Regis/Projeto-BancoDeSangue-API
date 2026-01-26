using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Models.ViewModels
{
    public class RelatorioUltimos30DiasViewModel
    {

        public RelatorioUltimos30DiasViewModel(string nome, string email, DateTime dataNascimento,
            Genero genero, double peso, TipoSanguineo tipoSanguineo, FatorRh fatorRh, string logradouro,
            string cidade, string estado, string cEP, int quantidadeMl, DateTime dataDoacao)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
            QuantidadeMl = quantidadeMl;
            DataDoacao = dataDoacao;
        }

        public string Nome { get; set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; set; }
        public Genero Genero { get; set; }
        public double Peso { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public FatorRh FatorRh { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public int QuantidadeMl { get; set; }
        public DateTime DataDoacao { get; set; }

        public static RelatorioUltimos30DiasViewModel FromEntity(Doacao doacao)
            => new RelatorioUltimos30DiasViewModel
            (
                doacao.Doador.Nome, doacao.Doador.Email, doacao.Doador.DataNascimento,
                doacao.Doador.Genero, doacao.Doador.Peso, doacao.Doador.TipoSanguineo,
                doacao.Doador.FatorRh, doacao.Doador.Endereco.Logradouro, doacao.Doador.Endereco.Cidade,
                doacao.Doador.Endereco.Estado, doacao.Doador.Endereco.CEP, doacao.QuantidadeMl, doacao.DataDoacao
            );
    }
}

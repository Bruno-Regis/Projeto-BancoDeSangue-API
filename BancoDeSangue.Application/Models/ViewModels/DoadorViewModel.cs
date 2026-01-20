using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Models.ViewModels
{
    public class DoadorViewModel
    {
        public DoadorViewModel(int id, string nome, string email, DateTime dataNascimento, Genero genero, double peso,
            TipoSanguineo tipoSanguineo, FatorRh fatorRh, List<DoacaoViewlModel> doacoes, string logradouro,
            string cidade, string estado, string cEP)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            Doacoes = doacoes;
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Genero Genero { get; set; }
        public double Peso { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public FatorRh FatorRh { get; set; }
        public List<DoacaoViewlModel> Doacoes { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public static DoadorViewModel FromEntity(Doador doador)
        {
            return new DoadorViewModel(
                doador.Id,
                doador.Nome,
                doador.Email,
                doador.DataNascimento,
                doador.Genero,
                doador.Peso,
                doador.TipoSanguineo,
                doador.FatorRh,
                doador.Doacoes?
                    .Select(d => DoacaoViewlModel.FromEntity(d))
                    .ToList() ?? new List<DoacaoViewlModel>(),
                doador.Endereco.Logradouro,
                doador.Endereco.Cidade,
                doador.Endereco.Estado,
                doador.Endereco.CEP
            );
        }
    }
}

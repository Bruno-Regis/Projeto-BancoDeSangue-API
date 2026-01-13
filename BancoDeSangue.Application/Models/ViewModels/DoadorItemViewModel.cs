using BancoDeSangue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Models.ViewModels
{
    public class DoadorItemViewModel
    {
        public DoadorItemViewModel(string nome, string email, DateTime dataNascimento,
            string genero, double peso, string tipoSanguineo, string fatorRh, string logradouro,
            string cidade, string estado, string cEP)
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
        }

        public String Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public double Peso { get; set; }
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public static DoadorItemViewModel FromEntity(Doador doador)
        {
            return new DoadorItemViewModel(
                doador.Nome,
                doador.Email,
                doador.DataNascimento,
                doador.Genero,
                doador.Peso,
                doador.TipoSanguineo,
                doador.FatorRh,
                doador.Endereco.Logradouro,
                doador.Endereco.Cidade,
                doador.Endereco.Estado,
                doador.Endereco.CEP
            );
        }
    }
}

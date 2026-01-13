using BancoDeSangue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Models.InputModels
{
    public class CreateDoadorInputModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public double Peso { get; set; }
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public Endereco Endereco { get; set; }

        public Doador ToEntity()
        {
            return new Doador(Nome, Email, DataNascimento, Genero, Peso, TipoSanguineo, FatorRh, Endereco);
        }
    }
}

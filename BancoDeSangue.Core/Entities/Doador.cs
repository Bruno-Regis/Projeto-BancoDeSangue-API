
using BancoDeSangue.Core.Exceptions;

namespace BancoDeSangue.Core.Entities
{
    public class Doador : BaseEntity
    {
        private Doador() { }
        public Doador(string nome, string email, DateTime dataNascimento, string genero, double peso, string tipoSanguineo, string fatorRh, Endereco endereco)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            Doacoes = new List<Doacao>() { };
            Endereco = endereco;
        }

        public String Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Genero { get; private set; }
        public double Peso { get; private set; }
        public string TipoSanguineo { get; private set; }
        public string FatorRh { get; private set; }
        public List<Doacao> Doacoes { get; private set; }
        public Endereco Endereco { get; private set; }


        public void RealizarDoacao()
        {
            var idade = DateTime.Now.Year - DataNascimento.Year;
            if (idade < 18)
                throw new DomainException("Doador precisa ter no mínimo 18 anos");
            if(Peso < 50)
                throw new DomainException("Doador precisa ter no mínimo 50kg");
        }       
    }
}

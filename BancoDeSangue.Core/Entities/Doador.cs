
using BancoDeSangue.Core.Enums;
using BancoDeSangue.Core.Exceptions;

namespace BancoDeSangue.Core.Entities
{
    public class Doador : BaseEntity
    {
        private Doador() { }
        public Doador(string nome, string email, DateTime dataNascimento, Genero genero, double peso, TipoSanguineo tipoSanguineo, FatorRh fatorRh, Endereco endereco)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new DomainException("Nome é obrigatório");

            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("Email é obrigatório");

            if (peso <= 0)
                throw new DomainException("Peso deve ser maior que zero");

            if (dataNascimento >= DateTime.Now)
                throw new DomainException("Data de nascimento inválida");

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

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Genero Genero { get; private set; }
        public double Peso { get; private set; }
        public TipoSanguineo TipoSanguineo { get; private set; }
        public FatorRh FatorRh { get; private set; }
        public List<Doacao> Doacoes { get; private set; } = new List<Doacao>();
        public Endereco Endereco { get; private set; }


        public void RealizarDoacao(Doacao doacao)
        {
            Doacoes.Add(doacao);
        }       

        public void ValidarDoacao()
        {
            var idade = DateTime.Now.Year - DataNascimento.Year;
            if (idade < 18)
                throw new DomainException("Doador precisa ter no mínimo 18 anos");
            if (Peso < 50)
                throw new DomainException("Doador precisa ter no mínimo 50kg");

            if (Doacoes is null || Doacoes.Count == 0)
                return;
         
            var ultimaDoacao = Doacoes
                .OrderByDescending(d => d.DataDoacao)
                .First();

            var diferencaDias = (DateTime.Now - ultimaDoacao.DataDoacao).TotalDays;

            if (Genero == Genero.Masculino && diferencaDias < 60)
                throw new DomainException("Doador só pode realizar uma nova doação após 60 dias da última doação");
            if (Genero == Genero.Feminino && diferencaDias < 90)
                throw new DomainException("Doador só pode realizar uma nova doação após 90 dias da última doação");
            if (Genero == Genero.Outro && diferencaDias < 90)
                throw new DomainException("Doador só pode realizar uma nova doação após 90 dias da última doação");
            
        }
    }
}


namespace BancoDeSangue.Core.Entities
{
    public class Doador : BaseEntity
    {
        public String Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Genero { get; private set; }
        public string TipoSanguineo { get; private set; }
        public string FatorRh { get; private set; }
        public List<Doacao> Doacoes { get; private set; }
        public Endereco Endereco { get; private set; }

    }
}

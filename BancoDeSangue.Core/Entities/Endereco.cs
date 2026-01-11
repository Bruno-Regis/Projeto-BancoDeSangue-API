namespace BancoDeSangue.Core.Entities
{
    public class Endereco : BaseEntity
    {
        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }
        public Doador Doador { get; private set; }
    }
}
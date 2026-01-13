namespace BancoDeSangue.Core.Entities
{
    public class Endereco
    {
        private Endereco() { }
        public Endereco(string logradouro, string cidade, string estado, string cEP)
        {
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
        }

        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }
    }
}
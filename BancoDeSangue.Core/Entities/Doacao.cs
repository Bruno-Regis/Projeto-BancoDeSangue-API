namespace BancoDeSangue.Core.Entities
{
    public class Doacao : BaseEntity
    {
        private Doacao() { }
        public Doacao(int doadorId, DateTime dataDoacao, int quantidadeMl, Doador doador)
        {
            DoadorId = doadorId;
            DataDoacao = dataDoacao;
            QuantidadeMl = quantidadeMl;
            Doador = doador;
        }

        public int DoadorId { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeMl { get; private set; }
        public Doador Doador { get; private set; }
  
    }
}
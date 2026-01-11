namespace BancoDeSangue.Core.Entities
{
    public class Doacao : BaseEntity
    {
        public int DoadorId { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeMl { get; private set; }
        public Doador Doador { get; private set; }
    }
}
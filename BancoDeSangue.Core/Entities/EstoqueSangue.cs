
namespace BancoDeSangue.Core.Entities
{
    public class EstoqueSangue : BaseEntity  
    {
        public string TipoSanguineo { get; private set; }
        public string FatorRH { get; private set; }
        public int QuantidadeMl { get; private set; }
    }
}

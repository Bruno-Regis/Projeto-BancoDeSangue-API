
namespace BancoDeSangue.Core.Entities
{
    public class EstoqueSangue : BaseEntity  
    {
        
        private EstoqueSangue() { }
        public EstoqueSangue(string tipoSanguineo, string fatorRH, int quantidadeMl)
        {
            TipoSanguineo = tipoSanguineo;
            FatorRH = fatorRH;
            QuantidadeMl = quantidadeMl;
        }

        public string TipoSanguineo { get; private set; }
        public string FatorRH { get; private set; }
        public int QuantidadeMl { get; private set; }
    }
}

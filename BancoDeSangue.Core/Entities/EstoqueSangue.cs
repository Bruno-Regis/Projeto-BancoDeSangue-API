
using BancoDeSangue.Core.Enums;

namespace BancoDeSangue.Core.Entities
{
    public class EstoqueSangue : BaseEntity  
    {
        
        private EstoqueSangue() { }
        public EstoqueSangue(TipoSanguineo tipoSanguineo, FatorRh fatorRH, int quantidadeMl)
        {
            TipoSanguineo = tipoSanguineo;
            FatorRH = fatorRH;
            QuantidadeMl = quantidadeMl;
        }

        public TipoSanguineo TipoSanguineo { get; private set; }
        public FatorRh FatorRH { get; private set; }
        public int QuantidadeMl { get; private set; }
    }
}

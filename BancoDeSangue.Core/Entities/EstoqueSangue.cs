
using BancoDeSangue.Core.Enums;
using BancoDeSangue.Core.Exceptions;

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
        public int QuantidadeMinimaMl { get; private set;  } = 5000;

        public void AdicionarSangueAoEstoque(int quantidadeMl)
        {
            if (quantidadeMl <= 0)
                throw new DomainException("A quantidade a ser adicionada deve ser maior que zero.");
            QuantidadeMl += quantidadeMl;
        }

        public void RemoverSangueDoEstoque(int quantidadeMl)
        {
            if (quantidadeMl <= 0)
                throw new DomainException("A quantidade a ser removida deve ser maior que zero.");
            if (quantidadeMl > QuantidadeMl)
                throw new DomainException("Quantidade insuficiente no estoque para remoção.");
            QuantidadeMl -= quantidadeMl;
        }

        public void AtualizarQuantidadeMinima(int quantidadeMl)
        {
            if (quantidadeMl < 0)
                throw new DomainException("A quantidade mínima não pode ser negativa.");
            QuantidadeMinimaMl = quantidadeMl;
        }
    }
}

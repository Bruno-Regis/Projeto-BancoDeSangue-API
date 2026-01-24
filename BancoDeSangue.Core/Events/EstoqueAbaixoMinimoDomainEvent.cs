using BancoDeSangue.Core.Entities;


namespace BancoDeSangue.Core.Events
{
    public class EstoqueAbaixoMinimoDomainEvent : IDomainEvent
    {
        public EstoqueAbaixoMinimoDomainEvent(EstoqueSangue estoqueSangue)
        {
            EstoqueSangue = estoqueSangue;
        }

        public EstoqueSangue EstoqueSangue { get; }
    }
}

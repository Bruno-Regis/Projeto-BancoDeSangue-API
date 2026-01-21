using BancoDeSangue.Core.Entities;

namespace BancoDeSangue.Application.Models.InputModels
{
    public class CreateDoacaoInputModel
    {
        public int DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeMl { get; set; }
    }
}

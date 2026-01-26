using BancoDeSangue.Application.Models.ViewModels;

namespace BancoDeSangue.Application.Services
{
    public interface IRelatorioService
    {
        Task<ResultViewModel<List<RelatorioUltimos30DiasViewModel>>> GetRelatorioUltimos30DiasAsync();
    }
}

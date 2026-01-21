
using BancoDeSangue.Core.Entities;

namespace BancoDeSangue.Core.Repositories
{
    public interface IDoacaoRepository
    {
        Task<List<Doacao>> GetAllAsync();
        Task<Doacao?> GetByIdAsync(int id);
        Task<Doacao?> GetDetailsByIdAsync(int id);
        Task<int> AddAsync(Doacao doacao);
    }
}

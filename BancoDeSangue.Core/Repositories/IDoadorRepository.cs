using BancoDeSangue.Core.Entities;

namespace BancoDeSangue.Core.Repositories
{
    public interface IDoadorRepository
    {
        Task<List<Doador>> GetAllAsync();
        Task<Doador?> GetByIdAsync(int id);
        Task<Doador?> GetDetailsByIdAsync(int id);
        Task<int> AddAsync(Doador doador);
        Task<bool> ExistsEmailAsync(string email);
    }
}

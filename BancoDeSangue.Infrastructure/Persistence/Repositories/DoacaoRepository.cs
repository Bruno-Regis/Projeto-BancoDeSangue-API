using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BancoDeSangue.Infrastructure.Persistence.Repositories
{
    public class DoacaoRepository : IDoacaoRepository
    {
        private readonly DoacoesDbContext _context;
        public DoacaoRepository(DoacoesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Doacao>> GetAllAsync()
        {
            return await _context.Doacoes
                .Include(d => d.Doador)
                .OrderByDescending(d => d.DataDoacao)
                .ToListAsync();
        }

        public async Task<Doacao?> GetByIdAsync(int id)
        {
            return await _context.Doacoes
                .Include(d => d.Doador)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Doacao?> GetDetailsByIdAsync(int id)
        {
            var doacao = await _context.Doacoes
                .Include(d => d.Doador)
                .FirstOrDefaultAsync(d => d.Id == id);

            return doacao;
        }

        public async Task<int> AddAsync(Doacao doacao)
        {
            
            await _context.Doacoes.AddAsync(doacao);
            await _context.SaveChangesAsync();
            return doacao.Id;
        }
    }
}

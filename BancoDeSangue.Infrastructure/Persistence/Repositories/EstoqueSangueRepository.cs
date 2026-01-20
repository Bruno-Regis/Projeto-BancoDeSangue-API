using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Enums;
using BancoDeSangue.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Infrastructure.Persistence.Repositories
{
    public class EstoqueSangueRepository : IEstoqueSangueRepository
    {
        private readonly DoacoesDbContext _context;

        public EstoqueSangueRepository(DoacoesDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(EstoqueSangue estoqueSangue)
        {
            await _context.Estoques.AddAsync(estoqueSangue);
            await _context.SaveChangesAsync();
            return estoqueSangue.Id;
        }

        public async Task<bool> ExistsTipoSanguineoAsync(TipoSanguineo tipoSanguineo, FatorRh fatorRh)
        {
            return await _context.Estoques
                .AnyAsync(e => e.TipoSanguineo == tipoSanguineo && e.FatorRH == fatorRh);
        }

        public async Task<List<EstoqueSangue>> GetAllAsync()
        {
            return await _context.Estoques.ToListAsync();
        }

        public async Task<EstoqueSangue?> GetDetailsByIdAsync(int id)
        {
            var estoqueSangue = await _context.Estoques
                .SingleOrDefaultAsync(t => t.Id == id);

            return estoqueSangue;
        }
    }
}

using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Infrastructure.Persistence.Repositories
{
    public class HistoricoEstoqueAbaixoDoMinimoRepository : IHistoricoEstoqueAbaixoDoMinimoRepository
    {
        private readonly DoacoesDbContext _context;
        public HistoricoEstoqueAbaixoDoMinimoRepository(DoacoesDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(HistoricoEstoqueAbaixoDoMinimo estoqueAbaixoDoMinimo)
        {
            await _context.Historicos.AddAsync(estoqueAbaixoDoMinimo);
            await _context.SaveChangesAsync();
            return estoqueAbaixoDoMinimo.Id;
        }
    }
}

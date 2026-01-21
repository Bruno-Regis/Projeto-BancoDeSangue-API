using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Infrastructure.Persistence.Repositories
{
    public class DoadorRepository : IDoadorRepository
    {
        private readonly DoacoesDbContext _context;

        public DoadorRepository(DoacoesDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Doador doador)
        {
            await _context.Doadores.AddAsync(doador);
            await _context.SaveChangesAsync();
            return doador.Id;
        }

        public async Task<bool> ExistsEmailAsync(string email)
        {
            return await _context.Doadores
                .AnyAsync(d => d.Email == email);
        }

        public async Task<List<Doador>> GetAllAsync()
        {
            return await _context.Doadores.ToListAsync();
        }

        public async Task<Doador?> GetByIdAsync(int id)
        {
            return await _context.Doadores
                .Include(d => d.Doacoes)
                .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async  Task<Doador?> GetDetailsByIdAsync(int id)
        {
            var doador = await _context.Doadores
                .Include(d => d.Doacoes)
                .SingleOrDefaultAsync(d => d.Id == id);

            return doador;
        }
    }
}

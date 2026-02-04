using BancoDeSangue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Core.Repositories
{
    public interface IHistoricoEstoqueAbaixoDoMinimoRepository
    {
        Task<int> AddAsync(HistoricoEstoqueAbaixoDoMinimo estoqueAbaixoDoMinimo);
    }
}

using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Core.Repositories
{
    public interface IEstoqueSangueRepository
    {
        Task<List<EstoqueSangue>> GetAllAsync();
        Task<EstoqueSangue?> GetDetailsByIdAsync(int id);
        Task<int> AddAsync(EstoqueSangue estoqueSangue);
        Task<bool> ExistsTipoSanguineoAsync(TipoSanguineo tipoSanguineo, FatorRh fatorRh);

    }
}

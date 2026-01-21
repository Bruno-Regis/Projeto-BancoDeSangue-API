using BancoDeSangue.Application.Models.InputModels;
using BancoDeSangue.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Services
{
    public interface IDoacaoService
    {
        Task<ResultViewModel<List<DoacaoItemViewModel>>> GetAllAsync();
        Task<ResultViewModel<DoacaoViewModel>> GetByIdAsync(int id);
        Task<ResultViewModel<int>> InsertAsync(CreateDoacaoInputModel model);

    }
}

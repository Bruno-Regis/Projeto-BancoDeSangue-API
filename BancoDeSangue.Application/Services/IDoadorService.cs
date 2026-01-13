using BancoDeSangue.Application.Models.InputModels;
using BancoDeSangue.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Services
{
    public interface IDoadorService
    {
        Task<ResultViewModel<List<DoadorItemViewModel>>> GetAllAsync();
        Task<ResultViewModel<DoadorViewModel>> GetByIdAsync(int id);
        Task<ResultViewModel<int>> Insert(CreateDoadorInputModel model);
    }
}

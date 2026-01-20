using BancoDeSangue.Application.Models.InputModels;
using BancoDeSangue.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Services
{
    public interface IEstoqueSangueService
    {
        Task<ResultViewModel<List<EstoqueSangueItemViewModel>>> GetAllAsync();
        Task<ResultViewModel<EstoqueSangueViewModel>> GetByIdAsync(int id);
        Task<ResultViewModel<int>> Insert(CreateEstoqueSangueInputModel model);    
    }
}

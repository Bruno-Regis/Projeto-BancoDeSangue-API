using BancoDeSangue.Application.Models.InputModels;
using BancoDeSangue.Application.Models.ViewModels;
using BancoDeSangue.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Services
{
    public class EstoqueSangueService : IEstoqueSangueService
    {
        private readonly IEstoqueSangueRepository _repository;
        public EstoqueSangueService(IEstoqueSangueRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<EstoqueSangueItemViewModel>>> GetAllAsync()
        {
            var estoqueSangues = await _repository.GetAllAsync();

            var model = estoqueSangues
                .Select(EstoqueSangueItemViewModel.FromEntity)
                .ToList();

            return new ResultViewModel<List<EstoqueSangueItemViewModel>>(model);
        }

        public async Task<ResultViewModel<EstoqueSangueViewModel>> GetByIdAsync(int id)
        {
            var estoqueSangue = await _repository.GetDetailsByIdAsync(id);
            if (estoqueSangue is null)
                return ResultViewModel<EstoqueSangueViewModel>.Error("Estoque de sangue não encontrado.");

            var model = EstoqueSangueViewModel.FromEntity(estoqueSangue);

            return ResultViewModel<EstoqueSangueViewModel>.Success(model);

        }

        public async Task<ResultViewModel<int>> Insert(CreateEstoqueSangueInputModel model)
        {
            var estoqueJaExiste = await _repository.ExistsTipoSanguineoAsync(model.TipoSanguineo, model.FatorRH);
            
            if (estoqueJaExiste)
                return ResultViewModel<int>.Error("Estoque de sangue já existe.");

            var estoque = model.ToEntity();

            await _repository.AddAsync(estoque);

            return ResultViewModel<int>.Success(estoque.Id);
        }
    }
}

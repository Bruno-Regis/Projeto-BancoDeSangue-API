using BancoDeSangue.Application.Models.InputModels;
using BancoDeSangue.Application.Models.ViewModels;
using BancoDeSangue.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Services
{
    public class DoadorService : IDoadorService
    {
        private readonly IDoadorRepository _repository;

        public DoadorService(IDoadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<DoadorItemViewModel>>> GetAllAsync()
        {
            var doadores = await _repository.GetAllAsync();
            var model = doadores
                .Select(d => DoadorItemViewModel.FromEntity(d))
                .ToList();
            return ResultViewModel<List<DoadorItemViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<DoadorViewModel>> GetByIdAsync(int id)
        {
            var doador = await _repository.GetByIdAsync(id);

            if (doador is null)
                return ResultViewModel<DoadorViewModel>.Error("Doador não encontrado.");

            var model = DoadorViewModel.FromEntity(doador);

            return ResultViewModel<DoadorViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> Insert(CreateDoadorInputModel model)
        {
            var doadorJaExiste = await _repository.ExistsEmailAsync(model.Email);
            if (doadorJaExiste)
                return ResultViewModel<int>.Error("Já existe um doador com este e-mail.");

            var doador = model.ToEntity();

            await _repository.AddAsync(doador);

            return ResultViewModel<int>.Success(doador.Id);
        }
    }
}

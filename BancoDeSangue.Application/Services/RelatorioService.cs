using BancoDeSangue.Application.Models.ViewModels;
using BancoDeSangue.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IDoacaoRepository _repository;
        public RelatorioService(IDoacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<RelatorioUltimos30DiasViewModel>>> GetRelatorioUltimos30DiasAsync()
        {
            var doacoes = await _repository.GetAllAsync();

            if (doacoes is null)
                return ResultViewModel<List<RelatorioUltimos30DiasViewModel>>.Error("Nenhuma doação encontrada.");

            var model = doacoes
                .Where(d => d.DataDoacao >= DateTime.Now.AddDays(-30))
                .Select(d => RelatorioUltimos30DiasViewModel.FromEntity(d))
                .ToList();

            if(model is null)
                return ResultViewModel<List<RelatorioUltimos30DiasViewModel>>.Error("Nenhuma doação encontrada nos últimos 30 dias.");

            return ResultViewModel<List<RelatorioUltimos30DiasViewModel>>.Success(model);
        }
    }
}

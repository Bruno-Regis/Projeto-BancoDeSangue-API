using BancoDeSangue.Application.Models.InputModels;
using BancoDeSangue.Application.Models.ViewModels;
using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Services
{
    public class DoacaoService : IDoacaoService
    {
        private readonly IDoadorRepository _doadorRepository;
        private readonly IEstoqueSangueRepository _estoqueRepository;
        private readonly IDoacaoRepository _doacaoRepository;

        public DoacaoService(IDoadorRepository doadorRepository , IEstoqueSangueRepository estoqueRepository, IDoacaoRepository doacaoRepository)
        {
            _doadorRepository = doadorRepository;
            _estoqueRepository = estoqueRepository;
            _doacaoRepository = doacaoRepository;
        }
        public async Task<ResultViewModel<List<DoacaoItemViewModel>>> GetAllAsync()
        {
            var doacao = await _doacaoRepository.GetAllAsync();

            var model = doacao
                .Select(d => DoacaoItemViewModel.FromEntity(d))
                .ToList();

            return ResultViewModel<List<DoacaoItemViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<DoacaoViewModel>> GetByIdAsync(int id)
        {
            var doacao = await _doacaoRepository.GetByIdAsync(id);

            if (doacao == null)
                return ResultViewModel<DoacaoViewModel>.Error("Doação não encontrada.");

            var model = DoacaoViewModel.FromEntity(doacao);

            return ResultViewModel<DoacaoViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> InsertAsync(CreateDoacaoInputModel model)
        {
            var doador = await _doadorRepository.GetByIdAsync(model.DoadorId);

            if (doador is null)
                return ResultViewModel<int>.Error("Doador não encontrado.");

            
            doador.ValidarDoacao();

            var estoqueSangue = await _estoqueRepository.GetByTipoSanguineoAsync(doador.TipoSanguineo, doador.FatorRh);
            
            if (estoqueSangue is null)
                return ResultViewModel<int>.Error("Estoque de sangue não encontrado para o tipo sanguíneo do doador.");

            estoqueSangue.AdicionarSangueAoEstoque(model.QuantidadeMl);

            var doacao = new Doacao(model.DoadorId,model.DataDoacao,model.QuantidadeMl,doador);
            
            doador.RealizarDoacao(doacao);


            await _doacaoRepository.AddAsync(doacao);
            await _estoqueRepository.UpdateAsync(estoqueSangue);

            return ResultViewModel<int>.Success(doacao.Id);
        }    
    }
}

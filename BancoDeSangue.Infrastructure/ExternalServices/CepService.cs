using BancoDeSangue.Core.Exceptions;
using BancoDeSangue.Core.Models;
using BancoDeSangue.Infrastructure.ExternalServices.Interfaces;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace BancoDeSangue.Infrastructure.ExternalServices
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;

        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<EnderecoViewModel> ConsultCepAsync(string cep)
        {
            cep = cep.Replace("-", "").Trim();

            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (!response.IsSuccessStatusCode)
                throw new ExternalServiceException("Erro ao consultar o serviço de CEP.");

            var viaCepResponse = await response.Content.ReadFromJsonAsync<ViaCepResponse>();

            if (viaCepResponse?.Erro == true)
                throw new ExternalServiceException("CEP não encontrado.");

            return new EnderecoViewModel
            {
                CEP = viaCepResponse.Cep,
                Logradouro = viaCepResponse.Logradouro + " " + viaCepResponse.Bairro,
                Cidade = viaCepResponse.Localidade,
                Estado = viaCepResponse.Uf
            };
        }
    }

    internal class ViaCepResponse
    {
        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("localidade")]
        public string Localidade { get; set; }

        [JsonPropertyName("uf")]
        public string Uf { get; set; }

        [JsonPropertyName("erro")]
        public bool Erro { get; set; }
    }
}

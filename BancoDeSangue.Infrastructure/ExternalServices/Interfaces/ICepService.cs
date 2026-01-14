
using BancoDeSangue.Core.Models;

namespace BancoDeSangue.Infrastructure.ExternalServices.Interfaces
{
    public interface ICepService
    {
        Task<EnderecoViewModel> ConsultCepAsync(string cep);
    }
}

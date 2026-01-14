
using BancoDeSangue.Infrastructure.ExternalServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BancoDeSangue.API.Controllers
{
    [Route("api/Enderecos")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly ICepService _cepService;
        public EnderecoController(ICepService cepService)
        {
            _cepService = cepService;
        }

        // GET api/Enderecos/cep
        [HttpGet("{cep}")]
        public async Task<IActionResult> GetByCep(string cep)
        {
            try
            {
                var endereco = await _cepService.ConsultCepAsync(cep);
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

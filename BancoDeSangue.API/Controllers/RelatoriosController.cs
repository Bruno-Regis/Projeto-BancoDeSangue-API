using BancoDeSangue.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoDeSangue.API.Controllers

{
    [Route("api/relatorios")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _service;

        public RelatoriosController(IRelatorioService service)
        {
            _service = service;
        }

        // GET api/relatorios/ultimos30dias
        [HttpGet]
        public async Task<IActionResult> GetRelatorioUltimos30Dias()
        {
            var result = await _service.GetRelatorioUltimos30DiasAsync();

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}

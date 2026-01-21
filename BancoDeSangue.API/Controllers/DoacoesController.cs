using BancoDeSangue.Application.Models.InputModels;
using BancoDeSangue.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoDeSangue.API.Controllers
{
    [Route("api/doacoes")]
    [ApiController]
    public class DoacoesController : ControllerBase
    {
        private readonly IDoacaoService _doacaoService;

        public DoacoesController(IDoacaoService doacaoService)
        {
            _doacaoService = doacaoService;
        }

        // GET api/doacoes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _doacaoService.GetAllAsync();
            return Ok(result);
        }

        // GET api/doacoes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _doacaoService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }

        // POST api/doacoes
        [HttpPost]
        public async Task<IActionResult> Post(CreateDoacaoInputModel model)
        {
            var result = await _doacaoService.InsertAsync(model);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }
    }
}

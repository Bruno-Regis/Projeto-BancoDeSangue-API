using BancoDeSangue.Application.Models.InputModels;
using BancoDeSangue.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoDeSangue.API.Controllers
{
    [Route("api/estoques")]
    [ApiController]
    public class EstoquesController : ControllerBase
    {
        private readonly IEstoqueSangueService _estoqueSangueService;

        public EstoquesController(IEstoqueSangueService estoqueSangueService)
        {
            _estoqueSangueService = estoqueSangueService;
        }

        // GET api/estoques
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _estoqueSangueService.GetAllAsync();
            return Ok(result);
        }

        // GET api/estoques/5  
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _estoqueSangueService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }

        // POST api/estoques
        [HttpPost]
        public async Task<IActionResult> Post(CreateEstoqueSangueInputModel model)
        {
            
            var result = await _estoqueSangueService.Insert(model);

            if (!result.IsSuccess)
                return Conflict(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        // PUT api/estoques/1234
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, int quantidadeMl)
        {
            var result = await _estoqueSangueService.RegistrarRetiradaDeSangue(id, quantidadeMl);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}

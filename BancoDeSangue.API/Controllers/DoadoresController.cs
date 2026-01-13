using BancoDeSangue.Application.Models.InputModels;
using BancoDeSangue.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoDeSangue.API.Controllers
{
    [Route("api/doadores")]
    [ApiController]
    public class DoadoresController : ControllerBase
    {
        private readonly IDoadorService _doadorService;

        public DoadoresController(IDoadorService doadorService)
        {
            _doadorService = doadorService;
        }

        // GET api/doadores?search=term
        [HttpGet]
        public async Task<IActionResult> Get(string search = "") // TENHO QUE PROGRAMAR O MECANISMO DE BUSCA    
        {
            var result = await _doadorService.GetAllAsync();
            return Ok(result);
        }

        // GET api/doadores/5   
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _doadorService.GetByIdAsync(id);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        // POST api/doadores
        [HttpPost]
        public async Task<IActionResult> Post(CreateDoadorInputModel model)
        {
            var result = await _doadorService.Insert(model);
            

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

    }
}

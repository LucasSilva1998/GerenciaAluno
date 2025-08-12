using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Application.Interfaces;
using GerenciaAluno.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAluno.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoresController(IProfessorService professorService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ProfessorResponse), 201)]
        public async Task<IActionResult> Cadastrar([FromBody] ProfessorRequest request)
        {
            return StatusCode(201, await professorService.CadastrarAsync(request));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProfessorResponse), 200)]
        public async Task<IActionResult> Atualizar(int id, [FromBody] ProfessorRequest request)
        {
            return Ok(await professorService.AtualizarAsync(id, request));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProfessorResponse), 200)]
        public async Task<IActionResult> Remover(int id)
        {
            return Ok(await professorService.RemoverAsync(id));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProfessorResponse), 200)]
        public async Task<ActionResult<ProfessorResponse>> ObterPorId(int id)
        {
            var response = await professorService.ObterPorIdAsync(id);

            if (response != null)
                return Ok(response);
            else
                return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProfessorResponse>), 200)]
        public async Task<ActionResult<IEnumerable<ProfessorResponse>>> ObterTodos()
        {
            return Ok(await professorService.ObterTodosAsync());
        }
    }
}
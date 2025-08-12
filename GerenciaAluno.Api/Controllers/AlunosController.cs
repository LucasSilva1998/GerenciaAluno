using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAluno.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController(IAlunoService alunoService) : ControllerBase
    {   
        [HttpPost]
        [ProducesResponseType(typeof(AlunoResponse), 201)]
        public async Task<IActionResult> Cadastrar([FromBody] AlunoRequest request)
        {
            return StatusCode(201, await alunoService.CadastrarAsync(request));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AlunoResponse), 200)]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AlunoRequest request)
        {
            return Ok(await alunoService.AtualizarAsync(id, request));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AlunoResponse), 200)]
        public async Task<IActionResult> Remover(int id)
        {
            return Ok(await alunoService.RemoverAsync(id));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AlunoResponse), 200)]
        public async Task<ActionResult<AlunoResponse>> ObterPorId(int id)
        {
            var response = await alunoService.ObterPorIdAsync(id);

            if (response != null)
                return Ok(response);
            else
                return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AlunoResponse>), 200)]
        public async Task<ActionResult<IEnumerable<AlunoResponse>>> ObterTodos()
        {
            return Ok(await alunoService.ObterTodosAsync());
        }
    }
}
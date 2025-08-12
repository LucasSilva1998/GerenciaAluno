using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Application.Interfaces;
using GerenciaAluno.Application.Services;
using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAluno.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController(INotaService notaService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(NotaResponse), 201)]
        public async Task<IActionResult> LancarNota([FromBody] NotaRequest request)
        {
            return StatusCode(201, await notaService.LancarNotaAsync(request));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(NotaResponse), 200)]
        public async Task<IActionResult> AtualizarNota(int id, [FromBody] NotaRequest request)
        {
            return Ok(await notaService.AtualizarNotaAsync(id, request));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NotaResponse), 200)]
        public async Task<ActionResult<NotaResponse>> ObterPorId(int id)
        {
            var response = await notaService.ObterPorIdAsync(id);

            if (response != null)
                return Ok(response);
            else
                return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<NotaResponse>), 200)]
        public async Task<ActionResult<IEnumerable<NotaResponse>>> ObterTodos()
        {
            return Ok(await notaService.ObterTodosAsync());
        }

        [HttpGet("Aluno/{alunoId}")]
        [ProducesResponseType(typeof(IEnumerable<NotaResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NotaResponse>>> ObterPorAluno(int alunoId)
        {
            return Ok(await notaService.ObterPorAlunoIdAsync(alunoId));
        }

        [HttpGet("Professor/{professorId}")]
        [ProducesResponseType(typeof(IEnumerable<NotaResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NotaResponse>>> ObterPorProfessor(int professorId)
        {
            return Ok(await notaService.ObterPorProfessorIdAsync(professorId));
        }

        [HttpGet("Disciplina/{disciplina}")]
        [ProducesResponseType(typeof(IEnumerable<NotaResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NotaResponse>>> ObterPorDisciplina(Disciplina disciplina)
        {
            return Ok(await notaService.ObterPorDisciplinaAsync(disciplina));
        }
    }
}

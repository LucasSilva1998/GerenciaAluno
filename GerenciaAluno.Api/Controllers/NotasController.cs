using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Application.Interfaces;
using GerenciaAluno.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAluno.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : ControllerBase
    {
        private readonly INotaService _notaService;

        public NotasController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LancarNota([FromBody] NotaRequest request)
        {
            try
            {
                await _notaService.LancarNotaAsync(request);
                return Created(string.Empty, new { mensagem = "Nota lançada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarNota(int id, [FromBody] NotaRequest request)
        {
            try
            {
                await _notaService.AtualizarNotaAsync(id, request);
                return Ok(new { mensagem = "Nota atualizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NotaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NotaResponse>> ObterPorId(int id)
        {
            try
            {
                var nota = await _notaService.ObterPorIdAsync(id);
                if (nota == null)
                    return NotFound(new { erro = "Nota não encontrada." });

                return Ok(nota);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NotaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<NotaResponse>>> ObterTodos()
        {
            try
            {
                var notas = await _notaService.ObterTodosAsync();
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }

        [HttpGet("Aluno/{alunoId}")]
        [ProducesResponseType(typeof(IEnumerable<NotaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<NotaResponse>>> ObterPorAluno(int alunoId)
        {
            try
            {
                var notas = await _notaService.ObterPorAlunoIdAsync(alunoId);
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }

        [HttpGet("Professor/{professorId}")]
        [ProducesResponseType(typeof(IEnumerable<NotaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<NotaResponse>>> ObterPorProfessor(int professorId)
        {
            try
            {
                var notas = await _notaService.ObterPorProfessorIdAsync(professorId);
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }

        [HttpGet("Disciplina/{disciplina}")]
        [ProducesResponseType(typeof(IEnumerable<NotaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<NotaResponse>>> ObterPorDisciplina(int disciplina)
        {
            try
            {
                var disciplinaEnum = (Disciplina)disciplina;
                var notas = await _notaService.ObterPorDisciplinaAsync(disciplinaEnum);
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }
    }
}

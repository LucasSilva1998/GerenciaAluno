using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Application.Interfaces;
using GerenciaAluno.Application.Mappers;
using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Enums;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Exceptions.Aluno;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;

public class NotaService (INotaDomainService notaDomainService, IAlunoDomainService alunoDomainService, IProfessorDomainService professorDomainService) : INotaService
{
    public async Task LancarNotaAsync(NotaRequest request)
    {
        var aluno = await alunoDomainService.ObterPorId(request.AlunoId);
        var professor = await professorDomainService.ObterPorId(request.ProfessorId);

        var nota = NotaMapper.ToEntity(request, aluno, professor);

        notaDomainService.CadastarNota(nota);
    }

    public async Task AtualizarNotaAsync(int id, NotaRequest request)
    {
        var notaExistente = await notaDomainService.ObterPorId(id);
        var aluno = await alunoDomainService.ObterPorId(request.AlunoId);
        var professor = await professorDomainService.ObterPorId(request.ProfessorId);

        NotaMapper.AtualizarEntidade(notaExistente, request, aluno, professor);

        notaDomainService.Atualizar(notaExistente);
    }


    public async Task<NotaResponse> ObterPorIdAsync(int id)
    {
        var nota = await notaDomainService.ObterPorId(id);

        return NotaMapper.ToResponse(nota);
    }

    public async Task<IEnumerable<NotaResponse>> ObterTodosAsync()
    {
        var notas = await notaDomainService.ObterTodos();

        return notas.Select(NotaMapper.ToResponse);
    }

    public async Task<IEnumerable<NotaResponse>> ObterPorAlunoIdAsync(int alunoId)
    {
        var notas = await notaDomainService.ObterPorAlunoIdAsync(alunoId);

        return notas.Select(NotaMapper.ToResponse);
    }

    public async Task<IEnumerable<NotaResponse>> ObterPorProfessorIdAsync(int professorId)
    {
        var notas = await notaDomainService.ObterPorProfessorIdAsync(professorId);

        return notas.Select(NotaMapper.ToResponse);
    }

    public async Task<IEnumerable<NotaResponse>> ObterPorDisciplinaAsync(Disciplina disciplina)
    {
        var notas = await notaDomainService.ObterPorDisciplinaAsync(disciplina);

        return notas.Select(NotaMapper.ToResponse);
    }
}

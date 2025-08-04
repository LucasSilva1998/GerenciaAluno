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

public class NotaService : INotaService
{
    private readonly INotaRepository _notaRepository;
    private readonly IAlunoRepository _alunoRepository;
    private readonly IProfessorRepository _professorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public NotaService(INotaRepository notaRepository, IAlunoRepository alunoRepository, IProfessorRepository professorRepository, IUnitOfWork unitOfWork)
    {
        _notaRepository = notaRepository;
        _alunoRepository = alunoRepository;
        _professorRepository = professorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task LancarNotaAsync(NotaRequest request)
    {
        var aluno = await ObterAlunoOuErroAsync(request.AlunoId);
        var professor = await ObterProfessorOuErroAsync(request.ProfessorId);

        var nota = NotaMapper.ToEntity(request, aluno, professor);

        await _notaRepository.AdicionarAsync(nota);
        await _unitOfWork.CommitAsync();
    }

    public async Task AtualizarNotaAsync(int id, NotaRequest request)
    {
        var notaExistente = await ObterNotaOuErroAsync(id);
        var aluno = await ObterAlunoOuErroAsync(request.AlunoId);
        var professor = await ObterProfessorOuErroAsync(request.ProfessorId);

        NotaMapper.AtualizarEntidade(notaExistente, request, aluno, professor);

        _notaRepository.Atualizar(notaExistente);
        await _unitOfWork.CommitAsync();
    }


    public async Task<NotaResponse> ObterPorIdAsync(int id)
    {
        var nota = await ObterNotaOuErroAsync(id);
        return NotaMapper.ToResponse(nota);
    }

    public async Task<IEnumerable<NotaResponse>> ObterTodosAsync()
    {
        var notas = await _notaRepository.ObterTodosAsync();
        return notas.Select(NotaMapper.ToResponse);
    }

    public async Task<IEnumerable<NotaResponse>> ObterPorAlunoIdAsync(int alunoId)
    {
        var notas = await _notaRepository.ObterPorAlunoIdAsync(alunoId);
        return notas.Select(NotaMapper.ToResponse);
    }

    public async Task<IEnumerable<NotaResponse>> ObterPorProfessorIdAsync(int professorId)
    {
        var notas = await _notaRepository.ObterPorProfessorIdAsync(professorId);
        return notas.Select(NotaMapper.ToResponse);
    }

    public async Task<IEnumerable<NotaResponse>> ObterPorDisciplinaAsync(Disciplina disciplina)
    {
        var notas = await _notaRepository.ObterPorDisciplinaAsync(disciplina);
        return notas.Select(NotaMapper.ToResponse);
    }

    // Métodos auxiliares para evitar repetição e tratar erros com exceções específicas
    private async Task<Aluno> ObterAlunoOuErroAsync(int alunoId)
    {
        var aluno = await _alunoRepository.ObterPorIdAsync(alunoId);
        if (aluno == null)
            throw new AlunoNaoEncontradoException($"Aluno com Id {alunoId} não encontrado.");
        return aluno;
    }

    private async Task<Professor> ObterProfessorOuErroAsync(int professorId)
    {
        var professor = await _professorRepository.ObterPorIdAsync(professorId);
        if (professor == null)
            throw new ProfessorNaoEncontradoException($"Professor com Id {professorId} não encontrado.");
        return professor;
    }

    private async Task<Nota> ObterNotaOuErroAsync(int id)
    {
        var nota = await _notaRepository.ObterPorIdAsync(id);
        if (nota == null)
            throw new NotaNaoEncontradaException($"Nota com Id {id} não encontrada.");
        return nota;
    }
}

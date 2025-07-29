using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Application.Interfaces;
using GerenciaAluno.Application.Mappers;
using GerenciaAluno.Domain.Enums;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Services
{
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
            var aluno = await _alunoRepository.ObterPorIdAsync(request.AlunoId);
            if (aluno == null)
                throw new Exception("Aluno não encontrado.");

            var professor = await _professorRepository.ObterPorIdAsync(request.ProfessorId);
            if (professor == null)
                throw new Exception("Professor não encontrado.");

            var nota = NotaMapper.ToEntity(request, aluno, professor);

            await _notaRepository.AdicionarAsync(nota);
            await _unitOfWork.CommitAsync();
        }

        public async Task AtualizarNotaAsync(int id, NotaRequest request)
        {
            var notaExistente = await _notaRepository.ObterPorIdAsync(id);
            if (notaExistente == null)
                throw new Exception("Nota não encontrada.");

            var aluno = await _alunoRepository.ObterPorIdAsync(request.AlunoId);
            if (aluno == null)
                throw new Exception("Aluno não encontrado.");

            var professor = await _professorRepository.ObterPorIdAsync(request.ProfessorId);
            if (professor == null)
                throw new Exception("Professor não encontrado.");

            notaExistente.Aluno = aluno;
            notaExistente.Professor = professor;
            notaExistente.Disciplina = (Disciplina)request.Disciplina;
            notaExistente.Valor = request.Valor;
            notaExistente.DataLancamento = DateTime.Now; 
            notaExistente.Status = StatusNota.Lançada; 

            _notaRepository.Atualizar(notaExistente);
            await _unitOfWork.CommitAsync();
        }


        public async Task<NotaResponse> ObterPorIdAsync(int id)
        {
            var nota = await _notaRepository.ObterPorIdAsync(id);
            if (nota == null)
                throw new Exception("Nota não encontrada.");

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
    }
}
using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Application.Interfaces;
using GerenciaAluno.Application.Mappers;
using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Exceptions.Aluno;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;
using GerenciaAluno.Domain.ValueObjects;

namespace GerenciaAluno.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAlunoDomainService _alunoDomainService;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoService(IAlunoRepository alunoRepository, IAlunoDomainService alunoDomainService, IUnitOfWork unitOfWork)
        {
            _alunoRepository = alunoRepository;
            _alunoDomainService = alunoDomainService;
            _unitOfWork = unitOfWork;
        }

        public async Task CadastrarAsync(AlunoRequest request)
        {
            var aluno = AlunoMapper.ToEntity(request);

            await _alunoDomainService.ValidarCadastroAsync(aluno);

            await _alunoRepository.AdicionarAsync(aluno);
            await _unitOfWork.CommitAsync();
        }

        public async Task AtualizarAsync(int id, AlunoRequest request)
        {
            var alunoExistente = await _alunoRepository.ObterPorIdAsync(id);
            if (alunoExistente == null)
                throw new AlunoNaoEncontradoException("Aluno não encontrado.");

            AlunoMapper.AtualizarEntidade(alunoExistente, request);

            _alunoRepository.Atualizar(alunoExistente);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var alunoExistente = await _alunoRepository.ObterPorIdAsync(id);
            if (alunoExistente == null)
                throw new AlunoNaoEncontradoException("Aluno não encontrado.");

            _alunoRepository.Remover(alunoExistente);
            await _unitOfWork.CommitAsync();
        }

        public async Task<AlunoResponse> ObterPorIdAsync(int id)
        {
            var aluno = await _alunoRepository.ObterPorIdAsync(id);
            if (aluno == null)
                throw new AlunoNaoEncontradoException("Aluno não encontrado.");

            return AlunoMapper.ToResponse(aluno);
        }

        public async Task<IEnumerable<AlunoResponse>> ObterTodosAsync()
        {
            var alunos = await _alunoRepository.ObterTodosAsync();
            return alunos.Select(AlunoMapper.ToResponse);
        }
    }
}

using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Application.Interfaces;
using GerenciaAluno.Application.Mappers;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;
using GerenciaAluno.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICadastroDomainService _cadastroDomainService;

        public AlunoService(IAlunoRepository alunoRepository, IUnitOfWork unitOfWork, ICadastroDomainService cadastroDomainService)
        {
            _alunoRepository = alunoRepository;
            _unitOfWork = unitOfWork;
            _cadastroDomainService = cadastroDomainService;
        }

        public async Task CadastrarAsync(AlunoRequest request)
        {
            var aluno = AlunoMapper.ToEntity(request);

            await _cadastroDomainService.CadastrarAlunoAsync(aluno);
        }

        public async Task AtualizarAsync(int id, AlunoRequest request)
        {
            var alunoExistente = await _alunoRepository.ObterPorIdAsync(id);
            if (alunoExistente == null)
                throw new Exception("Aluno não encontrado.");

            AlunoMapper.AtualizarEntidade(alunoExistente, request);

            _alunoRepository.Atualizar(alunoExistente);
            await _unitOfWork.CommitAsync();
        }


        public async Task RemoverAsync(int id)
        {
            var alunoExistente = await _alunoRepository.ObterPorIdAsync(id);
            if (alunoExistente == null)
                throw new Exception("Aluno não encontrado.");

            _alunoRepository.Remover(alunoExistente);
            await _unitOfWork.CommitAsync();
        }

        public async Task<AlunoResponse> ObterPorIdAsync(int id)
        {
            var aluno = await _alunoRepository.ObterPorIdAsync(id);
            if (aluno == null)
                throw new Exception("Aluno não encontrado.");

            return AlunoMapper.ToResponse(aluno);
        }

        public async Task<IEnumerable<AlunoResponse>> ObterTodosAsync()
        {
            var alunos = await _alunoRepository.ObterTodosAsync();
            return alunos.Select(AlunoMapper.ToResponse);
        }
    }
}
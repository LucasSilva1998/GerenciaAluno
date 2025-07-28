using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Application.Interfaces;
using GerenciaAluno.Application.Mappers;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICadastroDomainService _cadastroDomainService;

        public ProfessorService(IProfessorRepository professorRepository, IUnitOfWork unitOfWork, ICadastroDomainService cadastroDomainService)
        {
            _professorRepository = professorRepository;
            _unitOfWork = unitOfWork;
            _cadastroDomainService = cadastroDomainService;
        }

        public async Task CadastrarAsync(ProfessorRequest request)
        {
            var professor = ProfessorMapper.ToEntity(request);

            await _cadastroDomainService.CadastrarProfessorAsync(professor);
        }

        public async Task AtualizarAsync(int id, ProfessorRequest request)
        {
            var professorExistente = await _professorRepository.ObterPorIdAsync(id);
            if (professorExistente == null)
                throw new Exception("Professor não encontrado.");

            ProfessorMapper.AtualizarEntidade(professorExistente, request);

            _professorRepository.Atualizar(professorExistente);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var professorExistente = await _professorRepository.ObterPorIdAsync(id);
            if (professorExistente == null)
                throw new Exception("Professor não encontrado.");

            _professorRepository.Remover(professorExistente);
            await _unitOfWork.CommitAsync();
        }

        public async Task<ProfessorResponse> ObterPorIdAsync(int id)
        {
            var professor = await _professorRepository.ObterPorIdAsync(id);
            if (professor == null)
                throw new Exception("Professor não encontrado.");

            return ProfessorMapper.ToResponse(professor);
        }

        public async Task<IEnumerable<ProfessorResponse>> ObterTodosAsync()
        {
            var professores = await _professorRepository.ObterTodosAsync();
            return professores.Select(ProfessorMapper.ToResponse);
        }
    }
}
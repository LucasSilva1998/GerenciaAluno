using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Application.Interfaces;
using GerenciaAluno.Application.Mappers;
using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProfessorDomainService _professorDomainService;

        public ProfessorService(IProfessorRepository professorRepository, IUnitOfWork unitOfWork, IProfessorDomainService professorDomainService)
        {
            _professorRepository = professorRepository;
            _unitOfWork = unitOfWork;
            _professorDomainService = professorDomainService;
        }

        public async Task CadastrarAsync(ProfessorRequest request)
        {
            var professor = ProfessorMapper.ToEntity(request);

            await _professorDomainService.ValidarCadastroAsync(professor);

            await _professorRepository.AdicionarAsync(professor);
            await _unitOfWork.CommitAsync();
        }

        public async Task AtualizarAsync(int id, ProfessorRequest request)
        {
            var professorExistente = await ObterOuErroAsync(id);

            ProfessorMapper.AtualizarEntidade(professorExistente, request);

            _professorRepository.Atualizar(professorExistente);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var professorExistente = await ObterOuErroAsync(id);

            _professorRepository.Remover(professorExistente);
            await _unitOfWork.CommitAsync();
        }

        public async Task<ProfessorResponse> ObterPorIdAsync(int id)
        {
            var professor = await ObterOuErroAsync(id);

            return ProfessorMapper.ToResponse(professor);
        }

        public async Task<IEnumerable<ProfessorResponse>> ObterTodosAsync()
        {
            var professores = await _professorRepository.ObterTodosAsync();
            return professores.Select(ProfessorMapper.ToResponse);
        }

        // 🔧 Método auxiliar centraliza a validação de existência
        private async Task<Professor> ObterOuErroAsync(int id)
        {
            var professor = await _professorRepository.ObterPorIdAsync(id);
            if (professor == null)
                throw new ProfessorNaoEncontradoException($"Professor com Id {id} não encontrado.");

            return professor;
        }
    }
}

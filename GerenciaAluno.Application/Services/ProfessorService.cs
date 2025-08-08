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
    public class ProfessorService (IProfessorDomainService professorDomainService) : IProfessorService
    {      
        public async Task CadastrarAsync(ProfessorRequest request)
        {
            var professor = ProfessorMapper.ToEntity(request);

            await professorDomainService.CadastarProfessor(professor);
        }

        public async Task AtualizarAsync(int id, ProfessorRequest request)
        {
            var professorExistente = await professorDomainService.ObterPorId(id);

            ProfessorMapper.AtualizarEntidade(professorExistente, request);

            professorDomainService.Atualizar(professorExistente);
        }

        public async Task RemoverAsync(int id)
        {
            var professorExistente = await professorDomainService.ObterPorId(id);

            professorDomainService.Remover(professorExistente);
        }

        public async Task<ProfessorResponse> ObterPorIdAsync(int id)
        {
            var professor = await professorDomainService.ObterPorId(id);

            return ProfessorMapper.ToResponse(professor);
        }

        public async Task<IEnumerable<ProfessorResponse>> ObterTodosAsync()
        {
            var professores = await professorDomainService.ObterTodos();
            return professores.Select(ProfessorMapper.ToResponse);
        }       
    }
}

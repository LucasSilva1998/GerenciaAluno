using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Exceptions.Professor;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Services;

namespace GerenciaAluno.Domain.Services
{
    public class ProfessorDomainService (IUnitOfWork unitOfWork) : IProfessorDomainService
    {
        public async Task Atualizar(Professor professor)
        {            
            await unitOfWork.ProfessorRepository.Atualizar(professor);
            await unitOfWork.CommitAsync();
        }

        public async Task CadastarProfessor(Professor professor)
        {
            if (await unitOfWork.ProfessorRepository.ExisteCpfAsync(professor.Cpf.Numero))
                throw new ProfessorJaCadastradoException("Já existe um professor cadastrado com esse CPF.");

            await unitOfWork.ProfessorRepository.AdicionarAsync(professor);
            await unitOfWork.CommitAsync();
        }

        public async Task<Professor?> ObterPorId(int id)
        {
            var professor = await unitOfWork.ProfessorRepository.ObterPorIdAsync(id);
            if (professor == null)
                throw new ProfessorNaoEncontradoException("Professor não encontrado.");

            return professor;
        }

        public async Task<List<Professor>> ObterTodos()
        {
            var professores = await unitOfWork.ProfessorRepository.ObterTodosAsync();
            if (professores == null || !professores.Any())
                throw new ProfessorNaoEncontradoException("Nenhum professor encontrado.");

            return professores.ToList();
        }

        public async Task Remover(Professor professor)
        {          
            await unitOfWork.ProfessorRepository.Remover(professor);
            await unitOfWork.CommitAsync();
        }      
    }
}

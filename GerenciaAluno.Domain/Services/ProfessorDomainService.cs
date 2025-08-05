using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Exceptions.Professor;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;

namespace GerenciaAluno.Domain.Services
{
    internal class ProfessorDomainService (IUnitOfWork unitOfWork) : IProfessorDomainService
    {
        public async Task ValidarCadastroAsync(Professor professor)
        {
            if (await unitOfWork.ProfessorRepository.ExisteCpfAsync(professor.Cpf.Numero))
                throw new ProfessorJaCadastradoException("Já existe um professor cadastrado com esse CPF.");
        }
    }
}

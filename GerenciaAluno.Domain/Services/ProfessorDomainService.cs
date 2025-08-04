using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Exceptions.Professor;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;

namespace GerenciaAluno.Domain.Services
{
    public class ProfessorDomainService : IProfessorDomainService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorDomainService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task ValidarCadastroAsync(Professor professor)
        {
            if (await _professorRepository.ExisteCpfAsync(professor.Cpf.Numero))
                throw new ProfessorJaCadastradoException("Já existe um professor cadastrado com esse CPF.");
        }
    }
}

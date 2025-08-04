using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Exceptions.Aluno;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;

namespace GerenciaAluno.Domain.Services
{
    public class AlunoDomainService : IAlunoDomainService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoDomainService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task ValidarCadastroAsync(Aluno aluno)
        {
            if (await _alunoRepository.ExisteCpfAsync(aluno.Cpf.Numero))
                throw new AlunoJaCadastradoException("Já existe um aluno cadastrado com esse CPF.");
        }
    }
}

using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Exceptions.Aluno;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;

namespace GerenciaAluno.Domain.Services
{
    internal class AlunoDomainService (IUnitOfWork unitOfWork) : IAlunoDomainService
    { 
        public async Task ValidarCadastroAsync(Aluno aluno)
        {
            if (await unitOfWork.AlunoRepository.ExisteCpfAsync(aluno.Cpf.Numero))
                throw new AlunoJaCadastradoException("Já existe um aluno cadastrado com esse CPF.");
        }
    }
}

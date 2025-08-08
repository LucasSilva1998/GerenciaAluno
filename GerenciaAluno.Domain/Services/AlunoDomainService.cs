using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Exceptions.Aluno;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;

namespace GerenciaAluno.Domain.Services
{
    public class AlunoDomainService (IUnitOfWork unitOfWork) : IAlunoDomainService
    {
        public async Task Atualizar(Aluno aluno)
        {           
            await unitOfWork.AlunoRepository.Atualizar(aluno);
            await unitOfWork.CommitAsync();
        }

        public async Task CadastarAluno(Aluno aluno)
        {
            if (await unitOfWork.AlunoRepository.ExisteCpfAsync(aluno.Cpf.Numero))
                throw new AlunoJaCadastradoException("Já existe um aluno cadastrado com esse CPF.");

            await unitOfWork.AlunoRepository.AdicionarAsync(aluno);
            await unitOfWork.CommitAsync();
        }

        public async Task<Aluno?> ObterPorId(int id)
        {
            var aluno = await unitOfWork.AlunoRepository.ObterPorIdAsync(id);
            if (aluno == null)
                throw new AlunoNaoEncontradoException("Aluno não encontrado.");

            return aluno;
        }

        public async Task<List<Aluno>> ObterTodos()
        {
            var alunos = await unitOfWork.AlunoRepository.ObterTodosAsync();
            if (alunos == null || !alunos.Any())
                throw new AlunoNaoEncontradoException("Nenhum aluno encontrado.");

            return alunos.ToList();
        }

        public async Task Remover(Aluno aluno)
        {
            await unitOfWork.AlunoRepository.Remover(aluno);
            await unitOfWork.CommitAsync();
        }        
    }
}

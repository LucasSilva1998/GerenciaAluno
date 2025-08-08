using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Enums;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Exceptions.Nota;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;

namespace GerenciaAluno.Domain.Services
{
    public class NotaDomainService (IUnitOfWork unitOfWork) : INotaDomainService
    {
        public async Task Atualizar(Nota nota)
        {
            await unitOfWork.NotaRepository.Atualizar(nota);
            await unitOfWork.CommitAsync();
        }

        public async Task CadastarNota(Nota nota)
        {
            if (nota.Valor < 0 || nota.Valor > 10)
                throw new NotaInvalidaException("O valor da nota deve estar entre 0 e 10.");

            if (!Enum.IsDefined(typeof(Disciplina), nota.Disciplina))
                throw new DisciplinaInvalidaException("Disciplina inválida.");

            if (!Enum.IsDefined(typeof(StatusNota), nota.Status))
                throw new StatusNotaInvalidoException("Status da nota inválido.");

            await unitOfWork.NotaRepository.AdicionarAsync(nota);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Nota>> ObterPorAlunoIdAsync(int alunoId)
        {
            if (alunoId <= 0)
                throw new ArgumentException("O ID do aluno deve ser maior que zero.", nameof(alunoId));

            return await unitOfWork.NotaRepository.ObterPorAlunoIdAsync(alunoId);
        }


        public Task<IEnumerable<Nota>> ObterPorDisciplinaAsync(Disciplina disciplina)
        {
            if (!Enum.IsDefined(typeof(Disciplina), disciplina))
                throw new DisciplinaInvalidaException("Disciplina inválida.");

            return unitOfWork.NotaRepository.ObterPorDisciplinaAsync(disciplina);
        }

        public async Task<Nota> ObterPorId(int id)
        {
            var nota = await unitOfWork.NotaRepository.ObterPorIdAsync(id);
            if (nota == null)
                throw new NotaNaoEncontradaException($"Nota com Id {id} não encontrada.");

            return nota;
        }

        public Task<IEnumerable<Nota>> ObterPorProfessorIdAsync(int professorId)
        {
            if (professorId <= 0)
                throw new ArgumentException("O ID do professor deve ser maior que zero.", nameof(professorId));

            return unitOfWork.NotaRepository.ObterPorProfessorIdAsync(professorId);
        }

        public async Task<List<Nota>> ObterTodos()
        {
            var notas = await unitOfWork.NotaRepository.ObterTodosAsync();
            if (notas == null || !notas.Any())
                throw new NotaNaoEncontradaException("Nenhuma nota encontrada.");

            return notas.ToList();
        }

        public async Task Remover(Nota nota)
        {
            await unitOfWork.NotaRepository.Remover(nota);
            await unitOfWork.CommitAsync();
        }
    }
}

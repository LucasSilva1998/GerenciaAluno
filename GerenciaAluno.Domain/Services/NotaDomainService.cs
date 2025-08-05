using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Enums;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Exceptions.Nota;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;

namespace GerenciaAluno.Domain.Services
{
    internal class NotaDomainService (IUnitOfWork unitOfWork) : INotaDomainService
    { 
        public async Task ValidarCadastroAsync(Nota nota)
        {
            if (nota.Valor < 0 || nota.Valor > 10)
                throw new NotaInvalidaException("O valor da nota deve estar entre 0 e 10.");

            if (!Enum.IsDefined(typeof(Disciplina), nota.Disciplina))
                throw new DisciplinaInvalidaException("Disciplina inválida.");

            if (!Enum.IsDefined(typeof(StatusNota), nota.Status))
                throw new StatusNotaInvalidoException("Status da nota inválido.");
        }
    }
}

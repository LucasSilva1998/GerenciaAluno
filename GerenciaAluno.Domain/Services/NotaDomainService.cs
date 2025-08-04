using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Enums;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Exceptions.Nota;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;

namespace GerenciaAluno.Domain.Services
{
    public class NotaDomainService : INotaDomainService
    {
        private readonly INotaRepository _notaRepository;

        public NotaDomainService(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }

        public async Task ValidarCadastroAsync(Nota nota)
        {
            if (nota.Valor < 0 || nota.Valor > 10)
                throw new NotaInvalidaException("O valor da nota deve estar entre 0 e 10.");

            if (!Enum.IsDefined(typeof(Disciplina), nota.Disciplina))
                throw new NotaInvalidaException("Disciplina inválida.");

            if (!Enum.IsDefined(typeof(StatusNota), nota.Status))
                throw new NotaInvalidaException("Status da nota inválido.");
        }
    }
}

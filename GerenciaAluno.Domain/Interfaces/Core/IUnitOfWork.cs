using GerenciaAluno.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Interfaces.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync();

        Task<bool> CommitAsync();

        Task RollbackAsync();

        #region Propriedades para acesso aos repositórios

        IAlunoRepository AlunoRepository { get; }
        IProfessorRepository ProfessorRepository { get; }
        INotaRepository NotaRepository { get; }

        #endregion

    }
}
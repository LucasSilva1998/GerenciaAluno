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
        Task<bool> CommitAsync();

        Task RollbackAsync();

        #region

        IAlunoRepository AlunoRepository { get; }
        IProfessorRepository professorRepository { get; }
        INotaRepository NotaRepository { get; }

        #endregion

    }
}
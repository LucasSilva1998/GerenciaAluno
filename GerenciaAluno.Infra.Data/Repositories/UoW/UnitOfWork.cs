using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Infra.Data.Repositories.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IDbContextTransaction _transaction;


        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public IAlunoRepository AlunoRepository => throw new NotImplementedException();

        public IProfessorRepository professorRepository => throw new NotImplementedException();

        public INotaRepository NotaRepository => throw new NotImplementedException();


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

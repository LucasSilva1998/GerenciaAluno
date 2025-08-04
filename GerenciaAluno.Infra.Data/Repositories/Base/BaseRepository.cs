using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAluno.Infra.Data.Repositories.Base
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        protected readonly DataContext _dataContext;

        protected BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual async Task AdicionarAsync(TEntity entity)
        {
            await _dataContext.Set<TEntity>().AddAsync(entity);
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            await Task.FromResult(_dataContext.Set<TEntity>().Update(entity));
        }

        public virtual async Task<TEntity?> ObterPorIdAsync(TKey id)
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            return await _dataContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task Remover(TEntity entity)
        {
            await Task.FromResult(_dataContext.Set<TEntity>().Remove(entity));

        }
    }
}
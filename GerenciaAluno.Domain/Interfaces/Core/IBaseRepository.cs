using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Interfaces.Core
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        Task AdicionarAsync(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Remover(TEntity entity);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task<TEntity?> ObterPorIdAsync(TKey id);
    }
}

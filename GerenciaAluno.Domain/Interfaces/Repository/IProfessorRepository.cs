using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Interfaces.Repository
{
    public interface IProfessorRepository : IBaseRepository<Professor>
    {
        Task<Professor> ObterPorCpfAsync(string cpf);
    }
}

using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Enums;
using GerenciaAluno.Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Interfaces.Repository
{
    public interface INotaRepository : IBaseRepository<Nota>
    {
        Task<IEnumerable<Nota>> ObterPorAlunoIdAsync(int alunoId);
        Task<IEnumerable<Nota>> ObterPorProfessorIdAsync(int professorId);
        Task<IEnumerable<Nota>> ObterPorDisciplinaAsync(Disciplina disciplina);
    }
}

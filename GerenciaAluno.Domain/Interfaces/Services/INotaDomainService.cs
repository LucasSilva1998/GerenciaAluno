using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciaAluno.Domain.Entities;

namespace GerenciaAluno.Domain.Interfaces.Services
{
    public interface INotaDomainService
    {
        Task CadastarNota(Nota nota);
        Task Atualizar(Nota nota);
        Task Remover(Nota nota);
        Task<List<Nota>> ObterTodos();
        Task<Nota> ObterPorId(int id);
        Task<IEnumerable<Nota>> ObterPorAlunoIdAsync(int alunoId);
        Task<IEnumerable<Nota>> ObterPorProfessorIdAsync(int professorId);
        Task<IEnumerable<Nota>> ObterPorDisciplinaAsync(Domain.Enums.Disciplina disciplina);

    }
}


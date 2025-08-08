using GerenciaAluno.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Interfaces.Services
{
    public interface IProfessorDomainService
    {
        Task CadastarProfessor(Professor professor);
        Task Atualizar(Professor professor);
        Task Remover(Professor professor);
        Task<List<Professor>> ObterTodos();
        Task<Professor?> ObterPorId(int id);
    }
}


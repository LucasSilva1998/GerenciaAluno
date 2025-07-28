using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Interfaces
{
    public interface INotaService
    {
        Task LancarNotaAsync(NotaRequest request);
        Task<NotaResponse> ObterPorIdAsync(int id);
        Task<IEnumerable<NotaResponse>> ObterTodosAsync();

        Task<IEnumerable<NotaResponse>> ObterPorAlunoIdAsync(int alunoId);
        Task<IEnumerable<NotaResponse>> ObterPorProfessorIdAsync(int professorId);
        Task<IEnumerable<NotaResponse>> ObterPorDisciplinaAsync(Disciplina disciplina);
    }
}

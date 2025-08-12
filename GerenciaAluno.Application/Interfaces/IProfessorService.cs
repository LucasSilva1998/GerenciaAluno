using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Interfaces
{
    public interface IProfessorService
    {
        Task<ProfessorResponse> CadastrarAsync(ProfessorRequest request);
        Task<ProfessorResponse> AtualizarAsync(int id, ProfessorRequest request);
        Task<ProfessorResponse> RemoverAsync(int id);

        Task<ProfessorResponse> ObterPorIdAsync(int id);
        Task<IEnumerable<ProfessorResponse>> ObterTodosAsync();
    }
}
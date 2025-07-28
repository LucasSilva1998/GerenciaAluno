using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Interfaces
{
    public interface IAlunoService
    {
        Task CadastrarAsync(AlunoRequest request);
        Task AtualizarAsync(int id, AlunoRequest request);
        Task RemoverAsync(int id);

        Task<AlunoResponse> ObterPorIdAsync(int id);
        Task<IEnumerable<AlunoResponse>> ObterTodosAsync();
    }
}
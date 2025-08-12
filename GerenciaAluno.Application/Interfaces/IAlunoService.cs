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
        Task<AlunoResponse> CadastrarAsync(AlunoRequest request);
        Task<AlunoResponse> AtualizarAsync(int id, AlunoRequest request);
        Task<AlunoResponse> RemoverAsync(int id);

        Task<AlunoResponse> ObterPorIdAsync(int id);
        Task<IEnumerable<AlunoResponse>> ObterTodosAsync();
    }
}
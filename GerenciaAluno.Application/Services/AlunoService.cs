using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Application.Interfaces;
using GerenciaAluno.Application.Mappers;
using GerenciaAluno.Domain.Interfaces.Services;

namespace GerenciaAluno.Application.Services
{
    public class AlunoService (IAlunoDomainService alunoDomainService) : IAlunoService
    {      
        public async Task CadastrarAsync(AlunoRequest request)
        {
            var aluno = AlunoMapper.ToEntity(request);

            await alunoDomainService.CadastarAluno(aluno);
        }

        public async Task AtualizarAsync(int id, AlunoRequest request)
        {
            var alunoExistente = await alunoDomainService.ObterPorId(id);

            AlunoMapper.AtualizarEntidade(alunoExistente, request);

            alunoDomainService.Atualizar(alunoExistente);
        }

        public async Task RemoverAsync(int id)
        {
            var alunoExistente = await alunoDomainService.ObterPorId(id);

            alunoDomainService.Remover(alunoExistente);
        }

        public async Task<AlunoResponse> ObterPorIdAsync(int id)
        {
            var aluno = await alunoDomainService.ObterPorId(id);           

            return AlunoMapper.ToResponse(aluno);
        }

        public async Task<IEnumerable<AlunoResponse>> ObterTodosAsync()
        {
            var alunos = await alunoDomainService.ObterTodos();

            return alunos.Select(AlunoMapper.ToResponse);
        }
    }
}

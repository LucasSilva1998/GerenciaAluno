using Dapper;
using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.ValueObjects;
using GerenciaAluno.Infra.Data.Context;
using GerenciaAluno.Infra.Data.Repositories.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GerenciaAluno.Infra.Data.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno, int>, IAlunoRepository
    {
        private readonly IConfiguration _configuration;

        public AlunoRepository(DataContext context, IConfiguration configuration)
            : base(context)
        {
            _configuration = configuration;
        }

        public async Task<Aluno?> ObterPorCpfAsync(string cpf)
        {
            var sql = @"SELECT * FROM Alunos WHERE Cpf = @Cpf";
            using var connection = new SqlConnection(_configuration.GetConnectionString("GerenciaAlunoBD"));

            var alunoDto = await connection.QueryFirstOrDefaultAsync<AlunoDto>(sql, new { Cpf = cpf });

            if (alunoDto == null) return null;

            return new Aluno(
                alunoDto.Id,
                alunoDto.Nome,
                new Cpf(alunoDto.Cpf),
                alunoDto.DataNascimento,
                alunoDto.Email);
        }

        public async Task<bool> ExisteCpfAsync(string cpf)
        {
            var sql = @"SELECT COUNT(1) FROM Alunos WHERE Cpf = @Cpf";
            using var connection = new SqlConnection(_configuration.GetConnectionString("GerenciaAlunoBD"));

            var count = await connection.ExecuteScalarAsync<int>(sql, new { Cpf = cpf });
            return count > 0;
        }

        public override async Task<Aluno?> ObterPorIdAsync(int id)
        {
            var sql = @"SELECT * FROM Alunos WHERE Id = @Id";
            using var connection = new SqlConnection(_configuration.GetConnectionString("GerenciaAlunoBD"));

            var alunoDto = await connection.QueryFirstOrDefaultAsync<AlunoDto>(sql, new { Id = id });

            if (alunoDto == null) return null;

            return new Aluno(
                alunoDto.Id,
                alunoDto.Nome,
                new Cpf(alunoDto.Cpf),
                alunoDto.DataNascimento,
                alunoDto.Email);
        }

        public override async Task<IEnumerable<Aluno>> ObterTodosAsync()
        {
            var sql = @"SELECT * FROM Alunos";
            using var connection = new SqlConnection(_configuration.GetConnectionString("GerenciaAlunoBD"));

            var alunosDto = await connection.QueryAsync<AlunoDto>(sql);

            return alunosDto.Select(dto =>
                new Aluno(
                    dto.Id,
                    dto.Nome,
                    new Cpf(dto.Cpf),
                    dto.DataNascimento,
                    dto.Email)).ToList();
        }

        // DTO para uso com Dapper
        private class AlunoDto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Cpf { get; set; }
            public DateTime DataNascimento { get; set; }
            public string Email { get; set; }
        }
    }
}

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
    public class ProfessorRepository : BaseRepository<Professor, int>, IProfessorRepository
    {
        private readonly IConfiguration _configuration;

        public ProfessorRepository(DataContext context, IConfiguration configuration)
            : base(context)
        {
            _configuration = configuration;
        }

        public async Task<Professor?> ObterPorCpfAsync(string cpf)
        {
            var sql = @"SELECT * FROM Professores WHERE Cpf = @Cpf";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var dto = await connection.QueryFirstOrDefaultAsync<ProfessorDto>(sql, new { Cpf = cpf });

            return dto == null ? null :
                new Professor(dto.Id, dto.Nome, new Cpf(dto.Cpf), dto.DataNascimento, dto.Email);
        }

        public async Task<bool> ExisteCpfAsync(string cpf)
        {
            var sql = @"SELECT COUNT(1) FROM Professores WHERE Cpf = @Cpf";
            using var connection = new SqlConnection(_configuration.GetConnectionString("GerenciaAlunoBD"));

            var count = await connection.ExecuteScalarAsync<int>(sql, new { Cpf = cpf });
            return count > 0;
        }

        public override async Task<Professor?> ObterPorIdAsync(int id)
        {
            var sql = @"SELECT * FROM Professores WHERE Id = @Id";
            using var connection = new SqlConnection(_configuration.GetConnectionString("GerenciaAlunoBD"));

            var dto = await connection.QueryFirstOrDefaultAsync<ProfessorDto>(sql, new { Id = id });

            return dto == null ? null :
                new Professor(dto.Id, dto.Nome, new Cpf(dto.Cpf), dto.DataNascimento, dto.Email);
        }

        public override async Task<IEnumerable<Professor>> ObterTodosAsync()
        {
            var sql = @"SELECT * FROM Professores";
            using var connection = new SqlConnection(_configuration.GetConnectionString("GerenciaAlunoBD"));

            var dtos = await connection.QueryAsync<ProfessorDto>(sql);

            return dtos.Select(dto =>
                new Professor(dto.Id, dto.Nome, new Cpf(dto.Cpf), dto.DataNascimento, dto.Email)).ToList();
        }

        // DTO para uso com Dapper
        private class ProfessorDto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Cpf { get; set; }
            public DateTime DataNascimento { get; set; }
            public string Email { get; set; }
        }
    }
}

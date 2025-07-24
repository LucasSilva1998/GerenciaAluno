using Dapper;
using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.ValueObjects;
using GerenciaAluno.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Infra.Data.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public ProfessorRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task AdicionarAsync(Professor professor)
        {
            await _context.Professores.AddAsync(professor);
        }

        public void Atualizar(Professor professor)
        {
            _context.Professores.Update(professor);
        }

        public void Remover(Professor professor)
        {
            _context.Professores.Remove(professor);
        }

        public async Task<Professor> ObterPorCpfAsync(string cpf)
        {
            var sql = @"SELECT * FROM Professores WHERE Cpf = @Cpf";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var dto = await connection.QueryFirstOrDefaultAsync<ProfessorDto>(sql, new { Cpf = cpf });

            if (dto == null) return null;

            return new Professor(dto.Id, dto.Nome, new Cpf(dto.Cpf), dto.DataNascimento, dto.Email);
        }

        public async Task<bool> ExisteCpfAsync(string cpf)
        {
            var sql = @"SELECT COUNT(1) FROM Professores WHERE Cpf = @Cpf";
            using var connection = new SqlConnection(_configuration.GetConnectionString("GerenciaAlunoBD"));

            var count = await connection.ExecuteScalarAsync<int>(sql, new { Cpf = cpf });
            return count > 0;
        }

        public async Task<Professor> ObterPorIdAsync(int id)
        {
            var sql = @"SELECT * FROM Professores WHERE Id = @Id";
            using var connection = new SqlConnection(_configuration.GetConnectionString("GerenciaAlunoBD"));

            var dto = await connection.QueryFirstOrDefaultAsync<ProfessorDto>(sql, new { Id = id });

            if (dto == null) return null;

            return new Professor(dto.Id, dto.Nome, new Cpf(dto.Cpf), dto.DataNascimento, dto.Email);
        }

        public async Task<IEnumerable<Professor>> ObterTodosAsync()
        {
            var sql = @"SELECT * FROM Professores";
            using var connection = new SqlConnection(_configuration.GetConnectionString("GerenciaAlunoBD"));

            var dtos = await connection.QueryAsync<ProfessorDto>(sql);

            var professores = dtos.Select(dto =>
                new Professor(dto.Id, dto.Nome, new Cpf(dto.Cpf), dto.DataNascimento, dto.Email)).ToList();

            return professores;
        }

        internal class ProfessorDto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Cpf { get; set; }
            public DateTime DataNascimento { get; set; }
            public string Email { get; set; }
        }
    }
}
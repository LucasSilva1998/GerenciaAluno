using Dapper;
using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Enums;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Infra.Data.Context;
using GerenciaAluno.Infra.Data.Repositories.UoW;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Infra.Data.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public NotaRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task AdicionarAsync(Nota nota)
        {
            await _context.Notas.AddAsync(nota);
        }

        public void Atualizar(Nota nota)
        {
            _context.Notas.Update(nota);
        }

        public void Remover(Nota nota)
        {
            _context.Notas.Remove(nota);
        }

        public async Task<IEnumerable<Nota>> ObterPorAlunoIdAsync(int alunoId)
        {
            var sql = @"SELECT * FROM Notas WHERE AlunoId = @AlunoId";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var notas = await connection.QueryAsync<NotaDto>(sql, new { AlunoId = alunoId });

            return notas.Select(MapearParaNota);
        }

        public async Task<IEnumerable<Nota>> ObterPorProfessorIdAsync(int professorId)
        {
            var sql = @"SELECT * FROM Notas WHERE ProfessorId = @ProfessorId";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var notas = await connection.QueryAsync<NotaDto>(sql, new { ProfessorId = professorId });

            return notas.Select(MapearParaNota);
        }

        public async Task<IEnumerable<Nota>> ObterPorDisciplinaAsync(Disciplina disciplina)
        {
            var sql = @"SELECT * FROM Notas WHERE Disciplina = @Disciplina";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var notas = await connection.QueryAsync<NotaDto>(sql, new { Disciplina = (int)disciplina });

            return notas.Select(MapearParaNota);
        }

        private Nota MapearParaNota(NotaDto dto)
        {
            return new Nota(
                dto.Id,
                dto.AlunoId,
                dto.ProfessorId,
                (Disciplina)dto.Disciplina,
                dto.Valor,
                (StatusNota)dto.Status,
                dto.DataLancamento
            );
        }

        public async Task<Nota> ObterPorIdAsync(int id)
        {
            var sql = @"SELECT * FROM Notas WHERE Id = @Id";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var dto = await connection.QueryFirstOrDefaultAsync<NotaDto>(sql, new { Id = id });

            return dto == null ? null : MapearParaNota(dto);
        }

        public async Task<IEnumerable<Nota>> ObterTodosAsync()
        {
            var sql = @"SELECT * FROM Notas";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var dtos = await connection.QueryAsync<NotaDto>(sql);
            return dtos.Select(MapearParaNota).ToList();
        }

        internal class NotaDto
        {
            public int Id { get; set; }
            public int AlunoId { get; set; }
            public int ProfessorId { get; set; }
            public int Disciplina { get; set; }
            public decimal Valor { get; set; }
            public int Status { get; set; }
            public DateTime DataLancamento { get; set; }
        }
    }
}


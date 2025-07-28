using GerenciaAluno.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Entities
{
    public class Nota
    {
        public int Id { get; set; }

        public int AlunoId { get; set; }
        public int ProfessorId { get; set; }

        public Disciplina Disciplina { get; set; }
        public decimal Valor { get; set; }
        public StatusNota Status { get; set; }
        public DateTime DataLancamento { get; set; }

        public Aluno Aluno { get; set; }
        public Professor Professor { get; set; }


        // Construtor para criação com objetos (Application ou EF)
        public Nota(Aluno aluno, Professor professor, Disciplina disciplina, decimal valor, StatusNota status, DateTime dataLancamento)
        {
            Aluno = aluno;
            Professor = professor;
            AlunoId = aluno.Id;
            ProfessorId = professor.Id;
            Disciplina = disciplina;
            Valor = valor;
            Status = status;
            DataLancamento = dataLancamento;
        }

        // Construtor para reconstrução com objetos (Entity completa)
        public Nota(int id, Aluno aluno, Professor professor, Disciplina disciplina, decimal valor, StatusNota status, DateTime dataLancamento)
            : this(aluno, professor, disciplina, valor, status, dataLancamento)
        {
            Id = id;
        }

        // Construtor para Dapper ou uso com apenas IDs (Infra)
        public Nota(int id, int alunoId, int professorId, Disciplina disciplina, decimal valor, StatusNota status, DateTime dataLancamento)
        {
            Id = id;
            AlunoId = alunoId;
            ProfessorId = professorId;
            Disciplina = disciplina;
            Valor = valor;
            Status = status;
            DataLancamento = dataLancamento;
        }
    }
}
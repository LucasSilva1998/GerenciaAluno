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
        public int Id { get; private set; }
        public int AlunoId { get; private set; }
        public int ProfessorId { get; private set; }

        public Disciplina Disciplina { get; private set; }
        public decimal Valor { get; private set; }
        public StatusNota Status { get; private set; }
        public DateTime DataLancamento { get; private set; }

        public Aluno Aluno { get; private set; }
        public Professor Professor { get; private set; }
    }
}
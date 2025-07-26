using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Dtos.Response
{
    public class NotaResponse
    {
        public int Id { get; set; }
        public string Disciplina { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
        public DateTime DataLancamento { get; set; }

        public string AlunoNome { get; set; }
        public string ProfessorNome { get; set; }
    }
}
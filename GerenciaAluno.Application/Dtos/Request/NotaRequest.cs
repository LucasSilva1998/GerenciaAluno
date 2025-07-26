using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Dtos.Request
{
    public class NotaRequest
    {
        public int AlunoId { get; set; }
        public int ProfessorId { get; set; }
        public int Disciplina { get; set; }  
        public decimal Valor { get; set; }
    }
}
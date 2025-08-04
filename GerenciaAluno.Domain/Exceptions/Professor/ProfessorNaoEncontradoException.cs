using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Exceptions
{
    public class ProfessorNaoEncontradoException : DomainException
    {
        public ProfessorNaoEncontradoException(string message) : base(message) { }
    }
}

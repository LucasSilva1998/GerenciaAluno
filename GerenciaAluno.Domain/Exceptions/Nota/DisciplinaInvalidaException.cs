using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Exceptions.Nota
{
    public class DisciplinaInvalidaException : DomainException
    {
        public DisciplinaInvalidaException(string message) : base(message) { }
    }
}

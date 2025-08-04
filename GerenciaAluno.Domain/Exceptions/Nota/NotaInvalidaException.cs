using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Exceptions.Nota
{
    public class NotaInvalidaException : DomainException
    {
        public NotaInvalidaException(string message) : base(message) { }
    }
}

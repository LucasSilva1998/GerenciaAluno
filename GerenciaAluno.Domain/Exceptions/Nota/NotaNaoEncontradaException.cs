using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Exceptions
{
    public class NotaNaoEncontradaException : DomainException
    {
        public NotaNaoEncontradaException(string message) : base(message) { }
    }
}

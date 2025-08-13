using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Exceptions
{
    public class NaoEncontradoException : Exception
    {
        protected NaoEncontradoException(string message) : base(message) { }
    }
}
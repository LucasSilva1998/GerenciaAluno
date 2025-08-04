using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Exceptions.Aluno
{
    public class AlunoNaoEncontradoException : DomainException
    {
        public AlunoNaoEncontradoException(string message) : base(message) { }
    }
}

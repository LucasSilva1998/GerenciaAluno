using System;

namespace GerenciaAluno.Domain.Exceptions.Aluno
{
    public class AlunoJaCadastradoException : DomainException
    {
        public AlunoJaCadastradoException(string message) : base(message) { }
    }
}

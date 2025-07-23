using GerenciaAluno.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Entities
{
    public class Aluno
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Cpf Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }

        public ICollection<Nota> Notas { get; private set; }
    }
}
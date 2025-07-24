using GerenciaAluno.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Entities
{
    public class Professor
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Cpf Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }

        public ICollection<Nota> NotasLançadas { get; private set; }


        // Construtor para reconstrução
        public Professor(int id, string nome, Cpf cpf, DateTime dataNascimento, string email)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            NotasLançadas = new List<Nota>();
        }
    }
}

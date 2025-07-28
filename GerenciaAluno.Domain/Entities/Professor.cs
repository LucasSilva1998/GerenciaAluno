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
        public int Id { get; set; }
        public string Nome { get; set; }
        public Cpf Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }

        public ICollection<Nota> NotasLançadas { get; set; }


        // Construtor para criação (sem id)
        public Professor(string nome, Cpf cpf, DateTime dataNascimento, string email)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            NotasLançadas = new List<Nota>();
        }

        // Construtor para reconstrução (com id)
        public Professor(int id, string nome, Cpf cpf, DateTime dataNascimento, string email)
            : this(nome, cpf, dataNascimento, email)
        {
            Id = id;
        }
    }

}

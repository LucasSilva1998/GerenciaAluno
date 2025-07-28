using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Mappers
{
    public static class AlunoMapper
    {
        public static Aluno ToEntity(AlunoRequest request)
        {
            return new Aluno(
                nome: request.Nome,
                cpf: new Cpf(request.Cpf),
                dataNascimento: request.DataNascimento,
                email: request.Email
            );
        }

        public static void AtualizarEntidade(Aluno aluno, AlunoRequest request)
        {
            aluno.Nome = request.Nome;
            aluno.Cpf = new Cpf(request.Cpf);
            aluno.DataNascimento = request.DataNascimento;
            aluno.Email = request.Email;
        }

        public static AlunoResponse ToResponse(Aluno aluno)
        {
            return new AlunoResponse
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Cpf = aluno.Cpf.Numero,
                DataNascimento = aluno.DataNascimento,
                Email = aluno.Email
            };
        }
    }
}
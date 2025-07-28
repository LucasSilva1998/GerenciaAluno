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
    public static class ProfessorMapper
    {
        public static Professor ToEntity(ProfessorRequest request)
        {
            return new Professor(
                nome: request.Nome,
                cpf: new Cpf(request.Cpf),
                dataNascimento: request.DataNascimento,
                email: request.Email
            );
        }

        public static void AtualizarEntidade(Professor professor, ProfessorRequest request)
        {
            professor.Nome = request.Nome;
            professor.Cpf = new Cpf(request.Cpf);
            professor.DataNascimento = request.DataNascimento;
            professor.Email = request.Email;
        }

        public static ProfessorResponse ToResponse(Professor professor)
        {
            return new ProfessorResponse
            {
                Id = professor.Id,
                Nome = professor.Nome,
                Cpf = professor.Cpf.Numero,
                DataNascimento = professor.DataNascimento,
                Email = professor.Email
            };
        }
    }
}
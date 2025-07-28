using GerenciaAluno.Application.Dtos.Request;
using GerenciaAluno.Application.Dtos.Response;
using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Mappers
{
    public static class NotaMapper
    {
        public static NotaResponse ToResponse(Nota nota)
        {
            return new NotaResponse
            {
                Id = nota.Id,
                Disciplina = nota.Disciplina.ToString(),
                Valor = nota.Valor,
                Status = nota.Status.ToString(),
                DataLancamento = nota.DataLancamento,
                AlunoNome = nota.Aluno?.Nome,
                ProfessorNome = nota.Professor?.Nome
            };
        }


        public static Nota ToEntity(NotaRequest request, Aluno aluno, Professor professor)
        {
            return new Nota(
                aluno,
                professor,
                (Disciplina)request.Disciplina,  
                request.Valor,
                StatusNota.Lançada,               
                DateTime.Now                    
            );
        }
    }
}

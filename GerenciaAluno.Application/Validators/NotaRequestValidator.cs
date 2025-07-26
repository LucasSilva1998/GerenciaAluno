using FluentValidation;
using GerenciaAluno.Application.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Validators
{
    public class NotaRequestValidator : AbstractValidator<NotaRequest>
    {
        public NotaRequestValidator()
        {
            RuleFor(x => x.AlunoId)
                .GreaterThan(0).WithMessage("O ID do aluno é obrigatório.");

            RuleFor(x => x.ProfessorId)
                .GreaterThan(0).WithMessage("O ID do professor é obrigatório.");

            RuleFor(x => x.Disciplina)
                .IsInEnum().WithMessage("Disciplina inválida.");

            RuleFor(x => x.Valor)
                .InclusiveBetween(0, 10).WithMessage("A nota deve estar entre 0 e 10.");
        }
    }
}

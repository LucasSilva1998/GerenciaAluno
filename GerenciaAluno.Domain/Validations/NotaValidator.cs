using FluentValidation;
using GerenciaAluno.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Validations
{
    public class NotaValidator : AbstractValidator<Nota>
    {
        public NotaValidator()
        {
            RuleFor(n => n.Valor)
                .InclusiveBetween(0, 10).WithMessage("A nota deve estar entre 0 e 10.");

            RuleFor(n => n.Disciplina)
                .IsInEnum().WithMessage("Disciplina inválida.");

            RuleFor(n => n.AlunoId)
                .NotEmpty().WithMessage("AlunoId é obrigatório.");

            RuleFor(n => n.ProfessorId)
                .NotEmpty().WithMessage("ProfessorId é obrigatório.");
        }
    }
}
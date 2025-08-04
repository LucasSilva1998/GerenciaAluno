using GerenciaAluno.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Interfaces.Services
{
    public interface IProfessorDomainService
    {
        Task ValidarCadastroAsync(Professor professor);
    }
}


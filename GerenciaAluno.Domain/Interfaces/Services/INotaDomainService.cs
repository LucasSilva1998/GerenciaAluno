using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciaAluno.Domain.Entities;

namespace GerenciaAluno.Domain.Interfaces.Services
{
    public interface INotaDomainService
    {
        Task ValidarCadastroAsync(Nota nota);
    }
}


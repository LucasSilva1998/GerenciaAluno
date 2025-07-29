using GerenciaAluno.Application.Interfaces;
using GerenciaAluno.Application.Services;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;
using GerenciaAluno.Domain.Services;
using GerenciaAluno.Infra.Data.Repositories;
using GerenciaAluno.Infra.Data.Repositories.UoW;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Application.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)

        {
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<INotaService, NotaService>();

            return services;
        }
    }
}

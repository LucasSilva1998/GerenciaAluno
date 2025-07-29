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

namespace GerenciaAluno.Infra.Data.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositórios
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<INotaRepository, NotaRepository>();

            // Serviços de domínio
            services.AddScoped<ICadastroDomainService, CadastroDomainService>();

            return services;
        }
    }
}

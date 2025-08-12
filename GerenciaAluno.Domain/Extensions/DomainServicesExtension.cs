using GerenciaAluno.Domain.Interfaces.Services;
using GerenciaAluno.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Extensions
{
     /// <summary>
    /// Classe de extensão para configurar as injeções de dependência dos serviços de domínio.
    /// </summary>
    public static class DomainServicesExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IAlunoDomainService, AlunoDomainService>();
            services.AddScoped<IProfessorDomainService, ProfessorDomainService>();
            services.AddScoped<INotaDomainService, NotaDomainService>();

            return services;
        }
    }
}



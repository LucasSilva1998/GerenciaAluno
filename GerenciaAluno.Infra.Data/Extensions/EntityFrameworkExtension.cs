using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Infra.Data.Extensions
{
    public static class EntityFrameworkExtension
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GerenciaAlunoBD")));

            // Injeção de dependência do UnitOfWork
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
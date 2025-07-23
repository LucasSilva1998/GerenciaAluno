using Microsoft.OpenApi.Models;

namespace GerenciaAluno.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GerenciaAluno API - Gerenciamento de Alunos",
                    Version = "v1",
                    Description = "API para gerenciamento de alunos, professores e notas.",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Pereira",
                        Email = "lucaslc08@gmail.com",
                        Url = new Uri("https://github.com/LucasSilva1998/GerenciaAluno")
                    }
                });

            });

            return services;
        }
    }
}
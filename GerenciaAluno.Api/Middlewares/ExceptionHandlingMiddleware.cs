using FluentValidation;
using GerenciaAluno.Domain.Exceptions;
using GerenciaAluno.Domain.Exceptions.Aluno;
using GerenciaAluno.Domain.Exceptions.Nota;
using GerenciaAluno.Domain.Exceptions.Professor;
using Newtonsoft.Json;
using System.Net;

namespace GerenciaAluno.Api.Middlewares
{
    /// <summary>
    /// Middleware para tratamento de exceções do projeto ASP.NET
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException e)
            {
                await HandleValidationException(context, e);
            }
            catch (NaoEncontradoException e)
            {
                await HandleNaoEncontradoException(context, e);
            }
            catch (AlunoJaCadastradoException e)
            {
                await HandleAlunoJaCadastradoException(context, e);
            }
            catch (AlunoNaoEncontradoException e)
            {
                await HandleAlunoNaoEncontradoException(context, e);
            }
            catch (DisciplinaInvalidaException e)
            {
                await HandleDisciplinaInvalidaException(context, e);
            }
            catch (NotaInvalidaException e)
            {
                await HandleNotaInvalidaException(context, e);
            }
            catch (NotaNaoEncontradaException e)
            {
                await HandleNotaNaoEncontradaException(context, e);
            }
            catch (StatusNotaInvalidoException e)
            {
                await HandleStatusNotaInvalidoException(context, e);
            }
            catch (ProfessorJaCadastradoException e)
            {
                await HandleProfessorJaCadastradoException(context, e);
            }
            catch (ProfessorNaoEncontradoException e)
            {
                await HandleProfessorNaoEncontradoException(context, e);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        private static Task HandleValidationException(HttpContext context, ValidationException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var errors = exception.Errors.Select(e => new
            {
                Name = e.PropertyName,
                Message = e.ErrorMessage,
                Severity = e.Severity.ToString()
            });

            var response = new
            {
                Message = "Ocorreram erros de validação.",
                Status = context.Response.StatusCode,
                Errors = errors
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static Task HandleNaoEncontradoException(HttpContext context, NaoEncontradoException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = exception.Message,
                Status = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static Task HandleAlunoJaCadastradoException(HttpContext context, AlunoJaCadastradoException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict; // 409
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = exception.Message,
                Status = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static Task HandleAlunoNaoEncontradoException(HttpContext context, AlunoNaoEncontradoException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound; // 404
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = exception.Message,
                Status = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static Task HandleDisciplinaInvalidaException(HttpContext context, DisciplinaInvalidaException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest; // 400
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = exception.Message,
                Status = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static Task HandleNotaInvalidaException(HttpContext context, NotaInvalidaException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest; // 400
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = exception.Message,
                Status = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static Task HandleNotaNaoEncontradaException(HttpContext context, NotaNaoEncontradaException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound; // 404
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = exception.Message,
                Status = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static Task HandleStatusNotaInvalidoException(HttpContext context, StatusNotaInvalidoException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest; // 400
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = exception.Message,
                Status = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static Task HandleProfessorJaCadastradoException(HttpContext context, ProfessorJaCadastradoException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict; // 409
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = exception.Message,
                Status = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static Task HandleProfessorNaoEncontradoException(HttpContext context, ProfessorNaoEncontradoException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound; // 404
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = exception.Message,
                Status = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = "Falha interna ao executar a operação.",
                Status = context.Response.StatusCode
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}

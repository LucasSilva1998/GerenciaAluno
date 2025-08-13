using FluentValidation.Validators;
using GerenciaAluno.Api.Extensions;
using GerenciaAluno.Api.Middlewares;
using GerenciaAluno.Application.Extensions;
using GerenciaAluno.Application.Interfaces;
using GerenciaAluno.Application.Services;
using GerenciaAluno.Domain.Extensions;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;
using GerenciaAluno.Domain.Services;
using GerenciaAluno.Infra.Data.Extensions;
using GerenciaAluno.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Application Services
builder.Services.AddApplicationServices();

// Domain Services
builder.Services.AddDomainServices();

// Infra Services 
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddInfrastructureServices();

// Swagger (centralizado na extensão)
builder.Services.AddSwaggerDocumentation();

builder.Services.AddOpenApi();

var app = builder.Build();

//Middlewares
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();

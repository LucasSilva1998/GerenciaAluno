📚 GerenciaAlunoAPI

API RESTful para gerenciamento de alunos, professores e notas, construída com .NET 9, utilizando princípios de DDD (Domain-Driven Design) e Clean Architecture.

---

🚀 Funcionalidades

✅ Cadastro de alunos com validação de CPF.

✅ Cadastro de professores com informações de disciplina.

✅ Registro e consulta de notas.

✅ Listagem de alunos, professores e notas.

✅ Estrutura modular baseada em DDD.

---


🏗️ Arquitetura

A API segue os princípios de DDD e está organizada nas seguintes camadas:

Presentation → Controllers e endpoints da API.

Application → DTOs, Services e lógica de aplicação.

Domain → Entidades, Value Objects, Interfaces, Enums, Exceptions e Validations.

Infrastructure → Persistência de dados e integrações externas.

---

🔧 Tecnologias Utilizadas

- .NET 9 / ASP.NET Core Web API

- Entity Framework Core (ou Dapper, se preferir)

- SQL Server

- JWT para autenticação

- Serilog para logging estruturado

- FluentValidation para validações

- xUnit + Bogus + FluentAssertions para testes

---

📂 Estrutura de Pastas<br>
GerenciaAlunoAPI/<br>
│── src/<br>
│   ├── GerenciaAlunoAPI.Presentation/    # Controllers<br>
│   ├── GerenciaAlunoAPI.Application/     # DTOs e Services<br>
│   ├── GerenciaAlunoAPI.Domain/          # Entidades, VOs, Enums, Exceptions<br>
│   ├── GerenciaAlunoAPI.Infrastructure/  # Persistência e repositórios<br>
│<br>
│── tests/<br>
│   ├── GerenciaAlunoAPI.Tests/           # Testes unitários e de integração

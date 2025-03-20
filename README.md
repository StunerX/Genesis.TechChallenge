
# 🏢 Genesis.TechChallenge

O Genesis.TechChallenge é uma aplicação que simula investimentos em CDB (Certificado de Depósito Bancário).
O usuário informa o valor inicial e o período do investimento, e a aplicação calcula o rendimento bruto e líquido ao final do prazo.

---

## 📚 Sumário
- [Tecnologias](#tecnologias)
- [Arquitetura](#arquitetura)
- [Como rodar o projeto](#como-rodar-o-projeto)
- [Endpoints](#endpoints)
- [Testes](#testes)
- [Logging](#logging)
- [Decisões Técnicas](#decisões-técnicas)
- [Autores](#autores)

---

## 🚀 Tecnologias

- .NET 8
- MediatR (CQRS)
- Serilog (Logs estruturados)
- FluentValidation
- Swagger / OpenAPI
- Frontend
  - Angular CLI
- Docker e Docker Compose
- Observabilidade
  - Elastic Search
  - Kibana
  - APM
---

## 🏛️ Arquitetura

O projeto foi desenvolvido seguindo os princípios da **Clean Architecture**, com separação clara de responsabilidades.

```
├── backend
│   ├── Genesis.TechChallenge.Domain
│   ├── Genesis.TechChallenge.Application
│   ├── Genesis.TechChallenge.Infrastructure
│   └── Genesis.TechChallenge.WebAPI
├── frontend
│   └── Genesis.TechChallenge.Frontend (Angular CLI)
├── docker-compose.yml
```

---

## 🔧 Como rodar o projeto

### Pré-requisitos

- Docker
- Docker Compose v2

### Passo a passo

1. Clone o repositório:

```bash
git clone https://github.com/stunerx/genesis.techchallenge.git
cd genesis.techchallenge
```

2. Rode o Docker Compose:

```bash
docker compose up -d --build
```

### Serviços que serão criados:

| Serviço    | Porta local | Container Name                 |
|------------|------------|--------------------------------|
| Web API    | 8080       | genesis.techchallenge.webapi   |
| Frontend   | 4200       | genesis.techchallenge.frontend |
| Elastic    | 9200       | elastic                        |
| Kibana     | 5601       | kibana                         |
| Apm-Server | 8200       | apm-server                     |

---

## 🌐 Endpoints

| Verbo  | Endpoint             | Descrição                                              |
|--------|----------------------|--------------------------------------------------------|
| POST   | `/api/cdb/calculate` | Calcula o cdb a a partir de um valor inicial e periodo |


---

## ✅ Testes

O projeto inclui:

- **Unit Tests:** Cobrem regras de negócio e validações de entrada.
- **Integration Tests:** Validam integrações entre componentes.
- **Functional Tests:** Validam os endpoints da API de ponta a ponta via HTTP.

### Rodando os testes:

```bash
dotnet test
```

### Gerando o relatório de cobertura de código

1. Execute os testes com coleta de cobertura
```bash
dotnet test Genesis.TechChallenge.sln --collect:"XPlat Code Coverage"
```

2. Gere o relatório em HTML
```bash
reportgenerator -reports:"./backend/tests/**/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```

3. Acesse o relatório
```bash
open ./coveragereport/index.html
```

---

## 📄 Logging

A aplicação usa **Serilog**, com configuração para:

- Logs no Console (modo Debug)
- Logs em Arquivo (modo Release)
- Enriquecimento com `Serilog.Exceptions` para detalhes de exceções

---

## 🔍 Decisões Técnicas

- **CQRS com MediatR** para separação de comandos e queries.
- **Serilog** como logger estruturado.
- **Validations** com FluentValidation.
- **Middleware Global** para tratamento de exceções.
- **Docker Compose** para orquestração de serviços.

---

## ✍️ Autor

| Nome      | GitHub                                     |
|-----------|--------------------------------------------|
| Cleyton   | [@stunerx](https://github.com/stunerx) |

---


# 🩸 Sistema de Gerenciamento de Banco de Sangue - API

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?logo=c-sharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoft-sql-server)](https://www.microsoft.com/sql-server)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-512BD4)](https://docs.microsoft.com/ef/core/)

## 📋 Sobre o Projeto

API RESTful completa para gerenciamento de banco de sangue, desenvolvida com **ASP.NET Core** seguindo princípios de **Clean Architecture** e **Domain-Driven Design (DDD)**. O sistema permite o controle de doadores, doações, estoque de sangue e gera alertas automáticos quando o estoque está abaixo do mínimo.

### 🎯 Problema que Resolve

Bancos de sangue precisam gerenciar eficientemente:
- ✅ Cadastro e validação de doadores
- ✅ Registro de doações com rastreabilidade
- ✅ Controle de estoque por tipo sanguíneo e fator RH
- ✅ Alertas automáticos de estoque baixo
- ✅ Histórico de eventos críticos

---

## ✨ Funcionalidades

### 👥 Gestão de Doadores
- Cadastro completo com validação de regras de negócio
- Validação de elegibilidade para doação (idade, peso, intervalo entre doações)
- Consulta de CEP automática via API ViaCEP
- Histórico de doações por doador

### 💉 Gestão de Doações
- Registro de doações com data e quantidade
- Atualização automática do estoque
- Validação de regras (intervalo mínimo entre doações)
- Rastreabilidade completa

### 📦 Controle de Estoque
- Gerenciamento por tipo sanguíneo (A, B, AB, O) e fator RH (+/-)
- Quantidade mínima configurável
- Entrada e saída de sangue
- Alertas automáticos via Domain Events

### 📊 Relatórios e Histórico
- Histórico de estoque abaixo do mínimo
- Logs de alertas críticos
- Consultas e relatórios personalizados

---

## 🏗️ Arquitetura e Padrões

### Clean Architecture
```
┌─────────────────────────────────────┐
│     BancoDeSangue.API (Web)        │
│  Controllers, Middleware, Config    │
└─────────────────┬───────────────────┘
                  │
┌─────────────────▼───────────────────┐
│  BancoDeSangue.Application (App)   │
│  Services, ViewModels, Validators   │
└─────────────────┬───────────────────┘
                  │
┌─────────────────▼───────────────────┐
│    BancoDeSangue.Core (Domain)     │
│  Entities, Events, Repositories     │
└─────────────────┬───────────────────┘
                  │
┌─────────────────▼───────────────────┐
│ BancoDeSangue.Infrastructure (Infra)│
│  EF Core, Repositories, External    │
└─────────────────────────────────────┘
```

### 🎨 Padrões Implementados
- **Clean Architecture** - Separação de responsabilidades em camadas
- **Domain-Driven Design (DDD)** - Modelagem rica de domínio
- **Repository Pattern** - Abstração de acesso a dados
- **CQRS Pattern** - Separação de comandos e consultas
- **Domain Events** - Comunicação assíncrona entre agregados (MediatR)
- **Dependency Injection** - Inversão de controle
- **Result Pattern** - Tratamento de erros e validações

---

## 🛠️ Stack Tecnológico

### Backend
- **ASP.NET Core 8.0** - Framework web
- **C# 12** - Linguagem de programação
- **Entity Framework Core** - ORM
- **SQL Server** - Banco de dados
- **MediatR** - Mediator pattern para eventos de domínio

### Bibliotecas e Ferramentas
- **Scalar** - Documentação interativa da API
- **FluentValidation** - Validação de modelos
- **ViaCEP API** - Consulta de endereços

### Arquitetura
- **Clean Architecture** - Estrutura do projeto
- **Domain Events** - Eventos de domínio com MediatR
- **Exception Handling Middleware** - Tratamento centralizado de erros

---

## 🚀 Como Executar

### Pré-requisitos
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) ou SQL Server Express
- IDE: Visual Studio 2022+ ou Visual Studio Code

### Passo a Passo

1. **Clone o repositório**
```bash
git clone https://github.com/Bruno-Regis/Projeto-BancoDeSangue-API.git
cd Projeto-BancoDeSangue-API
```

2. **Configure a conexão com o banco de dados**

Edite o arquivo `appsettings.json` em `BancoDeSangue.API`:
```json
{
  "ConnectionStrings": {
    "BancoDeDoacoesCs": "Server=SEU_SERVIDOR;Database=BancoDeSangueDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

3. **Execute as migrations**
```bash
cd BancoDeSangue.API
dotnet ef database update
```

4. **Execute a aplicação**
```bash
dotnet run
```

5. **Acesse a documentação da API**
- Swagger/Scalar: `https://localhost:7XXX/scalar/v1` (porta pode variar)

---

## 📡 Endpoints da API

### 👥 Doadores (`/api/doadores`)
```
GET    /api/doadores          - Lista todos os doadores
GET    /api/doadores/{id}     - Busca doador por ID
POST   /api/doadores          - Cadastra novo doador
PUT    /api/doadores/{id}     - Atualiza doador
DELETE /api/doadores/{id}     - Remove doador
```

### 💉 Doações (`/api/doacoes`)
```
GET    /api/doacoes           - Lista todas as doações
GET    /api/doacoes/{id}      - Busca doação por ID
POST   /api/doacoes           - Registra nova doação
```

### 📦 Estoque (`/api/estoques`)
```
GET    /api/estoques          - Lista estoque por tipo sanguíneo
GET    /api/estoques/{id}     - Busca estoque específico
POST   /api/estoques          - Cria novo registro de estoque
PUT    /api/estoques/{id}     - Atualiza estoque
PUT    /api/estoques/{id}/retirar - Retira sangue do estoque
```

### 📊 Relatórios (`/api/relatorios`)
```
GET    /api/relatorios/historico-estoque-baixo - Histórico de alertas
```

---

## 🎯 Destaques Técnicos

### Domain Events com MediatR
```csharp
// Evento disparado quando estoque fica abaixo do mínimo
public class EstoqueAbaixoMinimoDomainEvent : IDomainEvent
{
    public EstoqueSangue EstoqueSangue { get; }
}

// Handler que registra o evento no histórico
public class EstoqueAbaixoMinimoDomainEventHandler 
    : INotificationHandler<EstoqueAbaixoMinimoDomainEvent>
{
    public async Task Handle(EstoqueAbaixoMinimoDomainEvent notification)
    {
        // Loga alerta e salva no histórico
        _logger.LogWarning($"ALERTA: Estoque baixo para {notification.EstoqueSangue.TipoSanguineo}");
        await _historicoRepository.AddAsync(historico);
    }
}
```

### Validação de Regras de Negócio
```csharp
public class Doador : BaseEntity
{
    public void ValidarDoacao()
    {
        var idade = CalcularIdade();
        if (idade < 16 || idade > 69)
            throw new DomainException("Doador fora da faixa etária permitida");

        if (Peso < 50)
            throw new DomainException("Peso mínimo para doação é 50kg");

        var diasDesdeUltimaDoacao = CalcularDiasDesdeUltimaDoacao();
        var intervaloMinimo = Genero == Genero.Masculino ? 60 : 90;
        
        if (diasDesdeUltimaDoacao < intervaloMinimo)
            throw new DomainException($"Intervalo mínimo entre doações: {intervaloMinimo} dias");
    }
}
```

### Exception Handling Middleware
```csharp
public class ApiExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(Exception exception)
    {
        return exception switch
        {
            DomainException => HandleDomainException(),
            ExternalServiceException => HandleExternalServiceException(),
            _ => HandleGenericException()
        };
    }
}
```

---

## 📁 Estrutura do Projeto

```
Projeto-BancoDeSangue-API/
│
├── BancoDeSangue.API/              # Camada de apresentação
│   ├── Controllers/                # Controladores da API
│   ├── ExceptionHandler/           # Middleware de exceções
│   └── Program.cs                  # Configuração da aplicação
│
├── BancoDeSangue.Application/      # Camada de aplicação
│   ├── Events/                     # Handlers de eventos
│   ├── Models/                     # DTOs (ViewModels e InputModels)
│   ├── Services/                   # Serviços de aplicação
│   └── Validators/                 # Validadores FluentValidation
│
├── BancoDeSangue.Core/             # Camada de domínio
│   ├── Entities/                   # Entidades de domínio
│   ├── Enums/                      # Enumeradores
│   ├── Events/                     # Eventos de domínio
│   ├── Exceptions/                 # Exceções customizadas
│   └── Repositories/               # Interfaces de repositórios
│
└── BancoDeSangue.Infrastructure/   # Camada de infraestrutura
    ├── ExternalServices/           # Integração com APIs externas
    ├── Persistence/                # EF Core, DbContext, Migrations
    │   ├── Configurations/         # Configurações do EF
    │   ├── Migrations/             # Migrations do banco
    │   └── Repositories/           # Implementação dos repositórios
    └── InfrastructureModule.cs     # Configuração de DI
```

---

## 🔮 Melhorias Futuras

- [ ] **Autenticação e Autorização** - JWT/OAuth2
- [ ] **Testes Automatizados** - Unitários, Integração e E2E
- [ ] **Cache** - Redis para consultas frequentes
- [ ] **Notificações** - Email/SMS quando estoque baixo
- [ ] **Auditoria** - Log de todas as operações críticas
- [ ] **Dashboard** - Interface web para visualização
- [ ] **API Versionamento** - Suporte a múltiplas versões
- [ ] **Docker** - Containerização da aplicação
- [ ] **CI/CD** - Pipeline automatizado

---

## 👨‍💻 Desenvolvedor

**Bruno Régis**

- 💼 LinkedIn: [Adicione seu LinkedIn aqui]
- 📧 Email: [Adicione seu email aqui]
- 🌐 Portfolio: [Adicione seu portfolio aqui]

---

## 📄 Licença

Este projeto foi desenvolvido para fins de estudo e portfólio.

---

⭐ **Se este projeto foi útil, considere deixar uma estrela!**
# 📌 Vaccination Card API
A .NET 9 Web API to manage a person's vaccination card. 
It allows for registration, consultation, updating, and deletion of recorded vaccines.

# 📊 Domain Model (Class Diagram)
This project has 3 main entities:
- Person
- Vaccine
- VaccinationRecord

classDiagram
    class Person {
        Guid Id
        string Name
        List<VaccinationRecord> VaccinationRecords
    }

    class Vaccine {
        Guid Id
        string Name
        List<VaccinationRecord> VaccinationRecords
    }

    class VaccinationRecord {
        Guid Id
        Guid PersonId
        Guid VaccineId
        Dose Dose
        DateTime DateAplication
        Person Person
        Vaccine Vaccine
    }

    Person "1" --> "many" VaccinationRecord : has
    Vaccine "1" --> "many" VaccinationRecord : has

## ⚙️ Tech Stack:
- .NET 9
- EF Core + SQLite
- Swashbuckle (aka Swagger)
- AutoMapper
- FluentValidation
- dotnet-ef para Migrations 
- xUnit + Microsoft.NET.Test.Sdk 

## 🚀 Features
- CRUD operations for Person, Vaccine, and VaccinationRecord
- Swagger UI for API documentation
- DTOs + AutoMapper for clean separation
- Validation with FluentValidation
- Repository pattern for persistence
- DDD-inspired architecture

## 📌 TO-DO
- ✅ Unit Tests (xUnit + FluentAssertions + Mocks)
- 🔒 Authentication & Login
- 🛡️ Middleware to check authentication


# Documentation of the process

## Setup & Installation

1. Install .NET
Follow the official docs: 
- [👉 Install .NET on Windoes](https://learn.microsoft.com/pt-br/dotnet/core/install/windows)
- [👉 Install .NET on Macos](https://learn.microsoft.com/pt-br/dotnet/core/install/macos)
- [👉 Install .NET on Linux](https://learn.microsoft.com/pt-br/dotnet/core/install/linux)

For Arch Linux:
``` bash
sudo pacman -S dotnet-sdk dotnet-runtime aspnet-runtime
```

2. Create the API Project
```bash
dotnet new webapi -n cartao-vacinacao-api
```

Rename the directory to '/api' to follow solution arquitecture
```bash
mv /cartao-vacinacao-api /api
```

Create solution:
```bash
dotnet new sln -n cartao-vacinacao-sln
```

Add API Project in solution
```bash
dotnet sln add api/cartao-vacinacao-api.csproj
```

3. Create Test Project
```bash
dotnet new xunit -n tests
```

Add Test Project in solution
```bash
dotnet sln cartao-vacinacao-sln add cartao-vacinacao-api.csproj
```

Add a referência from tests to API projeto 
```bash
dotnet add tests/tests.csproj reference api/cartao-vacinacao-api.csproj
```

4. Install Dependencies
```bash
# EF Core + SQLite
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0

# EF CLI
dotnet new tool-manifest
dotnet tool install dotnet-ef --version 9.0.0

# Swagger
dotnet add package Swashbuckle.AspNetCore --version 6.5.0

# AutoMapper
dotnet add package AutoMapper --version 12.0.1
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1

# Validation
dotnet add package FluentValidation
dotnet add package FluentValidation.AspNetCore
```

in the api directory add some packages to start the DB configuration, in this case EF Core, im using --version 9.0.0 because thats the verson of dotnet i have, don't forget to use your current version

5. Database Migrations
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
Undo migration:
If you need to undo
```bash
dotnet ef migrations remove
```

6. Run the API
To run the api:
```bash
dotnet run
```

Swagger UI will be available at: 
[👉 http://localhost:5147/swagger](http://localhost:5147/swagger)


##  API Arquiteture 
Modified DDD + Clean Architecture with Repository Pattern:
- / (Solution root)
- /Api/ (projeto Web API)
- /Api/Controllers/ — endpoints REST
- /Api/Services/ — business rules
- /Api/Repositories/ — acesso a dados (EF Core)
- /Api/Data/ — ApplicationDbContext (EF Core + SQLite)
- /Api/Dtos/ — DTOs de entrada/saída
- /Api/Models/ — entities (Person, Vaccine, VaccinationRecord)
- /Api/Mappings/ — AutoMapper profiles
- /Api/Validators/ — FluentValidation
- /Tests/ — projeto de testes (xUnit)

```bash
/ (Solution root)
 ├── /Api/ (Web API project)
 │    ├── Controllers/                 → REST endpoints
 │    ├── /Application/Services/       → business rules & use cases
 │    ├── /Application/Dtos/           → input/output DTOs
 │    ├── /Application/Profiles/       → AutoMapper profiles
 │    ├── /Application/Validators/     → FluentValidation rules
 │    ├── /Domain/Entities/            → core entities (Person, Vaccine, VaccinationRecord)
 │    ├── /Domain/Enums/               → domain enums (e.g. Dose)
 │    ├── /Domain/Interfaces/          → repository & service contracts
 │    ├── /Infrastructure/Repositories/→ EF Core data access implementations
 │    ├── /Infrastructure/Data/        → ApplicationDbContext (EF Core + SQLite)
 │    ├── /Infrastructure/Mappings/    → entity configurations (EF Core mappings)
 │    ├── /Configurations/             → app setup (Swagger, Dependency Injection, etc.)
 ├── /Tests/                           → unit tests (xUnit)
```

Layers:
- Domain → entities + business rules
- Application → services, DTOs, use cases
- Infrastructure → persistence (SQLite, EF Core)
- Web/API → controllers & endpoints
- Tests → unit tests


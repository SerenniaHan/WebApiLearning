# WebApiLearning

A minimal .NET solution that exposes a CQRS-style Web API backed by MongoDB, plus a Blazor Server UI.

## Features

- ASP.NET Core Minimal APIs with MediatR (request/handler pattern)
- MongoDB repositories (GUIDs with Standard representation)
- Blazor Server UI for basic CRUD
- OpenAPI/Swagger (Scalar UI) in Development
- Docker Compose for local MongoDB with seed data

## Tech stack

- .NET 9, ASP.NET Core Minimal APIs
- MediatR, LanguageExt (Option/Result)
- MongoDB.Driver
- Blazor Server

## Project structure

- API: `src/WebApiLearning.Api`
  - Endpoints: `Endpoints/WeaponEndpoints.cs`, `Endpoints/ShopEndpoints.cs`, `Endpoints/InventoryEndpoints.cs`
  - Composition in `Program.cs`
- Application: `src/WebApiLearning.Application` (MediatR commands/queries)
- Domain: `src/WebApiLearning.Domain` (entities + repository interfaces)
- Infrastructure (Mongo): `src/WebApiLearning.Infrastructure.Mongo` (repositories, configuration)
- Blazor UI: `src/WebApiLearning.Blazor` (pages + services)
- Tests: `tests/WebApiLearning.UnitTests`
- Seed: `mongo-init/01-init.js`
- Container: `Dockerfile`, `docker-compose.yml`

## Prerequisites

- .NET 9 SDK
- Docker (for MongoDB)
- macOS or Linux/Windows

## Quick start

1) Start MongoDB (with seed):
````sh
docker compose up -d
````
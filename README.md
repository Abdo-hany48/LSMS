# LSMS — Lecture Schedule Management System

A web application for managing university lecture schedules, built with ASP.NET Core MVC and Entity Framework Core. The project emphasizes clean separation of concerns, maintainability, and a responsive UI.
---

## Features and Strengths

- Clean MVC architecture
  - `Controllers`, `Models`, `Views` with clear role separation
  - `Services` layer for domain logic
  - `data_access` for persistence concerns
- Database-first approach with migrations
  - `Migrations` directory for tracked schema evolution
  - Easily reproducible environments via `dotnet ef database update`
- Modern UI stack
  - `wwwroot` assets, HTML/CSS, SCSS, Less for styling
  - Responsive layout suitable for academic scheduling use-cases
- Production-friendly configuration
  - `appsettings.json` and `appsettings.Development.json` for environment-specific config
  - `Program.cs` for minimal hosting model
- Solution-level organization
  - `LSMS.sln` and `LSMS.csproj` simplify IDE and CLI workflows

---

## Tech Stack

- ASP.NET Core MVC (C#)
- Entity Framework Core (Code-First Migrations)
- SQL Server (LocalDB/Express/Full)
- Razor Views, SCSS/Less/CSS
- .NET SDK (check `TargetFramework` in `LSMS.csproj`)

---

## Project Structure

- `Controllers/` — MVC controllers (HTTP endpoints and actions)
- `Models/` — Domain models and view models
- `Views/` — Razor views for UI
- `Services/` — Business/domain services
- `data_access/` — Data access and repository abstractions
- `Migrations/` — EF Core migrations
- `wwwroot/` — Static assets (CSS, JS, images)
- `Program.cs` — App bootstrapping / hosting
- `appsettings*.json` — Configuration files
- `LSMS.sln`, `LSMS.csproj` — Solution and project files

---

## Prerequisites

- .NET SDK 6.0+ (verify in `LSMS.csproj` under `<TargetFramework>`)
- SQL Server (LocalDB/Express/Full)
  - LocalDB default instance works out of the box on Windows
- Optional (if you need EF CLI): `dotnet tool install --global dotnet-ef`

---

## Configuration

Update your database connection string in `appsettings.json` (or `appsettings.Development.json`):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=LSMS;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

Use your own SQL Server instance as needed.

---

## Setup and Run (CLI)

1. Restore and build:
   ```bash
   dotnet restore
   dotnet build
   ```

2. Apply database migrations:
   ```bash
   # If you don't have EF CLI:
   # dotnet tool install --global dotnet-ef

   dotnet ef database update
   ```

3. Run the application:
   ```bash
   dotnet run --project LSMS.csproj
   ```
   The console output will show the listening URL(s), e.g. `http://localhost:5xxx`.

---

## Setup and Run (Visual Studio)

1. Open `LSMS.sln`.
2. Set `LSMS` as the startup project.
3. Ensure the connection string is valid in `appsettings.Development.json`.
4. Update database via:
   - Package Manager Console:
     ```powershell
     Update-Database
     ```
   - Or via EF CLI in terminal:
     ```bash
     dotnet ef database update
     ```
5. Press F5 (Debug) or Ctrl+F5 (Run).

---

## Entity Framework Migrations

- Add a migration:
  ```bash
  dotnet ef migrations add <MigrationName>
  ```

- Apply migrations to the database:
  ```bash
  dotnet ef database update
  ```

- Remove last migration (if not applied):
  ```bash
  dotnet ef migrations remove
  ```

---

## Environment Configuration

- Use `ASPNETCORE_ENVIRONMENT=Development` for local development.
- Keep production secrets out of source control; prefer environment variables or a secure secret store.

---

## Troubleshooting

- EF CLI not found:
  ```bash
  dotnet tool install --global dotnet-ef
  ```
- Connection issues:
  - Verify SQL Server is running and the connection string is correct.
  - For LocalDB: ensure `(localdb)\MSSQLLocalDB` instance exists.
- Port conflicts:
  - Stop other apps on the same port or override via `ASPNETCORE_URLS`.

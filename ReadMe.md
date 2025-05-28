### Asp.Net Core Minimal API

A minimal ASP.NET Core Web API built with SQLite and Entity Framework Core to manage games and genres.

---

#### 📁 Project Structure

```
GameStore.API/
├── Data/                  # DbContext and EF-related extensions
├── DTOs/                  # Data Transfer Objects for Game and Genre
├── Endpoints/             # Minimal API endpoint definitions
├── Entities/              # Entity models for EF Core
├── Mapping/               # Extension methods to map Entities to DTOs
├── games.http             # Sample HTTP requests for testing Game endpoints
├── genre.http             # Sample HTTP requests for testing Genre endpoints
├── GameStore.db           # SQLite database (auto-generated at runtime)
├── Program.cs             # Application entry point
└── GameStore.API.csproj   # Project file
```

---

#### How to Run

```bash
# Clone the repository
$ git clone <repo-url>
$ cd GameStore.API

# Restore packages and run the project
$ dotnet run
```

✅ The SQLite database (`GameStore.db`) will be created automatically on first run using `Database.Migrate()`.

---

#### 📌 Key Features

* Minimal API style (no controllers)
* SQLite + EF Core with code-first migrations
* DTO usage for secure, clean API responses
* Auto-applies migrations on startup (development only)

---

#### 🗂️ Endpoints Overview

##### Game Endpoints

```
GET     /games             # Get all games
GET     /games/{id}        # Get a single game by ID
POST    /games             # Create a new game
PUT     /games/{id}        # Update a game
DELETE  /games/{id}        # Delete a game
```

##### Genre Endpoints

```
GET     /genres            # Get all genres
```

---

####  Notable Concepts

#####  Why use DTOs?

DTOs are used instead of entities in API responses to expose only safe and necessary data.
This prevents leaking internal or sensitive fields and keeps the API contract clean and stable.

#####  Automatic Migration

The application applies EF Core migrations automatically at startup using `Database.Migrate()`,
which has the same effect as running `dotnet ef database update`. This is useful during development.
You can delete `GameStore.db`, and it will be regenerated on next `dotnet run`.

#####  Route Naming

Route naming via `WithName(...)` is used to reference routes programmatically (e.g., `CreatedAtRoute("GetGame")`).

---

#### EF Core Migration Commands

```bash
# Add a new migration
$ dotnet ef migrations add <MigrationName>

# Apply migrations to the database
$ dotnet ef database update
```

#### Docker


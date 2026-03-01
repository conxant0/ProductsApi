# Steam Library Tracker API

A REST API for tracking your personal Steam game library. Manage your games, prices, and hours spent — all persisted to a local database.

Built as a practice project to learn ASP.NET Core, Entity Framework Core, and SQLite.

---

## Technologies

| Technology | Purpose |
|---|---|
| ASP.NET Core 10.0 | Web API framework |
| Entity Framework Core 10.0 | ORM — handles all database communication |
| SQLite | Local file-based database (`games.db`) |
| OpenAPI / Swagger | Auto-generated API documentation (dev only) |
| C# / .NET 10 | Language and runtime |

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- `dotnet-ef` CLI tool:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

---

## Getting Started

**1. Clone the repository**
```bash
git clone <repo-url>
cd ProductsApi
```

**2. Restore dependencies**
```bash
dotnet restore
```

**3. Apply the database migration**

This creates `games.db` locally with the correct schema:
```bash
dotnet ef database update
```

**4. Run the API**
```bash
dotnet run
```

The API will be available at `http://localhost:5272`.

---

## API Endpoints

Base URL: `http://localhost:5272/api/games`

| Method | Endpoint | Description | Success |
|--------|----------|-------------|---------|
| GET | `/api/games` | Get all games | 200 |
| GET | `/api/games/{id}` | Get a game by ID | 200 / 404 |
| POST | `/api/games` | Add a new game | 201 |
| PUT | `/api/games/{id}` | Update a game | 200 / 404 |
| DELETE | `/api/games/{id}` | Remove a game | 204 / 404 |

### Request Body (POST / PUT)

```json
{
  "gameName": "Elden Ring",
  "price": 59.99,
  "hoursSpent": 142.5
}
```

For free games, set `price` to `0`:
```json
{
  "gameName": "Path of Exile",
  "price": 0,
  "hoursSpent": 800.0
}
```

### Example Response

```json
{
  "id": 1,
  "gameName": "Elden Ring",
  "price": 59.99,
  "hoursSpent": 142.5
}
```

---

## Project Structure

```
ProductsApi/
├── Controllers/
│   └── GamesController.cs    # CRUD endpoints for /api/games
├── Data/
│   └── AppDbContext.cs       # EF Core database context
├── Migrations/               # EF-generated database schema history
├── Models/
│   └── Game.cs               # Game entity (Id, GameName, Price, HoursSpent)
├── appsettings.json          # Configuration (connection string)
└── Program.cs                # App startup, DI, middleware pipeline
```

---

## OpenAPI Docs

When running in Development, the raw OpenAPI spec is available at:
```
http://localhost:5272/openapi/v1.json
```

Import this into Postman or any API client to explore and test all endpoints.

---

## Database

The API uses a local SQLite file (`games.db`) created automatically when you run `dotnet ef database update`. The file lives in the project root and is excluded from source control.

If you change the `Game` model, create a new migration:
```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

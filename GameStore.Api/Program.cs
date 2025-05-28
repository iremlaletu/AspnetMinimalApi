
using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GameStoreContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GameStore")));


var app = builder.Build();

// Maps all Game-related endpoints (CRUD operations) to the application pipeline
app.MapGamesEndpoints();
app.MapGenreEndpoints();

// Apply pending migrations automatically (for development purposes only).
await app.MigrateDbAsync();


app.Run();
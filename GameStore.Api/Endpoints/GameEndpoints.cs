using GameStore.Api.Data;
using GameStore.Api.DTOs;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndPointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        // GET /games

        group.MapGet("/", async (GameStoreContext dbContext) =>
            await dbContext.Games
                .Include(game => game.Genre)
                .Select(game => game.ToGameSummaryDTO())
                .AsNoTracking() // NO need to track these entities just send them to the client
                .ToListAsync()
        );

        // GET /games/1

        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            Game? game = await dbContext.Games.FindAsync(id);

            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDTO());
        })
        .WithName(GetGameEndPointName);

        // POST /games

        // Uses CreatedAtRoute to return a 201 Created response
        // Includes the Location header with the URI of the newly created resource
        // Helps clients easily access the new game by its ID using the named route "GetGame" which is defined above as a GetGameEndPointName
        group.MapPost("/", async (CreateGameDTO newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity(); // coming from mapping extension method

            // game.Genre = dbContext.Genres.Find(newGame.GenreId); no need to set ID here cause it is set in ToGameDetailsDTO, EFCore take care of it

            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            // Returns DTO to avoid exposing internal or sensitive entity data
            // GameDTO is a simplified version of the Game entity, suitable for API responses

            return Results.CreatedAtRoute(
                GetGameEndPointName,
                new { id = game.Id },
                game.ToGameDetailsDTO()
            );
        });

        // PUT

        group.MapPut("/{id}", async (int id, UpdateGameDTO updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(id);

            if (existingGame is null) return Results.NotFound();

            // locate the existing entry inside our dbcontext and replace it with brand new one that created here

            dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE

        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Games
                .Where(game => game.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}

// just one call to map all the endpoints
// used MinimalApis.Extensions for parameter validation. recoginizes data annotaion in create and update DTOs
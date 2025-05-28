
using GameStore.Api.DTOs;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDTO game)
    {
        return new Game()
        {
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

    }


    // UpdateGameDTO doesnt come with Id so we add it here
    public static Game ToEntity(this UpdateGameDTO game, int id)
    {
        return new Game()
        {
            Id = id,
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

    }

    public static GameSummaryDTO ToGameSummaryDTO(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.Genre!.Name, // Genre is not null because GenreId is valid above
            game.Price,
            game.ReleaseDate
        );
    }

    public static GameDetailsDTO ToGameDetailsDTO(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.GenreId, 
            game.Price,
            game.ReleaseDate
        );
    }
}

// is meant for extension methods so make it static
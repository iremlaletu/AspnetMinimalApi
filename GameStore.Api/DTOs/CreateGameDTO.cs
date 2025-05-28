using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

public record class CreateGameDTO(
    [Required][StringLength(50, MinimumLength = 1)] string Name,
    int GenreId,
    [Range(1,1000)] decimal Price,
    DateOnly ReleaseDate
);

// CreateGameDTO is used to receive data from the client when creating a new game
// It includes only the necessary input fields and excludes properties like Id
// This helps separate the API's input model from the internal data model (Game)

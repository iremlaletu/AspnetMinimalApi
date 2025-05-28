using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

public record class UpdateGameDTO(
    [Required][StringLength(50, MinimumLength = 1)] string Name,
    int GenreId,
    [Range(1,1000)] decimal Price,
    DateOnly ReleaseDate
);

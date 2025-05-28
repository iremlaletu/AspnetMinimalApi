namespace GameStore.Api.DTOs;

public record class GameSummaryDTO(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate);

// DTO (Data Transfer Object)
// By default, records are immutable, meaning that once they are created, their properties cannot be changed.
// Carry data one to another without the need for modification.
// Purpose: To transfer only the necessary data between layers (e.g., Controller ↔ Service)
// - Helps to decouple internal data models from API responses
// - Improves security by exposing only selected fields
// - Simplifies data shaping for clients
// - Useful for input validation and clean API contracts

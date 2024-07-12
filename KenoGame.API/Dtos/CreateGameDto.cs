using System.ComponentModel.DataAnnotations;

namespace KenoGame.API.Dtos;

public record class CreateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Required][Range(1, 100)] Decimal Price,
    DateOnly ReleaseDate
);

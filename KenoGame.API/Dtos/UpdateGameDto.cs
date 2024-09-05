using System.ComponentModel.DataAnnotations;

namespace KenoGame.API.Dtos;

public record class UpdateGameDto(
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Required][Range(1, 100)] Decimal Price,
    [Required][StringLength(50)] string UserId,
    DateOnly ReleaseDate
);
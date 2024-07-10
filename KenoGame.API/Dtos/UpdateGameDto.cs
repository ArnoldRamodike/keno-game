namespace KenoGame.API.Dtos;

public record class UpdateGameDto(
    string Name,
    string Genre,
    Decimal Price,
    DateOnly ReleaseDate
);
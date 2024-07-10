namespace KenoGame.API.Dtos;

public record class CreateGameDto(
    string Name,
    string Genre,
    Decimal Price,
    DateOnly ReleaseDate
);

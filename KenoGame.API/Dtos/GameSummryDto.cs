namespace KenoGame.API.Dtos;

public record class GameSummryDto(
    int Id,
    string Name,
    string Genre,
    Decimal Price,
    string FullName,
    DateOnly ReleaseDate
    );

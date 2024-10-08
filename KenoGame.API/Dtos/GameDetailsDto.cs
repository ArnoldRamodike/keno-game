﻿namespace KenoGame.API.Dtos;

public record class GameDetailsDto(
    int Id,
    string Name,
    int GenreId,
    Decimal Price,
    string UserId,
    DateOnly ReleaseDate
    );

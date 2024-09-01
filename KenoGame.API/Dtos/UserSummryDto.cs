namespace KenoGame.API.Dtos;

public record class UserSummryDto(
    int Id,
    string FullName,
    string Email,
    string Password,
    string Role,
    DateOnly CreatedAt
    );

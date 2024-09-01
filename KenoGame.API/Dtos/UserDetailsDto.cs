namespace KenoGame.API.Dtos;

public record class UserDetailsDto(
    int Id,
    string FullName,
    string Email,
    string Password,
    int PhoneNumbers,
    string Role,
    DateOnly CreatedAt
    );

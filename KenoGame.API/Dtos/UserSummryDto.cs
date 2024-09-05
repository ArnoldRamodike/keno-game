namespace KenoGame.API.Dtos;

public record class UserSummryDto(
    string Id,
    string FullName,
    string Email,
    string Password,
    decimal PhoneNumbers,
    string Roles,
    Boolean? IsVerified,
    DateOnly CreatedAt
    );

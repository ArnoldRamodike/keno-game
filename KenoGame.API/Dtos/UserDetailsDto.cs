namespace KenoGame.API.Dtos;

public record class UserDetailsDto(
    string Id,
    string FullName,
    string Email,
    string Password,
    decimal PhoneNumbers,
    int RoleId,
    Boolean? IsVerified,
    DateOnly CreatedAt
    );

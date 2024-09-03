﻿using System.ComponentModel.DataAnnotations;

namespace KenoGame.API.Dtos;

public record class CreateUserDto(
    [Required][StringLength(50)] string FullName,
    [Required][StringLength(50)] string Email,
    [Required][StringLength(50)] string Password,
    int PhoneNumbers,
    string? Role,
    DateOnly CreatedAt
);

public class LoginUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

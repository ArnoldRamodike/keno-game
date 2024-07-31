using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KenoGame.API.Dtos
{
    public record class RegisterUserDto(
        [Required][StringLength(50)] string Name,
        [Required][EmailAddress] string Email,
        [Required] string Password,
        [Required] int Numbers
        );
}
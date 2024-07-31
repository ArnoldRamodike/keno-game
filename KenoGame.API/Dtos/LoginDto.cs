using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KenoGame.API.Dtos
{
    public record class LoginDto
    (
        [Required][EmailAddress] string Email,
        [Required] string Password
    );
}
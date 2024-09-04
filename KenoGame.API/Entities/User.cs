using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KenoGame.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNumbers { get; set; }
        public string? Role { get; set; }
        public Boolean? IsVerified { get; set; }
        public DateOnly CreatedAt { get; set; }

    }
}
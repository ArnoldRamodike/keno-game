using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KenoGame.API.Entities
{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string FullName { get; set; }

        public required string Email { get; set; }
        public required string Password { get; set; }
        public decimal PhoneNumbers { get; set; }
        public int RoleId { get; set; }
        public Role? Roles { get; set; }
        public Boolean? IsVerified { get; set; }
        public DateOnly CreatedAt { get; set; }

    }
}
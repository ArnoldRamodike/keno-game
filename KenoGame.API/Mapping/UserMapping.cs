using KenoGame.API.Dtos;
using KenoGame.API.Entities;

namespace KenoGame.API.Mapping
{
    public static class UserMapping
    {
        public static User ToEntity(this CreateUserDto user)
        {
            return new User()
            {
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,
                PhoneNumbers = user.PhoneNumbers,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }


        public static UserSummryDto ToUserSummuryDto(this User user)
        {
            return new(
                   user.Id,
                   user.FullName,
                   user.Email,
                   user.Password,
                   user.PhoneNumbers,
                   user.Role,
                   user.CreatedAt
               );
        }
        public static UserDetailsDto ToUserDetailsDto(this User user)
        {
            return new(
                   user.Id,
                   user.FullName,
                   user.Email,
                   user.Password,
                   user.PhoneNumbers,
                   user.Role,
                   user.CreatedAt
               );
        }
        public static User ToUserUpdateDto(this UpdateUserDto user, int id)
        {
            return new User()
            {
                Id = id,
                FullName = user.FullName,
                Password = user.Password,
                Email = user.Email,
                PhoneNumbers = user.PhoneNumbers,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }

    }
}
using KenoGame.API.Dtos;
using KenoGame.API.Entities;

namespace KenoGame.API.Mapping
{
    public static class GenreMapping
    {
        public static GenreDto ToEntity(this Genre genre)
        {
            return new GenreDto(
                genre.Id, genre.Name
            );
        }
    }
}
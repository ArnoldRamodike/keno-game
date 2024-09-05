using KenoGame.API.Entities;

namespace KenoGame.API.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int GenreId { get; set; }

        public Genre? Genre { get; set; }

        public decimal Price { get; set; }
        public required string UserId { get; set; }

        public User? User { get; set; }

        public DateOnly ReleaseDate { get; set; }
    }
}
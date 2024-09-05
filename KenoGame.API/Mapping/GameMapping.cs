using KenoGame.API.Dtos;
using KenoGame.API.Entities;

namespace KenoGame.API.Mapping
{
    public static class GameMapping
    {
        public static Game ToEntity(this CreateGameDto game)
        {
            return new Game()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                UserId = game.UserId,
                ReleaseDate = game.ReleaseDate
            };
        }


        public static GameSummryDto ToGameSummuryDto(this Game game)
        {
            return new(
                   game.Id,
                   game.Name,
                   game.Genre!.Name,
                   game.Price,
                   game.User.FullName,
                   game.ReleaseDate
               );
        }
        public static GameDetailsDto ToGameDetailsDto(this Game game)
        {
            return new(
                   game.Id,
                   game.Name,
                   game.GenreId,
                   game.Price,
                   game.UserId,
                   game.ReleaseDate
               );
        }
        public static Game ToGameUpdateDto(this UpdateGameDto game, int id)
        {
            return new Game()
            {
                Id = id,
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                UserId = game.UserId,
                ReleaseDate = game.ReleaseDate
            };
        }

    }
}
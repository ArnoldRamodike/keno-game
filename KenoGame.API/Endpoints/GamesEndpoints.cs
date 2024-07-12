using KenoGame.API.Dtos;

namespace KenoGame.API;

public static class GamesEndpoints
{
    private static readonly List<GameDto> games = [
     new (
        1,
        "Street Fighting II",
        "Fighting",
        19.99M,
        new DateOnly(1992, 7, 15)
        ),
    new (
        2,
        "Need for Speed",
        "Racing",
        13.99M,
        new DateOnly(2005, 7, 15)
        ),
    new (
        3,
        "FIFA",
        "Football",
        30.99M,
        new DateOnly(2023, 8, 15)
        )
  ];
    const string GetGameEndpointName = "GetGame";
    public static RouteGroupBuilder MapGaesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games")
            .WithParameterValidation();

        // Get Games
        group.MapGet("/", () => games);

        // Get Game/id
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
            .WithName(GetGameEndpointName);

        // Get Games
        group.MapPost("/", (CreateGameDto newGame) =>
        {

            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });


        // Put Games
        group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                updateGame.Name,
                updateGame.Genre,
                updateGame.Price,
                updateGame.ReleaseDate
            );

            return Results.NoContent();
        });

        // Get Games
        group.MapDelete("/{id}", (int id) =>
        {

            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return group;
    }

}

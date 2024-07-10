using KenoGame.API.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
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

app.MapGet("api/", () => "Hello World!");

// Get Games
app.MapGet("games/", () => games);

// Get Game/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
    .WithName(GetGameEndpointName);

// Get Games
app.MapPost("games/", (CreateGameDto newGame) =>
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
app.MapPut("games/{id}", (int id, UpdateGameDto updateGame) =>
{
    var index = games.FindIndex(game => game.Id == id);

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
app.MapDelete("games/{id}", (int id) =>
{

    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
});

app.Run();

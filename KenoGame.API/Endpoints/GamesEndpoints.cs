using KenoGame.API.Data;
using KenoGame.API.Dtos;
using KenoGame.API.Entities;
using KenoGame.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace KenoGame.API;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games")
            .WithParameterValidation()
            .RequireAuthorization();

        // Get Games
        group.MapGet("/", async (GamesStoreContext dbContext) =>
         await dbContext.Games
                .Include(game => game.Genre)
                .Include(user => user.User)
                .Select(game => game.ToGameSummuryDto())
                .AsNoTracking()
                .ToListAsync()
        );

        // Get Game/id
        group.MapGet("/{id}", async (int id, GamesStoreContext dbContext) =>
        {
            Game? game = await dbContext.Games.FindAsync(id);

            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
        })
            .WithName(GetGameEndpointName);

        // Get Games
        group.MapPost("/", async (CreateGameDto newGame, GamesStoreContext dbContext) =>
        {

            Game game = newGame.ToEntity();

            await dbContext.Games.AddAsync(game);
            await dbContext.SaveChangesAsync();


            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.ToGameDetailsDto());
        });


        // Put Games
        group.MapPut("/{id}", async (int id, UpdateGameDto updateGame, GamesStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame)
                    .CurrentValues
                    .SetValues(updateGame.ToGameUpdateDto(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // Delete Game
        group.MapDelete("/{id}", async (GamesStoreContext dbContext, int id) =>
        {
            await dbContext.Games
                          .Where(game => game.Id == id)
                          .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }

}

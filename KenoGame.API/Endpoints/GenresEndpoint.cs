using KenoGame.API.Data;
using KenoGame.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace KenoGame.API.Endpoints
{
    public static class GenresEndpoint
    {
        public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("genres");

            group.MapGet("/", async (GamesStoreContext dbContext) =>
              await dbContext.Genre
                    .Select(genre => genre.ToEntity())
                    .AsNoTracking()
                        .ToListAsync()
            );

            return group;
        }
    }
}
using Microsoft.EntityFrameworkCore;

namespace KenoGame.API.Data
{
    public static class DataExtensions
    {
        public static async Task MigrateDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GamesStoreContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
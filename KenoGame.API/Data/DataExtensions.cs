using Microsoft.EntityFrameworkCore;

namespace KenoGame.API.Data
{
    public static class DataExtensions
    {
        public static void MigrateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GamesStoreContext>();
            dbContext.Database.Migrate();
        }
    }
}
using KenoGame.API.Entities;
using Microsoft.EntityFrameworkCore;


namespace KenoGame.API.Data
{
    public class GamesStoreContext(DbContextOptions<GamesStoreContext> options) : DbContext(options)
    {
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Genre> Genre => Set<Genre>();
    }
}
using KenoGame.API.Entities;
using Microsoft.EntityFrameworkCore;


namespace KenoGame.API.Data
{
    public class GamesStoreContext(DbContextOptions<GamesStoreContext> options) : DbContext(options)
    {
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Genre> Genre => Set<Genre>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new { Id = 1, Name = "Fighting" },
                new { Id = 2, Name = "RolePlaying" },
                new { Id = 3, Name = "Sports" },
                new { Id = 4, Name = "Racing" },
                new { Id = 5, Name = "Kids" }
            );

            modelBuilder.Entity<Role>().HasData(
                new { Id = 1, Roles = "USER" },
                new { Id = 2, Roles = "OWNER" },
                new { Id = 3, Roles = "ADMIN" }
            );

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}
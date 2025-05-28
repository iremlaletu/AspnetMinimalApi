
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>()
            .HasData(
                new { Id = 1, Name = "Action" },
                new { Id = 2, Name = "Adventure" },
                new { Id = 3, Name = "Role-Playing" },
                new { Id = 4, Name = "Simulation" },
                new { Id = 5, Name = "Sports" },
                new { Id = 6, Name = "Kids and Family" },
                new { Id = 7, Name = "Fighting" },
                new { Id = 8, Name = "Racing" }
            );

        modelBuilder.Entity<Game>()
            .HasData(
                new
                {
                    Id = 1,
                    Name = "The Witcher 3",
                    Price = 49.99m,
                    ReleaseDate = new DateOnly(2015, 5, 19),
                    GenreId = 3 // Role-Playing
                },
                new
                {
                    Id = 2,
                    Name = "Stardew Valley",
                    Price = 14.99m,
                    ReleaseDate = new DateOnly(2016, 2, 26),
                    GenreId = 4 // Simulation
                },
                new
                {
                    Id = 3,
                    Name = "Celeste",
                    Price = 19.99m,
                    ReleaseDate = new DateOnly(2018, 1, 25),
                    GenreId = 1 // Action
                }
        );

    }
}

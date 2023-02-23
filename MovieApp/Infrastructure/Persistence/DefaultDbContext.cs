using Domain.Entities;
using Infrastructure.Persistence.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DefaultDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public DbSet<Actor> Actors { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<MovieGenre> MovieGenres { get; set; }

    public DbSet<WishListItem> WishListItems { get; set; }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
    }

    public DefaultDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=MovieSite;Trusted_Connection=True;TrustServerCertificate=True");
        }

        #if DEBUG
        optionsBuilder.EnableSensitiveDataLogging();
        #endif

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WishListItemConfiguration());

        modelBuilder.ApplyConfiguration(new MovieConfiguration());

        modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());

        modelBuilder.ApplyConfiguration(new ActorConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}


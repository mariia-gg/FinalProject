using Domain.Entities;
using Infrastructure.Persistence.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AuthorizationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Actor> Actors { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<MovieGenre> MovieGenres { get; set; }

    public DbSet<WishListItem> WishListItems { get; set; }

    public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options) : base(options)
    {
    }

    public AuthorizationDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();

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


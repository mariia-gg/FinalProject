using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Admin> Admin { get; set; }

    DbSet<Actor> Actors { get; set; }

    DbSet<Movie> Movies { get; set; }

    DbSet<MovieGenre> MovieGenres { get; set; }

    DbSet<WishListItem> WishListItems { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
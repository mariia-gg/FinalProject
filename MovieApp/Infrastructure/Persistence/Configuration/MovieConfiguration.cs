using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder
            .ToTable("Movies", "dbo");

        builder
            .HasKey(movie => movie.Id);

        builder
            .Property(movie => movie.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");

        builder
            .Property(movie => movie.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(movie => movie.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder
            .Property(movie => movie.ImageURL)
            .IsRequired()
            .HasMaxLength(500);

        builder
            .Property(movie => movie.ImageURL)
            .IsRequired()
            .HasMaxLength(500);

        builder
            .Property(movie => movie.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETUTCDATE()");

        builder
            .HasMany(movie => movie.WishListItems)
            .WithOne(wishListItem => wishListItem.Movie)
            .HasPrincipalKey(movie => movie.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
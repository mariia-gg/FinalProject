using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
{
    public void Configure(EntityTypeBuilder<MovieGenre> builder)
    {
        builder
            .ToTable("MovieGenres", "dbo");

        builder
            .Property(moviegenre => moviegenre.MovieId)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");

        builder
            .Property(moviegenre => moviegenre.Action)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(moviegenre => moviegenre.Adventure)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(moviegenre => moviegenre.Anime)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(moviegenre => moviegenre.Comedy)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(moviegenre => moviegenre.Drama)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(moviegenre => moviegenre.Documentary)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(moviegenre => moviegenre.Cartoon)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(moviegenre => moviegenre.Horror)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(moviegenre => moviegenre.Fantasy)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(moviegenre => moviegenre.Thriller)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasMany(moviegenre => moviegenre.Movies)
            .WithMany(movie => movie.Genres);
    }
}
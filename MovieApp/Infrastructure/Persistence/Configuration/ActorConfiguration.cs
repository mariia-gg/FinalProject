using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder
            .ToTable("Actors", "dbo");

        builder
            .HasKey(actor => actor.Id);

        builder
            .Property(actor => actor.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");

        builder
            .Property(actor => actor.FullName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(actor => actor.ProfilePictureUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder
            .Property(actor => actor.Bio)
            .IsRequired()
            .HasMaxLength(500);
    }
}
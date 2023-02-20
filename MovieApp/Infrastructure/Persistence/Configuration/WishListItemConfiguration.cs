using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class WishListItemConfiguration : IEntityTypeConfiguration<WishListItem>
{
    public void Configure(EntityTypeBuilder<WishListItem> builder)
    {
        builder
            .ToTable("WishListItems", "dbo");

        builder
            .Property(wishList => wishList.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");
    }
}
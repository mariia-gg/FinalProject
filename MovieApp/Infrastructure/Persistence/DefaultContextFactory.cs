using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DefaultContextFactory
{
    public DefaultDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DefaultDbContext>();

        optionsBuilder.UseSqlServer("Data Source=blog.db");

        return new DefaultDbContext(optionsBuilder.Options);
    }
}
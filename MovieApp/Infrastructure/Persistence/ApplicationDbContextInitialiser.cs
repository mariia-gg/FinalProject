namespace Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    public static void Initialize(DefaultDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
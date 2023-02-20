namespace Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    public static void Initialize(AuthorizationDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
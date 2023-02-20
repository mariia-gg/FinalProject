using Domain.Entities;
using Infrastructure.Contract;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Actor>, DefaultRepository<Actor>>();
        services.AddScoped<IRepository<Admin>, DefaultRepository<Admin>>();
        services.AddScoped<IRepository<Movie>, DefaultRepository<Movie>>();
        services.AddScoped<IRepository<MovieGenre>, DefaultRepository<MovieGenre>>();
        services.AddScoped<IRepository<WishListItem>, DefaultRepository<WishListItem>>();
    }
}
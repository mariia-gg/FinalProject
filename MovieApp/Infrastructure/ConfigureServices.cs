using Application.Common.Interfaces;
using Infrastructure.IdentityService;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        //services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        // services.UseSqlServer("ThisIsJustForMigrations");

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<AuthorizationDbContext>(options =>
                options.UseInMemoryDatabase("MovieAppDb"));
        }
        else
        {
            services.AddDbContext<AuthorizationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(AuthorizationDbContext).Assembly.FullName)));
        }

        //services.AddDbContext<ApplicationDbContext>(options =>
        //options.UseSqlServer(GetConnectionString("DefaultConnection")));

        // services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AuthorizationDbContext>();

        // services.AddIdentityServer()
        //  .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        //services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService.IdentityService>();
        // services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        services.AddDbContext<AuthorizationDbContext>();

        return services;
    }
}
using Application.Common.Interfaces;
using Infrastructure.IdentityService;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(
        IServiceCollection services,
        IConfiguration configuration,
        IApplicationBuilder app,
        IWebHostEnvironment env,
        IApiVersionDescriptionProvider provider
    )
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<DefaultDbContext>(options =>
                options.UseInMemoryDatabase("MovieAppDb"));
        }
        else
        {
            services.AddDbContext<DefaultDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(DefaultDbContext).Assembly.FullName)));
        }

        //Swagger 
        services.AddSwaggerGen();

        //Authentication and authorization
        services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<DefaultDbContext>();
        services.AddMemoryCache();
        services.AddSession();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        });

        //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //    .AddJwtBearer(options =>
        //    {
        //        options.Authority = configuration["Authentication:Authority"];
        //        options.Audience = configuration["Authentication:Audience"];
        //    });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy =>
                policy.RequireRole("admin"));
        });

        services.AddScoped<ApplicationDbContextInitialiser>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DefaultDbContext>();

        services.AddTransient<IIdentityService, IdentityService.IdentityService>();

        //services.AddAuthentication()
        //    .AddIdentityServerJwt();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        services.AddDbContext<DefaultDbContext>();

        return services;
    }
}
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<DefaultDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        //builder.Services.AddAuthentication(options =>
        //    {
        //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //    })

        // Adding Jwt Bearer
        //.AddJwtBearer(options =>
        //{
        //    options.SaveToken = true;
        //    options.RequireHttpsMetadata = false;

        //    options.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidAudience = configuration["JWT:ValidAudience"],
        //        ValidIssuer = configuration["JWT:ValidIssuer"],
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
        //    };
        //});

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            "default",
            "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
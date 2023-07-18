using Microsoft.EntityFrameworkCore;
using VehicleCatalogAPI.Data;
using VehicleCatalogAPI.Repositories;
using VehicleCatalogAPI.Repositories.Interfaces;
using VehicleCatalogAPI.Services;

namespace VehicleCatalogAPI.Extensions;

public static class AppExtensions
{
    public static void ConfigureMvc(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<VehicleCatalogDbContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );

        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }

    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<VehicleCatalogDbContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<UserService>();
    }
}
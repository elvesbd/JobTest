using Microsoft.EntityFrameworkCore;
using VehicleCatalogAPI.Data;
using VehicleCatalogAPI.Repositories;
using VehicleCatalogAPI.Repositories.Interfaces;

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
}
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VehicleCatalogAPI.Data;
using VehicleCatalogAPI.Repositories;
using VehicleCatalogAPI.Repositories.Interfaces;
using VehicleCatalogAPI.Services;

namespace VehicleCatalogAPI.Extensions;

public static class AppExtensions
{
    public static void ConfigureAuthentication(this WebApplicationBuilder builder)
    {
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }

    public static void ConfigureMvc(this WebApplicationBuilder builder)
    {
        builder.Services
        .AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

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
        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<UserService>();
        builder.Services.AddTransient<TokenService>();
    }
}
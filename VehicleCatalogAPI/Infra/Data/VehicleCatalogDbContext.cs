using Microsoft.EntityFrameworkCore;
using VehicleCatalogAPI.Data.Mappings;
using VehicleCatalogAPI.Domain.Models;

namespace VehicleCatalogAPI.Data;

public class VehicleCatalogDbContext : DbContext
{
    public VehicleCatalogDbContext(DbContextOptions<VehicleCatalogDbContext> options)
        : base(options)
    {
        Vehicles = Set<Vehicle>();
        Users = Set<User>();
    }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new VehicleMap());
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}
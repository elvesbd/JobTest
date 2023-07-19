using VehicleCatalogAPI.Data;
using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.Repositories.Interfaces;

namespace VehicleCatalogAPI.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly VehicleCatalogDbContext _dbContext;
    public VehicleRepository(VehicleCatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Vehicle> AddAsync(Vehicle vehicle)
    {
        await _dbContext.AddAsync(vehicle);
        await _dbContext.SaveChangesAsync();
        return vehicle;
    }
}

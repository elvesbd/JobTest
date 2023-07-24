using Microsoft.EntityFrameworkCore;
using VehicleCatalogAPI.Data;
using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.Models.Repositories;

namespace VehicleCatalogAPI.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly VehicleCatalogDbContext _dbContext;
    public VehicleRepository(VehicleCatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<Vehicle>> GetAsync()
    {
        return await _dbContext.Vehicles
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Vehicle>> GetByUserIdAsync(Guid userId)
    {
        return await _dbContext.Vehicles
            .AsNoTracking()
            .Where(vehicle => vehicle.UserId == userId)
            .ToListAsync();
    }

    public async Task<Vehicle?> GetOneAsync(Guid id)
    {
        return await _dbContext.Vehicles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Vehicle> AddAsync(Vehicle vehicle)
    {
        await _dbContext.AddAsync(vehicle);
        await _dbContext.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
    {
        _dbContext.Vehicles.Update(vehicle);
        await _dbContext.SaveChangesAsync();
        return vehicle;
    }

    public async Task DeleteAsync(Vehicle vehicle)
    {
        _dbContext.Vehicles.Remove(vehicle);
        await _dbContext.SaveChangesAsync();
    }
}

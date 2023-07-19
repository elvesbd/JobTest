using VehicleCatalogAPI.Domain.Models;

namespace VehicleCatalogAPI.Repositories.Interfaces;

public interface IVehicleRepository
{
    Task<List<Vehicle>> GetAsync();
    Task<List<Vehicle>> GetByUserIdAsync(Guid userId);
    Task<Vehicle?> GetOneAsync(Guid id);
    Task<Vehicle> AddAsync(Vehicle vehicle);
}
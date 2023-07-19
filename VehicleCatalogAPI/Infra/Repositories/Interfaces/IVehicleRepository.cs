using VehicleCatalogAPI.Domain.Models;

namespace VehicleCatalogAPI.Repositories.Interfaces;

public interface IVehicleRepository
{
    Task<List<Vehicle>> GetAsync();
    Task<Vehicle> AddAsync(Vehicle vehicle);
}
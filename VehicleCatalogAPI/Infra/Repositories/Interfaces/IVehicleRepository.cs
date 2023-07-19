using VehicleCatalogAPI.Domain.Models;

namespace VehicleCatalogAPI.Repositories.Interfaces;

public interface IVehicleRepository
{
    Task<Vehicle> AddAsync(Vehicle vehicle);
}
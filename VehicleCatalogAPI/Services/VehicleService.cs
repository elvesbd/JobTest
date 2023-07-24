using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Models.Repositories;

namespace VehicleCatalogAPI.Services;

public class VehicleService
{
    private IVehicleRepository _repository;
    public VehicleService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Vehicle>> GetAsync()
    {
        return await _repository.GetAsync();
    }

    public async Task<List<Vehicle>> GetByUserIdAsync(Guid userId)
    {
        return await _repository.GetByUserIdAsync(userId);
    }

    public async Task<Vehicle?> GetOneAsync(Guid id)
    {
        return await _repository.GetOneAsync(id);
    }

    public async Task<Vehicle> AddAsync(VehicleDto dto, Guid userId)
    {
        var vehicle = new Vehicle
        (
            dto.Name,
            dto.Brand,
            dto.Model,
            dto.Image,
            userId
        );
        return await _repository.AddAsync(vehicle);
    }

    public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
    {
        return await _repository.UpdateAsync(vehicle);
    }

    public async Task DeleteAsync(Vehicle vehicle)
    {
        await _repository.DeleteAsync(vehicle);
    }
}
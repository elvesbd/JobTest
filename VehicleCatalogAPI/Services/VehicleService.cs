using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Exceptions;
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

    public async Task<Vehicle?> UpdateAsync(VehicleDto dto, Guid id)
    {
        var vehicle = await _repository.GetOneAsync(id);
        if (vehicle == null)
            throw new VehicleNotFoundException();

        vehicle.SetProperties(
            dto.Name,
            dto.Brand,
            dto.Model,
            dto.Image
        );
        return await _repository.UpdateAsync(vehicle);
    }

    public async Task DeleteAsync(Guid id)
    {
        var vehicle = await _repository.GetOneAsync(id);
        if (vehicle == null)
            throw new VehicleNotFoundException();

        await _repository.DeleteAsync(vehicle);
    }
}
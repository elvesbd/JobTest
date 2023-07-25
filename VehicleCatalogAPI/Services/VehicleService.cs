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
        var vehicle = await _repository.GetOneAsync(id);
        if (vehicle == null)
            throw new VehicleNotFoundException();

        return vehicle;
    }

    public async Task<Vehicle> AddAsync(VehicleDto dto, Guid userId)
    {
        var vehicle = Vehicle.CreateVehicle
        (
            dto.Name,
            dto.Brand,
            dto.Model,
            dto.Image,
            dto.Price,
            userId
        );
        return await _repository.AddAsync(vehicle);
    }

    public async Task<Vehicle?> UpdateAsync(VehicleDto dto, Guid id)
    {
        var vehicle = await _repository.GetOneAsync(id);
        if (vehicle == null)
            throw new VehicleNotFoundException();

        var updatedVehicle = Vehicle.CreateVehicle
        (
            dto.Name,
            dto.Brand,
            dto.Model,
            dto.Image,
            dto.Price,
            vehicle.UserId
        );

        await _repository.UpdateAsync(vehicle);
        return vehicle;
    }

    public async Task DeleteAsync(Guid id)
    {
        var vehicle = await _repository.GetOneAsync(id);
        if (vehicle == null)
            throw new VehicleNotFoundException();

        await _repository.DeleteAsync(vehicle);
    }
}
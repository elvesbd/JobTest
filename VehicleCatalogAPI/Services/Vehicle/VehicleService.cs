using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Repositories.Interfaces;

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

    public async Task<Vehicle> AddAsync(AddVehicleDto dto, Guid userId)
    {
        var vehicle = new Vehicle
        {
            Name = dto.Name,
            Brand = dto.Brand,
            Model = dto.Model,
            Image = dto.Image,
            UserId = userId
        };
        return await _repository.AddAsync(vehicle);
    }
}
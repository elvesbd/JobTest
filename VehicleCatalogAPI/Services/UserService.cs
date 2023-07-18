using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.Repositories.Interfaces;

namespace VehicleCatalogAPI.Services;

public class UserService
{
    private IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> GetByIdAsync(int userId)
    {
        return await _repository.GetByIdAsync(userId);
    }

    public async Task<User> AddAsync(User user)
    {
        return await _repository.AddAsync(user);
    }
}
using VehicleCatalogAPI.Domain.Models;

namespace VehicleCatalogAPI.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int userId);
    Task<User> AddByAsync(User user);
}
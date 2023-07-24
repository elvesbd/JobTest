using VehicleCatalogAPI.Domain.Models;

namespace VehicleCatalogAPI.Models.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User> AddAsync(User user);
}
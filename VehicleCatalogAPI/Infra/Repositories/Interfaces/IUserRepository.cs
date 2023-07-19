using VehicleCatalogAPI.Domain.Models;

namespace VehicleCatalogAPI.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User> AddAsync(User user);
}
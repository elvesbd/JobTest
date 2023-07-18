using SecureIdentity.Password;
using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.DTOs.User;
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

    public async Task<User> AddAsync(AddUserDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            CellPhone = dto.CellPhone,
        };
        var passwordHash = PasswordHasher.Hash(dto.Password);
        user.PasswordHash = passwordHash;
        return await _repository.AddAsync(user);
    }
}
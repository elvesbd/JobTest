using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Infra.Adapters.Interfaces;
using VehicleCatalogAPI.Repositories.Interfaces;

namespace VehicleCatalogAPI.Services;

public class UserService
{
    private IPasswordHasher _passwordHasher;
    private IUserRepository _repository;
    public UserService(IPasswordHasher passwordHasher, IUserRepository repository)
    {
        _passwordHasher = passwordHasher;
        _repository = repository;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _repository.GetByEmailAsync(email);
    }

    public async Task<User> AddAsync(AddUserDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            CellPhone = dto.CellPhone,
        };
        var passwordHash = _passwordHasher.Hash(dto.Password);
        user.PasswordHash = passwordHash;
        return await _repository.AddAsync(user);
    }
}
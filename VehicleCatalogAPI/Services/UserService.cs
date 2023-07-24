using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Infra.Adapters.Interfaces;
using VehicleCatalogAPI.Models.Repositories;

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
        var passwordHash = _passwordHasher.Hash(dto.Password);
        var user = new User
        (
            dto.Name,
            dto.Email,
            dto.CellPhone,
            passwordHash
        );
        return await _repository.AddAsync(user);
    }
}
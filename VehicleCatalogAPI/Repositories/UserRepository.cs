using Microsoft.EntityFrameworkCore;
using VehicleCatalogAPI.Data;
using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.Repositories.Interfaces;

namespace VehicleCatalogAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly VehicleCatalogDbContext _dbContext;
    public UserRepository(VehicleCatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<User> GetByIdAsync(int userId)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<User> AddAsync(User user)
    {
        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }
}

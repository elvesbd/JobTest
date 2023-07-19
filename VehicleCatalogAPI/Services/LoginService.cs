using VehicleCatalogAPI.DTOs;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Infra.Adapters.Interfaces;

namespace VehicleCatalogAPI.Services;

public class LoginService
{
    private IPasswordHasher _passwordHasher;
    private readonly TokenService _tokenService;
    private readonly UserService _userService;
    public LoginService(
        IPasswordHasher passwordHasher,
        TokenService tokenService,
        UserService userService
    )
    {
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
        _userService = userService;
    }

    public async Task<ResultDto<string>> LoginAsync(LoginDto dto)
    {
        var user = await _userService.GetByEmailAsync(dto.Email);
        if (user is null)
            return new ResultDto<string>("Invalid credentials!");

        var isPasswordValid = _passwordHasher.Verify(user.PasswordHash, dto.Password);
        if (!isPasswordValid)
            return new ResultDto<string>("Invalid credentials!");

        var token = _tokenService.GenerateToken(user);
        return new ResultDto<string>(token, null);
    }
}
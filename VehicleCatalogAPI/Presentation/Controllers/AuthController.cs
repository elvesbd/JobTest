using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;
using VehicleCatalogAPI.DTOs;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Extensions;
using VehicleCatalogAPI.Services;

namespace VehicleCatalogAPI.Presentation.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly TokenService _tokenService;
    public AuthController(TokenService tokenService, UserService userService)
    {
        _tokenService = tokenService;
        _userService = userService;
    }


    [HttpPost("v1/login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultDto<string>(ModelState.GetErrors()));

        var user = await _userService.GetByEmailAsync(dto.Email);
        if (user is null)
            return StatusCode(401, new ResultDto<string>("Invalid credentials!"));

        var isPasswordValid = PasswordHasher.Verify(user.PasswordHash, dto.Password);
        if (!isPasswordValid)
            return StatusCode(401, new ResultDto<string>("Invalid credentials!"));

        try
        {
            var token = _tokenService.GenerateToken(user);
            return Ok(new ResultDto<string>(token, null));
        }
        catch
        {
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }
    }
}
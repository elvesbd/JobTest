using Microsoft.AspNetCore.Mvc;
using VehicleCatalogAPI.DTOs;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Extensions;
using VehicleCatalogAPI.Services;

namespace VehicleCatalogAPI.Presentation.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly LoginService _loginService;
    private readonly UserService _userService;
    public AuthController(LoginService loginService, UserService userService)
    {
        _loginService = loginService;
        _userService = userService;
    }


    [HttpPost("v1/login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultDto<string>(ModelState.GetErrors()));

        try
        {
            var token = await _loginService.LoginAsync(dto);
            return Ok(token);
        }
        catch
        {
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }
    }
}
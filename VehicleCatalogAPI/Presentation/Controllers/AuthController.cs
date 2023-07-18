using Microsoft.AspNetCore.Mvc;
using VehicleCatalogAPI.Services;

namespace VehicleCatalogAPI.Presentation.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;
    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }


    [HttpPost("v1/login")]
    public IActionResult Login()
    {
        var token = _tokenService.GenerateToken(null);
        return Ok(token);
    }
}
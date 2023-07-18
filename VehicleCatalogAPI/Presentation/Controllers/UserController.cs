using Microsoft.AspNetCore.Mvc;
using VehicleCatalogAPI.Services;

namespace VehicleCatalogAPI.Presentation.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("v1/users/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }
}

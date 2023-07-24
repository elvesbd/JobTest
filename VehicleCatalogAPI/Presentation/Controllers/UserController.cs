using Microsoft.AspNetCore.Mvc;
using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Services;
using VehicleCatalogAPI.DTOs;
using VehicleCatalogAPI.Extensions;

namespace VehicleCatalogAPI.Presentation.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("v1/users")]
    public async Task<IActionResult> AddAsync([FromBody] AddUserDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultDto<string>(ModelState.GetErrors()));

            var user = await _userService.AddAsync(dto);
            return Created($"v1/users/{user.Id}", new ResultDto<User>(user));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }
    }
}

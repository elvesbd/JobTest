using Microsoft.AspNetCore.Mvc;
using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.DTOs.User;
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
        if (user == null)
            return NotFound("User not found!");
        return Ok(user);
    }

    [HttpPost("v1/users")]
    public async Task<IActionResult> AddAsync([FromBody] AddUserDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest("");

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            CellPhone = dto.CellPhone
        };

        await _userService.AddAsync(user);
        return Ok(user);
    }
}

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

    [HttpGet("v1/users/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound(new ResultDto<User>("User not found!"));

            return Ok(new ResultDto<User>(user));
        }
        catch (System.Exception)
        {
            return StatusCode(500, new ResultDto<User>("Internal server error!"));
        }
    }

    [HttpPost("v1/users")]
    public async Task<IActionResult> AddAsync([FromBody] AddUserDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultDto<string>(ModelState.GetErrors()));

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            CellPhone = dto.CellPhone
        };

        await _userService.AddAsync(user);
        return Created($"v1/categories/{user.Id}", new ResultDto<User>(user));
    }
}

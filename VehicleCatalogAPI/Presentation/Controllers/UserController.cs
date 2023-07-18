using Microsoft.AspNetCore.Mvc;
using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Services;
using VehicleCatalogAPI.DTOs;
using VehicleCatalogAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace VehicleCatalogAPI.Presentation.Controllers;

//[Authorize]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    /* [HttpGet("v1/users/{id:int}")]
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
    } */

    //[AllowAnonymous]
    [HttpPost("v1/users")]
    public async Task<IActionResult> AddAsync([FromBody] AddUserDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultDto<string>(ModelState.GetErrors()));

            var user = await _userService.AddAsync(dto);
            return Created($"v1/categories/{user.Id}", new ResultDto<User>(user));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultDto<string>("This email already in use!"));
        }
    }
}

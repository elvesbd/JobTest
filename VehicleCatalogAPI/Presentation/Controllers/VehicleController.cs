using Microsoft.AspNetCore.Mvc;
using VehicleCatalogAPI.DTOs;
using VehicleCatalogAPI.Extensions;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Services;
using VehicleCatalogAPI.Domain.Models;
using Microsoft.AspNetCore.Authorization;


namespace VehicleCatalogAPI.Presentation.Controllers;

[Authorize]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly JwtTokenHandler _jwtTokenHandler;
    private readonly VehicleService _vehicleService;
    public VehicleController(JwtTokenHandler jwtTokenHandler, VehicleService vehicleService)
    {
        _vehicleService = vehicleService;
        _jwtTokenHandler = jwtTokenHandler;
    }

    [AllowAnonymous]
    [HttpGet("v1/vehicles")]
    public async Task<IActionResult> GetAsync()
    {
        try
        {
            var vehicles = await _vehicleService.GetAsync();
            return Ok(new ResultDto<List<Vehicle>>(vehicles));
        }
        catch (Exception err)
        {
            Console.WriteLine(err);
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }
    }

    [HttpGet("v1/vehicles/{id:guid}")]
    public async Task<IActionResult> GetOneAsync([FromRoute] Guid id)
    {
        try
        {
            var vehicle = await _vehicleService.GetOneAsync(id);
            return Ok(new ResultDto<Vehicle?>(vehicle, null));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }
    }

    [HttpGet("v1/vehicles/user")]
    public async Task<IActionResult> GetByUserIdAsync([FromHeader(Name = "Authorization")] string token)
    {
        try
        {
            var userId = await _jwtTokenHandler.ExtractUserIdFromToken(token);
            var vehicles = await _vehicleService.GetByUserIdAsync(userId);
            return Ok(new ResultDto<List<Vehicle>>(vehicles, null));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }
    }

    [HttpPost("v1/vehicles")]
    public async Task<IActionResult> AddAsync([FromHeader(Name = "Authorization")] string token, [FromBody] VehicleDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultDto<string>(ModelState.GetErrors()));

            var userId = await _jwtTokenHandler.ExtractUserIdFromToken(token);
            var vehicle = await _vehicleService.AddAsync(dto, userId);
            return Created($"v1/vehicles/{vehicle.Id}", new ResultDto<Vehicle>(vehicle));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }
    }

    [HttpPut("v1/vehicles/{id:guid}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] VehicleDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultDto<string>(ModelState.GetErrors()));

        var vehicle = await _vehicleService.GetOneAsync(id);
        if (vehicle == null)
            return NotFound(new ResultDto<Vehicle>("Vehicle not found!"));

        vehicle.SetProperties(
            dto.Name,
            dto.Brand,
            dto.Model,
            dto.Image
        );

        try
        {
            var newVehicle = await _vehicleService.UpdateAsync(vehicle);
            return Ok(new ResultDto<Vehicle?>(newVehicle, null));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }
    }

    [HttpDelete("v1/vehicles/{id:guid}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var vehicle = await _vehicleService.GetOneAsync(id);
        if (vehicle == null)
            return NotFound(new ResultDto<Vehicle>("Vehicle not found!"));

        try
        {
            await _vehicleService.DeleteAsync(vehicle);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }


    }
}
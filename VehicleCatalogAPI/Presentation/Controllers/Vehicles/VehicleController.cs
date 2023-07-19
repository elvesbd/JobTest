using Microsoft.AspNetCore.Mvc;
using VehicleCatalogAPI.DTOs;
using VehicleCatalogAPI.Extensions;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Services;
using VehicleCatalogAPI.Domain.Models;
using Microsoft.AspNetCore.Authorization;


namespace VehicleCatalogAPI.Presentation.Controllers.Vehicles;

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

    [HttpGet("v1/vehicles/user")]
    public async Task<IActionResult> GetByUserIdAsync([FromHeader(Name = "Authorization")] string token)
    {
        try
        {
            var userId = await _jwtTokenHandler.ExtractUserIdFromToken(token);
            var vehicles = await _vehicleService.GetByUserIdAsync(userId);
            return Ok(new ResultDto<List<Vehicle>>(vehicles, null));
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
        catch (Exception err)
        {
            Console.WriteLine(err);
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }
    }

    [HttpPost("v1/vehicles")]
    public async Task<IActionResult> AddAsync([FromBody] AddVehicleDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultDto<string>(ModelState.GetErrors()));

            var vehicle = await _vehicleService.AddAsync(dto, new Guid("98adaa47-74b9-4119-91b2-08db88760e0a"));
            return Created($"v1/vehicles/{vehicle.Id}", new ResultDto<Vehicle>(vehicle));
        }
        catch (Exception err)
        {
            Console.WriteLine(err);
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }
    }
}

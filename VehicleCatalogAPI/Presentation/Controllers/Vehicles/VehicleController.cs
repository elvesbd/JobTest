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

    [HttpGet("v1/vehicles")]
    public async Task<IActionResult> GetAsync([FromHeader(Name = "Authorization")] string token)
    {
        try
        {
            var userId = await _jwtTokenHandler.ExtractUserIdFromToken(token);
            Console.WriteLine(userId);
            var vehicles = await _vehicleService.GetAsync(userId);
            return Ok(new ResultDto<Vehicle>(vehicles));
        }
        catch (Exception err)
        {
            Console.WriteLine(err);
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }
    }

    //[AllowAnonymous]
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

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
    private readonly VehicleService _vehicleService;
    public VehicleController(VehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    //[AllowAnonymous]
    [HttpPost("v1/vehicles")]
    public async Task<IActionResult> AddAsync([FromBody] AddVehicleDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultDto<string>(ModelState.GetErrors()));

            var vehicle = await _vehicleService.AddAsync(dto, new Guid("a4652923-4d6c-4c7a-644d-08db8861f97c"));
            return Created($"v1/vehicles/{vehicle.Id}", new ResultDto<Vehicle>(vehicle));
        }
        catch (Exception err)
        {
            Console.WriteLine(err);
            return StatusCode(500, new ResultDto<string>("Internal server error!"));
        }
    }
}

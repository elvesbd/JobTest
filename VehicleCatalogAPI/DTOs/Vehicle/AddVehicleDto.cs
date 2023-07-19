using System.ComponentModel.DataAnnotations;

namespace VehicleCatalogAPI.DTOs.User;

public class AddVehicleDto
{
    [Required(ErrorMessage = "Name is required!")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Brand is required!")]
    public string Brand { get; set; } = string.Empty;

    [Required(ErrorMessage = "Model is required!")]
    public string Model { get; set; } = string.Empty;

    [Required(ErrorMessage = "Image is required!")]
    public string Image { get; set; } = string.Empty;
}
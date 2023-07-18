using System.ComponentModel.DataAnnotations;

namespace VehicleCatalogAPI.DTOs.User;

public class AddUserDto
{
    [Required(ErrorMessage = "Name is required!")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required!")]
    [EmailAddress(ErrorMessage = "Email is invalid!")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "CellPhone is required!")]
    public string CellPhone { get; set; } = string.Empty;
}
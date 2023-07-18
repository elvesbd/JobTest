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

    [Required(ErrorMessage = "Password is required!")]
    [StringLength(25, MinimumLength = 8, ErrorMessage = "Password must contain between 8 and 25 characters")]
    public string Password { get; set; } = string.Empty;
}
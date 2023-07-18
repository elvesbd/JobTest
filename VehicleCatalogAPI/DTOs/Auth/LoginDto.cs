using System.ComponentModel.DataAnnotations;

namespace VehicleCatalogAPI.DTOs.User;

public class LoginDto
{
    [Required(ErrorMessage = "Inform the email!")]
    [EmailAddress(ErrorMessage = "Email is invalid!")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Inform the Password!")]
    [StringLength(25, MinimumLength = 8, ErrorMessage = "Password must contain between 8 and 25 characters")]
    public string Password { get; set; } = string.Empty;
}
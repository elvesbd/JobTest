namespace VehicleCatalogAPI.Domain.Models;

public class Users
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? CellPhone { get; set; }
}
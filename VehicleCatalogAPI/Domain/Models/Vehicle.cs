namespace VehicleCatalogAPI.Domain.Models;

public class Vehicle
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Photo { get; set; }
}
namespace VehicleCatalogAPI.Domain.Models;

public class Vehicle
{
    public Vehicle(string name, string brand, string model, string image, Guid userId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Brand = brand;
        Model = model;
        Image = image;
        UserId = userId;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Image { get; set; }
    public Guid UserId { get; set; }

    public User? User { get; set; }
}
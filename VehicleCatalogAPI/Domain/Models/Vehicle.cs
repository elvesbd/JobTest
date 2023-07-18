namespace VehicleCatalogAPI.Domain.Models;

public class Vehicle
{
    public Vehicle(string name, string brand, string model, string image)
    {
        Name = name;
        Brand = brand;
        Model = model;
        Image = image;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Image { get; set; }
}
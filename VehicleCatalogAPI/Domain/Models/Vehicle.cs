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

    public int Id { get; set; } = 0;
    public string Name { get; private set; }
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Image { get; private set; }
}
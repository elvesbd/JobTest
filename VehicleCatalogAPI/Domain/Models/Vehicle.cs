using Store.Domain.Models;

namespace VehicleCatalogAPI.Domain.Models;

public class Vehicle : Entity
{
    public Vehicle(string name, string brand, string model, string image, Guid userId)
    {
        Name = name;
        Brand = brand;
        Model = model;
        Image = image;
        UserId = userId;
    }

    public string Name { get; private set; }
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Image { get; private set; }
    public Guid UserId { get; private set; }
    public User? User { get; set; }

    public void SetProperties(string name, string brand, string model, string image)
    {
        Name = name;
        Brand = brand;
        Model = model;
        Image = image;
    }
}
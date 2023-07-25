using Store.Domain.Models;

namespace VehicleCatalogAPI.Domain.Models;

public class Vehicle : Entity
{
    public Vehicle(string name, string brand, string model, string image, long priceInCents, Guid userId)
    {
        Name = name;
        Brand = brand;
        Model = model;
        Image = image;
        PriceInCents = priceInCents;
        UserId = userId;
    }

    public string Name { get; private set; }
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Image { get; private set; }
    public long PriceInCents { get; private set; }
    public Guid UserId { get; private set; }
    public User? User { get; set; }

    public static Vehicle CreateVehicle
        (
            string name,
            string brand,
            string model,
            string image,
            string price,
            Guid userId
        )
    {
        long priceInCents = ConvertToCents(price);
        return new Vehicle(name, brand, model, image, priceInCents, userId);
    }

    public static long ConvertToCents(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Value cannot be null or empty.", nameof(value));

        string numericValue = new string(value.Where(c => char.IsDigit(c) || c == '.').ToArray());

        if (!decimal.TryParse(numericValue, out decimal decimalValue))
            throw new ArgumentException("Invalid numeric value.", nameof(value));

        long centsValue = (long)(decimalValue * 100);

        return centsValue;
    }
}
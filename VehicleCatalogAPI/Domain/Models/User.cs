using System.Text.Json.Serialization;
using Store.Domain.Models;

namespace VehicleCatalogAPI.Domain.Models;

public class User : Entity
{
    public User(string name, string email, string cellPhone, string passwordHash)
    {
        Name = name;
        Email = email;
        CellPhone = cellPhone;
        PasswordHash = passwordHash;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string CellPhone { get; private set; }
    public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();

    [JsonIgnore]
    public string? PasswordHash { get; set; }
}
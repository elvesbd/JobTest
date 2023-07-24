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

    public string Name { get; set; }
    public string Email { get; set; }
    public string CellPhone { get; set; }
    public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    [JsonIgnore]
    public string? PasswordHash { get; set; }
}
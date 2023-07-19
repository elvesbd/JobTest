using System.Text.Json.Serialization;

namespace VehicleCatalogAPI.Domain.Models;

public class User
{
    public User()
    { }

    public User(string name, string email, string cellPhone, string passwordHash)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        CellPhone = cellPhone;
        PasswordHash = passwordHash;
    }

    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? CellPhone { get; set; }

    [JsonIgnore]
    public string? PasswordHash { get; set; }
}
namespace VehicleCatalogAPI.Domain.Models;

public class User
{
    public User()
    { }

    public User(string name, string email, string cellPhone, string passwordHash)
    {
        Name = name;
        Email = email;
        CellPhone = cellPhone;
        PasswordHash = passwordHash;
    }

    public int Id { get; set; } = 0;
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? CellPhone { get; set; }
    public string? PasswordHash { get; set; }
}
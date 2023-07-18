namespace VehicleCatalogAPI.Domain.Models;

public class User
{
    public User(string name, string email, string cellPhone)
    {
        Name = name;
        Email = email;
        CellPhone = cellPhone;
    }

    public int Id { get; private set; } = 0;
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string CellPhone { get; private set; }
}
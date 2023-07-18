namespace VehicleCatalogAPI.Domain.Models;

public class User
{
    public User(string name, string email, string cellPhone)
    {
        Name = name;
        Email = email;
        CellPhone = cellPhone;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string CellPhone { get; set; }
}
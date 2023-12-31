namespace VehicleCatalogAPI.Infra.Adapters.Interfaces;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string passwordHash, string password);
}
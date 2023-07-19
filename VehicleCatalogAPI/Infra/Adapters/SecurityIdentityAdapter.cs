using SecureIdentity.Password;
using VehicleCatalogAPI.Infra.Adapters.Interfaces;

namespace VehicleCatalogAPI.Infra.Adapters;

public class SecureIdentityAdapter : IPasswordHasher
{
    public string Hash(string password)
    {
        return PasswordHasher.Hash(password);
    }

    public bool Verify(string passwordHash, string password)
    {
        return PasswordHasher.Verify(passwordHash, password);
    }
}
using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.Infra.Adapters.Interfaces;

namespace VehicleCatalogAPI.Services;

public class TokenService
{
    private ITokenGenerator _token;
    public TokenService(ITokenGenerator token)
    {
        _token = token;
    }

    public string GenerateToken(User user)
    {
        return _token.Generate(user);
    }
}
using System.Security.Claims;
using VehicleCatalogAPI.Domain.Models;

namespace VehicleCatalogAPI.Extensions;

public static class ClaimsExtension
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        var Id = user.Id.ToString();
        var result = new List<Claim>
        {
            new("UserId", Id)
        };
        return result;
    }
}
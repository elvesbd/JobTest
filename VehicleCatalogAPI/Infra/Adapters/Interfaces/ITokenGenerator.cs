using VehicleCatalogAPI.Domain.Models;

namespace VehicleCatalogAPI.Infra.Adapters.Interfaces;

public interface ITokenGenerator
{
    string Generate(User user);
}
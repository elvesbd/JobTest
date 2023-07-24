namespace VehicleCatalogAPI.Exceptions;

public class VehicleNotFoundException : Exception
{
    public VehicleNotFoundException() : base("Veículo não encontrado")
    { }
}
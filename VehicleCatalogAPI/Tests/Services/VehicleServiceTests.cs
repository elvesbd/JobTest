using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Models.Repositories;
using VehicleCatalogAPI.Services;

[TestClass]
public class VehicleServiceTests
{
    private Mock<IVehicleRepository>? _repositoryMock;
    private VehicleService? _vehicleService;
    private readonly Guid _userId = new Guid("8b0b1d6f-e875-4879-90ec-484e6f14bc78");
    private readonly VehicleDto _dto = new VehicleDto
    {
        Name = "Hilux",
        Brand = "Toyota",
        Model = "SW4 3.0-D",
        Image = "https://image",
    };
    private readonly Vehicle _vehicle = new Vehicle
    (
        "Hilux",
        "Toyota",
        "SW4 3.0-D",
        "https://image",
        new Guid("8b0b1d6f-e875-4879-90ec-484e6f14bc78")
    );
    private readonly List<Vehicle> _vehicles = new List<Vehicle>
        {
            new Vehicle(
                "Hilux",
                "Toyota",
                "SW4 3.0-D",
                "https://image1",
                new Guid("8b0b1d6f-e875-4879-90ec-484e6f14bc78")
            ),
            new Vehicle
            (
                "Corolla",
                "Toyota",
                "XEi 2.0",
                "https://image2",
                new Guid("8b0b1d6f-e875-4879-90ec-484e6f14bc78")
            ),
        };

    [TestInitialize]
    public void TestInitialize()
    {
        _repositoryMock = new Mock<IVehicleRepository>();
        _vehicleService = new VehicleService(_repositoryMock.Object);
    }

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_to_returns_a_list_of_all_vehicles()
    {
        _repositoryMock?.Setup(x => x.GetAsync()).ReturnsAsync(_vehicles);

        var result = await _vehicleService.GetAsync();

        Assert.IsNotNull(result);
        Assert.AreEqual(_vehicles, result);
    }

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_to_returns_a_empty_list_if_not_exists_vehicles()
    {
        _repositoryMock?.Setup(x => x.GetAsync()).ReturnsAsync(new List<Vehicle>());

        var result = await _vehicleService.GetAsync();

        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }
}
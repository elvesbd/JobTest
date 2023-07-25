using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Exceptions;
using VehicleCatalogAPI.Models.Repositories;
using VehicleCatalogAPI.Services;

[TestClass]
public class VehicleServiceTests
{
    private Mock<IVehicleRepository>? _repositoryMock;
    private VehicleService? _vehicleService;
    private readonly Guid _userId = new Guid("8b0b1d6f-e875-4879-90ec-484e6f14bc78");
    private readonly Guid _Id = new Guid("ac0b1d6f-e875-4879-90ec-484e6f14bc99");
    private readonly VehicleDto _dto = new VehicleDto
    {
        Name = "Hilux",
        Brand = "Toyota",
        Model = "SW4 3.0-D",
        Image = "https://image",
        Price = "200.50"
    };
    private readonly Vehicle _vehicle = Vehicle.CreateVehicle
    (
        "Hilux",
        "Toyota",
        "SW4 3.0-D",
        "https://image",
        "200.50",
        new Guid("8b0b1d6f-e875-4879-90ec-484e6f14bc78")
    );
    private readonly List<Vehicle> _vehicles = new List<Vehicle>
        {
            Vehicle.CreateVehicle(
                "Hilux",
                "Toyota",
                "SW4 3.0-D",
                "https://image1",
                "50.000",
                new Guid("8b0b1d6f-e875-4879-90ec-484e6f14bc78")
            ),
            Vehicle.CreateVehicle
            (
                "Corolla",
                "Toyota",
                "XEi 2.0",
                "https://image2",
                "80.000",
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

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_to_returns_a_list_of_all_vehicles_by_user_id()
    {
        _repositoryMock?.Setup(x => x.GetByUserIdAsync(_userId)).ReturnsAsync(_vehicles);

        var result = await _vehicleService.GetByUserIdAsync(_userId);

        Assert.IsNotNull(result);
        Assert.AreEqual(_userId, result?.FirstOrDefault()?.UserId);
        Assert.AreEqual(_vehicles, result);
    }

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_to_returns_a_empty_list_if_not_exists_vehicles_of_the_informed_user()
    {
        _repositoryMock?.Setup(x => x.GetByUserIdAsync(_userId)).ReturnsAsync(new List<Vehicle>());

        var result = await _vehicleService.GetByUserIdAsync(_userId);

        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_to_return_an_exception_if_vehicle_not_found()
    {
        _repositoryMock?.Setup(x => x.GetOneAsync(_Id)).ReturnsAsync((Vehicle?)null);

        var result = await Assert.ThrowsExceptionAsync<VehicleNotFoundException>
        (
            async () => await _vehicleService.GetOneAsync(_Id)
        );
    }

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_to_return_a_vehicle_by_id()
    {
        _repositoryMock?.Setup(x => x.GetOneAsync(_vehicle.Id)).ReturnsAsync(_vehicle);

        var result = await _vehicleService.GetOneAsync(_vehicle.Id);

        Assert.IsNotNull(result);
        Assert.AreEqual(result, _vehicle);
    }

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_to_return_a_created_vehicle()
    {
        _repositoryMock?.Setup(x => x.AddAsync(It.IsAny<Vehicle>())).ReturnsAsync(_vehicle);

        var result = await _vehicleService.AddAsync(_dto, _userId);

        Assert.IsNotNull(result);
        Assert.AreEqual(result, _vehicle);
    }

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_to_return_an_exception_if_vehicle_not_found_when_to_update()
    {
        _repositoryMock?.Setup(x => x.GetOneAsync(_Id)).ReturnsAsync((Vehicle?)null);

        var result = await Assert.ThrowsExceptionAsync<VehicleNotFoundException>
        (
            async () => await _vehicleService.UpdateAsync(_dto, _Id)
        );
    }

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_to_returns_an_updated_vehicle()
    {
        _repositoryMock?.Setup(x => x.GetOneAsync(_vehicle.Id)).ReturnsAsync(_vehicle);
        _repositoryMock?.Setup(x => x.UpdateAsync(_vehicle)).ReturnsAsync(_vehicle);

        var result = await _vehicleService.UpdateAsync(_dto, _vehicle.Id);

        Assert.IsNotNull(result);
        Assert.AreEqual(result, _vehicle);
    }

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_to_return_an_exception_if_vehicle_not_found_when_to_delete()
    {
        _repositoryMock?.Setup(x => x.GetOneAsync(_Id)).ReturnsAsync((Vehicle?)null);

        var result = await Assert.ThrowsExceptionAsync<VehicleNotFoundException>
        (
            async () => await _vehicleService.DeleteAsync(_Id)
        );
    }

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_to_delete_vehicle()
    {
        _repositoryMock?.Setup(x => x.GetOneAsync(_vehicle.Id)).ReturnsAsync(_vehicle);

        await _vehicleService.DeleteAsync(_vehicle.Id);

        _repositoryMock?.Verify(x => x.DeleteAsync(_vehicle), Times.Once);
    }
}
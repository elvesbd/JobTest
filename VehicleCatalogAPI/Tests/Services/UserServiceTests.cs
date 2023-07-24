using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.DTOs.User;
using VehicleCatalogAPI.Infra.Adapters.Interfaces;
using VehicleCatalogAPI.Models.Repositories;
using VehicleCatalogAPI.Services;

[TestClass]
public class UserServiceTests
{
    private Mock<IPasswordHasher>? passwordHasherMock;
    private Mock<IUserRepository>? repositoryMock;
    private UserService? userService;
    private readonly AddUserDto _dto = new AddUserDto
    {
        Name = "John Doe",
        Email = "john.doe@example.com",
        CellPhone = "1234567890",
        Password = "password"
    };

    [TestInitialize]
    public void TestInitialize()
    {
        passwordHasherMock = new Mock<IPasswordHasher>();
        repositoryMock = new Mock<IUserRepository>();
        userService = new UserService(passwordHasherMock.Object, repositoryMock.Object);
    }

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_to_return_a_user_by_email()
    {
        var mockUser = new User
        (
            "Elvis Presley",
            "elvesp@mail.com",
            "85999491212",
            "any_hash"
        );

        repositoryMock?.Setup(x => x.GetByEmailAsync(_dto.Email)).ReturnsAsync(
           mockUser
        );

        var result = await userService.GetByEmailAsync(_dto.Email);
        Assert.IsNotNull(result);
    }
}
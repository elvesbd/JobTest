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
    private Mock<IPasswordHasher>? _passwordHasherMock;
    private Mock<IUserRepository>? _repositoryMock;
    private UserService? _userService;
    private readonly AddUserDto _dto = new AddUserDto
    {
        Name = "John Doe",
        Email = "john.doe@example.com",
        CellPhone = "85999491515",
        Password = "12345678"
    };

    [TestInitialize]
    public void TestInitialize()
    {
        _passwordHasherMock = new Mock<IPasswordHasher>();
        _repositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_passwordHasherMock.Object, _repositoryMock.Object);
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

        _repositoryMock?.Setup(x => x.GetByEmailAsync(_dto.Email)).ReturnsAsync(
           mockUser
        );

        var result = await _userService.GetByEmailAsync(_dto.Email);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_that_a_user_is_successfully_added()
    {
        var mockHashed = "any_hash";
        _passwordHasherMock?.Setup(x => x.Hash(_dto.Password)).Returns(
          mockHashed
       );
        var mockUser = new User
        (
            "John Doe",
            "john.doe@example.com",
            "85999491515",
            mockHashed
        );

        _repositoryMock?.Setup(x => x.AddAsync(It.IsAny<User>())).ReturnsAsync(mockUser);

        var result = await _userService.AddAsync(_dto);
        Assert.IsNotNull(result);
    }
}
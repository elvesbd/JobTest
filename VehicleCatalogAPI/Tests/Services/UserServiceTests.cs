using System.Diagnostics;
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
        CellPhone = "85999491515",
        Password = "12345678"
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

    [TestMethod]
    [TestCategory("Services")]
    public async Task Ensures_that_a_user_is_successfully_added()
    {
        var mockHashed = "any_hash";
        Debug.Assert(mockHashed == "any_hash");
        passwordHasherMock?.Setup(x => x.Hash(_dto.Password)).Returns(
          mockHashed
       );
        var mockUser = new User
        (
            "Elvis Presley",
            "elvesp@mail.com",
            "85999491212",
            mockHashed
        );

        repositoryMock?.Setup(x => x.AddAsync(It.IsAny<User>())).ReturnsAsync(mockUser);

        var result = await userService.AddAsync(_dto);
        Assert.IsNotNull(result);
    }
}
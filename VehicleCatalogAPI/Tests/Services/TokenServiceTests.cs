using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VehicleCatalogAPI.Domain.Models;
using VehicleCatalogAPI.Infra.Adapters.Interfaces;
using VehicleCatalogAPI.Services;

[TestClass]
public class TokenServiceTests
{
    private Mock<ITokenGenerator>? tokenMock;
    private TokenService? tokenService;
    private readonly User _user = new User
    (
        "John Doe",
        "john.doe@example.com",
        "85999491515",
        "passwordHash"
    );

    [TestInitialize]
    public void TestInitialize()
    {
        tokenMock = new Mock<ITokenGenerator>();
        tokenService = new TokenService(tokenMock.Object);
    }

    [TestMethod]
    [TestCategory("Services")]
    public void Ensures_to_return_a_token()
    {
        var mocToken = "any_token";

        tokenMock?.Setup(x => x.Generate(_user)).Returns(
           mocToken
        );

        var result = tokenService?.GenerateToken(_user);
        Assert.IsNotNull(result);
        Assert.AreEqual(result, mocToken);
    }
}
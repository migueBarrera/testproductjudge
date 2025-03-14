using Microsoft.Extensions.Logging;
using Moq;
using ProductJudge.Mobile.DAL.Services;

namespace TestApi;

[TestClass]
public class RegisterServiceTest
{
    private Mock<ILogger<RegisterService>> mockLogger;
    private RegisterService registerService;

    [TestInitialize]
    public void Setup()
    {
        mockLogger = new Mock<ILogger<RegisterService>>();

        registerService = new RegisterService(mockLogger.Object, HttpClientHelper.CreateHttpClientFactory().Object);
    }

    [TestMethod]
    public async Task Register_ValidCredentials_ReturnsSuccess()
    {
        var result = await registerService.Register(UserCredentials.ValidEmail, UserCredentials.ValidEmail, UserCredentials.ValidPassword);

        Assert.IsTrue(result.IsSuccess);
        Assert.IsNotNull(result.Value);
    }

    [TestMethod]
    public async Task Register_EmptyCredentials_ReturnsError()
    {
        var result = await registerService.Register(string.Empty, string.Empty, string.Empty);

        Assert.IsFalse(result.IsSuccess);
    }
}

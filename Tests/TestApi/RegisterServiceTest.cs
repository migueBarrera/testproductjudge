using Microsoft.Extensions.Logging;
using Moq;
using ProductJudge.Mobile.DAL;
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
        var result = await registerService.Register(TestDALConstants.TEST_USER, TestDALConstants.TEST_EMAIL, TestDALConstants.TEST_PASSWORD);

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

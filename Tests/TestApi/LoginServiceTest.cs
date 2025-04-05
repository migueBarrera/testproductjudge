using Microsoft.Extensions.Logging;
using Moq;
using ProductJudge.Mobile.DAL;
using ProductJudge.Mobile.DAL.Services;

namespace TestApi;

[TestClass]
public class LoginServiceTest
{
    private Mock<ILogger<LoginService>> mockLogger;
    private LoginService loginService;

    [TestInitialize]
    public void Setup()
    {
        mockLogger = new Mock<ILogger<LoginService>>();
        
        loginService = new LoginService(mockLogger.Object, HttpClientHelper.CreateHttpClientFactory().Object);
    }

    [TestMethod]
    public async Task Login_ValidCredentials_ReturnsSuccess()
    {
        var result = await loginService.Login(TestDALConstants.TEST_EMAIL, TestDALConstants.TEST_PASSWORD);

        Assert.IsTrue(result.IsSuccess);
        Assert.IsNotNull(result.Value);
    }

    [TestMethod]
    public async Task Login_EmptyCredentials_ReturnsError()
    {
        var result = await loginService.Login(string.Empty, string.Empty);

        Assert.IsFalse(result.IsSuccess);
    }
}

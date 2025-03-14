using Microsoft.Extensions.Logging;
using Moq;
using ProductJudge.Mobile.DAL.Services;
using TestApi;

namespace TestApi;

[TestClass]
public class JudgeProductServiceTest
{
    private Mock<ILogger<JudgeProductService>> mockLogger;
    private JudgeProductService JudgeProductService;

        private LoginService loginService;

    [TestInitialize]
    public void Setup()
    {
        mockLogger = new Mock<ILogger<JudgeProductService>>();
        

        
        loginService = new LoginService(new Mock<ILogger<LoginService>>().Object, HttpClientHelper.CreateHttpClientFactory().Object);
    }

    [TestMethod]
    public async Task AddOpinion_ValidData_ReturnsSuccess()
    {
        
        var resultLogin = await loginService.Login(UserCredentials.ValidEmail, UserCredentials.ValidPassword);
        if (resultLogin.IsError)
        {
            Assert.Fail("Login failed");
        }

        var httpClientFactory = HttpClientHelper.CreateHttpClientFactory(resultLogin.Value!.Token);
        var JudgeProductService = new JudgeProductService(mockLogger.Object, httpClientFactory.Object);


        var reward = "Me encanta!!";
        var productId = "67c6272bae0270964cdb5293";
        var userId = "67c625bcae0270964cdb5291";

        var result = await JudgeProductService.AddJudge(reward, productId, userId);

        Assert.IsTrue(result.IsSuccess);
    }

}

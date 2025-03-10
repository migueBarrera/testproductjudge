using Microsoft.Extensions.Logging;
using Moq;
using ProductJudge.Mobile.DAL.Services;
using TestApi;

namespace Company.TestProject1;

[TestClass]
public class JudgeProductServiceTest
{
    private Mock<ILogger<JudgeProductService>> mockLogger;
    private JudgeProductService JudgeProductService;

    [TestInitialize]
    public void Setup()
    {
        mockLogger = new Mock<ILogger<JudgeProductService>>();
        var httpClientFactory = HttpClientHelper.CreateHttpClientFactory();

        JudgeProductService = new JudgeProductService(mockLogger.Object, httpClientFactory.Object);
    }

    [TestMethod]
    public async Task AddOpinion_ValidData_ReturnsSuccess()
    {
        var reward = "Gold Star";
        var productId = "12345";

        var result = await JudgeProductService.AddOpinion(reward, productId);

        Assert.IsTrue(result.IsSuccess);
    }

}

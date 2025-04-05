using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductJudge.Mobile.DAL.Services;

namespace TestApi;

[TestClass]
public class ProductDetailServiceTest
{
private Mock<ILogger<ProductDetailService>> mockLogger;
        private ProductDetailService productDetailService;

        [TestInitialize]
        public void Setup()
        {
            mockLogger = new Mock<ILogger<ProductDetailService>>();
            var httpClientFactory = HttpClientHelper.CreateHttpClientFactory();
            productDetailService = new ProductDetailService(mockLogger.Object, httpClientFactory.Object);
        }

                [TestMethod]
        public async Task GetProduct_ValidApiResponse_ReturnsProductList()
        {
            var result = await productDetailService.GetProduct("67d9ed2b394c8a439a8aa443");

            Assert.IsNotNull(result.Value);
            Assert.IsTrue(result.IsSuccess);
        }
}

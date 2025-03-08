using Microsoft.Extensions.Logging;
using Moq;
using ProductJudge.Mobile.DAL.Services;

namespace TestApi;

[TestClass]
    public class ListProductsServiceTest
    {
        private Mock<ILogger<ListProductsService>> mockLogger;
        private ListProductsService listProductsService;

        [TestInitialize]
        public void Setup()
        {
            mockLogger = new Mock<ILogger<ListProductsService>>();
            var httpClientFactory = HttpClientHelper.CreateHttpClientFactory();
            listProductsService = new ListProductsService(mockLogger.Object, httpClientFactory.Object);
        }

        [TestMethod]
        public async Task GetProducts_ValidApiResponse_ReturnsProductList()
        {
            var result = await listProductsService.GetProducts();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }
    }

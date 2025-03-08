using Microsoft.Extensions.Logging;
using Moq;
using ProductJudge.Mobile.DAL.Services;
using Refit;

namespace TestApi;

[TestClass]
public class CreateProductServiceTest
{
    private Mock<ILogger<CreateProductService>> mockLogger;
    private CreateProductService createProductService;

    [TestInitialize]
    public void Setup()
    {
        mockLogger = new Mock<ILogger<CreateProductService>>();

        var httpClientFactory = HttpClientHelper.CreateHttpClientFactory();
        createProductService = new CreateProductService(mockLogger.Object, httpClientFactory.Object);
    }

    [TestMethod]
    public async Task CreateProductWithOutImages_ValidData_ReturnsSuccess()
    {
        var productName = "Test Product";
        var productDescription = "Test Description";
        var images = new List<StreamPart>(); 
 
        var result = await createProductService.CreateProductWithImages(productName, productDescription, images);

        Assert.IsTrue(result.IsSuccess);
    }

            [TestMethod]
        public async Task CreateProductWithImage_ValidData_ReturnsSuccess()
        {
            var productName = "Test Product with Image";
            var productDescription = "Test Description with Image";

            // Path to the image in the root of the project
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "testImage.jpeg");

            // Ensure the file exists
            Assert.IsTrue(File.Exists(imagePath), "Test image not found.");

            var imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            var images = new List<StreamPart>
            {
                new(imageStream, "testImage.jpg", "image/jpeg") // Assuming a jpeg image
            };

            var result = await createProductService.CreateProductWithImages(productName, productDescription, images);

            // Close the stream after use
            imageStream.Close();

            Assert.IsTrue(result.IsSuccess);
        }
}
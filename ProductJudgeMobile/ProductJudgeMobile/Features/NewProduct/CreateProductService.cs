using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using ProductJudge.Api.Models.Products;
using ProductJudge.Mobile.DAL.API;
using ProductJudge.Mobile.DAL.Refit;
using Refit;
using SecretAligner.Telemedicine.Mobile.Infrastructure;

namespace ProductJudgeMobile.Features.NewProduct;

public class CreateProductService
{
    private readonly IProductsApi productApi;
    private readonly ILogger<CreateProductService> logger;

    public CreateProductService(ILogger<CreateProductService> logger, IHttpClientFactory httpClientFactory)
    {
        this.logger = logger;

        var httpClient = httpClientFactory.CreateClient(HttpClients.FAKE_API);
        productApi = Refit.RestService.For<IProductsApi>(httpClient);
    }

    internal async Task<ApiResultResponse> CreateProduct(string name, string description)
    {
        try
        {
            var request = new CreateProductRequestDto()
            {
                Name = name,
                Description = description
            };
            var response = await productApi.CreateProduct(request);

            return ApiResultResponse.CreateSuccess();
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return ApiResultResponse.CreateError(e.Message);
        }
    }

    internal async Task<ApiResultResponse> UploadImages(IEnumerable<ImageSource> images)
    {
        try
        {
            var list = await ImageHelper.ConvertImagesToStreamParts(images);
            var response = await productApi.UploadProductImages(list);

            return ApiResultResponse.CreateSuccess();
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return ApiResultResponse.CreateError(e.Message);
        }
    }

    public static class ImageHelper
    {
        public static async Task<IEnumerable<StreamPart>> ConvertImagesToStreamParts(IEnumerable<ImageSource> images)
        {
            var streamParts = new List<StreamPart>();

            foreach (var image in images)
            {
                // Convert ImageSource to Stream (this method needs to be implemented)
                var stream = await ConvertImageSourceToStream(image);
                streamParts.Add(new StreamPart(stream, "image.jpg", "image/jpeg")); // Adjust the name and type as needed
            }

            return streamParts;
        }

        private static async Task<Stream> ConvertImageSourceToStream(ImageSource imageSource)
        {
            // Your logic to convert an ImageSource to a Stream
            // This typically involves rendering the ImageSource to a bitmap and then to a stream
            // For demonstration, this part is left abstract
            throw new NotImplementedException();
        }
    }
}

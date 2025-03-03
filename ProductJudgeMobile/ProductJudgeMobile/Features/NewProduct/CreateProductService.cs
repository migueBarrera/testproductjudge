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

        internal async Task<ApiResultResponse> CreateProductWithImages(string name, string description,IEnumerable<ImageSource> images)
    {
        try
        {
            var request = new CreateProductRequestDto()
            {
                Name = name,
                Description = description
            };

            var list = await ImageHelper.ConvertImagesToStreamParts(images);
            var response = await productApi.CreateProductWithImages(request.Name, request.Description, list);

            return ApiResultResponse.CreateSuccess();
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return ApiResultResponse.CreateError(e.Message);
        }
    }

    // internal async Task<ApiResultResponse> CreateProduct(string name, string description)
    // {
    //     try
    //     {
    //         var request = new CreateProductRequestDto()
    //         {
    //             Name = name,
    //             Description = description
    //         };
    //         var response = await productApi.CreateProduct(request);

    //         return ApiResultResponse.CreateSuccess();
    //     }
    //     catch (Exception e)
    //     {
    //         logger.LogError(e, e.Message);
    //         return ApiResultResponse.CreateError(e.Message);
    //     }
    // }

    // internal async Task<ApiResultResponse> UploadImages(IEnumerable<ImageSource> images)
    // {
    //     try
    //     {
    //         var list = await ImageHelper.ConvertImagesToStreamParts(images);
    //         var response = await productApi.UploadProductImages(list);

    //         return ApiResultResponse.CreateSuccess();
    //     }
    //     catch (Exception e)
    //     {
    //         logger.LogError(e, e.Message);
    //         return ApiResultResponse.CreateError(e.Message);
    //     }
    // }
}

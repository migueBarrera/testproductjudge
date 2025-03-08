using Microsoft.Extensions.Logging;
using ProductJudge.Api.Models.Products;
using ProductJudge.Mobile.DAL;
using ProductJudge.Mobile.DAL.API;
using ProductJudge.Mobile.DAL.Helpers;

namespace ProductJudge.Mobile.DAL.Services;

public class ProductDetailService
{
    private readonly IProductsApi productApi;
    private readonly ILogger<ProductDetailService> logger;

    public ProductDetailService(ILogger<ProductDetailService> logger, IHttpClientFactory httpClientFactory)
    {
        this.logger = logger;

        var httpClient = httpClientFactory.CreateClient(HttpClients.FAKE_API);
        productApi = Refit.RestService.For<IProductsApi>(httpClient);
    }

    internal async Task<ApiResultResponse<GetProductByResponseDto>> GetProduct(string id)
    {
        try
        {
            var response = await productApi.GetProductDetail(id);

            if (response == null)
            {
                return ApiResultResponse<GetProductByResponseDto>.CreateError("Error");
            }

            return ApiResultResponse<GetProductByResponseDto>.CreateSuccess(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return ApiResultResponse<GetProductByResponseDto>.CreateError("Invalid username or password");
        }
    }
}

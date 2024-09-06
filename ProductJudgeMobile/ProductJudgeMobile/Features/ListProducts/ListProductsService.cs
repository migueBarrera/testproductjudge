using Microsoft.Extensions.Logging;
using ProductJudge.Api.Models.Products;
using ProductJudge.Mobile.DAL.API;

namespace ProductJudgeMobile.Features.ListProducts;

public class ListProductsService
{
    private readonly IProductsApi productApi;
    private readonly ILogger<ListProductsService> logger;

    public ListProductsService(IProductsApi productApi, ILogger<ListProductsService> logger)
    {
        this.productApi = productApi;
        this.logger = logger;
    }

    internal async Task<GetAllProductResponseDto> GetProducts()
    {
        try
        {
            var response = await productApi.GetAll(new GetAllProductsRequestDto());

            return response;
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return new GetAllProductResponseDto();
        }
    }
}

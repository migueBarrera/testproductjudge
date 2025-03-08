using Microsoft.Extensions.Logging;
using ProductJudge.Api.Models.Products;
using ProductJudge.Mobile.DAL;
using ProductJudge.Mobile.DAL.API;
using System.Net.Http.Headers;

namespace ProductJudge.Mobile.DAL.Services;

public class ListProductsService
{
    private readonly IProductsApi productApi;
    private readonly ILogger<ListProductsService> logger;

    public ListProductsService(ILogger<ListProductsService> logger, IHttpClientFactory httpClientFactory)
    {
        this.logger = logger;

        var httpClient = httpClientFactory.CreateClient(HttpClients.FAKE_API);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        productApi = Refit.RestService.For<IProductsApi>(httpClient);
    }

    public async Task<IEnumerable<GetAllProductResponseDto>> GetProducts()
    {
        try
        {
            var response = await productApi.GetAll(new GetAllProductsRequestDto());

            return response;
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return Enumerable.Empty<GetAllProductResponseDto>();
        }
    }
}

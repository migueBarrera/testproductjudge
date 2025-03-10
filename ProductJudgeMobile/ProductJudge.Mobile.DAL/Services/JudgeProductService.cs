using Microsoft.Extensions.Logging;
using ProductJudge.Api.Models.Products;
using ProductJudge.Mobile.DAL.API;
using ProductJudge.Mobile.DAL.Helpers;

namespace ProductJudge.Mobile.DAL.Services;

public class JudgeProductService
{
    private readonly IProductsApi productApi;
    private readonly ILogger<JudgeProductService> logger;

    public JudgeProductService(ILogger<JudgeProductService> logger, IHttpClientFactory httpClientFactory)
    {
        this.logger = logger;

        var httpClient = httpClientFactory.CreateClient(HttpClients.FAKE_API);
        productApi = Refit.RestService.For<IProductsApi>(httpClient);
    }

    public async Task<ApiResultResponse> AddOpinion(string judge, string productId)
    {
        try
        {
            var request = new CreateJudgeRequestDto
            {
                ProductId = productId,
                Judge = judge
            };

            var response = await productApi.AddJudge(request);

            return ApiResultResponse.CreateSuccess();
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return ApiResultResponse.CreateError(e.Message);
        }
    }
}

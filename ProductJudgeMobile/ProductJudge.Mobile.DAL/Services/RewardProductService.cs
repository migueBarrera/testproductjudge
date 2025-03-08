using Microsoft.Extensions.Logging;
using ProductJudge.Api.Models.Products;
using ProductJudge.Mobile.DAL.API;
using ProductJudge.Mobile.DAL.Helpers;

namespace ProductJudge.Mobile.DAL.Services;

public class RewardProductService
{
    private readonly IProductsApi productApi;
    private readonly ILogger<RewardProductService> logger;

    public RewardProductService(ILogger<RewardProductService> logger, IHttpClientFactory httpClientFactory)
    {
        this.logger = logger;

        var httpClient = httpClientFactory.CreateClient(HttpClients.FAKE_API);
        productApi = Refit.RestService.For<IProductsApi>(httpClient);
    }

    public async Task<ApiResultResponse> AddOpinion(string reward, string productId)
    {
        try
        {
            var request = new AddRewardRequestDto
            {
                ProductId = productId,
                Reward = reward
            };

            var response = await productApi.AddReward(request);

            return ApiResultResponse.CreateSuccess();
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return ApiResultResponse.CreateError(e.Message);
        }
    }
}

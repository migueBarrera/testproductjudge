using Refit;

namespace ProductJudge.Mobile.DAL;

public class APIService
{
    private readonly IHttpClientFactory httpClientFactory;

    public APIService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public virtual T For<T>(string uri)
    {
        var httpClient = httpClientFactory.CreateClient(uri);
        return RestService.For<T>(httpClient);
    }
}
using System;
using System.Net.Http.Headers;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using ProductJudge.Mobile.DAL;
using ProductJudge.Mobile.DAL.Helpers;

namespace TestApi;

public static class HttpClientHelper
{
    public static HttpClient CreateHttpClient()
    {
        var handler = new HttpLoggingHandler(LoggerHelper.CreateLogger<HttpLoggingHandler>());
        var httpClient = new HttpClient(handler) { BaseAddress = new Uri(HttpClients.URLS.URL_LOCAL_FAKE_API_BASE) };
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return httpClient;
    }

    public static Mock<IHttpClientFactory> CreateHttpClientFactory()
    {
        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        mockHttpClientFactory.Setup(f => f.CreateClient(HttpClients.FAKE_API)).Returns(CreateHttpClient());
        return mockHttpClientFactory;
    }
}
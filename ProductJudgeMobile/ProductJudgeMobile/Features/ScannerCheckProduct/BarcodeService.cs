using Microsoft.Extensions.Logging;
using ProductJudge.Api.Models.Barcode;
using ProductJudge.Mobile.DAL.API;
using ProductJudge.Mobile.DAL.Refit;
using SecretAligner.Telemedicine.Mobile.Infrastructure;
using System.Net.Http.Headers;

namespace ProductJudgeMobile.Features.ScannerCheckProduct;

public class BarcodeService
{
    private readonly IBarcodeApi barcodeApi;
    private readonly ILogger<BarcodeService> logger;

    public BarcodeService(ILogger<BarcodeService> logger, IHttpClientFactory httpClientFactory)
    {
        this.logger = logger;

        var httpClient = httpClientFactory.CreateClient(HttpClients.FAKE_API);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        barcodeApi = Refit.RestService.For<IBarcodeApi>(httpClient);
    }

    public async Task<ApiResultResponse<CheckProductByBarcodeResponseDto>> CheckProductByBarcode(string barcode)
    {
        try
        {
            var response = await barcodeApi.CheckProductByBarcode(new CheckProductByBarcodeRequestDto
            {
                Barcode = barcode
            });

            if (response == null)
            {
                return ApiResultResponse<CheckProductByBarcodeResponseDto>.CreateError("response is null");
            }

            return ApiResultResponse<CheckProductByBarcodeResponseDto>.CreateSuccess(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return ApiResultResponse<CheckProductByBarcodeResponseDto>.CreateError(e.Message);
        }
    }
}

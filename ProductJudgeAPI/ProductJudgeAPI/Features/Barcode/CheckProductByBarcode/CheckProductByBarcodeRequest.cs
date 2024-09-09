using MediatR;
using ProductJudge.Api.Models.Barcode;

namespace ProductJudgeAPI.Features.Barcode.CheckProductByBarcode;

public class CheckProductByBarcodeRequest : CheckProductByBarcodeRequestDto, IRequest<CheckProductByBarcodeResponse>
{
}

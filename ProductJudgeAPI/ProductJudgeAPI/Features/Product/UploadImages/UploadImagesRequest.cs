using MediatR;
using Microsoft.AspNetCore.Http;

namespace ProductJudgeAPI.Features.Product.UploadImages;

public class UploadImagesRequest : IRequest<UploadImagesResponse>
{
    public IFormFileCollection Images { get; set; }
}

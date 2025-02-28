namespace ProductJudgeAPI.Features.Product.UploadImages;

public class UploadImagesResponse
{
    public bool Success { get; set; }
        public List<string> BlobUrls { get; set; } = new List<string>();
}

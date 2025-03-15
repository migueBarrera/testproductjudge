using Azure.Storage.Blobs;
using MediatR;

namespace ProductJudgeAPI.Features.Product.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly ProductService applicationDbContext;
    private readonly BlobServiceClient _blobServiceClient;
    private readonly string _containerName = "product-images-test";

    public CreateProductHandler(ProductService applicationDbContext, IConfiguration configuration)
    {
        this.applicationDbContext = applicationDbContext;
        var connectionString = configuration.GetSection("BlobStorage").GetSection("ConnectionString").Value;
        _blobServiceClient = new BlobServiceClient(connectionString);
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Entities.Product()
        {
            Name = request.Name,
            Description = request.Description,
        };

        await applicationDbContext.CreateAsync(product);

        if (request.Images != null && request.Images.Count > 0)
        {
            foreach (var image in request.Images)
            {
                var imageUrl = await UploadImageToBlobAsync(image, cancellationToken);
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    product.Image.Add(imageUrl);

                    await applicationDbContext.UpdateAsync(product.Id!, product);
                }
            }
        }

        return new CreateProductResponse()
        {
            Id = product.Id!,
            Name = product.Name,
            Description = product.Description,
            Images = product.Image
        };
    }

    private async Task<string> UploadImageToBlobAsync(IFormFile image, CancellationToken cancellationToken)
    {
        try
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            await blobContainerClient.CreateIfNotExistsAsync(
                Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer
            );

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

            var blobClient = blobContainerClient.GetBlobClient(fileName);

            using (var stream = image.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true, cancellationToken);
            }

            return blobClient.Uri.ToString();
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
    }
}

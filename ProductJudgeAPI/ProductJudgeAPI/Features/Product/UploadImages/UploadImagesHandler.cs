using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
namespace ProductJudgeAPI.Features.Product.UploadImages;


public class UploadImagesHandler : IRequestHandler<UploadImagesRequest, UploadImagesResponse>
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "product-images";

        public UploadImagesHandler(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("BlobStorage").GetSection("ConnectionString").Value;
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<UploadImagesResponse> Handle(UploadImagesRequest request, CancellationToken cancellationToken)
        {
            var response = new UploadImagesResponse();

            try
            {
                var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
                await blobContainerClient.CreateIfNotExistsAsync();

                foreach (var image in request.Images)
                {
                    var blobClient = blobContainerClient.GetBlobClient(Guid.NewGuid().ToString() + Path.GetExtension(image.FileName));
                    
                    using (var stream = image.OpenReadStream())
                    {
                        await blobClient.UploadAsync(stream, true, cancellationToken);
                    }

                    response.BlobUrls.Add(blobClient.Uri.ToString());
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                // Log exception (ex) here
                response.Success = false;
            }

            return response;
        }
    }


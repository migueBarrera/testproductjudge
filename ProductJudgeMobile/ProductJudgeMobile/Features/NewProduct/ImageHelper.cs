using Refit;

public static class ImageHelper
{
    public static async Task<IEnumerable<StreamPart>> ConvertImagesToStreamParts(IEnumerable<ImageSource> images)
    {
        var streamParts = new List<StreamPart>();

        foreach (var image in images)
        {
            var stream = await ConvertImageSourceToStream(image);
            streamParts.Add(new StreamPart(stream, "image.jpg", "image/jpeg"));
        }

        return streamParts;
    }

    private static async Task<Stream> ConvertImageSourceToStream(ImageSource imageSource)
    {
        switch (imageSource)
        {
            case FileImageSource fileImageSource:
                // Load stream from a local file
                var filePath = fileImageSource.File;
                return File.OpenRead(filePath);

            case UriImageSource uriImageSource:
                // Load stream from a URI
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    var response = await httpClient.GetAsync(uriImageSource.Uri);
                    return await response.Content.ReadAsStreamAsync();
                }

            case StreamImageSource streamImageSource:
                // Use the provided stream
                return await streamImageSource.Stream(default);

            default:
                throw new NotSupportedException($"ImageSource type {imageSource.GetType()} is not supported");
        }
    }
}


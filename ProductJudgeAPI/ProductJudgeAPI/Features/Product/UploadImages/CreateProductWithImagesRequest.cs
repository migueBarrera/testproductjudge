public class CreateProductWithImagesRequest
{
public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public IFormFileCollection Images { get; set; }
}
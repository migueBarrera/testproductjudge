using ProductJudge.Api.Models.Products;

namespace ProductJudgeMobile.Features.ListProducts;

public class ItemProduct : GetAllProductResponseDto
{
    public ItemProduct(GetAllProductResponseDto x)
    {
        this.Description = x.Description;
        this.Id = x.Id;
        this.Image = x.Image;
        this.Name = x.Name;
        this.CategoryId = x.CategoryId;
    }
}

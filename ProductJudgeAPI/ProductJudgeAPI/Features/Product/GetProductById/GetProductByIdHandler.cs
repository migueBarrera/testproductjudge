using MediatR;
using MongoDB.Driver;
using ProductJudgeAPI.Features.Product.GetProductById;

namespace ProductJudgeAPI.Features.Product.GetProductByCategoryId;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
{
    private readonly ProductService applicationDbContext;

    public GetProductByIdHandler(ProductService applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {

        var filter = Builders<Entities.Product>.Filter.Eq(u => u.Id, request.Id);
        var items = await applicationDbContext.GetAsync(filter);

        var item = items.FirstOrDefault();
        return new GetProductByIdResponse()
        {
            Id = item.Id,
            Name = item.Name,
            CategoryId = item.CategoryId,
            Description = item.Description,
        };
    }
}

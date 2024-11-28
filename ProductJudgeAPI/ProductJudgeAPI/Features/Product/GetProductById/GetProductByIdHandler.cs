using MediatR;

namespace ProductJudgeAPI.Features.Product.GetProductByCategoryId;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, IEnumerable<GetProductByIdResponse>>
{
    private readonly ProductService applicationDbContext;

    public GetProductByIdHandler(ProductService applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<GetProductByIdResponse>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {

        //var filter = Builders<Entities.Product>.Filter.Eq(u => u.CategoryId, request.CategoryId);
        var items = await applicationDbContext.GetAsync();

        return items.Select(x => new GetProductByIdResponse()
        {
            Id = x.Id,
            Name = x.Name,
            CategoryId = x.CategoryId,
            Description = x.Description,
        });
    }
}

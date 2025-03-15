using MediatR;
using MongoDB.Driver;
using ProductJudge.Api.Models.Products;
using ProductJudgeAPI.Exceptions;
using ProductJudgeAPI.Extensions;
using ProductJudgeAPI.Features.Judge;
using ProductJudgeAPI.Features.Product.GetProductById;

namespace ProductJudgeAPI.Features.Product.GetProductByCategoryId;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
{
    private readonly ProductService applicationDbContext;
    private readonly JudgeService judgeService;

    public GetProductByIdHandler(ProductService applicationDbContext, JudgeService judgeService)
    {
        this.applicationDbContext = applicationDbContext;
        this.judgeService = judgeService;
    }

    public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var filter = Builders<Entities.Product>.Filter.Eq(u => u.Id, request.Id);
        var items = await applicationDbContext.GetAsync(filter);

        Ensure.That(items != null || items!.Count > 0, ExceptionMessagesConstants.InvalidCredentials);

        var item = items!.FirstOrDefault();

        var filterJudges = Builders<Entities.Judge>.Filter.Eq(u => u.ProductId, item!.Id!);
        var itemsJudges = await judgeService.GetAsync(filterJudges);

        return new GetProductByIdResponse()
        {
            Id = item!.Id!,
            Name = item.Name,
            Description = item.Description,
            Judges = itemsJudges?.Select(j => new CreateJudgeResponseDto()
            {
                Id = j.Id!,
                Judge = j.Text,
                CreatedAt = j.CreatedAt,
                UserId = j.UserId,
                ProductId = j.ProductId
            }) ?? new List<CreateJudgeResponseDto>()
        };
    }
}

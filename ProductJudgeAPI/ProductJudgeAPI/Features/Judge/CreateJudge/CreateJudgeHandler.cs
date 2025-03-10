using MediatR;
using MongoDB.Driver;
using ProductJudgeAPI.Exceptions;
using ProductJudgeAPI.Extensions;
using ProductJudgeAPI.Features.Product;
using ProductJudgeAPI.Features.User;

namespace ProductJudgeAPI.Features.Judge.CreateJudge;

public class CreateJudgeHandler : IRequestHandler<CreateJudgeRequest, CreateJudgeResponse>
{
    private readonly JudgeService applicationDbContext;

    private readonly UserService userService;

    private readonly ProductService productService;

    public CreateJudgeHandler(JudgeService applicationDbContext, UserService userService, ProductService productService)
    {
        this.applicationDbContext = applicationDbContext;
        this.userService = userService;
        this.productService = productService;
    }

    public async Task<CreateJudgeResponse> Handle(CreateJudgeRequest request, CancellationToken cancellationToken)
    {
        var filterUser = Builders<Entities.User>.Filter.Eq(u => u.Id, request.UserId);
        var user = await userService
            .GetAsync(filterUser);

        Ensure.That(user != null, ExceptionMessagesConstants.UserNotFound);

        var filterProduct = Builders<Entities.Product>.Filter.Eq(u => u.Id, request.ProductId);
        var Product = await productService
            .GetAsync(filterProduct);

        Ensure.That(Product != null, ExceptionMessagesConstants.ProductNotFound);

        var judge = new Entities.Judge()
        {
            Text = request.Judge,
            ProductId = request.ProductId,
            UserId = request.UserId,
            CreatedAt = DateTime.UtcNow,
        };

        await applicationDbContext.CreateAsync(judge);

        return new CreateJudgeResponse()
        {
            Id = judge.Id!,
            UserId = request.UserId,
            Judge = request.Judge,
            ProductId = request.ProductId,
        };
    }
}

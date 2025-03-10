using MediatR;

namespace ProductJudgeAPI.Features.Judge.CreateJudge;

public class CreateJudgeHandler : IRequestHandler<CreateJudgeRequest, CreateJudgeResponse>
{
    private readonly JudgeService applicationDbContext;

    public CreateJudgeHandler(JudgeService applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<CreateJudgeResponse> Handle(CreateJudgeRequest request, CancellationToken cancellationToken)
    {
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

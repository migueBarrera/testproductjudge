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
            Text = request.Text,
            ProductId = request.ProductId,
            UserId = request.UserId,
        };

        await applicationDbContext.CreateAsync(judge);

        return new CreateJudgeResponse()
        {
            UserId = request.UserId,
            Text = request.Text,
            ProductId = request.ProductId,
        };
    }
}

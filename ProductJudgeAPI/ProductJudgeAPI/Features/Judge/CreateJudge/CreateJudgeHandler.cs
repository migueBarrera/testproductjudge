using MediatR;
using ProductJudgeAPI.Context;

namespace ProductJudgeAPI.Features.Judge.CreateJudge;

public class CreateJudgeHandler : IRequestHandler<CreateJudgeRequest, CreateJudgeResponse>
{
    private readonly AppDbContext applicationDbContext;

    public CreateJudgeHandler(AppDbContext applicationDbContext)
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

        applicationDbContext.Judges.Add(judge);

        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return new CreateJudgeResponse()
        {
            UserId = request.UserId,
            Text = request.Text,
            ProductId = request.ProductId,
        };
    }
}

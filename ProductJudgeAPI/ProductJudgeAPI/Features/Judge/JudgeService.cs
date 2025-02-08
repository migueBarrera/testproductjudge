using Microsoft.Extensions.Options;
using ProductJudgeAPI.Entities;
using ProductJudgeAPI.Helpers;

namespace ProductJudgeAPI.Features.Judge;

public class JudgeService : MongoServiceBase<Entities.Judge>
{
    public JudgeService(IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings) : base(bookStoreDatabaseSettings)
    {
    }

    public override string CollectionName()
    {
        return bookStoreDatabaseSettings.Value.JudgeCollectionName;
    }
}

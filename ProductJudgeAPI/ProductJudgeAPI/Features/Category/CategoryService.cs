using Microsoft.Extensions.Options;
using ProductJudgeAPI.Entities;
using ProductJudgeAPI.Helpers;

namespace ProductJudgeAPI.Features.Category;

public class CategoryService : MongoServiceBase<Entities.Category>
{
    public CategoryService(IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings) : base(bookStoreDatabaseSettings)
    {
    }

    public override string CollectionName()
    {
        return bookStoreDatabaseSettings.Value.CategoryCollectionName;
    }
}

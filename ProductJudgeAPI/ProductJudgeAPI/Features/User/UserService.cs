using Microsoft.Extensions.Options;
using ProductJudgeAPI.Entities;
using ProductJudgeAPI.Helpers;

namespace ProductJudgeAPI.Features.User;

public class UserService : MongoServiceBase<Entities.User>
{
    public UserService(IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings)
        : base(bookStoreDatabaseSettings)
    {
        _collectionName = bookStoreDatabaseSettings.Value.BooksCollectionName;
    }
}

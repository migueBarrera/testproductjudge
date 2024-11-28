using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductJudgeAPI.Entities;

namespace ProductJudgeAPI.Helpers;

public class MongoClientService
{
    protected readonly MongoClient mongoClient;

    public MongoClientService(
        IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);
    }
}

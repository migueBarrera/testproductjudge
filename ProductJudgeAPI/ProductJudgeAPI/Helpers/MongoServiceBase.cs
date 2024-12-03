using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductJudgeAPI.Entities;

namespace ProductJudgeAPI.Helpers;

public abstract class MongoServiceBase<T> : IMongoService<T>
{
    protected readonly IMongoCollection<T> _collection;

    protected string _collectionName = string.Empty;
    protected IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings;

    protected MongoServiceBase(IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        this.bookStoreDatabaseSettings = bookStoreDatabaseSettings;

        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<T>(CollectionName());
    }

    public async Task<List<T>> GetAsync(FilterDefinition<T>? filter = null)
    {
        filter ??= Builders<T>.Filter.Empty;
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task<List<T>> GetAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<T?> GetAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T newEntity) =>
        await _collection.InsertOneAsync(newEntity);

    public async Task UpdateAsync(string id, T updatedEntity)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        await _collection.ReplaceOneAsync(filter, updatedEntity);
    }

    public async Task RemoveAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        await _collection.DeleteOneAsync(filter);
    }

    public abstract string CollectionName();
}

using MongoDB.Driver;

namespace ProductJudgeAPI.Helpers
{
    public interface IMongoService<T>
    {
        string CollectionName();
        Task<List<T>> GetAsync(FilterDefinition<T>? filter = null);
        Task<List<T>> GetAsync();
        Task<T?> GetAsync(string id);
        Task CreateAsync(T newEntity);
        Task UpdateAsync(string id, T updatedEntity);
        Task RemoveAsync(string id);
    }
}

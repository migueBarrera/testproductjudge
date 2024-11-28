using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductJudgeAPI.Entities;

public class Category
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public IEnumerable<Product> Products { get; set; } = new List<Product>();
}

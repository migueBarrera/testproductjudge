using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductJudgeAPI.Entities;

public class Judge
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public User? User { get; set; }

    public string ProductId { get; set; } = string.Empty;

    public Product? Product { get; set; }

}

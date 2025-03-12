using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductJudgeAPI.Entities;

public class Judge
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Text { get; set; } = string.Empty;

    [BsonRepresentation(BsonType.ObjectId)] 
    public string UserId { get; set; } = string.Empty;

    [BsonRepresentation(BsonType.ObjectId)] 
    public string ProductId { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
}

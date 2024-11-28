using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductJudgeAPI.Entities;

public class Barcode
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Value { get; set; } = string.Empty;

    public string ProductId { get; set; } = string.Empty;

    public Product? Product { get; set; }

}

﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductJudgeAPI.Entities;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ICollection<string> Image { get; set; } = new List<string>();

}

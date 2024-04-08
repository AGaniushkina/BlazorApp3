using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorApp2.Shared;

public class Route
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string DepartureCity { get; set; } = null!;
    public string ArrivalCity { get; set; } = null!;
}
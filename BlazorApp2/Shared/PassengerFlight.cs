using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BlazorApp2.Shared;

public class PassengerFlight
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string PassengerId { get; set; } = null!;
    public string FlightId { get; set; } = null!;
}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BlazorApp2.Shared;

public class Flight
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string FlightNumber { get; set; } = null!;
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public string? Plane { get; set; }
    public double Price { get; set; }
    public int AvailableSeatsCount { get; set; }
    // TODO: связать с таблицей route
    public Route? Route { get; set; }
}

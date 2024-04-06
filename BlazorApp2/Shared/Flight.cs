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
    [BsonRepresentation(BsonType.ObjectId)]
    public string? RouteId { get; set; }
    //public string? DepartureCity { get; set; }
    //public string? ArrivalCity { get; set; }
    [BsonIgnoreIfNull]
    public Route? Route { get; set; }
}

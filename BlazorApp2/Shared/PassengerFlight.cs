using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BlazorApp2.Shared;

public class PassengerFlight
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string passengerId { get; set; } = null!;
    public string flightId { get; set; } = null!;
    public Flight flight { get; set; } = new Flight();
    public PassengerFlight() { }
    public PassengerFlight(string passengerId, string flightId, Flight flight)
    {
        this.passengerId = passengerId;
        this.flightId = flightId;
        this.flight = flight;
    }
}

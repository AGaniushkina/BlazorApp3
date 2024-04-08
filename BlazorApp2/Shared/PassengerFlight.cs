using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorApp2.Shared
{
	public class PassengerFlight
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }
		public string passengerId { get; set; } = null!;
		public string flightId { get; set; } = null!;
	}
}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BlazorApp2.Shared;

public class Passenger
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string LastName { get; set; } = "";
	public string FirstName { get; set; } = "";
	public string Patronymic { get; set; } = "";
	public GenderEnum Sex { get; set; }
    public DateTime DateOfIssue { get; set; }
    public string? DocumentSeriesAndNumber { get; set; } = "";
    public string Email { get; set; } = "";
	public string PhoneNumber { get; set; } = "";
}

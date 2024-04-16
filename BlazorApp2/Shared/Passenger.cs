using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Shared;

public class Passenger
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string Patronymic { get; set; } = null!;
    public string? Sex { get; set; } = "";
    public DateTime DateOfIssue { get; set; }
    public string? DocumentSeriesAndNumber { get; set; } = "";
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    //public ICollection<string> FlightsId { get; set; } = null!;
    //public ICollection<Flight> Flights { get; set; } = new List<Flight>();
}

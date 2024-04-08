namespace BlazorApp2.Shared;

public class AirportDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string RoutesCollectionName { get; set; } = null!;
    public string FlightsCollectionName { get; set; } = null!;
    public string PassengersCollectionName { get; set; } = null!;
    public string PassengerFlightCollectionName { get; set; } = null!;
}
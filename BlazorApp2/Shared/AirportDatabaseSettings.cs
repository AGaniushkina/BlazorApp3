namespace BlazorApp2.Shared;

public class AirportDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string RoutesCollectionName { get; set; } = null!;
}

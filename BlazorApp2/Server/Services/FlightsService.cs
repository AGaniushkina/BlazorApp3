using BlazorApp2.Shared;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BlazorApp2.Server.Services;

public class FlightsService
{
    private readonly IMongoCollection<Flight> _flightsCollection;

    public FlightsService(
        IOptions<AirportDatabaseSettings> airportDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            airportDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            airportDatabaseSettings.Value.DatabaseName);

        _flightsCollection = mongoDatabase.GetCollection<Flight>(
            airportDatabaseSettings.Value.FlightsCollectionName);
    }

    public async Task<List<Flight>> GetAsync()
    {
        // var flights = await _flightsCollection.Find(_ => true).ToListAsync();
        var flights = await _flightsCollection.Aggregate()
            .Lookup("Routes", "RouteId", "_id", "Route")
            .Unwind("Route")
            .As<Flight>()
            .ToListAsync();
        return flights;
    }

    public async Task<Flight?> GetAsync(string id) =>
        await _flightsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Flight newRoute) =>
        await _flightsCollection.InsertOneAsync(newRoute);

    public async Task UpdateAsync(string id, Flight updatedRoute) =>
        await _flightsCollection.ReplaceOneAsync(x => x.Id == id, updatedRoute);

    public async Task RemoveAsync(string id) =>
        await _flightsCollection.DeleteOneAsync(x => x.Id == id);

    public async Task<List<Flight>> GetByCityAsync(string? routeId) =>
        await _flightsCollection.Find(x => x.RouteId == routeId).ToListAsync();
}
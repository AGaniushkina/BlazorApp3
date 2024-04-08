using BlazorApp2.Shared;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Route = BlazorApp2.Shared.Route;

namespace BlazorApp2.Server.Services;

public class RoutesService
{
    private readonly IMongoCollection<Route> _routesCollection;

    public RoutesService(
        IOptions<AirportDatabaseSettings> airportDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            airportDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            airportDatabaseSettings.Value.DatabaseName);

        _routesCollection = mongoDatabase.GetCollection<Route>(
            airportDatabaseSettings.Value.RoutesCollectionName);
    }

    public async Task<List<Route>> GetAsync() =>
        await _routesCollection.Find(_ => true).ToListAsync();

    public async Task<Route?> GetAsync(string id) =>
        await _routesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Route newRoute) =>
        await _routesCollection.InsertOneAsync(newRoute);

    public async Task UpdateAsync(string id, Route updatedRoute) =>
        await _routesCollection.ReplaceOneAsync(x => x.Id == id, updatedRoute);

    public async Task RemoveAsync(string id) =>
        await _routesCollection.DeleteOneAsync(x => x.Id == id);
}
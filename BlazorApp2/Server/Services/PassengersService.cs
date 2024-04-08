using BlazorApp2.Shared;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Passenger = BlazorApp2.Shared.Passenger;

namespace BlazorApp2.Server.Services;
    public class PassengersService
    {
    private readonly IMongoCollection<Passenger> _passengersCollection;

    public PassengersService(
        IOptions<AirportDatabaseSettings> airportDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            airportDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            airportDatabaseSettings.Value.DatabaseName);

        _passengersCollection = mongoDatabase.GetCollection<Passenger>(
            airportDatabaseSettings.Value.PassengersCollectionName);
    }

    public async Task<List<Passenger>> GetAsync() => 
        await _passengersCollection.Find(_ => true).ToListAsync();

    public async Task<Passenger?> GetAsync(string id) =>
        await _passengersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Passenger newPassenger) =>
        await _passengersCollection.InsertOneAsync(newPassenger);

    public async Task UpdateAsync(string id, Passenger updatedPassenger) =>
        await _passengersCollection.ReplaceOneAsync(x => x.Id == id, updatedPassenger);

    public async Task RemoveAsync(string id) =>
        await _passengersCollection.DeleteOneAsync(x => x.Id == id);
}


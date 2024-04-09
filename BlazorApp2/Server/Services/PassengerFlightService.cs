﻿using BlazorApp2.Shared;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PassengerFlight = BlazorApp2.Shared.PassengerFlight;

namespace BlazorApp2.Server.Services
{
	public class PassengerFlightService
	{
		private readonly IMongoCollection<PassengerFlight> _passengerFlightCollection;
		public PassengerFlightService(
		IOptions<AirportDatabaseSettings> airportDatabaseSettings)
		{
			var mongoClient = new MongoClient(
				airportDatabaseSettings.Value.ConnectionString);

			var mongoDatabase = mongoClient.GetDatabase(
				airportDatabaseSettings.Value.DatabaseName);

			_passengerFlightCollection = mongoDatabase.GetCollection<PassengerFlight>(
				airportDatabaseSettings.Value.PassengerFlightCollectionName);
		}

		public async Task<List<PassengerFlight>> GetAsync() =>
		await _passengerFlightCollection.Find(_ => true).ToListAsync();

		public async Task<PassengerFlight?> GetAsync(string id) =>
			await _passengerFlightCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

		public async Task CreateAsync(PassengerFlight newRoute) =>
			await _passengerFlightCollection.InsertOneAsync(newRoute);

		public async Task UpdateAsync(string id, PassengerFlight updatedRoute) =>
			await _passengerFlightCollection.ReplaceOneAsync(x => x.Id == id, updatedRoute);

		public async Task RemoveAsync(string id) =>
			await _passengerFlightCollection.DeleteOneAsync(x => x.Id == id);

		public async Task<List<PassengerFlight>> GetByPassengerIdAsync(string? passengerId) =>
			await _passengerFlightCollection.Find(x => x.passengerId == passengerId).ToListAsync();
	}
}

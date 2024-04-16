using BlazorApp2.Server.Services;
using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers;

[ApiController]
[Route("api/passengerflights")]
public class PassengerFlightController : ControllerBase
{
	private readonly PassengerFlightService _passengerFlightService;

	public PassengerFlightController(PassengerFlightService passengerFlightService)
	{
		_passengerFlightService = passengerFlightService;
	}

	[HttpGet]
	[Route("all")]
	public async Task<List<PassengerFlight>> Get() =>
		await _passengerFlightService.GetAsync();

	[HttpGet]
	public async Task<List<PassengerFlight>> GetByPassengerId([FromQuery] string? passengerId) =>
		await _passengerFlightService.GetByPassengerIdAsync(passengerId);

	[HttpPost]
	public async Task Post([FromQuery] PassengerFlight newPassengerFlight)
	{
		if (newPassengerFlight is null)
		{
			throw new ArgumentNullException(nameof(newPassengerFlight));
		}
		await _passengerFlightService.CreateAsync(newPassengerFlight);
	}
}


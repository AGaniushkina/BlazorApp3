using BlazorApp2.Server.RabbitMqProducer;
using BlazorApp2.Server.Services;
using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers;

[ApiController]
[Route("api/passengers")]
public class PassengersController : ControllerBase
{
    private readonly PassengersService _passengersService;
    private readonly PassengerFlightService _passengerFlightService;
    private readonly FlightsService _flightService;
    private readonly IRabbitMqService _mqService;

    public PassengersController(PassengersService passengersService, 
        PassengerFlightService passengerFlightService, 
        FlightsService flightsService,
        IRabbitMqService mqService)
    {
        _passengersService = passengersService;
        _passengerFlightService = passengerFlightService;
        _flightService = flightsService;
        _mqService = mqService;
    }

    [HttpPost]
    public IActionResult Booking(BookingModel bookingModel)
    {
        if (bookingModel == null)
        {
            throw new ArgumentNullException(nameof(bookingModel));
        }
		_mqService.SendMessage(bookingModel);
		return Ok();
	}

    [HttpGet]
    [Route("{passengerId}/flights")]
    public async Task<List<Flight>> GetPassengerFlights(string passengerId)
    {
        var flightsIds = await _passengerFlightService.GetFlightIsByPassengerId(passengerId);
        var result = new List<Flight>();
        foreach(var flightId in flightsIds) 
        {
            result.Add(_flightService.GetAsync(flightId));
        }
        return result;
    }

    [HttpGet]
    public async Task<ActionResult<Passenger>> GetPassenger(string passengerId, string email)
    {
        var passenger = await _passengersService.GetByPassportAsync(passengerId, email);
        if (passenger != null)
            return Ok(passenger);
        return NotFound();
    }
}

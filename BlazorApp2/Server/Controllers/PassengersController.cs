using BlazorApp2.Server.Services;
using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;
using Passenger = BlazorApp2.Shared.Passenger;

namespace BlazorApp2.Server.Controllers;

[ApiController]
[Route("api/passengers")]
public class PassengersController : ControllerBase
{
    private readonly PassengersService _passengersService;

    public PassengersController(PassengersService passengersService)
    {
        _passengersService = passengersService;
    }

    [HttpGet]
    [Route("all")]
    public async Task<List<Passenger>> Get() =>
        await _passengersService.GetAsync();

	[HttpPost]
	public async Task Post([FromQuery] Passenger newPassenger)
	{
		if (newPassenger is null)
		{
			throw new ArgumentNullException(nameof(newPassenger));
		}
		await _passengersService.CreateAsync(newPassenger);
	}
	[HttpPut]
	public async Task Put(string id, Passenger updatedPassenger)
	{
		if (updatedPassenger is null)
		{
			throw new ArgumentNullException(nameof(updatedPassenger));
		}
		await _passengersService.UpdateAsync(id, updatedPassenger);
	}

}


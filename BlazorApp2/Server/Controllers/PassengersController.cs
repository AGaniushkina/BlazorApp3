using BlazorApp2.Server.Services;
using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<List<Passenger>> Get() =>
        await _passengersService.GetAsync();

	[HttpGet]
	public async Task<Passenger?> GetById([FromQuery] string? id) =>
	   await _passengersService.GetAsync(id);

	[HttpPost]
    public async Task Post([FromBody] Passenger newPassenger)
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


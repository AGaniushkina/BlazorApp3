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

    [HttpPost]
    public async Task Post([FromQuery] Passenger newPassenger)
    {
        if (newPassenger is null)
        {
            throw new ArgumentNullException(nameof(newPassenger));
        }
        await _passengersService.CreateAsync(newPassenger);
    }
}

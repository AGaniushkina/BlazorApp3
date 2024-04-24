using BlazorApp2.Server.Services;
using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers;

[ApiController]
[Route("api/flights")]
public class FlightsController : ControllerBase
{
    private readonly FlightsService _flightsService;

    public FlightsController(FlightsService routesService)
    {
        _flightsService = routesService;
    }

    [HttpGet]
    [Route("all")]
    public async Task<List<Flight>> Get() =>
        await _flightsService.GetAsync();

    [HttpGet]
    [Route("{routeId}")]
    public async Task<List<Flight>> GetByCity([FromRoute] string routeId, [FromQuery] DateOnly date) =>
        await _flightsService.GetByCityAsync(routeId, date);
}

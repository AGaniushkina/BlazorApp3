using BlazorApp2.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Route = BlazorApp2.Shared.Route;

namespace BlazorApp2.Server.Controllers;

[ApiController]
[Route("api/routes")]
public class RoutesController : ControllerBase
{
    private readonly RoutesService _routesService;

    public RoutesController(RoutesService routesService)
    {
        _routesService = routesService;
    }

    [HttpGet]
    public async Task<List<Route>> Get() =>
        await _routesService.GetAsync();
}
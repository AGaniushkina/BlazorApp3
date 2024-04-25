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
    private readonly IRabbitMqService _mqService;

    public PassengersController(PassengersService passengersService, IRabbitMqService mqService)
    {
        _passengersService = passengersService;
        _mqService = mqService;
    }

    [HttpPost]
    public IActionResult Post([FromQuery] AddPassenger newPassenger)
    {
        if (newPassenger == null)
        {
            throw new ArgumentNullException(nameof(newPassenger));
        }
		_mqService.SendMessage(newPassenger);
		return Ok();
		//await _passengersService.CreateAsync(newPassenger);
	}

    [HttpPost]
    [Route("{message}")]
	public IActionResult SendMessage(string message)
	{
		_mqService.SendMessage(message);

		return Ok("Сообщение отправлено");
	}
}

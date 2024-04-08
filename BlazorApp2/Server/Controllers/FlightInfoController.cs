using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightInfoController : ControllerBase
    {
        private List<FlightInfo> flights = new()
        {
            new() {Id = 1, DirectionFrom = "Saratov, Russia", DirectionTo = "Moscow, Russia", Departing = new DateTime(20/02/2024), PassengersCount = 1 }
        };

        private readonly ILogger<FlightInfoController> _logger;

        public FlightInfoController(ILogger<FlightInfoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult Create(FlightInfo flight)
        {
            flight.Id = flights.Count + 1;
            flights.Add(flight);
            var newFlight = flights.Find(o => o.Id == flight.Id);
            return Ok(newFlight);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var flight = flights.Find(o => o.Id == id);
            if (flight is not null)
            {
                return Ok(flight);
            }
            return NotFound("Flight not found");
        }

        [HttpGet("List")]
        public ActionResult List()
        {
            return Ok(flights);
        }

        [HttpPut]
        public ActionResult Update(FlightInfo newFlight)
        {
            var oldFlight = flights.FirstOrDefault(o => o.Id == newFlight.Id);
            if (oldFlight is not null)
            {
                oldFlight.DirectionFrom = newFlight.DirectionFrom;
                oldFlight.DirectionTo = newFlight.DirectionTo;
                oldFlight.Departing = newFlight.Departing;
                oldFlight.PassengersCount = newFlight.PassengersCount;
                return Ok(newFlight);
            }
            return NotFound("Flight not found");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var flight = flights.FirstOrDefault(o => o.Id == id);
            if (flight is not null)
            {
                flights.Remove(flight);
                return Ok();
            }
            return NotFound("Flight not found");
        }
    }
}

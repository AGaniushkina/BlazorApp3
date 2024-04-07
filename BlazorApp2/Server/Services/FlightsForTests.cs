using BlazorApp2.Shared;
using Newtonsoft.Json;

namespace BlazorApp2.Server.Services;

public class FlightsForTests
{
    public static List<Flight> GetFlights()
    {
        string jsonFilePath = "C:\\Users\\s.nikiforov\\SSU\\Airport.Flights.json";
        string jsonContent = File.ReadAllText(jsonFilePath);
        try
        {
            Flight flight = JsonConvert.DeserializeObject<Flight>(jsonContent);
            return new List<Flight> { flight };
        }
        catch (Exception ex) { return new List<Flight>(); }
        
    }
}

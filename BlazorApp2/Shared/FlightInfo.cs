using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{
    public class FlightInfo
    {
        public int Id { get; set; }
        public string? DirectionFrom { get; set; } = "";
        public string? DirectionTo { get; set; } = "";
        public DateTime Departing { get; set; } = DateTime.Now;
        public DateTime Returning { get; set; } = DateTime.Now.AddHours(24);
        public int PassengersCount { get; set; } = 1;
    }
}

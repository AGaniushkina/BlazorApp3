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
        [Required]
        public string? DirectionFrom { get; set; } = "";
        [Required]
        public string? DirectionTo { get; set; } = "";
        [Required]
        public DateTime Departing { get; set; } = DateTime.Now;
        public DateTime Returning { get; set; } = DateTime.Now.AddHours(24);
        public int PassengersCount { get; set; } = 1;
    }
}

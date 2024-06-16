using System;

namespace flightapp.webapi.DTO
{
    public class FlightDTO
    {
        public int FlightId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime Boarding { get; set; }
        public DateTime ETA { get; set; }
        public string Url { get; set; }
        public double? Price { get; set; }
        public string ImageUrl { get; set; }
        public string Airline { get; set; }
    }
}
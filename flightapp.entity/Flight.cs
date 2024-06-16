using System;
using System.Collections.Generic;

namespace flightapp.entity
{
    public class Flight
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

        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }

        public DateTime DateAdded { get; set; }

        public List<FlightCategory> FlightCategories { get; set; }
    }
}
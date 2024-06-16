using System.Collections.Generic;

namespace flightapp.entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<FlightCategory> FlightCategories { get; set; }
        
    }
}
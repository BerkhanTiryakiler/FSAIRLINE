namespace flightapp.entity
{
    public class FlightCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
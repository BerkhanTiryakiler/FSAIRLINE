namespace flightapp.entity
{
    public class BookItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; } 

        public double Price { get; set; }
        public int SeatNumber { get; set; }  
    }
}
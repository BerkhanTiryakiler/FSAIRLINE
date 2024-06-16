namespace flightapp.entity
{
    public class CartItem
    {
        public int Id { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int SeatNumber { get; set; }
    }
}
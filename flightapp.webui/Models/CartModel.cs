using System.Collections.Generic;
using System.Linq;

namespace flightapp.webui.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public List<CartItemModel> CartItems { get; set; }

        public double TotalPrice()
        {
            return CartItems.Sum(i=>i.Price*i.SeatNumber);
        }
    }

    public class CartItemModel 
    {
        public int CartItemId { get; set; }
        public int flightId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int SeatNumber { get; set; }
    }


}
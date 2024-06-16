using System;
using System.Collections.Generic;
using System.Linq;
using flightapp.entity;

namespace flightapp.webui.Models
{
    public class BookListModel
    {
        public int BookId { get; set; }
        public string BookNumber { get; set; }
        public DateTime BookDate { get; set; }
        public string UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }      
        public EnumPaymentType PaymentType { get; set; }
        public EnumBookState BookState { get; set; }
        public List<BookItemModel> BookItems { get; set; }

        public double TotalPrice()
        {
            return BookItems.Sum(i=>i.Price * i.SeatNumber);
        }
    }

    public class BookItemModel
    {
        public int BookItemId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int SeatNumber { get; set; }
    }
}
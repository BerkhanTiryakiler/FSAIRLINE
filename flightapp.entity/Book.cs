using System;
using System.Collections.Generic;

namespace flightapp.entity
{
    public class Book
    {       
        public int Id { get; set; }
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
        public string PaymentId { get; set; }
        public string ConversationId { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public EnumBookState BookState { get; set; }
        public List<BookItem> BookItems { get; set; }
    }

    public enum EnumPaymentType
    {
        CreditCard=0,
        Eft=1
    }

    public enum EnumBookState
    {
        waiting=0,
        unpaid=1,
        completed=2
    } 
}
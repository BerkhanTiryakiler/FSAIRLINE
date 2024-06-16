using System.Collections.Generic;
using flightapp.entity;

namespace flightapp.webui.Models
{
    public class FlightDetailModel
    {
        public Flight Flight { get; set; }
        public List<Category> Categories { get; set; }
    }
}
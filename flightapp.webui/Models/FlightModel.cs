using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using flightapp.entity;

namespace flightapp.webui.Models
{
    public class FlightModel
    {
        public int flightId { get; set; }  
        public string Source { get; set; }
        
        public DateTime Boarding { get; set; }
        public DateTime ETA { get; set; }
        [Required(ErrorMessage = "Airline information is necessary.")]
        public string Airline { get; set; }


        [Required(ErrorMessage="Url is necessary.")]  
        public string Url { get; set; }     
        public double? Price { get; set; } 
      
        [Required(ErrorMessage="Destination is necessary.")]
        [StringLength(100,MinimumLength=5,ErrorMessage=".")]

        public string Destination { get; set; }      
       
        [Required(ErrorMessage="ImageUrl zorunlu bir alan.")]  
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
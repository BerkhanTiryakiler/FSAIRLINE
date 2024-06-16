using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using flightapp.entity;

namespace flightapp.webui.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
                
        [Required(ErrorMessage="Category name is necessary.")]
        [StringLength(100,MinimumLength=5,ErrorMessage= "Enter a value between 5-100 for the category.")]        
        public string Name { get; set; }

        [Required(ErrorMessage="Url is necessary.")]
        [StringLength(100,MinimumLength=5,ErrorMessage= "Enter a value between 5-100 for the url.")]        

        public string Url { get; set; }

        public List<Flight> flights { get; set; }
    }
}
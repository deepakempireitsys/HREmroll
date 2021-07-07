using System;
using System.ComponentModel.DataAnnotations;

namespace HREmroll.Models
{
    public class City
    {
        public int CITY_ID { get; set; }

        
        [Display(Name = "State Name")]
        [Required (ErrorMessage ="please select any State")]
        public Nullable<int> STATE_ID { get; set; }

        [Display(Name = "Country name")]
        [Required(ErrorMessage ="Please Select Any Country")]
        public Nullable<int> COUNTRY_ID { get; set; }

        [Display(Name = "City Name")]
        [Required(ErrorMessage = "Plese enter City Name")]
        public string CITY_NAME { get; set; }

        [Display(Name = "Description")] 
        
        public string DESCRIPTION { get; set; }

        [Display(Name = "Country Name")]
        public string COUNTRY_NAME { get; set; }
        public string STATE_NAME { get; set; }
    }
}

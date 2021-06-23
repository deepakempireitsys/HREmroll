using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class City
    {
        public int CITY_ID { get; set; }
        [Required(ErrorMessage = "Plese select any State")]
        [Display(Name = "State ID")]
        public int STATE_ID { get; set; }

        [Required(ErrorMessage = "Plese select any Country")]
        [Display(Name = "Country ID")]
        public int COUNTRY_ID { get; set; }
        [Display(Name = "City Name")]
        [Required(ErrorMessage = "Plese enter City Name")]
        public string CITY_NAME { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Plese enter description")]
        public string DESCRIPTION { get; set; }
        [Display(Name = "Country Name")]
        public string COUNTRY_NAME { get; set; }
        public string STATE_NAME { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class State
    {
        public long STATE_ID { get; set; }

        [Required(ErrorMessage ="Plese select any country")]
        [Display(Name ="Country ID")]
        public long COUNTRY_ID { get; set; }
        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Plese enter state name")]
        public string STATE_NAME { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Plese enter description")]
        public string DESCRIPTION { get; set; }
        [Display(Name = "Country Name")]
        public string COUNTRY_NAME { get; set; }
    }
}

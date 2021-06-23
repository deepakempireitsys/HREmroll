using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class Country
    {
        public int COUNTRY_ID { get; set; }
        [Required(ErrorMessage ="Country name is required")]
        [Display(Name = "Country name")]

        public string COUNTRY_NAME { get; set; }
    }
}

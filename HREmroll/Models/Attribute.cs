using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class Attribute
    {

        public int ATTRIBUTE_ID { get; set; }
        public long CMP_ID { get; set; }

        [Display(Name = "Attribute name")]
        [Required(ErrorMessage ="Enter Attribute Name")]
        public string ATTRIBUTE_NAME { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Enter Description")]
        public string DESCRIPTION { get; set; }

        [Display(Name = "Created By")]
        public int CREATED_BY { get; set; }
        [Required]
        [Display(Name = "Created Date")]
        public DateTime CREATED_DATE { get; set; }
        [Required]
        [Display(Name = "Modified By")]
        public int MODIFIED_BY { get; set; }
        [Required]
        [Display(Name = "Modified Date")]
        public DateTime MODIFIED_DATE { get; set; }

        public bool ISACTIVE { get; set; }
        [Display(Name = "Company Name")]
        public string CMP_NAME { get; set; }
    }
}

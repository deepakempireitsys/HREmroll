using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class Qualification
    {

        public int QUALIFICATION_ID { get; set; }
        public long CMP_ID { get; set; }

        [Required]
        [Display(Name ="Type")]

        //[Remote(action: "Designtionduplication", controller: "Home",ErrorMessage ="QUALIFICATION name in already exist")]
        public string TYPE { get; set; }
        [Display(Name = "Qualification name")]
        [Required]
        public string QUALIFICATION_NAME { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string DESCRIPTION { get; set; }
        [Required]
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

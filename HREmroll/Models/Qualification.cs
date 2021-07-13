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

        [Display(Name ="Company Id")]
        [Required(ErrorMessage ="Select Company Id")]
        public Nullable<long> CMP_ID { get; set; }

        [Required(ErrorMessage ="Select Qualification Type")]
        [Display(Name ="Type")]
        
        //[Remote(action: "Designtionduplication", controller: "Home",ErrorMessage ="QUALIFICATION name in already exist")]
        public string TYPE { get; set; }
        [Display(Name = "Qualification name")]
        [Required(ErrorMessage ="Enter Qulification Name")]
        public string QUALIFICATION_NAME { get; set; }

        [Display(Name = "Description")]
      
        public string DESCRIPTION { get; set; }
    
        [Display(Name = "Created By")]
        public int CREATED_BY { get; set; }
      
        [Display(Name = "Created Date")]
        public DateTime CREATED_DATE { get; set; }
       
        [Display(Name = "Modified By")]
        public int MODIFIED_BY { get; set; }
    
        [Display(Name = "Modified Date")]
        public DateTime MODIFIED_DATE { get; set; }

        public bool ISACTIVE { get; set; }

        [Display(Name = "Company Name")]
        public string CMP_NAME { get; set; }
    }

}

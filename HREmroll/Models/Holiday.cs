using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class Holiday
    {
        [Display(Name = "Holiday ID")]
        public long Holiday_ID { get; set; }        // NUMERIC(18, 0) null,
        
        [Display(Name = "CMP ID")]
        [Required(ErrorMessage ="Enter Company Id")]
        public Nullable<long> CMP_ID { get; set; }

        [Display(Name = "BRANCH NAME")]
        [Required(ErrorMessage = "Must Select Branch")]
        public Nullable<long> BRANCH_ID { get; set; }

        [Display(Name = "HOLIDAY NAME")]
        [Required(ErrorMessage = "Enter Hollyday Name")]
        public string HOLIDAY_NAME { get; set; }

        [Display(Name = "BRANCH")]
        public string BRANCH { get; set; }

        [Display(Name = "BRANCH")]
        public string BRANCH_NAME { get; set; }

        // NUMERIC(18,0) null,
        [Display(Name = "STATE NAME")]
        //[Required(ErrorMessage ="Enter State Name")]
        public string STATE { get; set; }    
        
        [Display(Name = "MULTIPLE HOLIDAY")]
        public bool MULTIPLE_HOLIDAY { get; set; }

        [Display(Name = "HOLIDAY DATE")]
        [Required(ErrorMessage ="Enter Hollyday Date")]
        public string HOLIDAY_DATE { get; set; }

        [Display(Name = "MESSAGE TEXT")]
        [Required(ErrorMessage ="Enter Massage text")]
        public string MESSAGE_TEXT { get; set; }

        [Display(Name = "HOLIDAY CATEGORY")]
        public string HOLIDAY_CATEGORY { get; set; }

        [Display(Name = "REPEAT ANNUALLY")]
        public bool REPEAT_ANNUALLY { get; set; }

        [Display(Name = "HALF DAY")]
        public bool HALF_DAY { get; set; }

        [Display(Name = "PRESENT COMPLUSARY")]
        public bool PRESENT_COMPLUSARY { get; set; }

        [Display(Name = "SMS")]
        public bool SMS { get; set; }

        [Display(Name = "OPTIONAL HOLIDAY")]
        public bool OPTIONAL_HOLIDAY { get; set; }

        [Display(Name = "IS ACTIVE")]
        public bool ISACTIVE { get; set; }

        //[Display(Name = "COMPANY")]
        //public string CMP_NAME { get; set; }           // NUMERIC(18,0) null,

        //[Display(Name = "BR ID")]
        //[Required, Range(1, int.MaxValue, ErrorMessage = "Must Select Branch")]
        //public long BRANCH_ID { get; set; }           // NUMERIC(18,0) null,

        //[Display(Name = "BRANCH")]
        //public string BRANCH_NAME { get; set; }           // NUMERIC(18,0) null,

        //[Display(Name = "NAME")]
        //public string Holiday_NAME { get; set; }  // VARCHAR(500) null,  

        //[Display(Name = "DESCRIPTION")]
        //public string DESCRIPTION { get; set; }      // VARCHAR(Max) null,  

        //[Display(Name = "CREATED BY")]
        //public long CREATED_BY { get; set; }       // NUMERIC(18, 0) null,  

        //[Display(Name = "CREATE DATE")]
        //public DateTime CREATED_DATE { get; set; }     // DATETIME null,

        //[Display(Name = "MODIFIED BY")]
        //public long MODIFIED_BY { get; set; }      // NUMERIC(18, 0) null,

        //[Display(Name = "MODIFIED DATE")]
        //public DateTime MODIFIED_DATE { get; set; }    // DATETIME null,

               // BIT null,

        //public HREmroll.Repository.BranchRepository br = new HREmroll.Repository.BranchRepository();
        
        


    }
}

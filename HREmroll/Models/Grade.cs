using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HREmroll.Models
{
    public class Grade
    {
        
        [Display(Name = "GRADE ID")]
        public long GRADE_ID { get; set; } //NUMERIC(18, 0) null,

        [Display(Name = "CMP ID")]
        [Required(ErrorMessage ="Enter Company Id")]
        public Nullable<long> CMP_ID { get; set; }           // NUMERIC(18,0) null,

        [Display(Name = "COMPANY")]
        public string CMP_NAME { get; set; }           // NUMERIC(18,0) null,

        [Display(Name = "BR ID")]
        [Required(ErrorMessage = "Must Select Branch")]
        public Nullable<long> BRANCH_ID { get; set; }           // NUMERIC(18,0) null,

        [Display(Name = "BRANCH")]
        
        public string BRANCH_NAME { get; set; }           // NUMERIC(18,0) null,

        [Display(Name = "NAME")]
        [Required(ErrorMessage = "Enter Grade Name")]
        public string GRADE_NAME { get; set; }  // VARCHAR(500) null,  

        [Display(Name = "DESCRIPTION")]
        public string DESCRIPTION { get; set; }      // VARCHAR(Max) null,  

        [Display(Name = "CREATED BY")]
        public long CREATED_BY { get; set; }       // NUMERIC(18, 0) null,  

        [Display(Name = "CREATE DATE")]
        public DateTime CREATED_DATE { get; set; }     // DATETIME null,

        [Display(Name = "MODIFIED BY")]
        public long MODIFIED_BY { get; set; }      // NUMERIC(18, 0) null,

        [Display(Name = "MODIFIED DATE")]
        public DateTime MODIFIED_DATE { get; set; }    // DATETIME null,

        [Display(Name = "IS ACTIVE")]
        public bool ISACTIVE { get; set; }         // BIT null,

        //public HREmroll.Repository.BranchRepository br = new HREmroll.Repository.BranchRepository(_configuration);
    }
}

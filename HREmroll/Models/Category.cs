using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HREmroll.Models
{
    public class Category
    {
        [DefaultValue(0)]
        [Display(Name = "CATEGORY ID")]
        public long CATEGORY_ID { get; set; } //NUMERIC(18, 0) null,

        [Display(Name = "CMP ID")]
        public long CMP_ID { get; set; }           // NUMERIC(18,0) null,

        [Display(Name = "COMPANY")]
        public string CMP_NAME { get; set; }           // NUMERIC(18,0) null,

        [Display(Name = "BR ID")]
        [Required, Range(1, int.MaxValue, ErrorMessage = "Must Select Branch")]
        public long BRANCH_ID { get; set; }           // NUMERIC(18,0) null,

        [Display(Name = "BRANCH")]
        public string BRANCH_NAME { get; set; } // NUMERIC(18,0) null,

        [Required(ErrorMessage ="Enter Category Name")]
        [Display(Name = "NAME")]
        public string CATEGORY_NAME { get; set; }  // VARCHAR(500) null,  

       
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

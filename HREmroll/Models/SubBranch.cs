using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HREmroll.Models
{
    public class SubBranch
    {
        [Display(Name = "SUB BBRANCH ID")]
        public int SUB_BRANCH_ID { get; set; }

        [Display(Name = "CMP ID")]
        [Required(ErrorMessage ="Enter Company Id")]
        public Nullable<long> CMP_ID { get; set; }

        [Display(Name = "COMPANY NAME")]
        public string CMP_NAME { get; set; }

        [Display(Name = "BR ID")]
        [Required(ErrorMessage = "Must Select Branch")]
        public Nullable<long> BRANCH_ID { get; set; }

        [Display(Name = "BRANCH")]
        public string BRANCH_NAME { get; set; }

        [Display(Name = "SUB BRANCH NAME")]
        [Required(ErrorMessage ="Enter SubBranch Name")]
        public string SUB_BRANCH_NAME { get; set; }

        [Display(Name = "SUB BRANCH CODE")]
        [Required(ErrorMessage ="Enter SubBranch Code")]
        public string SUB_BRANCH_CODE { get; set; }
        //[Required(ErrorMessage = "Branch Name is required.")]

        [Display(Name = "DESCRIPTION")]
        public String DESCRIPTION { get; set; }

        [Display(Name = "CREATED BY")]
        public long CREATED_BY { get; set; }

        [Display(Name = "CREATE DATE")]
        public DateTime CREATED_DATE { get; set; }

        [Display(Name = "MODIFIED BY")]
        public long MODIFIED_BY { get; set; }

        [Display(Name = "MODIFIED DATE")]
        public DateTime MODIFIED_DATE { get; set; }

        [Display(Name = "IS ACTIVE")]
        public bool ISACTIVE { get; set; }
    }
}

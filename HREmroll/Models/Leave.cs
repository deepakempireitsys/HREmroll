using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Dapper;

namespace HREmroll.Models
{
    public class Leave
    {
        [Display(Name = "LEAVE ID")]
        public int LEAVEID { get; set; }

        [Display(Name = "CMP ID")]
        public long CMP_ID { get; set; }

        [Display(Name = "COMPANY")]
        public string CMP_NAME { get; set; }

        [Display(Name = "BR ID")]
        [Required, Range(1, int.MaxValue, ErrorMessage = "Must Select Leave")]
        public long BRANCH_ID { get; set; }

        [Display(Name = "BRANCH")]
        public string BRANCH_NAME { get; set; }

        [Display(Name = "LEAVE TYPE")]
        public string LEAVETYPE { get; set; }
        //[Required(ErrorMessage = "Branch Name is required.")]
        [Display(Name = "DESCRIPTION")]
        public string DESCRIPTION { get; set; }
        //[Required(ErrorMessage = "Branch Name is required.")]

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

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class Designation
    {

        public long DESIGNATION_ID { get; set; }

        [Display(Name ="Compony ID")]
        [Required(ErrorMessage = "Plese enter Complany id")]
        public long CMP_ID { get; set; }

        [Required (ErrorMessage ="Plese enter Designation name")]
        [Display(Name ="Designation Name")]
        public string DESIGNATION_NAME { get; set; }

        [Required(ErrorMessage = "Plese enter Description")]

        [Display(Name = "Description")]
        public string DESCRIPTION { get; set; }

        [Display(Name = "Created By")]
        public long CREATED_BY { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CREATED_DATE { get; set; }

        [Display(Name = "Modified By")]
        public long MODIFIED_BY { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime MODIFIED_DATE { get; set; }

        public bool ISACTIVE { get; set; }

        [Display(Name = "Branch Name")]

        public string  Branch_name { get; set; }

        [Display(Name = "Branch Id")]
        [Required(ErrorMessage = "Plese select any branch")]
        public Nullable<long> BRANCH_ID { get; set; }
        //public string StatementType { get; set; }
    }
}

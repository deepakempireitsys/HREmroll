using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Dapper;

namespace HREmroll.Models
{
    public class Branch
    {
        [Display(Name = "BRANCH")]
        public long BRANCH_ID { get; set; }

        [Display(Name = "CMP ID")]
        public long CMP_ID { get; set; }           // NUMERIC(18,0) null,

        [Display(Name = "COMPANY")]
        public string CMP_NAME { get; set; }

        [Required(ErrorMessage = "Emter Branch Name")]
        [Display(Name = "BRANCH")]
        public string BRANCH_NAME { get; set; }

        [Display(Name ="DESCRIPTION")]
        public string DESCRIPTION { get; set; }
        
        public long CREATED_BY { get; set; }

        public DateTime CREATED_DATE { get; set; }
        public long MODIFIED_BY { get; set; }

        public DateTime MODIFIED_DATE { get; set; }
        public bool ISACTIVE { get; set; }


       // public  List<Branch> dynamicParameter{ get; set;}
        //static string strConnectionString = "User Id=sa;password=SUPERSOFTWARE#1;Server=24.13.245.114;Database=HREmroll;";
     

    }
}

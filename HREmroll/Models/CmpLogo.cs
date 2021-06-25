
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Dapper;

namespace HREmroll.Models
{
    public class CmpLogo
    {
        [Display(Name = "IMAGE")]
        public long IMAGE_ID { get; set; }

        [Display(Name = "CMP ID")]
        public long CMP_ID { get; set; }               // NUMERIC(18,0) null,

        [Display(Name = "COMPANY")]
        public string CMP_NAME { get; set; }           // NUMERIC(18,0) null,

        [Display(Name = "TYPE")]
        public string IMAGE_TYPE { get; set; }

        [Display(Name = "IMAGE NAME")]
        public string IMAGE_NAME { get; set; }

        [Display(Name = "IMAGE PATH")]
        public string IMAGE_PATH { get; set; }

        [Display(Name = "IMAGE EXT")]
        public string IMAGE_EXT { get; set; }

        [Display(Name = "IMAGE BLOB")]
        public Byte[] IMAGE_BLOB { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string DESCRIPTION { get; set; }
        
        public long CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public long MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DATE { get; set; }
        public bool ISACTIVE { get; set; }


       // public  List<CmpLogo> dynamicParameter{ get; set;}
        //static string strConnectionString = "User Id=sa;password=SUPERSOFTWARE#1;Server=24.13.245.114;Database=HREmroll;";
     

    }
}

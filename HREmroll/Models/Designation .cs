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

        public int DESIGNATION_ID { get; set; }
        public long CMP_ID { get; set; }
        [Required]
        [Remote("Designtionduplication", "Home", AdditionalFields = "DESIGNATION_ID", ErrorMessage = "Please enter a valid Designation name.")]
        //[Remote(action: "Designtionduplication", controller: "Home",ErrorMessage ="Designation name in already exist")]

        public string DESIGNATION_NAME { get; set; }
        [Required]
        public string DESCRIPTION { get; set; }
        [Required]
        public int CREATED_BY { get; set; }
        [Required]

        public DateTime CREATED_DATE { get; set; }
        [Required]
        public int MODIFIED_BY { get; set; }
        [Required]
        public DateTime MODIFIED_DATE { get; set; }

        public bool ISACTIVE { get; set; }
        public string  Branch_name { get; set; }
        public int BRANCH_ID { get; set; }
        //public string StatementType { get; set; }
    }
}

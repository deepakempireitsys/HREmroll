using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class Bank
    {
        public long BANK_ID{ get; set; }
        [Required(ErrorMessage ="Compony Id is reqired")]
        [Display(Name = "Compony  ID")]

        public long CMP_ID { get; set; }

        [Required]
        [Display(Name = "Bank Name")]
        public string BANK_Name { get; set; }

        [Required(ErrorMessage = "Bank Code is reqired")]
        [Display(Name = "Bank Code")]

        public long BANK_CODE { get; set; }
        [Required]
        [Display(Name = "Bank Name")]
        public string BRANCH_NAME { get; set; }
        [Required]
        [Display(Name = "Account Number")]
        [RegularExpression(@"^\d{9,18}$", ErrorMessage = "Invalid Account Number, you need to enter minimum 9 and maximum 18 digits")]
        public string ACCOUNT_NUMBER { get; set; }
        [Required]
        [Display(Name = "Adderess")]
        public string ADDERESS { get; set; }
        [Required]
        [Display(Name = "City")]
        public string CITY { get; set; }
        [Required]
        [Display(Name = "Bank BSR Code")]
        public long BANK_BSR_CODE { get; set; }
        [Required]
        [Display(Name = "Bank IFSC Code")]
        //[RegularExpression(@"^[A-Za-z]{4}\d{7}$", ErrorMessage = "Invalid IFC Code.")]
        public string BANK_IFSC_CODE { get; set; }
        [Required]
        [Display(Name = "Defoult Bank")]
        public bool DEFAULT_BANK { get; set; }
        [Required]
        [Display(Name = "Created By")]
        public long CREATED_BY { get; set; }
        [Required]
        [Display(Name = "Created date")]
        public DateTime CREATED_DATE { get; set; }
        [Required]
        [Display(Name = "Modified By")]
        public long MODIFIED_BY { get; set; }
        [Required]
        [Display(Name = "Modified date")]
        public DateTime MODIFIED_DATE { get; set; }
        [Display(Name = "Is Active")]
        public bool ISACTIVE { get; set; }
        

    }
}

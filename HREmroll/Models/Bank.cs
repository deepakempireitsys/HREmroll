using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class Bank
    {
        public int BANK_ID{ get; set; }
        [Required(ErrorMessage ="Compony Id is reqired")]
        [Display(Name = "Compony  ID")]

        public int CMP_ID { get; set; }

        [Required]
        [Display(Name = "Bank Name")]
        public string BANK_Name { get; set; }

        [Required(ErrorMessage = "Bank Code is reqired")]
        [Display(Name = "Bank Code")]

        public int BANK_CODE { get; set; }
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
        public int BANK_BSR_CODE { get; set; }
        [Required]
        [Display(Name = "Bank IFSC Code")]
        [RegularExpression(@"^[A-Z]{4}0[A-Z0-9]{6}$", ErrorMessage = "Invalid IFC Code.")]
        public int BANK_IFSC_CODE { get; set; }
        //[Required]
        //[Display(Name = "Defoult Bank")]
        public bool DEFAULT_BANK { get; set; }
        [Required]
        [Display(Name = "Created By")]
        public int CREATED_BY { get; set; }
        [Required]
        [Display(Name = "Created date")]
        public DateTime CREATED_DATE { get; set; }
        [Required]
        [Display(Name = "Modified By")]
        public int MODIFIED_BY { get; set; }
        [Required]
        [Display(Name = "Modified date")]
        public DateTime MODIFIED_DATE { get; set; }
        [Display(Name = "Is Active")]
        public bool ISACTIVE { get; set; }
        

    }
}

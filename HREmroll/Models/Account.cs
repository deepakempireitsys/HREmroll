using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class Account
    {
        public int UserId { get; set; }
        public long CMP_ID { get; set; }

        public string CMP_NAME { get; set; }

        [Required(ErrorMessage = "Enter User Name")]
        [Display(Name = "User Name")]
        public string User_Name { get; set; }

        [Required(ErrorMessage = "Enter Password Name")]
        [Display(Name = "Password Name")]
        public string Password { get; set; }

       
        public string Email { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> LastLoginDate { get; set; }

        public bool RememberMe { get; set; }
    }
}

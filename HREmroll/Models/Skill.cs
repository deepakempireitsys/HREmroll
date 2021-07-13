using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class Skill
    {

        public int SKILL_ID { get; set; }

        [Display(Name = "Company Id")]
        [Required(ErrorMessage = "Must Select Company Id")]
        public Nullable<long> CMP_ID { get; set;}

        [Display(Name = "Skill name")]
        [Required(ErrorMessage ="Enter Skill Name")]
        public string SKILL_NAME { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string DESCRIPTION { get; set; }
        [Required]
        [Display(Name = "Created By")]
        public int CREATED_BY { get; set; }
        [Required]
        [Display(Name = "Created Date")]
        public DateTime CREATED_DATE { get; set; }
        [Required]
        [Display(Name = "Modified By")]
        public int MODIFIED_BY { get; set; }
        [Required]
        [Display(Name = "Modified Date")]
        public DateTime MODIFIED_DATE { get; set; }

        public bool ISACTIVE { get; set; }
        [Display(Name = "Company Name")]
        public string CMP_NAME { get; set; }
    }
}

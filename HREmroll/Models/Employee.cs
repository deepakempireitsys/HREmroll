using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class Employee
    {
		[Display(Name = "EMP ID")]
		public long EMP_ID { get; set; }

		[Display(Name = "CMP ID")]
		public	long  CMP_ID { get; set; }          
		
		[Display(Name = "INITIALS")]
		public	string  INITIALS { get; set; }          

		[Required (ErrorMessage ="Please enter first name")]
		[Display(Name = "FIRST NAME")]
		public	string FIRST_NAME { get; set; }			

		[Display(Name = "MIDDLE NAME")]
		public	string MIDDLE_NAME { get; set; }

		[Required(ErrorMessage = "Please enter last name")]
		[Display(Name = "LAST NAME")]
		public	string LAST_NAME { get; set; }          

		[Display(Name = "EMPLOYEE CODE PREFIX")]
		public	string EMPLOYEE_CODE_PREFIX { get; set; }

		[Required(ErrorMessage = "Please enter employee code")]
		[Display(Name = "EMPLOYEE CODE")]
		public Nullable<int> EMPLOYEE_CODE { get; set; }

		[Required(ErrorMessage = "Please select grade")]
		[Display(Name = "BRANCH")]
		public Nullable<int> BRANCH_ID { get; set; }

		[Required(ErrorMessage = "Please select grade")]
		[Display(Name = "GRADE")]
		public	Nullable<int> GRADE_ID { get; set; }          

		[Display(Name = "DATE OF JOINING")]
		public	DateTime DATE_OF_JOINING	{ get; set; }

		[Required(ErrorMessage = "Please select shift")]
		[Display(Name = "SHIFT")]
		public Nullable<int> SHIFT_ID { get; set; }

		[Required(ErrorMessage = "Please select designation")]
		[Display(Name = "DESIGNATION")]
		public Nullable<int> DESIGNATION_ID { get; set; }

		[Required(ErrorMessage = "Please select department")]
		[Display(Name = "DEPARTMENT")]
		public Nullable<int> DEPARTMENT_ID { get; set; }		

		[Display(Name = "EMP TYPE")]
		public	long EMP_TYPE_ID { get; set; }

		[Required(ErrorMessage = "Please select category")]
		[Display(Name = "CATEGORY")]
		public Nullable<int> CATEGORY_ID { get; set; }			

		[Display(Name = "REPORTING MANAGER")]
		public	long REPORTING_MANAGER_ID { get; set; }           

		[Display(Name = "ENROLL OR PUNCH CODE")]
		public	string ENROLL_OR_PUNCH_CODE { get; set; }           

		[Display(Name = "CTC")]
		public	long CTC { get; set; }

		[Required(ErrorMessage = "Please select sub branch")]
		[Display(Name = "SUB BRANCH")]
		public Nullable<int> SUB_BRANCH_ID { get; set; }			
		
		[Display(Name = "GROSS SALARY")]
		public	long GROSS_SALARY { get; set; }         

		[Display(Name = "LOGIN ALIAS")]
		public	string LOGIN_ALIAS { get; set; }           
		
		[Display(Name = "BASIC SALARY")]
		public	long BASIC_SALARY { get; set; }  
		
	    
		
		[Display(Name = "LATE MARK")]
		public	bool IS_LATE_MARK { get; set; }          
		
		[Display(Name = "ISEARLY MARK")]
		public bool IS_EARLY_MARK { get; set; }			

		[Display(Name = "ISFIX SALARY")]
		public bool IS_FIX_SALARY { get; set; }			

		[Display(Name = "ISPART TIME")]
		public bool IS_PART_TIME { get; set; }			

		[Display(Name = "PROBATION")] 
		public bool IS_PROBATION { get; set; }			

		[Display(Name = "ISTRAINEE")]
		public	bool IS_TRAINEE { get; set; }

		//[Required (ErrorMessage ="Please Upload Image")]
		[Display(Name = "IMAGE FILE NAME")]
		public string IMAGE_NAME { get; set; }          

		[Display(Name = "IMAGE TYPE")]
		public string IMAGE_TYPE { get; set; }          

		[Display(Name = "IMAGE PATH")]
		public string IMAGE_PATH { get; set; }         

		[Display(Name = "IMAGE EXT")]
		public string IMAGE_EXT { get; set; }         

		[Display(Name = "IMAGE BLOB")]
		public byte[] IMAGE_BLOB { get; set; }          


		[Display(Name = "DESCRIPTION ")]
		public String DESCRIPTION { get; set; }

		[Display(Name = "CREATED_BY")]
		public long CREATED_BY { get; set; }

		[Display(Name = "CREATED DATE")]
		public DateTime CREATED_DATE { get; set; }

		[Display(Name = "MODIFIED BY")]
		public long MODIFIED_BY { get; set; }

		[Display(Name = "MODIFIED DATE")]
		public DateTime MODIFIED_DATE { get; set; }

		[Display(Name = "ISACTIVE")]
		public	bool  ISACTIVE		{ get; set; }

		//[Required(ErrorMessage = "Please enter grade name")]
		//[Display(Name = "GRADE NAME")]
		//public string GRADE_NAME { get; set; }

		//[Required(ErrorMessage = "Please enter shift name")]
		//[Display(Name = "SHIFT NAME")]
		//public string SHIFT_NAME { get; set; }

		//[Required(ErrorMessage = "Please enter department name")]
		//[Display(Name = "DEPARTMENT NAME")]
		//public string DEPARTMENT_NAME { get; set; }

		//[Required(ErrorMessage = "Please enter category name")]
		//[Display(Name = "CATEGORY NAME")]
		//public string CATEGORY_NAME { get; set; }

		//[Required(ErrorMessage = "Please enter sub branch name")]
		//[Display(Name = "SUB BRANCH NAME")]
		//public string SUB_BRANCH_NAME { get; set; }

		//[Required(ErrorMessage = "Please enter branch name")]
		//[Display(Name = "BRANCH NAME")]
		//public string BRANCH_NAME { get; set; }

		//[Required(ErrorMessage = "Please enter designation name")]
		//[Display(Name = "DESIGNATION NAME")]
		//public string DESIGNATION_NAME { get; set; }
	}
}

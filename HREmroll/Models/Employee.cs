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

		[Display(Name = "FIRST NAME")]
		public	string FIRST_NAME { get; set; }			

		[Display(Name = "MIDDLE NAME")]
		public	string MIDDLE_NAME { get; set; }			

		[Display(Name = "LAST NAME")]
		public	string LAST_NAME { get; set; }          

		[Display(Name = "EMPLOYEE CODE PREFIX")]
		public	string EMPLOYEE_CODE_PREFIX { get; set; }            

		[Display(Name = "EMPLOYEE CODE")]
		public	long EMPLOYEE_CODE { get; set; }          

		[Display(Name = "BRANCH")]
		public	long BRANCH_ID { get; set; }         

		[Display(Name = "GRADE")]
		public	long GRADE_ID { get; set; }          

		[Display(Name = "DATE OF JOINING")]
		public	DateTime DATE_OF_JOINING	{ get; set; }			

		[Display(Name = "SHIFT")]
		public	long SHIFT_ID { get; set; }          

		[Display(Name = "DESIGNATION")]
		public	long DESIGNATION_ID { get; set; }           

		[Display(Name = "DEPARTMENT")]
		public	long DEPARTMENT_ID { get; set; }		

		[Display(Name = "EMP TYPE")]
		public	long EMP_TYPE_ID { get; set; }			

		[Display(Name = "CATEGORY")]
		public	long CATEGORY_ID { get; set; }			

		[Display(Name = "REPORTING MANAGER")]
		public	long REPORTING_MANAGER_ID { get; set; }           

		[Display(Name = "ENROLL OR PUNCH CODE")]
		public	string ENROLL_OR_PUNCH_CODE { get; set; }           

		[Display(Name = "CTC")]
		public	long CTC { get; set; }			

		[Display(Name = "SUB BRANCH")]
		public	long SUB_BRANCH_ID { get; set; }			
		
		[Display(Name = "GROSS SALARY")]
		public	long GROSS_SALARY { get; set; }         

		[Display(Name = "LOGIN ALIAS")]
		public	string LOGIN_ALIAS { get; set; }           
		
		[Display(Name = "BASIC SALARY")]
		public	long BASIC_SALARY { get; set; }  
		
		[Display(Name = "EMP PHOTO")]
		public byte[] EMP_PHOTO { get; set; }           
		
		[Display(Name = "EMP SIGNATURE")]
		public byte[] EMP_SIGNATURE { get; set; }           
		
		[Display(Name = "IS LATE MARK")]
		public	bool IS_LATE_MARK { get; set; }          
		
		[Display(Name = "IS EARLY MARK")]
		public bool IS_EARLY_MARK { get; set; }			

		[Display(Name = "IS FIX SALARY")]
		public bool IS_FIX_SALARY { get; set; }			

		[Display(Name = "IS PART TIME")]
		public bool IS_PART_TIME { get; set; }			

		[Display(Name = "IS PROBATION")] 
		public bool IS_PROBATION { get; set; }			

		[Display(Name = "IS TRAINEE")]
		public	bool IS_TRAINEE { get; set; }

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

		[Display(Name = "GRADE NAME")]
		public string GRADE_NAME { get; set; }

		[Display(Name = "SHIFT NAME")]
		public string SHIFT_NAME { get; set; }

		[Display(Name = "DEPARTMENT NAME")]
		public string DEPARTMENT_NAME { get; set; }

		[Display(Name = "CATEGORY NAME")]
		public string CATEGORY_NAME { get; set; }

		[Display(Name = "SUB BRANCH NAME")]
		public string SUB_BRANCH_NAME { get; set; }

		[Display(Name = "BRANCH NAME")]
		public string BRANCH_NAME { get; set; }

		[Display(Name = "DESIGNATION NAME")]
		public string DESIGNATION_NAME { get; set; }
	}
}

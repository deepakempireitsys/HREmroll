using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class Company
    {
		[Display(Name = "CMP ID")]
		public	long				CMP_ID			{ get; set; }           // NUMERIC(18,0) NULL,
		
		[Display(Name = "NAME")]
		public	string				CMP_NAME		{ get; set; }           // VARCHAR(500) NULL,

		[Display(Name = "ADDRESS")]
		public	string				CMP_ADDRESS		{ get; set; }			// VARCHAR(MAX) NULL,

		[Display(Name = "CITY")]
		public	string				CITY			{ get; set; }			// VARCHAR(50) NULL,  

		[Display(Name = "STATE")]
		public	string				STATE			{ get; set; }           // VARCHAR(50) NULL, 

		[Display(Name = "PINCODE")]
		public	string				PINCODE			{ get; set; }           // VARCHAR(10) NULL, 

		[Display(Name = "COUNTRY")]
		public	string				COUNTRY			{ get; set; }           // VARCHAR(50) NULL, 

		[Display(Name = "PHONE NO")]
		public	string				PHONENO			{ get; set; }           // VARCHAR(50) NULL, 

		[Display(Name = "E-MAIL")]
		public	string				EMAIL			{ get; set; }           // VARCHAR(500) NULL,

		[Display(Name = "DATE FORMAT")]
		public	string				DATEFORMAT		{ get; set; }			// VARCHAR(50) NULL,

		[Display(Name = "REG DATE")]
		public	DateTime			FROMDATE		{ get; set; }           // DATETIME NULL,

		[Display(Name = "WEB-SITE")]
		public	string				WEBSITE			{ get; set; }           // VARCHAR(500) NULL,

		[Display(Name = "PF TRUST NO")]
		public	string				PF_TRUST_NO		{ get; set; }			// VARCHAR(50)NULL,

		[Display(Name = "PF APPLICABLE")]
		public	bool				PF_APPLICABLE	{ get; set; }			// TINYINT NULL,

		[Display(Name = "ESIC APPLICABLE")]
		public	bool				ESIC_APPLICABLE	{ get; set; }			// TINYINT NULL, 

		[Display(Name = "TAN NO")]
		public	string				TAN_NO			{ get; set; }           // VARCHAR(50) NULL, 

		[Display(Name = "ESIC NO")]
		public	string				ESIC_NO			{ get; set; }           // VARCHAR(10) NULL, 

		[Display(Name = "COMPANY CODE")]
		public	string				COMPANY_CODE	{ get; set; }			// VARCHAR(50) NULL, 

		[Display(Name = "DOMAIN NAME")]
		public	string				DOMAIN_NAME		{ get; set; }			// VARCHAR(50) NULL,
		
		[Display(Name = "LWF NO")]
		public	string				LWF_NO			{ get; set; }           // VARCHAR(50) NULL, 

		[Display(Name = "LOGO FILE NAME")]
		public	string				LOGO_NAME		{ get; set; }           // VARCHAR(250) NULL,
		
		[Display(Name = "LOGO TYPE")]
		public	string				LOGO_TYPE		{ get; set; }           // VARCHAR(10) NULL,
		
		[Display(Name = "LOGO PATH")]
		public	string				LOGO_PATH		{ get; set; }           // VARCHAR(250) NULL,
		
		[Display(Name = "LOGO EXT")]
		public	string				LOGO_EXT		{ get; set; }           // VARCHAR(5) NULL,
		
		[Display(Name = "LOGO BLOB")]
		public	byte[]				LOGO_BLOB		{ get; set; }           // VARCHAR(MAX) NULL,
		
		[Display(Name = "DESCRIPTION")]
		//[DataType(DataType.MultilineText)]
		public	string				DESCRIPTION		{ get; set; }			// VARCHAR(500) NULL, 

		[Display(Name = "CREATED BY")]
		public	long				CREATED_BY		{ get; set; }			// NUMERIC(18,0) NULL, 

		[Display(Name = "CREATED DATE")]
		public DateTime				CREATED_DATE	{ get; set; }			// DATETIME NULL,

		[Display(Name = "MODIFIED BY")] 
		public	long				MODIFIED_BY		{ get; set; }			// NUMERIC(18,0) NULL,

		[Display(Name = "MODIFIED DATE")]
		public	DateTime			MODIFIED_DATE	{ get; set; }			// DATETIME NULL,

		[Display(Name = "ISACTIVE")]
		public	bool				ISACTIVE		{ get; set; }           // BIT NULL,


		//public string		ACTION{ get; set; }				// NVARCHAR(20) = ''

		//public CmpLogo Logo { get; set; }


	}
}

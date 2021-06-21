using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HREmroll.Models
{
    public class Shift
    {
		

		[Display(Name = "SHIFT ID")]
		public long SHIFT_ID				{ get; set; }

		[Display(Name = "Name")]
		public string SHIFT_NAME			{ get; set; }

		[Display(Name = "CMP ID")]
		[Required, Range(1, int.MaxValue, ErrorMessage = "Must Select Company")]
		public long CMP_ID					{ get; set; }

		[Display(Name = "Company")]
		public string CMP_NAME				{ get; set; }

		[Display(Name = "BR ID")]
		[Required, Range(1, int.MaxValue, ErrorMessage = "Must Select Branch")]
		public long BRANCH_ID				{ get; set; }

		[Display(Name = "Branch")]
		public string BRANCH_NAME			{ get; set; }

		[Display(Name = "DEP ID")]
		[Required, Range(1, int.MaxValue, ErrorMessage = "Must Select Department")]
		public long DEPARTMENT_ID			{ get; set; }

		[Display(Name = "DEP Name")]
		public string DEPARTMENT_NAME		{ get; set; }

		[Display(Name = "Shift Start Time")]
		public string SHIFT_START_TIME		{ get; set; }

		[Display(Name = "Shift End Time")]
		public string SHIFT_END_TIME		{ get; set; }

		[Display(Name = "Shift Duration")]
		public string SHIFT_DURATION		{ get; set; }

		[Display(Name = "Break1 Available")]
		public bool BREAK1					{ get; set; }

		[Display(Name = "Break1 Start Time")]
		public string BREAK1_START_TIME		{ get; set; }

		[Display(Name = "Break 1 End Time")]
		public string BREAK1_END_TIME		{ get; set; }

		[Display(Name = "Break1 Duration")]
		public string BREAK1_DURATION		{ get; set; }

		[Display(Name = "Break2 Available")]
		public bool BREAK2					{ get; set; }

		[Display(Name = "Break2 Start Time")]
		public string BREAK2_START_TIME		{ get; set; }

		[Display(Name = "Break 2 End Time")]
		public string BREAK2_END_TIME		{ get; set; }

		[Display(Name = "Break 2 Duration")]
		public string BREAK2_DURATION		{ get; set; }

		[Display(Name = "Break3 Available")]
		public bool BREAK3					{ get; set; }

		[Display(Name = "Break3 Start Time")]
		public string BREAK3_START_TIME		{ get; set; }

		[Display(Name = "Break 3 End Time")]
		public string BREAK3_END_TIME		{ get; set; }

		[Display(Name = "Break3 Duration")]
		public string BREAK3_DURATION		{ get; set; }

		[Display(Name = "Auto Shift Available")]
		public bool AUTO_SHIFT				{ get; set; }

		[Display(Name = "Half Day Available")]
		public bool HALF_DAY_ON				{ get; set; }

		[Display(Name = "Week Day")]
		public string HALF_DAY_OF_WEEK		{ get; set; }

		[Display(Name = "Half Day Start Time")]
		public string HALF_DAY_START_TIME	{ get; set; }

		[Display(Name = "Half Day End Time")]
		public string HALF_DAY_END_TIME		{ get; set; }

		[Display(Name = "Half Day Duration")]
		public string HALF_DAY_DURATION		{ get; set; }

		[Display(Name = "Min Working Hours")]
		public string HALF_DAY_MIN_HOURS	{ get; set; }

		[Display(Name = "DESCRIPTION")]
		public string DESCRIPTION			{ get; set; }

		[Display(Name = "CREATED BY")]
		public long CREATED_BY				{ get; set; }

		[Display(Name = "CREATED DATE")]
		public DateTime CREATED_DATE		{ get; set; }

		[Display(Name = "MODIFIED BY")]
		public long MODIFIED_BY				{ get; set; }

		[Display(Name = "MODIFIED DATE")]
		public DateTime MODIFIED_DATE		{ get; set; }

		[Display(Name = "IS ACTIVE")]
		public bool ISACTIVE				{ get; set; }

	}
}

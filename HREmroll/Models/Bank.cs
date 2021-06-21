using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Models
{
    public class Bank
    {
        public int BANK_ID{ get; set; }
        public int CMP_ID { get; set; }
        public string BANK_Name { get; set; }
        public int BANK_CODE { get; set; }
        public string BRANCH_NAME { get; set; }

        public string ACCOUNT_NUMBER { get; set; }
        public string ADDERESS { get; set; }
        public string CITY { get; set; }
        public int BANK_BSR_CODE { get; set; }
        public int BANK_IFSC_CODE { get; set; }
        public bool DEFAULT_BANK { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public int MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DATE { get; set; }
        public bool ISACTIVE { get; set; }
        

    }
}

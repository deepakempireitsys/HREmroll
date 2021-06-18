using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HREmroll.Globals
{
    public class GlobalData
    {
        public Int64 Current_Company_ID = 0;
        public int checkSession()
        {
            int i= 0;

            //i = Htt Session.GetString("CMP_ID");
            //HttpContext.Session.GetString("CMP_ID");
            Current_Company_ID = i;
            if (i > 0)
            {
                return i;
            }
            else
            {
                return 0;
            }
            
        }

    }
}

using Dapper;
using HREmroll.DAL;
using HREmroll.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Repository
{
    public class AcccountRepository
    {
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        public int LoginCheck(Account ad)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                int i = 0;
                i = _dapperAdapter.Execute("Emroll_UserLogin", param, commandType: CommandType.StoredProcedure);

                return i;
            }
            catch(Exception ex)
            {
                return 0;
                throw ex;
            }
            finally
            {

            }

        }
    }
}


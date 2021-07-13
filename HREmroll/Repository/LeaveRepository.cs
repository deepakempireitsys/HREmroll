using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HREmroll.Models;
using HREmroll.DAL;
using Microsoft.Extensions.Configuration;

namespace HREmroll.Repository
{
    public class LeaveRepository : DapperAdapter
    {
        public SqlConnection con;

        private DapperAdapter _dapperAdapter = null;

        public LeaveRepository(IConfiguration config)
        {
            _dapperAdapter = new DapperAdapter(config);
        }


        public int AddLeaveDetail(Leave objLeave)
        {

            try
            {
                DynamicParameters param = new DynamicParameters();

                //param.Add("@LEAVETYPE", objLeave.LEAVETYPE);
                param.Add("@DESCRIPTION", objLeave.DESCRIPTION);
                param.Add("@CMP_ID", objLeave.CMP_ID);
                param.Add("@BRANCH_ID", objLeave.BRANCH_ID);
                param.Add("@LEAVETYPE", objLeave.LEAVETYPE);
                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 1);
                param.Add("@StatementType", "Insert");

                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_LEAVE_MASTER", param, commandType: CommandType.StoredProcedure);

                return i;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            finally
            {

            }

        }
        //For View All Leave details with list       
        public List<Leave> GetAllLeaveDetails()
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Select");
                IList<Leave> AllLeaveList = _dapperAdapter.GetAll<Leave>("PROC_EMROLL_LEAVE_MASTER", param, CommandType.StoredProcedure).ToList();
                return AllLeaveList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public List<Leave> GetActiveLeave()
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                IList<Leave> AllLeaveList = _dapperAdapter.GetAll<Leave>("PROC_EMROLL_LEAVE_MASTER", param, CommandType.StoredProcedure).ToList();

                return AllLeaveList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }

        }
        public List<Leave> GetInActiveLeave()
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                IList<Leave> AllLeaveList = _dapperAdapter.GetAll<Leave>("PROC_EMROLL_LEAVE_MASTER", param, CommandType.StoredProcedure).ToList();
                return AllLeaveList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public Leave GetAllLeaveDetailsById(int id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@LEAVEID", id);
                param.Add("@StatementType", "ById");
                Leave obj = _dapperAdapter.Get<Leave>("PROC_EMROLL_LEAVE_MASTER", param, CommandType.StoredProcedure);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        //For Update Leave details      
        public int UpdateLeaveDetail(Leave objUpdate)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@LEAVEID", objUpdate.LEAVEID);
                param.Add("@CMP_ID", objUpdate.CMP_ID);
                param.Add("@BRANCH_ID", objUpdate.BRANCH_ID);
                //param.Add("@CREATED_BY", objUpdate.CREATED_BY);
                //param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", objUpdate.ISACTIVE);
                param.Add("@LEAVETYPE", objUpdate.LEAVETYPE);
                param.Add("@DESCRIPTION", objUpdate.DESCRIPTION);

                param.Add("@StatementType", "Update");

                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_LEAVE_MASTER", param, commandType: CommandType.StoredProcedure);

                return i;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            finally
            {

            }

        }
        //for Delete Leave details      
        public bool DeleteLeaveData(int id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@LEAVEID", id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);

                _dapperAdapter.Execute("PROC_EMROLL_LEAVE_MASTER", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {

            }
        }
    }
}

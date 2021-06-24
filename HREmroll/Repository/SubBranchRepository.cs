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
    public class SubBranchRepository: DapperAdapter
    {
        public SqlConnection con;

        private DapperAdapter _dapperAdapter = null;

        public SubBranchRepository(IConfiguration config)
        {
            _dapperAdapter = new DapperAdapter(config);
        }

        public int AddSBranchDetail(SubBranch objsbr)
        {

            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@CMP_ID", objsbr.CMP_ID);
                //param.Add("@CMP_NAME", objsbr.CMP_NAME);
                param.Add("@BRANCH_ID", objsbr.BRANCH_ID);
                param.Add("@SUB_BRANCH_NAME", objsbr.SUB_BRANCH_NAME);
                param.Add("@SUB_BRANCH_CODE", objsbr.SUB_BRANCH_CODE);
                param.Add("@DESCRIPTION", objsbr.DESCRIPTION);
                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 1);
                param.Add("@StatementType", "Insert");

                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_SUB_BRANCH_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public List<SubBranch> GetAllSBranch()
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Select");
                IList<SubBranch> AllSubBranchList = _dapperAdapter.GetAll<SubBranch>("PROC_EMROLL_SUB_BRANCH_MASTER", param, CommandType.StoredProcedure).ToList();
                return AllSubBranchList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public List<SubBranch> GetActiveSBranch()
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                IList<SubBranch> AllLeaveList = _dapperAdapter.GetAll<SubBranch>("PROC_EMROLL_SUB_BRANCH_MASTER", param, CommandType.StoredProcedure).ToList();

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
        public List<SubBranch> GetInActiveSbranch()
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                IList<SubBranch> AllLeaveList = _dapperAdapter.GetAll<SubBranch>("PROC_EMROLL_SUB_BRANCH_MASTER", param, CommandType.StoredProcedure).ToList();
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
        public SubBranch GetAllSBranchById(int id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SUB_BRANCH_ID", id);
                param.Add("@StatementType", "ById");
                SubBranch obj = _dapperAdapter.Get<SubBranch>("PROC_EMROLL_SUB_BRANCH_MASTER", param, CommandType.StoredProcedure);
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
        public int UpdateSBranch(SubBranch objUpdate)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SUB_BRANCH_ID", objUpdate.SUB_BRANCH_ID);
                param.Add("@CMP_ID", objUpdate.CMP_ID);
                param.Add("@BRANCH_ID", objUpdate.BRANCH_ID);
                param.Add("@SUB_BRANCH_NAME", objUpdate.SUB_BRANCH_NAME);
                param.Add("@SUB_BRANCH_CODE", objUpdate.SUB_BRANCH_CODE);
                param.Add("@DESCRIPTION", objUpdate.DESCRIPTION);
                param.Add("@CREATED_BY", objUpdate.CREATED_BY);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", objUpdate.ISACTIVE);
                

                param.Add("@StatementType", "Update");

                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_SUB_BRANCH_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public bool DeleteSBranch(int id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@SUB_BRANCH_ID", id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);

                _dapperAdapter.Execute("PROC_EMROLL_SUB_BRANCH_MASTER", param, commandType: CommandType.StoredProcedure);
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

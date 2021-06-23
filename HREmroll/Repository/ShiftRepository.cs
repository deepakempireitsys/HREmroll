using Dapper;
//using Microsoft.IdentityModel.Protocols;
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
    public class ShiftRepository
    {
        
        //To Handle connection related activities      
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public ShiftRepository(IConfiguration config)
        {
            _dapperAdapter = new DapperAdapter(config);
        }
        //private void connection()
        //{
        //    //    string constr = ConfigurationManager.ConnectionStrings["mySqlConnection"].ToString();
        //    string constr = "Data Source=24.13.245.114;Initial Catalog=HREmroll;User Id=sa;password=SUPERSOFTWARE#1;Persist Security Info=False";
        //    con = new SqlConnection(constr);
        //
        //}

        //To Add Branch details      
        public int Add(Shift obj)
        {

            //Additing the employess      
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();

                //param.Add("@SHIFT_ID"               , obj.SHIFT_ID );
                param.Add("@CMP_ID"                 , obj.CMP_ID);
                param.Add("@BRANCH_ID"              , obj.BRANCH_ID);
                param.Add("@DEPARTMENT_ID"          , obj.DEPARTMENT_ID);
                param.Add("@SHIFT_NAME"             , obj.SHIFT_NAME);
                param.Add("@SHIFT_START_TIME"       , obj.SHIFT_START_TIME);
                param.Add("@SHIFT_END_TIME"         , obj.SHIFT_END_TIME);
                param.Add("@SHIFT_DURATION"         , obj.SHIFT_DURATION);
                param.Add("@BREAK1"                 , obj.BREAK1);
                param.Add("@BREAK1_START_TIME"      , obj.BREAK1_START_TIME);
                param.Add("@BREAK1_END_TIME"        , obj.BREAK1_END_TIME);
                param.Add("@BREAK1_DURATION"        , obj.BREAK1_DURATION);
                param.Add("@BREAK2"                 , obj.BREAK2);
                param.Add("@BREAK2_START_TIME"      , obj.BREAK2_START_TIME);
                param.Add("@BREAK2_END_TIME"        , obj.BREAK2_END_TIME);
                param.Add("@BREAK2_DURATION"        , obj.BREAK2_DURATION);
                param.Add("@BREAK3"                 , obj.BREAK3);
                param.Add("@BREAK3_START_TIME"      , obj.BREAK3_START_TIME);
                param.Add("@BREAK3_END_TIME"        , obj.BREAK3_END_TIME);
                param.Add("@BREAK3_DURATION"        , obj.BREAK3_DURATION);
                param.Add("@AUTO_SHIFT"             , obj.AUTO_SHIFT);
                param.Add("@HALF_DAY_ON"            , obj.HALF_DAY_ON);
                param.Add("@HALF_DAY_OF_WEEK"       , obj.HALF_DAY_OF_WEEK);
                param.Add("@HALF_DAY_START_TIME"    , obj.HALF_DAY_START_TIME);
                param.Add("@HALF_DAY_END_TIME"      , obj.HALF_DAY_END_TIME);
                param.Add("@HALF_DAY_DURATION"      , obj.HALF_DAY_DURATION);
                param.Add("@HALF_DAY_MIN_HOURS"     , obj.HALF_DAY_MIN_HOURS);
                param.Add("@DESCRIPTION"            , obj.DESCRIPTION);
                param.Add("@CREATED_BY"             , 1);
                param.Add("@CREATED_DATE"           , DateTime.Now);
                param.Add("@MODIFIED_BY"            , 1);
                param.Add("@MODIFIED_DATE"          , DateTime.Now);
                param.Add("@ISACTIVE"               , 1);
                param.Add("@StatementType"          , "Insert");
                //con.Execute("PROC_EMROLL_SHIFT_MASTER", param, commandType: CommandType.StoredProcedure);
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_SHIFT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
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
        //To view employee details with generic list       
        public List<Shift> GetAll()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "All");
                //IList<Shift> ShiftList = SqlMapper.Query<Shift>(con, "PROC_EMROLL_SHIFT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Shift> ShiftList = _dapperAdapter.GetAll<Shift>("PROC_EMROLL_SHIFT_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return ShiftList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }


        public List<Shift> GetActive()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                //IList<Shift> ShiftList = SqlMapper.Query<Shift>(con, "PROC_EMROLL_SHIFT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Shift> ShiftList = _dapperAdapter.GetAll<Shift>("PROC_EMROLL_SHIFT_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return ShiftList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }


        public List<Shift> GetInActive()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                //IList<Shift> ShiftList = SqlMapper.Query<Shift>(con, "PROC_EMROLL_SHIFT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Shift> ShiftList = _dapperAdapter.GetAll<Shift>("PROC_EMROLL_SHIFT_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return ShiftList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }

        public Shift GetByID(long id)
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@SHIFT_ID", id);
                param.Add("@StatementType", "ById");
                //IList<Shift> ShiftList = SqlMapper.Query<Shift>(con, "PROC_EMROLL_SHIFT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                Shift obj = _dapperAdapter.Get<Shift>("PROC_EMROLL_SHIFT_MASTER", param, CommandType.StoredProcedure);
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


        //To Update Branch details      
        public int Update(Shift obj)
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@SHIFT_ID"               , obj.SHIFT_ID );
                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@BRANCH_ID", obj.BRANCH_ID);
                param.Add("@DEPARTMENT_ID", obj.DEPARTMENT_ID);
                param.Add("@SHIFT_NAME", obj.SHIFT_NAME);
                param.Add("@SHIFT_START_TIME", obj.SHIFT_START_TIME);
                param.Add("@SHIFT_END_TIME", obj.SHIFT_END_TIME);
                param.Add("@SHIFT_DURATION", obj.SHIFT_DURATION);
                param.Add("@BREAK1", obj.BREAK1);
                param.Add("@BREAK1_START_TIME", obj.BREAK1_START_TIME);
                param.Add("@BREAK1_END_TIME", obj.BREAK1_END_TIME);
                param.Add("@BREAK1_DURATION", obj.BREAK1_DURATION);
                param.Add("@BREAK2", obj.BREAK2);
                param.Add("@BREAK2_START_TIME", obj.BREAK2_START_TIME);
                param.Add("@BREAK2_END_TIME", obj.BREAK2_END_TIME);
                param.Add("@BREAK2_DURATION", obj.BREAK2_DURATION);
                param.Add("@BREAK3", obj.BREAK3);
                param.Add("@BREAK3_START_TIME", obj.BREAK3_START_TIME);
                param.Add("@BREAK3_END_TIME", obj.BREAK3_END_TIME);
                param.Add("@BREAK3_DURATION", obj.BREAK3_DURATION);
                param.Add("@AUTO_SHIFT", obj.AUTO_SHIFT);
                param.Add("@HALF_DAY_ON", obj.HALF_DAY_ON);
                param.Add("@HALF_DAY_OF_WEEK", obj.HALF_DAY_OF_WEEK);
                param.Add("@HALF_DAY_START_TIME", obj.HALF_DAY_START_TIME);
                param.Add("@HALF_DAY_END_TIME", obj.HALF_DAY_END_TIME);
                param.Add("@HALF_DAY_DURATION", obj.HALF_DAY_DURATION);
                param.Add("@HALF_DAY_MIN_HOURS", obj.HALF_DAY_MIN_HOURS);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);
                param.Add("@CREATED_BY", obj.CREATED_BY);
                param.Add("@CREATED_DATE", obj.CREATED_DATE);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", obj.ISACTIVE);
                param.Add("@StatementType", "Update");
                //con.Execute("PROC_EMROLL_SHIFT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_SHIFT_MASTER", param, commandType: CommandType.StoredProcedure);

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
        //To delete Branch details      
        public bool Delete(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@SHIFT_ID", Id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_SHIFT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_SHIFT_MASTER", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //Log error as per your need       
                throw ex;
            }
            finally
            {

            }
        }
    }
}

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
    public class HolidayRepository : DapperAdapter 
    {
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public HolidayRepository(IConfiguration config)
        {
            _dapperAdapter = new DapperAdapter(config);
        }
        //private void connection()
        //{
            //    string constr = ConfigurationManager.ConnectionStrings["mySqlConnection"].ToString();
            //string constr = "Data Source=24.13.245.114;Initial Catalog=HREmroll;User Id=sa;password=SUPERSOFTWARE#1;Persist Security Info=False";
            //con = new SqlConnection(constr);

        //}

        //To Add Branch details      
        public int AddHoliday(Holiday obj)
        {

            //Additing the employess      
            try
            {
                
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //param.Add("@Holiday_ID", objEmp.Holiday_ID);
                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@HOLIDAY_NAME", obj.HOLIDAY_NAME);
                param.Add("@BRANCH_ID", obj.BRANCH_ID);
                param.Add("@MULTIPLE_HOLIDAY", obj.MULTIPLE_HOLIDAY);
                param.Add("@HOLIDAY_DATE", obj.HOLIDAY_DATE);
                param.Add("@MESSAGE_TEXT", obj.MESSAGE_TEXT);
                param.Add("@HOLIDAY_CATEGORY", obj.HOLIDAY_CATEGORY);
                param.Add("@REPEAT_ANNUALLY", obj.REPEAT_ANNUALLY);
                param.Add("@HALF_DAY", obj.HALF_DAY);
                param.Add("@PRESENT_COMPLUSARY", obj.PRESENT_COMPLUSARY);
                param.Add("@SMS", obj.SMS);
                param.Add("@OPTIONAL_HOLIDAY", obj.OPTIONAL_HOLIDAY);
                param.Add("@ISACTIVE", 1);
                param.Add("@StatementType", "Insert");
                //con.Execute("PROC_EMROLL_Holiday_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_Holiday_MASTER", param, commandType: CommandType.StoredProcedure);
                
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
        public List<Holiday> GetAllHolidays()
           
        {
            try
            {
                

                DynamicParameters param = new DynamicParameters();
                
                param.Add("@StatementType", "All");
                
                IList<Holiday> HolidayList = _dapperAdapter.GetAll<Holiday>("PROC_EMROLL_Holiday_MASTER", param, CommandType.StoredProcedure).ToList();
                return HolidayList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
            }
        }


        public List<Holiday> GetActiveHolidays()
        {
            try
            {
                
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                IList<Holiday> HolidayList = _dapperAdapter.GetAll<Holiday>("PROC_EMROLL_Holiday_MASTER", param, CommandType.StoredProcedure).ToList();
                return HolidayList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
            }

        }


        public List<Holiday> GetInActiveHolidays()
        {
            try
            {
               
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                IList<Holiday> HolidayList = _dapperAdapter.GetAll<Holiday>("PROC_EMROLL_Holiday_MASTER", param, CommandType.StoredProcedure).ToList();
                return HolidayList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
            }
        }

        public Holiday GetByID(long id)
        {
            try
            {
               
                DynamicParameters param = new DynamicParameters();
                param.Add("@Holiday_ID", id);
                param.Add("@StatementType", "ById");
                
                Holiday obj = _dapperAdapter.Get<Holiday>("PROC_EMROLL_Holiday_MASTER", param, CommandType.StoredProcedure);
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
        public int UpdateHoliday(Holiday obj)
        {
            try
            {
                
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Holiday_ID", obj.Holiday_ID);
                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@HOLIDAY_NAME", obj.HOLIDAY_NAME);
                param.Add("@STATE", obj.STATE);
                param.Add("@MULTIPLE_HOLIDAY", obj.MULTIPLE_HOLIDAY);
                param.Add("@HOLIDAY_DATE", obj.HOLIDAY_DATE);
                param.Add("@MESSAGE_TEXT", obj.MESSAGE_TEXT);
                param.Add("@HOLIDAY_CATEGORY", obj.HOLIDAY_CATEGORY);
                param.Add("@REPEAT_ANNUALLY", obj.REPEAT_ANNUALLY);
                param.Add("@HALF_DAY", obj.HALF_DAY);
                param.Add("@PRESENT_COMPLUSARY", obj.PRESENT_COMPLUSARY);
                param.Add("@SMS", obj.SMS);
                param.Add("@OPTIONAL_HOLIDAY", obj.OPTIONAL_HOLIDAY);
                param.Add("@ISACTIVE", obj.ISACTIVE);
                param.Add("@StatementType", "Update");
               
                int i = 0;
                i =_dapperAdapter.Execute("PROC_EMROLL_Holiday_MASTER", param, commandType: CommandType.StoredProcedure);
                
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
        public bool DeleteHoliday(int Id)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_Holiday_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_Holiday_MASTER", param, commandType: CommandType.StoredProcedure);
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

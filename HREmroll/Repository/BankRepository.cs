using HREmroll.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using HREmroll.Models;
using Dapper;
using System.Data;

namespace HREmroll.Repository
{
    public class BankRepository
    {

        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public BankRepository(IConfiguration config)
        {
            _dapperAdapter = new DapperAdapter(config);
        }
        public List<Bank> GetAllBank()
        {
            try
            {


                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "All");


                IList<Bank>Bankslist = _dapperAdapter.GetAll<Bank>("PROC_EMROLL_BANK_MASTER", param, CommandType.StoredProcedure).ToList();
                return Bankslist.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public List<Bank> GetActiveBank()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Bank> Bankslist = _dapperAdapter.GetAll<Bank>("PROC_EMROLL_BANK_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return Bankslist.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }

        }
        public List<Bank> GetInActiveBank()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Bank> Bankslist = _dapperAdapter.GetAll<Bank>("PROC_EMROLL_BANK_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return Bankslist.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public int AddBank(Bank obj)
        {

            //Additing the employess      
            try
            {

                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //param.Add("@DEPARTMENT_ID", objEmp.DEPARTMENT_ID);
                param.Add("@CMP_ID", obj.CMP_ID);
   
                param.Add("@BANK_NAME", obj.BANK_Name);
                param.Add("@BANK_CODE", obj.BANK_CODE);
                param.Add("@BRANCH_NAME", obj.BRANCH_NAME);
                param.Add("@ACCOUNT_NUMBER", obj.ACCOUNT_NUMBER);
                param.Add("@ADDERESS", obj.ADDERESS);

                param.Add("@CITY", obj.CITY);
                param.Add("@BANK_BSR_CODE", obj.BANK_BSR_CODE);
                param.Add("@BANK_IFSC_CODE", obj.BANK_IFSC_CODE);
                param.Add("@DEFAULT_BANK", obj.DEFAULT_BANK);
                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 1);
                param.Add("@StatementType", "Insert");
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_BANK_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public List<Bank> GrupbyidBank()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ById");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Bank> Banklist = _dapperAdapter.GetAll<Bank>("PROC_EMROLL_BANK_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return Banklist.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public int UpdateBank(Bank obj)
        {
            try
            {

                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //DynamicParameters param = new DynamicParameters();
                param.Add("@Bank_ID", obj.BANK_ID);
                param.Add("@CMP_ID", obj.CMP_ID);

                param.Add("@BANK_NAME", obj.BANK_Name);
                param.Add("@BANK_CODE", obj.BANK_CODE);
                param.Add("@BRANCH_NAME", obj.BRANCH_NAME);
                param.Add("@ACCOUNT_NUMBER", obj.ACCOUNT_NUMBER);
                param.Add("@ADDERESS", obj.ADDERESS);

                param.Add("@CITY", obj.CITY);
                param.Add("@BANK_BSR_CODE", obj.BANK_BSR_CODE);
                param.Add("@BANK_IFSC_CODE", obj.BANK_IFSC_CODE);
                param.Add("@DEFAULT_BANK", obj.DEFAULT_BANK);
                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", obj.ISACTIVE);
        
                param.Add("@StatementType", "Update");
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_BANK_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public bool DeleteBank(int Id)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@BANK_ID", Id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_BANK_MASTER", param, commandType: CommandType.StoredProcedure);
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

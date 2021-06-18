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
    public class DepartmentRepository : DapperAdapter 
    {
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public DepartmentRepository(IConfiguration config)
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
        public int AddDepartment(Department obj)
        {

            //Additing the employess      
            try
            {
                
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //param.Add("@DEPARTMENT_ID", objEmp.DEPARTMENT_ID);
                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@BRANCH_ID", obj.BRANCH_ID);
                param.Add("@DEPARTMENT_NAME", obj.DEPARTMENT_NAME);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);
                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 1);
                param.Add("@StatementType", "Insert");
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                
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
        public List<Department> GetAllDepartments()
            //public List<Department> GetAllDepartments(long CMP_ID, long BRANCH_ID)
        {
            try
            {
                //connection();
                //con.Open();
                //DynamicParameters param = new DynamicParameters();
                //param.Add("@StatementType", "All");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(
                //                  con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                //return DepartmentList.ToList();

                DynamicParameters param = new DynamicParameters();
                //param.Add("@CMP_ID", CMP_ID);
                //param.Add("@BRANCH_ID", BRANCH_ID);
                param.Add("@StatementType", "All");
                
                IList<Department> DepartmentList = _dapperAdapter.GetAll<Department>("PROC_EMROLL_DEPARTMENT_MASTER", param, CommandType.StoredProcedure).ToList();
                return DepartmentList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
            }
        }


        public List<Department> GetActiveDepartments()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Department> DepartmentList = _dapperAdapter.GetAll<Department>("PROC_EMROLL_DEPARTMENT_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return DepartmentList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
            }

        }


        public List<Department> GetInActiveDepartments()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Department> DepartmentList = _dapperAdapter.GetAll<Department>("PROC_EMROLL_DEPARTMENT_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return DepartmentList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
            }
        }

        public Department GetByID(long id)
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@DEPARTMENT_ID", id);
                param.Add("@StatementType", "ById");
                //IList<Company> CompanyList = SqlMapper.Query<Company>(con, "PROC_EMROLL_COMPANY_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                Department obj = _dapperAdapter.Get<Department>("PROC_EMROLL_DEPARTMENT_MASTER", param, CommandType.StoredProcedure);
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
        public int UpdateDepartment(Department obj)
        {
            try
            {
                
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //DynamicParameters param = new DynamicParameters();
                param.Add("@DEPARTMENT_ID", obj.DEPARTMENT_ID);
                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@BRANCH_ID", obj.BRANCH_ID);
                param.Add("@DEPARTMENT_NAME", obj.DEPARTMENT_NAME);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);
                param.Add("@CREATED_BY", obj.CREATED_BY);
                param.Add("@CREATED_DATE", obj.CREATED_DATE);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", obj.ISACTIVE);
                param.Add("@StatementType", "Update");
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i =_dapperAdapter.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                
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
        public bool DeleteDepartment(int Id)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@DEPARTMENT_ID", Id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
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

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
    public class EmployeeRepository : DapperAdapter 
    {
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public EmployeeRepository(IConfiguration config)
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
        public int AddEmployee(Employee obj)
        {

               
            try
            {
                DynamicParameters Param = new DynamicParameters();
                Param.Add("@CMP_ID",obj.CMP_ID);
	            Param.Add("@INITIALS",obj.INITIALS);
	            Param.Add("@FIRST_NAME", obj.FIRST_NAME);
                Param.Add("@MIDDLE_NAME",obj.MIDDLE_NAME);
                Param.Add("@LAST_NAME", obj.LAST_NAME);
                Param.Add("@EMPLOYEE_CODE_PREFIX", obj.EMPLOYEE_CODE_PREFIX);
                Param.Add("@EMPLOYEE_CODE", obj.EMPLOYEE_CODE);
                Param.Add("@BRANCH_ID", obj.BRANCH_ID);
                Param.Add("@GRADE_ID", obj.GRADE_ID);
                Param.Add("@DATE_OF_JOINING", obj.DATE_OF_JOINING);
                Param.Add("@SHIFT_ID", obj.SHIFT_ID);
                Param.Add("@DESIGNATION_ID", obj.DESIGNATION_ID);
                Param.Add("@DEPARTMENT_ID", obj.DEPARTMENT_ID);
                Param.Add("@EMP_TYPE_ID", obj.EMP_TYPE_ID);
                Param.Add("@CATEGORY_ID",obj.CATEGORY_ID);
	            Param.Add("@REPORTING_MANAGER_ID",obj.REPORTING_MANAGER_ID);
                Param.Add("@ENROLL_OR_PUNCH_CODE",obj.ENROLL_OR_PUNCH_CODE);
                Param.Add("@CTC", obj.CTC);
                Param.Add("@SUB_BRANCH_ID", obj.SUB_BRANCH_ID);
                Param.Add("@GROSS_SALARY",obj.GROSS_SALARY);
                Param.Add("@LOGIN_ALIAS", obj.LOGIN_ALIAS);
                Param.Add("@BASIC_SALARY",obj.BASIC_SALARY);
                Param.Add("@EMP_PHOTO", obj.EMP_PHOTO);
                Param.Add("@EMP_SIGNATURE", obj.EMP_SIGNATURE);
                Param.Add("@IS_LATE_MARK", obj.IS_LATE_MARK);
                Param.Add("@IS_EARLY_MARK", obj.IS_EARLY_MARK);
                Param.Add("@IS_FIX_SALARY", obj.IS_FIX_SALARY);
                Param.Add("@IS_PART_TIME", obj.IS_PART_TIME);
                Param.Add("@IS_PROBATION", obj.IS_PROBATION);
                Param.Add("@IS_TRAINEE", obj.IS_TRAINEE);
                Param.Add("@DESCRIPTION", obj.DESCRIPTION);
                Param.Add("@CREATED_BY", 1);
                Param.Add("@CREATED_DATE", DateTime.Now);
                Param.Add("@MODIFIED_BY",1);
                Param.Add("@MODIFIED_DATE", DateTime.Now);
                Param.Add("@ISACTIVE",1);
                Param.Add("@StatementType", "Insert");
               
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_EMPLOYEE_MASTER", Param, commandType: CommandType.StoredProcedure);
                
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
        public List<Employee> GetAllEmployees()
            
        {
            try
            {
               

                DynamicParameters param = new DynamicParameters();
               
                param.Add("@StatementType", "All");
                
                IList<Employee> EmployeeList = _dapperAdapter.GetAll<Employee>("PROC_EMROLL_EMPLOYEE_MASTER", param, CommandType.StoredProcedure).ToList();
                return EmployeeList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
            }
        }


        public List<Employee> GetActiveEmployees()
        {
            try
            {
                
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                IList<Employee> EmployeeList = _dapperAdapter.GetAll<Employee>("PROC_EMROLL_EMPLOYEE_MASTER", param, CommandType.StoredProcedure).ToList();
                return EmployeeList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
            }

        }


        public List<Employee> GetInActiveEmployees()
        {
            try
            {
                
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                IList<Employee> EmployeeList = _dapperAdapter.GetAll<Employee>("PROC_EMROLL_EMPLOYEE_MASTER", param, CommandType.StoredProcedure).ToList();
                return EmployeeList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
            }
        }

        public Employee GetByID(long id)
        {
            try
            {
                
                DynamicParameters param = new DynamicParameters();
                param.Add("@Employee_ID", id);
                param.Add("@StatementType", "ById");
                
                Employee obj = _dapperAdapter.Get<Employee>("PROC_EMROLL_EMPLOYEE_MASTER", param, CommandType.StoredProcedure);
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
        public int UpdateEmployee(Employee obj)
        {
            try
            {
                
                
                DynamicParameters Param = new DynamicParameters();
               
                Param.Add("@CMP_ID", obj.CMP_ID);
                Param.Add("@INITIALS", obj.INITIALS);
                Param.Add("@FIRST_NAME", obj.FIRST_NAME);
                Param.Add("@MIDDLE_NAME", obj.MIDDLE_NAME);
                Param.Add("@LAST_NAME", obj.LAST_NAME);
                Param.Add("@EMPLOYEE_CODE_PREFIX", obj.EMPLOYEE_CODE_PREFIX);
                Param.Add("@EMPLOYEE_CODE", obj.EMPLOYEE_CODE);
                Param.Add("@BRANCH_ID", obj.BRANCH_ID);
                Param.Add("@GRADE_ID", obj.GRADE_ID);
                Param.Add("@DATE_OF_JOINING", obj.DATE_OF_JOINING);
                Param.Add("@SHIFT_ID", obj.SHIFT_ID);
                Param.Add("@DESIGNATION_ID", obj.DESIGNATION_ID);
                Param.Add("@DEPARTMENT_ID", obj.DEPARTMENT_ID);
                Param.Add("@EMP_TYPE_ID", obj.EMP_TYPE_ID);
                Param.Add("@CATEGORY_ID", obj.CATEGORY_ID);
                Param.Add("@REPORTING_MANAGER_ID", obj.REPORTING_MANAGER_ID);
                Param.Add("@ENROLL_OR_PUNCH_CODE", obj.ENROLL_OR_PUNCH_CODE);
                Param.Add("@CTC", obj.CTC);
                Param.Add("@SUB_BRANCH_ID", obj.SUB_BRANCH_ID);
                Param.Add("@GROSS_SALARY", obj.GROSS_SALARY);
                Param.Add("@LOGIN_ALIAS", obj.LOGIN_ALIAS);
                Param.Add("@BASIC_SALARY", obj.BASIC_SALARY);
                Param.Add("@EMP_PHOTO", obj.EMP_PHOTO);
                Param.Add("@EMP_SIGNATURE", obj.EMP_SIGNATURE);
                Param.Add("@IS_LATE_MARK", obj.IS_LATE_MARK);
                Param.Add("@IS_EARLY_MARK", obj.IS_EARLY_MARK);
                Param.Add("@IS_FIX_SALARY", obj.IS_FIX_SALARY);
                Param.Add("@IS_PART_TIME", obj.IS_PART_TIME);
                Param.Add("@IS_PROBATION", obj.IS_PROBATION);
                Param.Add("@IS_TRAINEE", obj.IS_TRAINEE);
                Param.Add("@DESCRIPTION", obj.DESCRIPTION);
                Param.Add("@CREATED_BY", 1);
                Param.Add("@CREATED_DATE", DateTime.Now);
                Param.Add("@MODIFIED_BY", 1);
                Param.Add("@MODIFIED_DATE", DateTime.Now);
                Param.Add("@ISACTIVE", 1);
                Param.Add("@StatementType", "Update");
                int i = 0;
                i =_dapperAdapter.Execute("PROC_EMROLL_EMPLOYEE_MASTER", Param, commandType: CommandType.StoredProcedure);
                
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
        public bool DeleteEmployee(int Id)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@Employee_ID", Id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_EMPLOYEE_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_EMPLOYEE_MASTER", param, commandType: CommandType.StoredProcedure);
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

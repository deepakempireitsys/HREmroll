using Dapper;
using HREmroll.DAL;
using HREmroll.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Repository
{
    public class DesignationRepository
    {
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public DesignationRepository(IConfiguration config)
        {
            _dapperAdapter = new DapperAdapter(config);
        }
        //
        public List<Designation> GetAllDesignation()
        {
            try
            {


                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "All");

              
                IList<Designation> Designationlist = _dapperAdapter.GetAll<Designation>("PROC_EMROLL_DESIGNATION_MASTER", param, CommandType.StoredProcedure).ToList();
                return Designationlist.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public List<Designation> GetActiveDesignation()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Designation> Designationlist = _dapperAdapter.GetAll<Designation>("PROC_EMROLL_DESIGNATION_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return Designationlist.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }

        }
        public List<Designation> GetInActiveDesignation()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Designation> Designationlist = _dapperAdapter.GetAll<Designation>("PROC_EMROLL_DESIGNATION_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return Designationlist.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }

        public List<Designation>GrupbyidDesignation()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ById");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Designation> Designationlist = _dapperAdapter.GetAll<Designation>("PROC_EMROLL_DESIGNATION_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return Designationlist.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public int AddDesignation(Designation obj)
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
                param.Add("@DESIGNATION_NAME", obj.DESIGNATION_NAME);
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
                i = _dapperAdapter.Execute("PROC_EMROLL_DESIGNATION_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public int UpdateDesignation(Designation obj)
        {
            try
            {

                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //DynamicParameters param = new DynamicParameters();
                param.Add("@DESIGNATION_ID", obj.DESIGNATION_ID);
                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@BRANCH_ID", obj.BRANCH_ID);
                param.Add("@DESIGNATION_NAME", obj.DESIGNATION_NAME);
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
                i = _dapperAdapter.Execute("PROC_EMROLL_DESIGNATION_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public bool DeleteDesignation(int Id)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@DESIGNATION_ID", Id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_DESIGNATION_MASTER", param, commandType: CommandType.StoredProcedure);
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

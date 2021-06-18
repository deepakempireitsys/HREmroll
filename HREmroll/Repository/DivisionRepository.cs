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
    public class DivisionRepository
    {
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public DivisionRepository(IConfiguration config)
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
        public int AddDivision(Division obj)
        {

            //Additing the employess      
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                
                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@BRANCH_ID", obj.BRANCH_ID);
                param.Add("@DIVISION_NAME", obj.DIVISION_NAME);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);
                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 1);
                param.Add("@StatementType", "Insert");
                //con.Execute("PROC_EMROLL_DIVISION_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
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
        public List<Division> GetAllDivisions()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "All");
                //IList<Division> DivisionList = SqlMapper.Query<Division>(con, "PROC_EMROLL_DIVISION_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                IList<Division> DivisionList = _dapperAdapter.GetAll<Division>("PROC_EMROLL_DIVISION_MASTER", param, CommandType.StoredProcedure).ToList();
                return DivisionList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }


        public List<Division> GetActiveDivisions()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                //IList<Division> DivisionList = SqlMapper.Query<Division>(con, "PROC_EMROLL_DIVISION_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                IList<Division> DivisionList = _dapperAdapter.GetAll<Division>("PROC_EMROLL_DIVISION_MASTER", param, CommandType.StoredProcedure).ToList();
                return DivisionList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }


        public List<Division> GetInActiveDivisions()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                //IList<Division> DivisionList = SqlMapper.Query<Division>(con, "PROC_EMROLL_DIVISION_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                IList<Division> DivisionList = _dapperAdapter.GetAll<Division>("PROC_EMROLL_DIVISION_MASTER", param, CommandType.StoredProcedure).ToList();
                return DivisionList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }


        public Division GetByID(long id)
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@DIVISION_ID", id);
                param.Add("@StatementType", "ById");
                //IList<Division> DivisionList = SqlMapper.Query<Division>(con, "PROC_EMROLL_DIVISION_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                Division obj = _dapperAdapter.Get<Division>("PROC_EMROLL_DIVISION_MASTER", param, CommandType.StoredProcedure);
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
        public int UpdateDivision(Division obj)
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@DIVISION_ID", obj.DIVISION_ID);
                param.Add("@BRANCH_ID", obj.BRANCH_ID);
                param.Add("@DIVISION_NAME", obj.DIVISION_NAME);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);
                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", obj.ISACTIVE);
                param.Add("@StatementType", "Update");
                //con.Execute("PROC_EMROLL_DIVISION_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_DIVISION_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public bool DeleteDivision(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@DIVISION_ID", Id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_DIVISION_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_DIVISION_MASTER", param, commandType: CommandType.StoredProcedure);
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

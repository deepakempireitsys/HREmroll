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
    public class CmpLogoRepository : DapperAdapter 
    {
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public CmpLogoRepository(IConfiguration config)
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
        public int AddCmpLogo(CmpLogo obj)
        {

            //Additing the employess      
            try
            {
                
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //param.Add("@IMAGE_ID", objEmp.IMAGE_ID);
                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@IMAGE_NAME", obj.IMAGE_NAME);
                param.Add("@IMAGE_EXT", obj.IMAGE_EXT);
                param.Add("@IMAGE_TYPE", obj.IMAGE_TYPE);
                param.Add("@IMAGE_PATH", obj.IMAGE_PATH);
                param.Add("@IMAGE_BLOB", obj.IMAGE_BLOB);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);
                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 1);
                param.Add("@StatementType", "Insert");
                //con.Execute("PROC_EMROLL_COMPANY_LOGO", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_COMPANY_LOGO", param, commandType: CommandType.StoredProcedure);
                
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
        public List<CmpLogo> GetAllCmpLogos()
            //public List<CmpLogo> GetAllCmpLogos(long CMP_ID, long BRANCH_ID)
        {
            try
            {
                //connection();
                //con.Open();
                //DynamicParameters param = new DynamicParameters();
                //param.Add("@StatementType", "All");
                //IList<CmpLogo> CmpLogoList = SqlMapper.Query<CmpLogo>(
                //                  con, "PROC_EMROLL_COMPANY_LOGO", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                //return CmpLogoList.ToList();

                DynamicParameters param = new DynamicParameters();
                //param.Add("@CMP_ID", CMP_ID);
                //param.Add("@BRANCH_ID", BRANCH_ID);
                param.Add("@StatementType", "All");
                
                IList<CmpLogo> CmpLogoList = _dapperAdapter.GetAll<CmpLogo>("PROC_EMROLL_COMPANY_LOGO", param, CommandType.StoredProcedure).ToList();
                return CmpLogoList.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
            }
        }


        public List<CmpLogo> GetActiveCmpLogos()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                //IList<CmpLogo> CmpLogoList = SqlMapper.Query<CmpLogo>(con, "PROC_EMROLL_COMPANY_LOGO", param, commandType: CommandType.StoredProcedure).ToList();
                IList<CmpLogo> CmpLogoList = _dapperAdapter.GetAll<CmpLogo>("PROC_EMROLL_COMPANY_LOGO", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return CmpLogoList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
            }

        }


        public List<CmpLogo> GetInActiveCmpLogos()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                //IList<CmpLogo> CmpLogoList = SqlMapper.Query<CmpLogo>(con, "PROC_EMROLL_COMPANY_LOGO", param, commandType: CommandType.StoredProcedure).ToList();
                IList<CmpLogo> CmpLogoList = _dapperAdapter.GetAll<CmpLogo>("PROC_EMROLL_COMPANY_LOGO", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return CmpLogoList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
            }
        }

        public CmpLogo GetByID(long id)
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@IMAGE_ID", id);
                param.Add("@StatementType", "ById");
                //IList<Company> CompanyList = SqlMapper.Query<Company>(con, "PROC_EMROLL_COMPANY_LOGO", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                CmpLogo obj = _dapperAdapter.Get<CmpLogo>("PROC_EMROLL_COMPANY_LOGO", param, CommandType.StoredProcedure);
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
        public int UpdateCmpLogo(CmpLogo obj)
        {
            try
            {
                
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //DynamicParameters param = new DynamicParameters();
                param.Add("@IMAGE_ID", obj.IMAGE_ID);
                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@IMAGE_NAME", obj.IMAGE_NAME);
                param.Add("@IMAGE_EXT", obj.IMAGE_EXT);
                param.Add("@IMAGE_TYPE", obj.IMAGE_TYPE);
                param.Add("@IMAGE_PATH", obj.IMAGE_PATH);
                param.Add("@IMAGE_BLOB", obj.IMAGE_BLOB);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);
                param.Add("@CREATED_BY", obj.CREATED_BY);
                param.Add("@CREATED_DATE", obj.CREATED_DATE);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", obj.ISACTIVE);
                param.Add("@StatementType", "Update");
                //con.Execute("PROC_EMROLL_COMPANY_LOGO", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i =_dapperAdapter.Execute("PROC_EMROLL_COMPANY_LOGO", param, commandType: CommandType.StoredProcedure);
                
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
        public bool DeleteCmpLogo(int Id)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@IMAGE_ID", Id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_COMPANY_LOGO", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_COMPANY_LOGO", param, commandType: CommandType.StoredProcedure);
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

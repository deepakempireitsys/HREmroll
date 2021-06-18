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
    public class CompanyRepository
    {
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public CompanyRepository(IConfiguration config)
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
        public int AddCompany(Company obj)
        {

            //Additing the employess      
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //param.Add("@Company_ID", objEmp.Company_ID);

                param.Add("@CMP_ID"             , obj.CMP_ID);
                param.Add("@CMP_NAME"           , obj.CMP_NAME);
                param.Add("@CMP_ADDRESS"        , obj.CMP_ADDRESS);
                param.Add("@CITY"               , obj.CITY);
                param.Add("@STATE"              , obj.STATE);
                param.Add("@PINCODE"            , obj.PINCODE);
                param.Add("@COUNTRY"            , obj.COUNTRY);
                param.Add("@PHONENO"            , obj.PHONENO);
                param.Add("@EMAIL"              , obj.EMAIL);
                param.Add("@DATEFORMAT"         , obj.DATEFORMAT);
                param.Add("@FROMDATE"           , obj.FROMDATE);
                param.Add("@WEBSITE"            , obj.WEBSITE);
                param.Add("@PF_TRUST_NO"        , obj.PF_TRUST_NO);
                param.Add("@PF_APPLICABLE"      , obj.PF_APPLICABLE);
                param.Add("@ESIC_APPLICABLE"    , obj.ESIC_APPLICABLE);
                param.Add("@TAN_NO"             , obj.TAN_NO);
                param.Add("@ESIC_NO"             , obj.ESIC_NO);
                param.Add("@DOMAIN_NAME"        , obj.DOMAIN_NAME);
                param.Add("@COMPANY_CODE"       , obj.COMPANY_CODE);
                param.Add("@LWF_NO"             , obj.LWF_NO);
                param.Add("@DESCRIPTION"        , obj.DESCRIPTION);
                param.Add("@CREATED_BY"         , -1);
                param.Add("@CREATED_DATE"       , DateTime.Now);
                param.Add("@MODIFIED_BY"        , -1);
                param.Add("@MODIFIED_DATE"      , DateTime.Now);
                param.Add("@ISACTIVE"           , 1);
                param.Add("@StatementType"      , "Insert");

                //con.Execute("PROC_EMROLL_COMPANY_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_COMPANY_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public List<Company> GetAllCompanys()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "All");
                //IList<Company> CompanyList = SqlMapper.Query<Company>(con, "PROC_EMROLL_COMPANY_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                IList<Company> CompanyList = _dapperAdapter.GetAll<Company>("PROC_EMROLL_COMPANY_MASTER", param, CommandType.StoredProcedure).ToList();
                return CompanyList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }


        public List<Company> GetActiveCompanys()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                //IList<Company> CompanyList = SqlMapper.Query<Company>(con, "PROC_EMROLL_COMPANY_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                IList<Company> CompanyList = _dapperAdapter.GetAll<Company>("PROC_EMROLL_COMPANY_MASTER", param, CommandType.StoredProcedure).ToList();
                return CompanyList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }


        public List<Company> GetInActiveCompanys()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                //IList<Company> CompanyList = SqlMapper.Query<Company>(con, "PROC_EMROLL_COMPANY_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                IList<Company> CompanyList = _dapperAdapter.GetAll<Company>("PROC_EMROLL_COMPANY_MASTER", param, CommandType.StoredProcedure).ToList();
                return CompanyList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }

        public Company GetByID(long id)
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@CMP_ID", id );
                param.Add("@StatementType", "ById");
                //IList<Company> CompanyList = SqlMapper.Query<Company>(con, "PROC_EMROLL_COMPANY_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                Company obj = _dapperAdapter.Get<Company>("PROC_EMROLL_COMPANY_MASTER", param, CommandType.StoredProcedure);
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
        public int UpdateCompany(Company obj)
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //DynamicParameters param = new DynamicParameters();


                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@CMP_NAME", obj.CMP_NAME);
                param.Add("@CMP_ADDRESS", obj.CMP_ADDRESS);
                param.Add("@CITY", obj.CITY);
                param.Add("@STATE", obj.STATE);
                param.Add("@PINCODE", obj.PINCODE);
                param.Add("@COUNTRY", obj.COUNTRY);
                param.Add("@PHONENO", obj.PHONENO);
                param.Add("@EMAIL", obj.EMAIL);
                param.Add("@DATEFORMAT", obj.DATEFORMAT);
                param.Add("@FROMDATE", obj.FROMDATE);
                param.Add("@WEBSITE", obj.WEBSITE);
                param.Add("@PF_TRUST_NO", obj.PF_TRUST_NO);
                param.Add("@PF_APPLICABLE", obj.PF_APPLICABLE);
                param.Add("@ESIC_APPLICABLE", obj.ESIC_APPLICABLE);
                param.Add("@TAN_NO", obj.TAN_NO);
                param.Add("@ESIC_NO", obj.ESIC_NO);
                param.Add("@DOMAIN_NAME", obj.DOMAIN_NAME);
                param.Add("@COMPANY_CODE", obj.COMPANY_CODE);
                param.Add("@LWF_NO", obj.LWF_NO);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);
                //param.Add("@CREATED_BY", -1);
                //param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", obj.ISACTIVE);
                param.Add("@StatementType", "Update");


                //con.Execute("PROC_EMROLL_COMPANY_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_COMPANY_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public bool DeleteCompany(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@CMP_ID", Id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_COMPANY_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_COMPANY_MASTER", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                //Log error as per your need       
                throw ex;
            }
            finally
            {

            }
        }
    }
}

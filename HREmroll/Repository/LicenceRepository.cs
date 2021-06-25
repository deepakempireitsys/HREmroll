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
    public class LicenceRepository
    {

        //To Handle connection related activities      
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public LicenceRepository(IConfiguration config)
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

        //To Add Licence details      
        public int Add(Licence obj)
        {

            //Additing the employess      
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();

                param.Add("@CMP_ID", obj.CMP_ID);
                //param.Add("@LICENCE_ID", obj.LICENCE_ID);
                param.Add("@LICENCE_NAME", obj.LICENCE_NAME);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);
                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 1);
                param.Add("@StatementType", "Insert");
                //con.Execute("PROC_EMROLL_LICENCE_MASTER", param, commandType: CommandType.StoredProcedure);
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_LICENCE_MASTER", param, commandType: CommandType.StoredProcedure);
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
        public List<Licence> GetAll()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "All");
                //IList<Licence> LicenceList = SqlMapper.Query<Licence>(con, "PROC_EMROLL_LICENCE_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Licence> LicenceList = _dapperAdapter.GetAll<Licence>("PROC_EMROLL_LICENCE_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return LicenceList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }


        public List<Licence> GetActive()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                //IList<Licence> LicenceList = SqlMapper.Query<Licence>(con, "PROC_EMROLL_LICENCE_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Licence> LicenceList = _dapperAdapter.GetAll<Licence>("PROC_EMROLL_LICENCE_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return LicenceList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }


        public List<Licence> GetInActive()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                //IList<Licence> LicenceList = SqlMapper.Query<Licence>(con, "PROC_EMROLL_LICENCE_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Licence> LicenceList = _dapperAdapter.GetAll<Licence>("PROC_EMROLL_LICENCE_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return LicenceList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }

        public Licence GetByID(long id)
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@LICENCE_ID", id);
                param.Add("@StatementType", "ById");
                //IList<Licence> LicenceList = SqlMapper.Query<Licence>(con, "PROC_EMROLL_LICENCE_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                Licence obj = _dapperAdapter.Get<Licence>("PROC_EMROLL_LICENCE_MASTER", param, CommandType.StoredProcedure);
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


        //To Update Licence details      
        public int Update(Licence obj)
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@CMP_ID", obj.CMP_ID);
                
                param.Add("@LICENCE_ID", obj.LICENCE_ID);
                param.Add("@LICENCE_NAME", obj.LICENCE_NAME);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);
                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", obj.ISACTIVE);
                param.Add("@StatementType", "Update");
                //con.Execute("PROC_EMROLL_LICENCE_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_LICENCE_MASTER", param, commandType: CommandType.StoredProcedure);

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
        //To delete Licence details      
        public bool Delete(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@LICENCE_ID", Id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_LICENCE_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_LICENCE_MASTER", param, commandType: CommandType.StoredProcedure);
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

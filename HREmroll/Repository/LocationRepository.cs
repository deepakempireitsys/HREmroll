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
    public class LocationRepository
    {
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public LocationRepository(IConfiguration config)
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
        public int AddLocation(Location obj)
        {

            //Additing the employess      
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                
                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@BRANCH_ID", obj.BRANCH_ID);
                param.Add("@LOCATION_NAME", obj.LOCATION_NAME);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);
                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 1);
                param.Add("@StatementType", "Insert");
                //con.Execute("PROC_EMROLL_Location_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_Location_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public List<Location> GetAllLocations()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "All");
                //IList<Location> LocationList = SqlMapper.Query<Location>(con, "PROC_EMROLL_LOCATION_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                IList<Location> LocationList = _dapperAdapter.GetAll<Location>("PROC_EMROLL_LOCATION_MASTER", param, CommandType.StoredProcedure).ToList();
                return LocationList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }


        public List<Location> GetActiveLocations()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                IList<Location> LocationList = _dapperAdapter.GetAll<Location>("PROC_EMROLL_LOCATION_MASTER", param, CommandType.StoredProcedure).ToList();
                return LocationList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }


        public List<Location> GetInActiveLocations()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                IList<Location> LocationList = _dapperAdapter.GetAll<Location>("PROC_EMROLL_LOCATION_MASTER", param, CommandType.StoredProcedure).ToList();
                return LocationList.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }

        public Location GetByID(long id)
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@LOCATION_ID", id);
                param.Add("@StatementType", "ById");
                //IList<Location> LocationList = SqlMapper.Query<Location>(con, "PROC_EMROLL_LOCATION_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                //con.Close();
                Location obj = _dapperAdapter.Get<Location>("PROC_EMROLL_LOCATION_MASTER", param, CommandType.StoredProcedure);
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
        public int UpdateLocation(Location obj)
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@CMP_ID", obj.CMP_ID);
                param.Add("@LOCATION_ID", obj.LOCATION_ID);
                param.Add("@BRANCH_ID", obj.BRANCH_ID);
                param.Add("@LOCATION_NAME", obj.LOCATION_NAME);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);
                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", obj.ISACTIVE);
                param.Add("@StatementType", "Update");
                //con.Execute("PROC_EMROLL_Location_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_Location_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public bool DeleteLocation(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@LOCATION_ID", Id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_LOCATION_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_LOCATION_MASTER", param, commandType: CommandType.StoredProcedure);
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

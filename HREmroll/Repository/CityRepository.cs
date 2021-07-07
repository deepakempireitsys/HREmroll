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
    public class CityRepository
    {

        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public string Connectionstring = "Server=24.13.245.114;Database=Emroll;User Id=sa;password=SUPERSOFTWARE#1";
        public CityRepository(IConfiguration config)
        {
            _dapperAdapter = new DapperAdapter(config);
        }
        public List<City> GetAllCity()
        {
            try
            {


                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Select");


                IList<City> CITYlist = _dapperAdapter.GetAll<City>("PROC_EMROLL_CITY_MASTER", param, CommandType.StoredProcedure).ToList();
                return CITYlist.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public int AddCity(City obj)
        {


            try
            {

                DynamicParameters param = new DynamicParameters();

                param.Add("@COUNTRY_ID", obj.COUNTRY_ID);
                param.Add("@STATE_ID", obj.STATE_ID);
                param.Add("@CITY_NAME", obj.CITY_NAME);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);



                param.Add("@StatementType", "Insert");
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_CITY_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public List<City> GetById()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ById");

                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<City> Citylist = _dapperAdapter.GetAll<City>("PROC_EMROLL_CITY_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return Citylist.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public int UpdateCity(City obj)
        {
            try
            {

                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //DynamicParameters param = new DynamicParameters();
                param.Add("@CITY_ID", obj.CITY_ID);
                param.Add("@STATE_ID", obj.STATE_ID);

                param.Add("@COUNTRY_ID", obj.COUNTRY_ID);
                param.Add("@CITY_NAME", obj.CITY_NAME);
                param.Add("@DESCRIPTION", obj.DESCRIPTION);

                param.Add("@StatementType", "Update");
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_CITY_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public bool Delete(int Id)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@CITY_ID", Id);

                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_CITY_MASTER", param, commandType: CommandType.StoredProcedure);
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
        public DataSet Get_Country()
        {
            using (SqlConnection con = new SqlConnection(Connectionstring))
            {
                SqlCommand com = new SqlCommand("Select * from EMROLL_COUNTRY_MASTER", con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }


        }

        //Get all State
        public DataSet Get_State(string country_id)
        {
            using (SqlConnection con = new SqlConnection(Connectionstring))
            {

                //SqlCommand com = new SqlCommand("Select * from EMROLL_STATE_MASTER where COUNTRY_ID=@COUNTRY_ID", con);
                SqlCommand com = new SqlCommand("SELECT * FROM EMROLL_STATE_MASTER WHERE COUNTRY_ID=@COUNTRY_ID", con);
                com.Parameters.AddWithValue("@COUNTRY_ID", country_id);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
        }
    }
}

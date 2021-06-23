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
    public class CountryRepository
    {
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public CountryRepository(IConfiguration config)
        {
            _dapperAdapter = new DapperAdapter(config);
        }
        public List<Country> GetAll()
        {
            try
            {


                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "All");


                IList<Country> Countrylist = _dapperAdapter.GetAll<Country>("PROC_EMROLL_COUNTRY_MASTER", param, CommandType.StoredProcedure).ToList();
                return Countrylist.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public int AddCountry(Country obj)
        {

         
            try
            {

                DynamicParameters param = new DynamicParameters();
           
                param.Add("@COUNTRY_NAME", obj.COUNTRY_NAME);

               
                param.Add("@StatementType", "Insert");
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_COUNTRY_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public int UpdateCountry(Country obj)
        {
            try
            {

                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //DynamicParameters param = new DynamicParameters();
                param.Add("@COUNTRY_NAME", obj.COUNTRY_NAME);
                param.Add("@COUNTRY_ID", obj.COUNTRY_ID);


                param.Add("@StatementType", "Update");
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_COUNTRY_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public bool DeleteCountry(int Id)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@COUNTRY_ID", Id);
         
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_COUNTRY_MASTER", param, commandType: CommandType.StoredProcedure);
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

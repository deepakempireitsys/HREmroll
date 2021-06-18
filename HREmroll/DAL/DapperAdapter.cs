using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
//using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.DAL
{
    public class DapperAdapter : IDapper
    {

        private readonly IConfiguration _config;
        private string Connectionstring = "DefaultConnection";
        private SqlConnection DBConn = new SqlConnection();

        public DapperAdapter()
        {

            Connectionstring = "";
        }

        public DapperAdapter(IConfiguration config)
        {
            
            _config = config;
            Connectionstring = _config.GetConnectionString("mySqlConnection");

            setDbConnection();
        }

        public void setDbConnection()
        {
            DBConn = new SqlConnection(Connectionstring);
        
        }

        public int Delete(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(Connectionstring);
            db.Open();
            //return db.Execute(sp, parms, commandType: commandType);
            int i = db.Execute(sp, parms, commandType: commandType);
            db.Close();
            return i;

            //throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = new SqlConnection(Connectionstring);
            return db.Execute(sp, parms, commandType: commandType); 
            //throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string query, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = new SqlConnection(Connectionstring);
            return db.Execute(query,  commandType: commandType);
            //throw new NotImplementedException();
        }

        public DataSet ExecuteQuery(string query, CommandType commandType = CommandType.Text)
        {
            DataSet ds = null;

            return ds;

            //throw new NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = new SqlConnection(Connectionstring);

            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = new SqlConnection(Connectionstring);
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public DataSet GetDataset(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            DataSet ds = null;

            return ds;
            //throw new NotImplementedException();
        }

        public DbConnection GetDbconnection()
        {
            //return new SqlConnection(_config.GetConnectionString(Connectionstring));
            return new SqlConnection(Connectionstring);
        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = new SqlConnection(Connectionstring);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = new SqlConnection(Connectionstring);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }


        dynamic ExecuteQueryMultiple(string query, CommandType commandType = CommandType.Text)
        {
            
            DBConn.Open();
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = new SqlConnection(Connectionstring);
            dynamic result = DBConn.QueryMultiple(query, CommandType.Text);
            DBConn.Close();
            return result;
            
        }

        dynamic ExecuteSPmultiple(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {

            DBConn.Open();
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = new SqlConnection(Connectionstring);

            dynamic result = DBConn.QueryMultiple(sp, parms,null,null,CommandType.StoredProcedure);
            DBConn.Close();
            return result;

        }
        dynamic ExecuteSPmultiple(string sp, DynamicParameters parms,  IDbTransaction trans, int Timeout, CommandType commandType = CommandType.StoredProcedure)
        {

            DBConn.Open();
            //using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            using IDbConnection db = new SqlConnection(Connectionstring);

            dynamic result = DBConn.QueryMultiple(sp, parms, trans, Timeout, CommandType.StoredProcedure);
            DBConn.Close();
            return result;

        }
    }
}

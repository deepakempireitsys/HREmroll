using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.DAL
{
    interface IDapper : IDisposable
    {

        DbConnection GetDbconnection();
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        DataSet GetDataset(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        
        //T Delete<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        int Delete (string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        DataSet ExecuteQuery(string query, CommandType commandType = CommandType.Text);
        int ExecuteNonQuery(string query, CommandType commandType = CommandType.Text);
    }
}

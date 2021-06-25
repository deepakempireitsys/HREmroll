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
    public class AttributeRepository
    {
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public AttributeRepository(IConfiguration config)
        {
            _dapperAdapter = new DapperAdapter(config);
        }
        public List<Models.Attribute> GetAllAttribute()
        {
            try
            {


                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "All");


                IList<Models.Attribute> Attributeist = _dapperAdapter.GetAll<Models.Attribute>("PROC_EMROLL_ATTRIBUTE_MASTER", param, CommandType.StoredProcedure).ToList();
                return Attributeist.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public List<Models.Attribute> GetActiveAttribute()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Models.Attribute> Attributeist = _dapperAdapter.GetAll<Models.Attribute>("PROC_EMROLL_ATTRIBUTE_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return Attributeist.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }

        }
        public List<Models.Attribute> GetInActiveAttribute()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Models.Attribute> Attributeist = _dapperAdapter.GetAll<Models.Attribute>("PROC_EMROLL_ATTRIBUTE_MASTER", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return Attributeist.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public int AddAtteribute(Models.Attribute obj)
        {


            try
            {


                DynamicParameters param = new DynamicParameters();

                param.Add("@CMP_ID", obj.CMP_ID);

                param.Add("@ATTRIBUTE_NAME", obj.ATTRIBUTE_NAME);

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
                i = _dapperAdapter.Execute("PROC_EMROLL_ATTRIBUTE_MASTER", param, commandType: CommandType.StoredProcedure);

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

        public int UpdateAttribute(Models.Attribute obj)
        {
            try
            {

                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //DynamicParameters param = new DynamicParameters();
                param.Add("@ATTRIBUTE_ID", obj.ATTRIBUTE_ID);
                param.Add("@CMP_ID", obj.CMP_ID);

                param.Add("@ATTRIBUTE_NAME", obj.ATTRIBUTE_NAME);

                param.Add("@DESCRIPTION", obj.DESCRIPTION);

                param.Add("@CREATED_BY", 1);
                param.Add("@CREATED_DATE", DateTime.Now);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", obj.ISACTIVE);

                param.Add("@StatementType", "Update");
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                int i = 0;
                i = _dapperAdapter.Execute("PROC_EMROLL_ATTRIBUTE_MASTER", param, commandType: CommandType.StoredProcedure);

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
        public bool DeleteAttribute(int Id)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@ATTRIBUTE_ID", Id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_ATTRIBUTE_MASTER", param, commandType: CommandType.StoredProcedure);
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

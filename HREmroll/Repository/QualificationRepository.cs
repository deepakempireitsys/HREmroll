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
    public class QualificationRepository
    {
        private DapperAdapter _dapperAdapter = null;
        public SqlConnection con;
        //To Handle connection related activities
        //
        public QualificationRepository(IConfiguration config)
        {
            _dapperAdapter = new DapperAdapter(config);
        }
        public List<Qualification> GetAllQualification()
        {
            try
            {


                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "All");


                IList<Qualification> Qualificationlist = _dapperAdapter.GetAll<Qualification>("PROC_EMROLL_QUALIFICATION", param, CommandType.StoredProcedure).ToList();
                return Qualificationlist.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public List<Qualification> GetActiveQualifiction()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "ActiveOnly");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Qualification> Qualificationlist = _dapperAdapter.GetAll<Qualification>("PROC_EMROLL_QUALIFICATION", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return Qualificationlist.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }

        }
        public List<Qualification> GetInActiveQualifiction()
        {
            try
            {
                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "InActiveOnly");
                //IList<Department> DepartmentList = SqlMapper.Query<Department>(con, "PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure).ToList();
                IList<Qualification> Qualificationlist = _dapperAdapter.GetAll<Qualification>("PROC_EMROLL_QUALIFICATION", param, CommandType.StoredProcedure).ToList();
                //con.Close();
                return Qualificationlist.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public int AddQualification(Qualification obj)
        {

    
            try
            {

          
                DynamicParameters param = new DynamicParameters();

                param.Add("@CMP_ID", obj.CMP_ID);

                param.Add("@QUALIFICATION_NAME", obj.QUALIFICATION_NAME);
                param.Add("@TYPE", obj.TYPE);
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
                i = _dapperAdapter.Execute("PROC_EMROLL_QUALIFICATION", param, commandType: CommandType.StoredProcedure);

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

        public int UpdateQualification(Qualification obj)
        {
            try
            {

                //connection();
                //con.Open();
                DynamicParameters param = new DynamicParameters();
                //DynamicParameters param = new DynamicParameters();
                param.Add("@QUALIFICATION_ID", obj.QUALIFICATION_ID);
                param.Add("@CMP_ID", obj.CMP_ID);

                param.Add("@QUALIFICATION_NAME", obj.QUALIFICATION_NAME);
                param.Add("@TYPE", obj.TYPE);
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
                i = _dapperAdapter.Execute("PROC_EMROLL_QUALIFICATION", param, commandType: CommandType.StoredProcedure);

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
        public bool DeleteQualification(int Id)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@StatementType", "Delete");
                param.Add("@QUALIFICATION_ID", Id);
                param.Add("@MODIFIED_BY", 1);
                param.Add("@MODIFIED_DATE", DateTime.Now);
                param.Add("@ISACTIVE", 0);
                //connection();
                //con.Open();
                //con.Execute("PROC_EMROLL_DEPARTMENT_MASTER", param, commandType: CommandType.StoredProcedure);
                //con.Close();
                _dapperAdapter.Execute("PROC_EMROLL_QUALIFICATION", param, commandType: CommandType.StoredProcedure);
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

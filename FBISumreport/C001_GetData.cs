using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FBISumreport
{
    public class C001_GetData
    {
        public DataTable SearchRegionFromDBO()
        {
            DataTable _dt = new DataTable();
            try
            {
                C002_DataAccess _dbConn = new C002_DataAccess();
                SqlConnection SqlConn = _dbConn.GetConnection();
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();

                command.Connection = SqlConn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[baac].[UpperLevelForRep_select]";
                //command.CommandTimeout = _TimeOut;

                adapter = new SqlDataAdapter(command);
                adapter.Fill(_dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dt;
        }

        public DataTable SearchProvinceFromDBO(string upperLevelCode)
        {
            DataTable _dt = new DataTable();
            try
            {
                C002_DataAccess _dbConn = new C002_DataAccess();
                SqlConnection SqlConn = _dbConn.GetConnection();
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();

                command.Connection = SqlConn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[baac].[DivisionForRep_select]";
                command.Parameters.Add(new SqlParameter("@UpperLevelCode", upperLevelCode));
                //command.CommandTimeout = _TimeOut;

                adapter = new SqlDataAdapter(command);
                adapter.Fill(_dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dt;
        }

        public DataTable SearchBranchFromDBO(string upperLevelCode, string divisionCode)
        {
            DataTable _dt = new DataTable();
            try
            {
                C002_DataAccess _dbConn = new C002_DataAccess();
                SqlConnection SqlConn = _dbConn.GetConnection();
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();

                command.Connection = SqlConn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[baac].[BranchForRep_select]";
                command.Parameters.Add(new SqlParameter("@ProvinceCode", upperLevelCode));
                command.Parameters.Add(new SqlParameter("@RegionCode", divisionCode));

                adapter = new SqlDataAdapter(command);
                adapter.Fill(_dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dt;
        }

        public DataTable GetPlanCategories()
        {
            DataTable _dt = new DataTable();
            try
            {
                C002_DataAccess _dbConn = new C002_DataAccess();
                SqlConnection SqlConn = _dbConn.GetConnection();
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();

                command.Connection = SqlConn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[baac].[PlanCategories_select]";
                //command.CommandTimeout = _TimeOut;

                adapter = new SqlDataAdapter(command);
                adapter.Fill(_dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dt;
        }

        public DataTable GetPlanAssurance(string planCategoriesID)
        {
            DataTable _dt = new DataTable();
            try
            {
                C002_DataAccess _dbConn = new C002_DataAccess();
                SqlConnection SqlConn = _dbConn.GetConnection();
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();

                command.Connection = SqlConn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[baac].[PlanAssurance_select]";
                command.Parameters.Add(new SqlParameter("@PLANCATEGORIESID", planCategoriesID));

                adapter = new SqlDataAdapter(command);
                adapter.Fill(_dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dt;
        }

        public DataTable GetCategories()
        {
            DataTable _dt = new DataTable();
            try
            {
                C002_DataAccess _dbConn = new C002_DataAccess();
                SqlConnection SqlConn = _dbConn.GetConnection();
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();

                command.Connection = SqlConn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[baac].[Categories_select]";

                adapter = new SqlDataAdapter(command);
                adapter.Fill(_dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dt;
        }
    }
}
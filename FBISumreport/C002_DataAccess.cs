using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace FBISumreport
{
    public class C002_DataAccess
    {
        public SqlConnection GetConnection()
        {
            SqlConnection _conn = null;

            try
            {
                string _strConn = C003_DatabaseInfo.Instance.GetConnectionString();

                if (_conn == null)
                    _conn = new SqlConnection(_strConn);

                if (_conn.State == ConnectionState.Open)
                    _conn.Close();

                _conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _conn;
        }

        public DataTable GetDataTable(string sql)
        {
            DataTable _result = null;

            try
            {
                _result = this.GetDataTable(this.GetConnection(), sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _result;
        }

        public DataTable GetDataTable(SqlConnection conn, string sql)
        {
            DataTable _result = null;
            SqlCommand _cmd = null;
            SqlDataAdapter _adap = null;

            try
            {
                _cmd = new SqlCommand(sql, conn);
                _adap = new SqlDataAdapter(_cmd);
                _result = new DataTable();

                _adap.Fill(_result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_adap != null) _adap.Dispose();
                if (_cmd != null) _cmd.Dispose();
                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();

                    conn.Dispose();
                }
            }

            return _result;
        }

        public bool ExecuteNonQuery(string sql)
        {
            bool _result = false;

            try
            {
                _result = this.ExecuteNonQuery(this.GetConnection(), sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _result;
        }

        public bool ExecuteNonQuery(SqlConnection conn, string sql)
        {
            bool _result = false;
            SqlCommand _cmd = null;

            try
            {
                _cmd = new SqlCommand(sql, conn);
                _cmd.ExecuteNonQuery();

                _result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_cmd != null) _cmd.Dispose();
                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();

                    conn.Dispose();
                }
            }

            return _result;
        }

        public bool ExecuteNonQueryCommit(string strSql)
        {
            bool _result = false;
            SqlConnection _conn = null;
            SqlCommand _cmd = new SqlCommand();
            SqlTransaction _trans = null;

            try
            {
                _conn = this.GetConnection();

                _trans = _conn.BeginTransaction();

                _cmd.Connection = _conn;
                _cmd.Transaction = _trans;

                _cmd.CommandText = strSql;
                _cmd.CommandType = CommandType.Text;
                _cmd.ExecuteNonQuery();

                _trans.Commit();

                _result = true;
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                throw ex;
            }
            finally
            {
                if (_cmd != null) _cmd.Dispose();
                if (_conn != null)
                {
                    if (_conn.State != ConnectionState.Closed)
                        _conn.Close();

                    _conn.Dispose();
                }
            }

            return _result;
        }
    }
}
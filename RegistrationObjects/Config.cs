using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RegistrationObjects
{
    public class Config
    {
        public string sDatabase;
        public string sqlServer;
        public string sqlErrorMsg;

        public SqlConnection sqlDbConnection;

        public bool SetConfiguration(System.Collections.Specialized.NameValueCollection settings)
        {
            try
            {
                sDatabase = settings["SqlDatabase"].ToString();
                sqlServer = settings["sqlServer"].ToString();
                sqlDbConnection = null;
                sqlErrorMsg = "OK";
                return true;
            }
            catch(Exception ex)
            {
                sqlErrorMsg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Function to get the SQL Connection object
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private SqlConnection getConnection(string connectionString)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlErrorMsg = string.Empty;
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                sqlDbConnection = sqlConnection;
            }
            catch (Exception exp)
            {
                sqlErrorMsg = exp.Message;
                throw exp;
            }
            return sqlConnection;
        }

        /// <summary>
        /// Function to get the connection to the database
        /// </summary>
        /// <param name="SqlServerName"></param>
        /// <param name="SqlDatabaseName"></param>
        public bool OpenSqlDBConnection(string SqlServerName, string SqlDatabaseName)
        {
            bool bOpenConnection = true;
            try
            {
                sqlErrorMsg = string.Empty;
                string strConnect = string.Format("Integrated Security=SSPI;Data Source={0};Initial Catalog={1};Pooling=False;", SqlServerName, SqlDatabaseName);
                sqlDbConnection = getConnection(strConnect);
            }
            catch (Exception exp)
            {
                bOpenConnection = false;
                sqlErrorMsg = exp.Message;
            }
            return bOpenConnection;
        }
            
    }
}

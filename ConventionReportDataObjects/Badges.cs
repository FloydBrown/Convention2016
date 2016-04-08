using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Convention_ReportDataObjects
{
    public class BadgeData
    {
        bool _bOpenDbConnection = false;
        public string sqlErrorMsg;

        public SqlConnection sqlDbConn;

        public DataTable GetBadgeInfo()
        {
            DataTable dt = new DataTable();
            if (_bOpenDbConnection)
                sqlErrorMsg = string.Empty;
            else
            {
                sqlErrorMsg = "Registration database is not connected";
                return dt;
            }
            try
            {
                string sqlCommandText = "Select Top 1 * From Badge_Info WHERE Active=1";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlCommandText, sqlDbConn))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                sqlErrorMsg = ex.Message;
            }
            return dt;
        }


        public DataTable GetUnprintedBadges()
        {
            DataTable dt = new DataTable();
            if(_bOpenDbConnection)
                sqlErrorMsg = string.Empty;
            else
            {
                sqlErrorMsg = "Registration database is not connected";
                return dt;
            }
            try
            {
                string sqlCommandText = "Select Reg_ID, Last_Name, Badge_Name, Badge_ID, Member_ID, Camp_Name, Camp_Number, Full_Name, "+
                                            " First_Time, Line2, Line3, Member_Type From Badge_Print where printed=0 Order by Last_Name";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlCommandText, sqlDbConn))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                sqlErrorMsg = ex.Message;
            }
            return dt;
        }

        public bool OpenSqlDBConnection(string SqlServerName, string SqlDatabaseName)
        {
            // bool bOpenConnection = true;
            if (!_bOpenDbConnection)
            {
                try
                {
                    string strConnect = string.Format("Integrated Security=SSPI;Data Source={0};Initial Catalog={1};Pooling=False;", SqlServerName, SqlDatabaseName);
                    sqlDbConn = new SqlConnection(strConnect);
                    sqlDbConn.Open();
                    _bOpenDbConnection = true;
                }
                catch (Exception exp)
                {
                    _bOpenDbConnection = false;
                    sqlErrorMsg = exp.Message;
                }
            }
            return _bOpenDbConnection;
        }

        public bool UpdateBadge( string sBadgeID)
        {
            bool bok = true;
            if (_bOpenDbConnection)
                sqlErrorMsg = string.Empty;
            else
            {
                sqlErrorMsg = "Registration database is not connected";
                return false;
            }
            try
            {
                string sqlCommandText = "Update Badge  SET Printed=1 WHERE Badge_ID=@BadgeID";
                using (SqlCommand cmd = new SqlCommand(sqlCommandText, sqlDbConn))
                {
                    cmd.Parameters.AddWithValue("@BadgeID", sBadgeID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                sqlErrorMsg = ex.Message;
                bok = false;
            }
            return bok;

        }

    }
}

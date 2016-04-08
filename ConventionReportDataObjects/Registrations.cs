using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convention_ReportDataObjects
{
    public class Registrations
    {
        public string sqlErrorMsg;

        public SqlConnection sqlDbConnection;


        public DataTable LoadRegistrations(string sRegID)
        {
            DataTable dt = new DataTable();
            //OpenSqlDBConnection();
            try
            {
                string sqlCommand = "Select * From Badge b join Registration r ON b.Badge_ID = r.primaryBadgeID WHERE";
                if (string.IsNullOrEmpty(sRegID))
                    sqlCommand += " isnull(r.Printed,0)=0";
                else
                    sqlCommand += " r.[Reg_ID] =" + sRegID;
                sqlCommand += " Order by b.Last_Name, b.First_Name";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand, sqlDbConnection))
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

        public DataTable GetBadges(string regID)
        { 
            DataTable dt = new DataTable();
            //OpenSqlDBConnection();
            try
            {
                string sqlCommand = "Select * from Badge where Reg_ID =" + regID + " Order by Member_Type";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand, sqlDbConnection))
                {
                    da.Fill(dt);
                }
            }
            catch(Exception ex)
            {
                sqlErrorMsg = ex.Message;
            }
            return dt;
        }

        public DataTable GetRegistration(  int regID)
        {
            DataTable dt = new DataTable();
            //Registration reg = new Registration();
            //OpenSqlDBConnection();
            string sqlCommand = "Select * from Registration Where [Reg_ID] =" + regID.ToString();

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand, sqlDbConnection);
            da.Fill(dt);

            //reg.RegistrationID = regID;
            //reg.MemberID = Convert.ToInt32(dr["Member_ID"]);
            //reg.SpouseID = Convert.ToInt32(dr["Spouse_ID"]);
            //reg.DateRegistered = Convert.ToDateTime(dr["Date_Registered"]);
            //reg.FirstName = dr["First_Name"].ToString();
            //reg.LastName = dr["Last_Name"].ToString();

            da.Dispose();
            return dt;
        }

        public DataTable GetTickets(string sRegID)
        {
            DataTable dt = new DataTable();
            //OpenSqlDBConnection();
            try
            {
                string sqlCommand = "Select Event_ID, ISNULL(t.Count, 0) as Qty, Event_Name, e.Cost, ISNULL(t.cost, 0) as Amount" +
                    " From event e left join Tickets t on e.Event_ID=t.EventID AND RegID=" + sRegID + "Order by Event_ID";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand, sqlDbConnection))
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
                string strConnect = string.Format("Integrated Security=SSPI;Data Source={0};Initial Catalog={1};Pooling=False;", SqlServerName, SqlDatabaseName);
                sqlDbConnection = new SqlConnection(strConnect);
                sqlDbConnection.Open();
            
            }
            catch (Exception exp)
            {
                bOpenConnection = false;
                sqlErrorMsg = exp.Message;
            }
            return bOpenConnection;
        }

        public bool UpdateRegistrationPrinted(string sRegID)
        {
            bool bok = true;
             
            //if (_bOpenDbConnection)
                sqlErrorMsg = string.Empty;
            /**else
            {
                sqlErrorMsg = "Registration database is not connected";
                return false;
            }***/
            try
            {
                string sqlCommandText = "Update Registration  SET Printed=1 WHERE Reg_ID=@RegID";
                using (SqlCommand cmd = new SqlCommand(sqlCommandText, sqlDbConnection))
                {
                    cmd.Parameters.AddWithValue("@RegID", sRegID);
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

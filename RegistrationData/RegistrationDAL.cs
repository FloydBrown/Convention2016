using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using RegistrationObjects;

namespace RegistrationData
{
    public class RegistrationDAL
    {
        public static int AddRegistration( SqlConnection conn, Registration reg)
        {
            int result = 0;
            string errMsg = string.Empty;
            try
            {
                string sqlCmdText = "sI_Registration";
                    
                SqlCommand cmd = new SqlCommand(sqlCmdText,  conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DateReg", reg.DateRegistered.ToString());
                cmd.Parameters.AddWithValue("@MemberID",reg.MemberID.ToString());
                cmd.Parameters.AddWithValue("@FirstName",reg.FirstName);
                cmd.Parameters.AddWithValue("@LastName",reg.LastName);
                cmd.Parameters.AddWithValue("@SpouseID",reg.SpouseID.ToString());
                cmd.Parameters.AddWithValue("@Special", reg.bSpecialGuest.ToString());
                cmd.Parameters.AddWithValue("@BadgeID", reg.sBadgeID);
                SqlParameter spReturn = cmd.Parameters.AddWithValue("@Return", 0);
                spReturn.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteScalar();
                result = Convert.ToInt32(spReturn.Value);
                    if (result < 0)
                    {
                        errMsg = "SQL Error: " + result.ToString();

                        return 0;
                    }
                
                    //reg = GetRegistrationByMemberID(conn, reg.MemberID);

                    return result;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                throw new Exception("Add Registration Error:" + ex.Message, ex);
            }
        }

        // find a registration by MemberID or SpouseID

        public static Registration GetRegistrationByMemberID( SqlConnection conn, int memID )
        {
            DataTable dt = new DataTable();
            Registration reg = new Registration();
            if(memID==0)
            {
                
                reg.RegistrationID = 0;
                reg.MemberID = memID;
                reg.FirstName = reg.LastName = string.Empty;
                reg.SpouseID = 0;
                return reg;
            }
            string sqlCommand = "Select * from Registration Where [Member_ID] =" + memID.ToString()
                + "OR [Spouse_ID] =" + memID.ToString();

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand, conn);
            da.Fill(dt);
            if (dt.Rows.Count == 0)
                reg.RegistrationID = 0;
            else
            {
                DataRow dr = dt.Rows[0];
                reg.MemberID = memID;
                reg.RegistrationID = Convert.ToInt32(dr["Reg_ID"]);
                reg.SpouseID = Convert.ToInt32(dr["Spouse_ID"]);
                reg.DateRegistered = Convert.ToDateTime(dr["Date_Registered"]);
                reg.FirstName = dr["First_Name"].ToString();
                reg.LastName = dr["Last_Name"].ToString();
            }
            return reg;
        }

        public static Registration GetRegistrationByRegID(SqlConnection conn, int regID)
        {
            DataTable dt = new DataTable();
            Registration reg = new Registration();
            string sqlCommand = "Select * from Registration Where [Reg_ID] =" + regID.ToString();

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand, conn);
            da.Fill(dt);
            if (dt.Rows.Count == 0)
                reg.RegistrationID = 0;
            else
            {
                DataRow dr = dt.Rows[0];
                reg.RegistrationID = regID;
                reg.MemberID = Convert.ToInt32(dr["Member_ID"]);
                reg.SpouseID = Convert.ToInt32(dr["Spouse_ID"]);
                reg.DateRegistered = Convert.ToDateTime(dr["Date_Registered"]);
                reg.FirstName = dr["First_Name"].ToString();
                reg.LastName = dr["Last_Name"].ToString();
            
            }
            return reg;
        }

        public static bool UpdateRegistration(SqlConnection conn, int nRegID, int nGideonID, int nSpouseID, string sFirstName, string sLastName)
        {
            string errMsg = string.Empty;
            try
            {
                string sqlCmdText = "UPDATE [dbo].[Registration] SET [Member_ID]=@MembID, [First_Name]=@FName, [Last_Name]=@LName" +
                    ",[Spouse_ID]=@SpouseID WHERE REG_ID=@RegID";
                           
                SqlCommand cmd = new SqlCommand(sqlCmdText, conn);
                cmd.Parameters.AddWithValue("@MembID", nGideonID.ToString());
                cmd.Parameters.AddWithValue("@FName", sFirstName);
                cmd.Parameters.AddWithValue("@LName", sLastName);
                cmd.Parameters.AddWithValue("@SpouseID", nSpouseID.ToString());
                cmd.Parameters.AddWithValue("@RegID", nRegID.ToString());
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                throw new Exception("Update Registration Error:" + ex.Message, ex);
            }
        }
            
    }
}

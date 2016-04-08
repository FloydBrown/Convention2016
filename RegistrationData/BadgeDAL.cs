using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using RegistrationObjects;

namespace RegistrationData
{
    public class BadgeDAL
    {
        // add a members badge
        public static bool AddBadgeFromMember(SqlConnection conn, Member mem, int RegID, int BadgeId, bool fTime)
        {
            string sErrMsg = string.Empty;
            try
            {
                string sqlCmdText = "INSERT Into [dbo].[Badge] ([Badge_ID],[Member_ID],[Reg_ID],[Title],[First_Name],[Middle_Name],[Last_Name]" +
                    ",[Full_Name],[Badge_Name],[Address1],[Address2],[City],[State],[Zip],[Home_Phone],[Cell_Phone],[Email],[Camp_Number],[Camp_Name]" +
                    ",[Member_Type],[Spouse_ID],First_Time, Printed ) VALUES(@BadgeID,@MemID,@RegID,@Title,@FName,@MName,@Lname,@FullNam" +
                    ",@BadNam,@adr1,@adr2,@city,@st,@zip,@phone,@cell,@em,@cno,@cnam,@memTyp,@SpouseID,@FTime,0)";

                SqlCommand cmd = new SqlCommand(sqlCmdText, conn);
                cmd.Parameters.AddWithValue("@BadgeID", BadgeId.ToString());
                cmd.Parameters.AddWithValue("@MemID", mem.MemberID.ToString());
                cmd.Parameters.AddWithValue("@RegID", RegID.ToString());
                cmd.Parameters.AddWithValue("@Title", mem.Title);
                cmd.Parameters.AddWithValue("@FName", mem.FirstName);
                cmd.Parameters.AddWithValue("@MName", mem.MiddleName);
                cmd.Parameters.AddWithValue("@LName", mem.LastName);
                cmd.Parameters.AddWithValue("@FullNam", mem.FullName);
                cmd.Parameters.AddWithValue("@BadNam", mem.PrefName);
                cmd.Parameters.AddWithValue("@adr1", mem.Address1);
                cmd.Parameters.AddWithValue("@adr2", mem.Address2);
                cmd.Parameters.AddWithValue("@city", mem.City);
                cmd.Parameters.AddWithValue("@st", mem.State);
                cmd.Parameters.AddWithValue("@zip", mem.PostalCode);
                cmd.Parameters.AddWithValue("@phone", mem.HomePhone);
                cmd.Parameters.AddWithValue("@cell", mem.MobilePhone);
                cmd.Parameters.AddWithValue("@em", mem.email);
                cmd.Parameters.AddWithValue("@cno", mem.CampNumber);
                cmd.Parameters.AddWithValue("@cnam", mem.CampName);
                cmd.Parameters.AddWithValue("@memTyp", mem.MemberType);
                cmd.Parameters.AddWithValue("@spouseID", mem.SpouseID.ToString());
                cmd.Parameters.AddWithValue("@FTime", fTime.ToString());

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                throw new Exception("Add Badge Error:" + ex.Message, ex);
            }
        }

        // add a guest badge
        public static bool AddBadgeFromRoster( SqlConnection conn, DataRow drImp, Member mem, int RegID )
        {
            string sErrMsg = string.Empty;
            try
            {
                string sDenom = drImp["IF YOU HAVE A DENOMINATION PREFERENCE, TYPE IN BELOW#"].ToString();
                string sFirstTime = drImp["IS THIS YOUR FIRST STATE CONVENTION?"].ToString();
                bool bFirstTime = (sFirstTime.ToUpper() == "YES");
                string sqlCmdText = "INSERT Into [dbo].[Badge] ([Badge_ID],[Member_ID],[Reg_ID]" +
                    ",[Title],[First_Name],[Last_Name],[Full_Name],[Badge_Name],[Address1],[Address2],[City],[State],[Zip]" +
                    ",[Home_Phone],[Cell_Phone],[Email],[Camp_Number],[Camp_Name],[Member_Type],First_Time, Printed )  " +
                    "VALUES(@BadgeID,@MembID,@RegID,@Title,@FName,@LName,@FullName,@BadgeName,@Addr1,@Addr2,@City,@ST,@ZIP" +
                    ",@phone,@cell,@em,@cno,@cnam,@MT,@FT, 0 )";
                        
                SqlCommand cmd = new SqlCommand(sqlCmdText, conn);
                cmd.Parameters.AddWithValue("@BadgeID", drImp["Badge_Number"].ToString());
                cmd.Parameters.AddWithValue("@MembID", mem.MemberID.ToString());
                cmd.Parameters.AddWithValue("@RegID", RegID.ToString());
                cmd.Parameters.AddWithValue("@Title", drImp["SALUTATION"].ToString());
                cmd.Parameters.AddWithValue("@FName", drImp["FIRST_NAME"].ToString());
                cmd.Parameters.AddWithValue("@LName", drImp["LAST_NAME"].ToString());
                cmd.Parameters.AddWithValue("@FullName", drImp["FULL_NAME"].ToString());
                cmd.Parameters.AddWithValue("@BadgeName", drImp["BADGE_NAME"].ToString());
                cmd.Parameters.AddWithValue("@Addr1", drImp["ADDRESS1"].ToString());
                cmd.Parameters.AddWithValue("@Addr2", drImp["ADDRESS2"].ToString());
                cmd.Parameters.AddWithValue("@City", drImp["CITY"].ToString());
                cmd.Parameters.AddWithValue("@ST", drImp["STATE"].ToString());
                cmd.Parameters.AddWithValue("@ZIP", drImp["ZIP_CODE"].ToString());
                cmd.Parameters.AddWithValue("@phone", mem.HomePhone);
                cmd.Parameters.AddWithValue("@cell", mem.MobilePhone);
                cmd.Parameters.AddWithValue("@em", mem.email);
                cmd.Parameters.AddWithValue("@cno", mem.CampNumber);
                cmd.Parameters.AddWithValue("@cnam", mem.CampName);
                cmd.Parameters.AddWithValue("@MT", mem.MemberType);
                cmd.Parameters.AddWithValue("@FT", bFirstTime.ToString());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                throw new Exception("Add Badge Error:" + ex.Message, ex);
            }
        }

    // add a members badge - retired version, use data from badge record in all cases
     public static bool AddBadgeFromRosterEx( SqlConnection conn, DataRow drImp, Member mem, int RegID )
        {
            string sErrMsg = string.Empty;
            try
            {
                string sDenom = drImp["IF YOU HAVE A DENOMINATION PREFERENCE, TYPE IN BELOW#"].ToString();
                string sFirstTIme = drImp["IS THIS YOUR FIRST STATE CONVENTION?"].ToString();
                bool bFirstTime = (sFirstTIme.ToUpper() == "YES");


                string sqlCmdText = "INSERT Into [dbo].[Badge] ([Badge_ID],[Member_ID],[Reg_ID],[Title],[First_Name],[Middle_Name],[Last_Name]" +
                    ",[Full_Name],[Badge_Name],[Address1],[Address2],[City],[State],[Zip],[Home_Phone],[Cell_Phone],[Email],[Camp_Number],[Camp_Name]" +
                    ",[Member_Type],[Spouse_ID],[Denomination],First_Time, Printed ) VALUES(@BadgeID,@MemID,@RegID,@Title,@FName,@MName,@Lname,@FullNam"+
                    ",@BadNam,@adr1,@adr2,@city,@st,@zip,@phone,@cell,@em,@cno,@cnam,@memTyp,@SpouseID,@Denom,@FTime,0)";    
                      
                SqlCommand cmd = new SqlCommand(sqlCmdText, conn);
                cmd.Parameters.AddWithValue("@BadgeID", drImp["Badge_Number"].ToString());
                cmd.Parameters.AddWithValue("@MemID", mem.MemberID.ToString());
                cmd.Parameters.AddWithValue("@RegID", RegID.ToString());
                if (mem.Title == null )
                    cmd.Parameters.AddWithValue("@Title", string.Empty);
                else
                    cmd.Parameters.AddWithValue("@Title",mem.Title);
                cmd.Parameters.AddWithValue("@FName",mem.FirstName);
                cmd.Parameters.AddWithValue("@MName",mem.MiddleName);
                cmd.Parameters.AddWithValue("@LName",mem.LastName);
                cmd.Parameters.AddWithValue("@FullNam", mem.FullName);
                cmd.Parameters.AddWithValue("@BadNam", drImp["Badge_Name"].ToString());
                cmd.Parameters.AddWithValue("@adr1", mem.Address1);
                cmd.Parameters.AddWithValue("@adr2", mem.Address2);
                cmd.Parameters.AddWithValue("@city", mem.City);
                cmd.Parameters.AddWithValue("@st", mem.State);
                cmd.Parameters.AddWithValue("@zip", mem.PostalCode);
                cmd.Parameters.AddWithValue("@phone", mem.HomePhone); 
                cmd.Parameters.AddWithValue("@cell", mem.MobilePhone);
                cmd.Parameters.AddWithValue("@em", mem.email);
                cmd.Parameters.AddWithValue("@cno", mem.CampNumber);
                cmd.Parameters.AddWithValue("@cnam", mem.CampName);
                cmd.Parameters.AddWithValue("@memTyp", mem.MemberType);
                cmd.Parameters.AddWithValue("@spouseID", mem.SpouseID.ToString());
                if (sDenom.Length > 50)
                    cmd.Parameters.AddWithValue("@denom", sDenom.Substring(0, 48));
                else
                    cmd.Parameters.AddWithValue("@denom", sDenom );
                cmd.Parameters.AddWithValue("@FTime", bFirstTime.ToString());

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                throw new Exception("Add Badge Error:" + ex.Message, ex);
            }
        }

        public static bool AddEmptyBadge(SqlConnection conn, int BadgeId, int RegId)
        {
            string sErrMsg = string.Empty;
            try
            {
                //string sqlCmdText = "INSERT Into [dbo].[Badge] ([Badge_ID],[Member_ID],[Reg_ID]) VALUES(@BadgeID,@MemID,@RegID)";
                string sqlCmdText = "sI_NewBadge";
                SqlCommand cmd = new SqlCommand(sqlCmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BadgeID", BadgeId.ToString());
                cmd.Parameters.AddWithValue("@MemberID", BadgeId.ToString());
                cmd.Parameters.AddWithValue("@RegID", RegId.ToString());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                throw new Exception("Add Badge Error:" + ex.Message, ex);
            }
        }

        public static int FindBadge( SqlConnection conn, string sBadgeID )
        {
            string sErrMsg = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                string sqlCommand = "Select * from Badge where BADGE_ID=" + sBadgeID;
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand, conn);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int regID = Convert.ToInt32(dt.Rows[0]["Reg_ID"]);
                    return regID;
                }
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                throw new Exception("Find Badge Error:" + ex.Message, ex);
            }
            return 0;
        }

        public static bool FindBadgeByMemberID(SqlConnection conn, int memberID)
        {
            string sErrMsg = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                string sqlCommand = "Select * from Badge where Member_ID=" + memberID.ToString();
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand, conn);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return true;
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                throw new Exception("Find Badge Error:" + ex.Message, ex);
            }
            return false;
        }
        public static bool UpdateBadge(SqlConnection conn, string sBadgeId, string sTitle, string sFirst, string sMid, string sLast, string sBadge, string sCity, bool bPrinted)
        {
            string sErrMsg = string.Empty;
            string sqlCmdText = "UPDATE Badge Set First_Name=@FNam, Middle_Name=@Mid, Last_Name=@LNam, Title=@Ti, Badge_Name=@BNam, Full_Name=@FulNam," +
                "City=@City, [Printed]=@print Where Badge_ID=@BadgeId";
            try
            {
                SqlCommand cmd = new SqlCommand(sqlCmdText, conn);
                cmd.Parameters.AddWithValue("@FNam", sFirst);
                cmd.Parameters.AddWithValue("@Mid", sMid);
                cmd.Parameters.AddWithValue("@Lnam", sLast);
                cmd.Parameters.AddWithValue("@Ti", sTitle);
                cmd.Parameters.AddWithValue("@BNam", sBadge);
                cmd.Parameters.AddWithValue("@FulNam", sTitle + " " + sFirst + " " + sLast);
                cmd.Parameters.AddWithValue("@BadgeID", sBadgeId);
                cmd.Parameters.AddWithValue("@City", sCity);
                if (bPrinted)
                    cmd.Parameters.AddWithValue("@Print", "1");
                else
                    cmd.Parameters.AddWithValue("@Print", "0");

                cmd.ExecuteNonQuery();
                return true;
            }

            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                throw new Exception("Update Badge Error:" + ex.Message, ex);
            }
        }
    }

}

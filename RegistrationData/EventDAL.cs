using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using RegistrationObjects;

namespace RegistrationData
{
    public class EventDAL
    {
        private string errMsg;
        public string ErrorMessage
        {
            get
            { return errMsg; }
        }
        public bool DeleteAllTickets(Config cfg)
        {
            try
            {
                cfg.OpenSqlDBConnection(cfg.sqlServer, cfg.sDatabase);
                SqlCommand cmd = new SqlCommand("Delete Tickets", cfg.sqlDbConnection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                errMsg = "Delete Tickets Error:" + ex.Message;
                //throw new Exception(errMsg, ex);
            }
            return true;
        }
        public bool ImportAllEvents(Config cfg, string filename)
        {
            Attendee attend = new Attendee();
             DataTable dtImport;
        int iRegID = 0;
            Registration lastReg = new Registration();
            //string sTemp;
            try
            {
                cfg.OpenSqlDBConnection(cfg.sqlServer, cfg.sDatabase);
                //DeleteAllTickets(cfg.sqlDbConnection);
                dtImport = attend.LoadExcelWS(filename);
                foreach (DataRow dr in dtImport.Rows)
                {
                    //
                    // already registered? look for badge
                    //
                    string sBadgeID = dr["BADGE_NUMBER"].ToString();
                    iRegID = BadgeDAL.FindBadge(cfg.sqlDbConnection, sBadgeID);
                    if(iRegID==0)
                    {
                        errMsg = "Unexpected Error - Badge Num:" + sBadgeID;
                        return false;
                    }
                    ImportEvents(cfg.sqlDbConnection, dr, iRegID, dtImport.Columns);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                throw new Exception("Import Event Tickets Error:" + ex.Message, ex);
            }
            return true;
        }
        public static bool ImportEvents (SqlConnection conn, DataRow drImp, int regID, DataColumnCollection dc)
        {
            int nCount = 0;
            try
            {
                foreach (DataColumn c in dc)
                {
                    string cName = c.ColumnName;
                    string sValue = drImp[cName].ToString();
                    if (cName.Contains("Member Registration Fee"))
                        if (sValue.Length > 0)
                        {
                            nCount = Convert.ToInt32(sValue);
                            if (nCount > 0)
                                EventDAL.AddTickets(conn, regID, 1, nCount);
                        }
                    if (cName.Contains("Pre-convention Dinner"))
                        if (sValue.Length > 0)
                        {
                            nCount = Convert.ToInt32(sValue);
                            if (nCount > 0)
                                EventDAL.AddTickets(conn, regID, 2, nCount);
                        }
                    if (cName.Contains("Kickoff Luncheon"))
                        if (sValue.Length > 0)
                        {
                            nCount = Convert.ToInt32(sValue);
                            if (nCount > 0)
                                EventDAL.AddTickets(conn, regID, 3, nCount);
                        }
                    if (cName.Contains("Pastors Banquet"))
                        if (sValue.Length > 0)
                        {
                            nCount = Convert.ToInt32(sValue);
                            if (nCount > 0)
                                EventDAL.AddTickets(conn, regID, 4, nCount);
                        }
                    if (cName.Contains("Auxiliary Presidents Breakfast"))
                        if (sValue.Length > 0)
                        {
                            nCount = Convert.ToInt32(sValue);
                            if (nCount > 0)
                                EventDAL.AddTickets(conn, regID, 7, nCount);
                        }
                    if (cName.Contains("Gideon Presidents Breakfast"))
                        if (sValue.Length > 0)
                        {
                            nCount = Convert.ToInt32(sValue);
                            if (nCount > 0)
                                EventDAL.AddTickets(conn, regID, 6, nCount);
                        }
                    if (cName.Contains("Gideon and Auxiliary Member Breakfast"))
                        if (sValue.Length > 0)
                        {
                            nCount = Convert.ToInt32(sValue);
                            if (nCount > 0)
                                EventDAL.AddTickets(conn, regID, 5, nCount);
                        }
                    if (cName.Contains("Auxiliary Luncheon"))
                        if (sValue.Length > 0)
                        {
                            nCount = Convert.ToInt32(sValue);
                            if (nCount > 0)
                                EventDAL.AddTickets(conn, regID, 8, nCount);
                        }
                    if (cName.Contains("International Outreach Ministry Lunch"))
                        if (sValue.Length > 0)
                        {
                            nCount = Convert.ToInt32(sValue);
                            if (nCount > 0)
                                EventDAL.AddTickets(conn, regID, 9, nCount);
                        }
                    if (cName.Contains("Fellowship Banquet"))
                        if (sValue.Length > 0)
                        {
                            nCount = Convert.ToInt32(sValue);
                            if (nCount > 0)
                                EventDAL.AddTickets(conn, regID, 10, nCount);
                        }
                    if (cName.Contains("Youth Activities"))
                        if (sValue.Length > 0)
                        {
                            nCount = Convert.ToInt32(sValue);
                            if (nCount > 0)
                                EventDAL.AddTickets(conn, regID, 11, nCount);
                        }
                    if (cName.Contains("Consecration Breakfast"))
                        if (sValue.Length > 0)
                        {
                            nCount = Convert.ToInt32(sValue);
                            if (nCount > 0)
                                EventDAL.AddTickets(conn, regID, 12, nCount);
                        }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Import Events Error:" + ex.Message, ex);
            }
        }

        public static bool AddTickets( SqlConnection conn, int regID, int eventID, int nCount)
        {
            string errMsg;
            try
            {
                SqlCommand cmd = new SqlCommand("EXEC sI_EventTicket @EventID, @RegID, @Count", conn);
                cmd.Parameters.Add("@EventID", SqlDbType.Int).Value = eventID;
                cmd.Parameters.Add("@RegID", SqlDbType.Int).Value = regID;
                cmd.Parameters.Add("@Count", SqlDbType.Int).Value = nCount;
                cmd.Parameters.Add("@Return", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                if(cmd.Parameters[3].Value.ToString() == "0")
                    return true;
                errMsg = "sI_EventTicket returned:" + cmd.Parameters[3].Value.ToString()
                    + "EventID" + eventID.ToString() + " RegID:" + regID.ToString();
                return false;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                throw new Exception("Add Tickets Error:" + ex.Message, ex);
            }
        }

        public static bool UpdateTickets( SqlConnection conn, int regID, int eventID, int numb)
        {
            string errMsg;
            try
            {
                SqlCommand cmd = new SqlCommand("EXEC sU_EventTicket @p1, @p2, @p3", conn);
                cmd.Parameters.Add("@p1", SqlDbType.Int).Value = eventID;
                cmd.Parameters.Add("@p2", SqlDbType.Int).Value = regID;
                cmd.Parameters.Add("@p3", SqlDbType.Int).Value = numb;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                throw new Exception("Update Tickets Error:" + ex.Message, ex);
            }
        }
    }
}

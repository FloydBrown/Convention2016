using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using RegistrationObjects;

namespace RegistrationData
{
    public class Attendee
    {
        private DataTable dtImport;
        public string errorMsg;

        public bool ImportRoster(Config cfg, string filename)
        {
            int lastRegID = 0;
            Registration lastReg = new Registration();
            //string sTemp;
            try
            {
                cfg.OpenSqlDBConnection(cfg.sqlServer, cfg.sDatabase);
                dtImport = LoadExcelWS(filename);
                foreach (DataRow dr in dtImport.Rows)
                {
                    bool addBadge = false;
                    bool bFoundMember = false;
                    int memberID = 0;
                    Member member = new Member(dr); // fills MemberID
                    int regID = 0;
                    Registration reg = new Registration();

                    //
                    // already registered? look for badge
                    //
                    string sBadgeID = dr["BADGE_NUMBER"].ToString();
                    regID = BadgeDAL.FindBadge(cfg.sqlDbConnection, sBadgeID);

                    // find the member (if any) if not already registered
                    memberID = member.MemberID;
                    if (memberID > 0)
                    {
                        member = MemberDAL.GetMember(cfg.sqlDbConnection, memberID);
                        if (member.MemberID == 0)
                            member = new Member(dr);
                        else
                            bFoundMember = true;
                    }
                    else
                        member = new Member(dr);

                    //look for a spouse registration by member/spouse ID
                    if ((memberID > 0) && (regID == 0))
                    {
                        reg = RegistrationDAL.GetRegistrationByMemberID(cfg.sqlDbConnection, memberID);
                        regID = reg.RegistrationID;
                        addBadge = true;
                    }

                    // create a registration
                    if (regID == 0)
                    {
                        addBadge = true;
                        if (memberID == 0)
                        {
                            // special test for non-member spouse
                            if ((lastReg.DateRegistered == Convert.ToDateTime(dr["SALES_DATE"])) & (lastReg.LastName.ToUpper() == dr["LAST_NAME"].ToString().ToUpper()))
                                regID = lastRegID;
                            else
                            {
                                reg.MemberID = 0;
                                reg.DateRegistered = Convert.ToDateTime(dr["Sales_Date"]);
                                reg.FirstName = member.FirstName;
                                reg.LastName = member.LastName;
                                reg.SpouseID = 0;
                                reg.sBadgeID = sBadgeID;
                                if (dr["DISCOUNT_CODE_LIST"].ToString().ToUpper() == "SPECIAL")
                                    reg.bSpecialGuest = true;
                                if (dr["DISCOUNT_CODE_LIST"].ToString().ToUpper() == "SPEC")
                                    reg.bSpecialGuest = true;
                                regID = RegistrationDAL.AddRegistration(cfg.sqlDbConnection, reg);
                                if (regID == 0)
                                    return false;
                            }
                        }
                        // find Registration by Member ID
                        else
                        {
                            // special test for non-member spouse
                            if ((lastReg.DateRegistered == Convert.ToDateTime(dr["SALES_DATE"])) & (lastReg.LastName.ToUpper() == dr["LAST_NAME"].ToString().ToUpper()))
                                regID = lastRegID;
                            else
                            {
                                reg = RegistrationDAL.GetRegistrationByMemberID(cfg.sqlDbConnection, memberID);
                                regID = reg.RegistrationID;
                            }
                            if(regID==0)
                            {
                                // out of state member for example
                                if(!bFoundMember)
                                    member = new Member(dr);
                                reg.MemberID = memberID;
                                reg.DateRegistered = Convert.ToDateTime(dr["Sales_Date"]);
                                reg.FirstName = member.FirstName;
                                reg.LastName = member.LastName;
                                reg.SpouseID = member.SpouseID;
                                reg.sBadgeID = sBadgeID;
                                if (dr["DISCOUNT_CODE_LIST"].ToString().ToUpper() == "SPECIAL")
                                    reg.bSpecialGuest = true;
                                 
                                regID = RegistrationDAL.AddRegistration(cfg.sqlDbConnection, reg);
                                if (regID == 0)
                                    return false;
                            }
                        }
                    }

                    if (addBadge)
                    {
                        BadgeDAL.AddBadgeFromRoster(cfg.sqlDbConnection, dr, member, regID);
                        
                        //import events
                        EventDAL.ImportEvents(cfg.sqlDbConnection, dr, regID, dtImport.Columns);
                    }
                    lastReg = reg;
                    lastRegID = regID;
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
        }
         
        public DataTable LoadExcelWS(string fileName)
        {
            DataTable dt = new DataTable();
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + fileName;
            connectString += "; Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            // Mr. before Mrs. may not always work
            string query = "Select * from [Report$] Where [ATTENDEE_STATUS] <> 'Canceled' Order by [Sales_Date], [Salutation] ";
            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();

            return dt;
        }
    }
}

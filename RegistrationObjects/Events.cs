using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace RegistrationObjects
{
    public class Events
    {
    }

    public class Tickets
    {
        Dictionary<string, int> m_tickets = new Dictionary<string, int>();

        public bool Import(int regID, DataTable dt, DataRow dr )
        {
            foreach (DataColumn dc in dt.Columns)
            {
                int nCount = 0;
                string cName = dc.ColumnName;
                string sValue = dr[cName].ToString();
                if (cName.Contains("Member Registration Fee"))
                    if(sValue.Length>0)
                        nCount = Convert.ToInt32(sValue);
                if (cName.Contains("Gideon Member Registration Fee"))
                    if (sValue.Length > 0)
                    {
                        nCount = Convert.ToInt32(sValue);
                    }
                if (cName.Contains("Pre-convention Dinner"))
                    if (sValue.Length > 0)
                        nCount = Convert.ToInt32(sValue);
                if (cName.Contains("Kickoff Luncheon"))
                    if (sValue.Length > 0)
                        nCount = Convert.ToInt32(sValue);
                if (cName.Contains("Pastors Banquet"))
                    if (sValue.Length > 0)
                        nCount = Convert.ToInt32(sValue);
                if (cName.Contains("Auxiliary Presidents Breakfast"))
                    if (sValue.Length > 0)
                        nCount = Convert.ToInt32(sValue);
                if (cName.Contains("Gideon Presidents Breakfast"))
                    if (sValue.Length > 0)
                        nCount = Convert.ToInt32(sValue);
                if (cName.Contains("Gideon and Auxiliary Member Breakfast"))
                    if (sValue.Length > 0)
                        nCount = Convert.ToInt32(sValue);
                if (cName.Contains("Auxiliary Luncheon"))
                    if (sValue.Length > 0)
                        nCount = Convert.ToInt32(sValue);
                if (cName.Contains("International Outreach Ministry Lunch"))
                    if (sValue.Length > 0)
                        nCount = Convert.ToInt32(sValue);
                if (cName.Contains("Fellowship Banquet"))
                    if (sValue.Length > 0)
                        nCount = Convert.ToInt32(sValue);
                if (cName.Contains("Youth Activities"))
                    if (sValue.Length > 0)
                        nCount = Convert.ToInt32(sValue);
                if (cName.Contains("Consecration Breakfast"))
                    if (sValue.Length > 0)
                        nCount = Convert.ToInt32(sValue);
            }
            
            return false;
        }
    }
}

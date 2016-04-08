using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RegistrationObjects
{
    // member data from Gideons International

    public class Member
    {
        public int MemberID;
        public int SpouseID;
        public string Title;
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public string Suffix;
        public string MemberType;
        public string Address1;
        public string Address2;
        public string City;
        public string State;
        public string PostalCode;
        public string email;
        public string HomePhone;
        public string MobilePhone;
        public string CampNumber;
        public string CampName;
        public string FullName;
        public string PrefName;
        // set default values
        public Member()
        {
            MemberID = 0;
            MemberType = "Unknown";
            SpouseID = 0;
            FirstName = MiddleName = LastName = FullName = string.Empty;
            CampName = CampNumber = HomePhone = MobilePhone = email = string.Empty;
        }

        // create a default member from Roster data - data needed to create registration only
        public Member(DataRow dr)
        {
            FirstName = dr["FIRST_NAME"].ToString();
            LastName = dr["LAST_NAME"].ToString();
            MemberType = dr["ATTENDEE_TYPE"].ToString();
            if (MemberType.ToUpper() == "GUEST")
                MemberID = 0;
            else
            {
                string sTemp = dr["Member_Number"].ToString();
                if (sTemp.Length > 2)
                    MemberID = Convert.ToInt32(sTemp);
            }
            SpouseID = 0;   // updated later
            CampName = dr["Company_Name"].ToString();
            CampNumber = email = HomePhone = MobilePhone = string.Empty;
        }
    }
}

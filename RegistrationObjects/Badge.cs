using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationObjects
{
    // member data from eReg system
    public class Badge
    {
        public int BadgeID; // assigned by eReg
        public int MemberID;
        public int SpouseID;
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public string MemberType;
        public string Address1;
        public string Address2;
        public string City;
        public string State;
        public string PostalCode;
        public string email;
        public string HomePhone;
        public string MobilePhone;
        public bool firstTime;
    }
}

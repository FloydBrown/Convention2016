using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationObjects
{
    public class Registration
    {
        public int MemberID;
        public int RegistrationID;
        public int SpouseID;
        public DateTime DateRegistered;
        public string FirstName;
        public string LastName;
        public bool bSpecialGuest;
        public string sBadgeID;
        //--private float PaymentDue;
        public Registration()
        {
            MemberID = SpouseID = RegistrationID = 0;
            FirstName = LastName = sBadgeID = string.Empty;
            bSpecialGuest = false;
        }
    }
}

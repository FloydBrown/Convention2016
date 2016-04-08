using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using RegistrationObjects;

namespace RegistrationData
{
    public class MemberDAL
    {
        public static Member GetMember(SqlConnection conn, int memberID)
        {
            string sTemp = string.Empty;
            DataTable dt = new DataTable();
            Member mobj = new Member();

            string   sqlCommand = "Select * from Members Where [Account ID] =" + memberID.ToString();

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand, conn);
            da.Fill(dt);
            mobj.MemberID = 0;
            mobj.SpouseID = 0;
            if (dt.Rows.Count > 0)
            {
                mobj.MemberID = memberID;
                DataRow dr = dt.Rows[0];
                mobj.FirstName = dr["First Name"].ToString();
                mobj.MiddleName = dr["Middle Name"].ToString();
                mobj.LastName = dr["Last Name"].ToString();
                mobj.Suffix = dr["Suffix"].ToString();
                mobj.Title = dr["Title"].ToString();
                mobj.PrefName = dr["Preferred Name"].ToString();
                mobj.FullName = dr["Preferred Full Name"].ToString();
                sTemp = dr["Spouse ID"].ToString();
                if (sTemp.Length > 1)
                    mobj.SpouseID = Convert.ToInt32(sTemp);
                else
                    mobj.SpouseID = 0;
                mobj.MemberType = dr["Member Type"].ToString();
                mobj.Address1 = dr["Address 1"].ToString();
                mobj.Address2 = dr["Address 2"].ToString();
                mobj.City = dr["City"].ToString();
                mobj.State = dr["State"].ToString();
                mobj.PostalCode = dr["Zip"].ToString();
                mobj.HomePhone = dr["Phone"].ToString();
                mobj.MobilePhone = dr["Cell Phone"].ToString();
                mobj.email = dr["email"].ToString();
                mobj.CampNumber = dr["Camp Number"].ToString();
                mobj.CampName = dr["Camp Name"].ToString();
                // "Denomination"
                mobj.MemberType = dr["Member Type"].ToString();
            }
            else
                mobj.MemberType = "NOT_FOUND";
            return mobj;
        }
    }
}

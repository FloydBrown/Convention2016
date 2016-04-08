using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RegistrationData
{
    public class Payments
    {
        public static bool AddPayment(SqlConnection conn, int regID, double amount, DateTime payDate, string payMethod, string itemNumber )
        {
            bool bResult = false;
            int result = 0;
            string errMsg = string.Empty;
            try
            {
                string sqlCmdText = "sI_Payment";

                SqlCommand cmd = new SqlCommand(sqlCmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@PayAmount", amount.ToString());
                cmd.Parameters.AddWithValue("@PayDate", payDate.ToString());
                cmd.Parameters.AddWithValue("@PayType", payMethod);
                cmd.Parameters.AddWithValue("@ItemNum", itemNumber);
                cmd.Parameters.AddWithValue("@RegID", regID.ToString());
                SqlParameter spReturn = cmd.Parameters.AddWithValue("@Return", 0);
                spReturn.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteScalar();
                result = Convert.ToInt32(spReturn.Value);
                if (result < 0)
                {
                    errMsg = "SQL Error: " + result.ToString();
                    return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
            }
            return bResult;
        }

        public static double GetPaymentSum(SqlConnection conn, int regID)
        {
            double dResult = 0;
            string errMsg = string.Empty;
            try
            {
                string sqlCmdText = " Select SUM(PAYMENT_AMOUNT) FROM Payments WHERE REG_ID=@RegID";

                SqlCommand cmd = new SqlCommand(sqlCmdText, conn);
                cmd.Parameters.AddWithValue("@RegID", regID.ToString());
                string sTemp = cmd.ExecuteScalar().ToString();
                dResult = Convert.ToDouble(sTemp);

                return dResult;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return dResult;
            }
        }
    }
}

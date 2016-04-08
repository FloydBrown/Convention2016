using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConventionRegistration
{
    public partial class PaymentBatchForm : Form
    {
        private SqlConnection _sqlConn;
        private string _PaymentMethod = string.Empty;

        public PaymentBatchForm()
        {
            InitializeComponent();
        }


        public PaymentBatchForm(SqlConnection sqlConn)
        {
            InitializeComponent();
            _sqlConn = sqlConn;
        }

        private void LoadData()
        {
            this.batchPaymentsTableAdapter.Fill(this.gA_Gideon_ConvDataSet.BatchPayments, _PaymentMethod);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _PaymentMethod = "Check";
            LoadData();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _PaymentMethod = "Credit_Card";
            LoadData();
        }

        private void PaymentBatchForm_Load(object sender, EventArgs e)
        {
            _PaymentMethod = "Check";
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sErrMsg = string.Empty;
            string sqlCmdText = "sI_PaymentBatch";
            SqlCommand cmd = new SqlCommand(sqlCmdText, _sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PayMethod", _PaymentMethod);
            cmd.Parameters.AddWithValue("@BatchDate", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@Comment",textComment.Text);
            cmd.ExecuteNonQuery();
        }
    }
}

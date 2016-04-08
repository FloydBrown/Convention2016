using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RegistrationData;
using RegistrationObjects;

namespace ConventionRegistration
{
    public partial class CheckinFrm : Form
    {
        SqlConnection m_conn;
        private int m_regID;
        Registration m_reg;
        double dAmountDue = 0;
        public CheckinFrm( SqlConnection conn, Registration reg )
        {
            InitializeComponent();
            m_conn = conn;
            m_reg = reg;
            m_regID = reg.RegistrationID;
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Registration Num: " + m_regID.ToString() + "  " + m_reg.FirstName + " " + m_reg.LastName +
                "\r\nMember ID:" + m_reg.MemberID.ToString() +
                "\r\nDate Registered: " + m_reg.DateRegistered.ToString("MM/dd/yyyy HH:mm");
            LoadData();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    int eventID = Convert.ToInt32(dr.Cells[0].Value);
                    int xCount = Convert.ToInt32(dr.Cells[1].Value);
                    int nCount = Convert.ToInt32(dr.Cells["Count2"].Value);
                    if (nCount != xCount)
                        EventDAL.UpdateTickets(m_conn, m_regID, eventID, nCount);
                }
                LoadData();
                dataGridView1.Update();
                dataGridView1.Refresh();
            }
            catch
            {
                MessageBox.Show("Something wroong here!", "Edit Events");
            }
        }

        private void btnBadge_Click(object sender, EventArgs e)
        {
            BadgeForm bf = new BadgeForm(m_conn, m_regID);
            bf.Show();
        }

        private void LoadData()
        {
            double cost = 0, paid;
            this.eventTableAdapter.Fill(this.gA_Gideon_ConvDataSet.Event, m_regID);
            foreach( DataGridViewRow dr in dataGridView1.Rows)
            {
                if(dr.Cells["Cost"].Value != DBNull.Value )
                    cost = cost + Convert.ToDouble(dr.Cells["Cost"].Value);
            }
            
            textTotal.Text = cost.ToString("C2");
            paid = Payments.GetPaymentSum(m_conn, m_regID);
            txtPayments.Text = paid.ToString("C2");
            dAmountDue = (cost - paid);
            textDue.Text = dAmountDue.ToString("C2");


        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            PaymentForm pf = new PaymentForm(m_conn, m_regID);
            pf.amountDue = dAmountDue;
            pf.ShowDialog();

            //update amount due
            LoadData();
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RegistrationData;

namespace ConventionRegistration
{
    public partial class PaymentForm : Form
    {
        private int m_regID;
        private SqlConnection m_conn;
        public double amountDue;
        public double amountPaid;

        public PaymentForm( SqlConnection conn, int regID )
        {
            InitializeComponent();
            m_conn = conn;
            m_regID = regID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // save the payment
            double amount = Convert.ToDouble(textBox2.Text);
            DateTime payDate = Convert.ToDateTime(textPayDate.Text);
            if (!Payments.AddPayment(m_conn, m_regID, amount, payDate, listBox1.SelectedItem.ToString(), textBox3.Text))
                MessageBox.Show("Error");
            else
            {
                amountPaid = amount;
                this.Close();
            }
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = m_regID.ToString();
            textBox2.Text = amountDue.ToString();
            textPayDate.Text = DateTime.Now.ToString();
            listBox1.SelectedIndex = 1;     // default to checks
        }
    }
}

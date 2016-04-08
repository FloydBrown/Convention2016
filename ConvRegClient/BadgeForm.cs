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
    public partial class BadgeForm : Form
    {
        private SqlConnection m_conn;
        private int m_RegID;
        public BadgeForm(SqlConnection conn, int regID)
        {
            m_conn = conn;
            InitializeComponent();
            m_RegID = regID;
        }

        private void BadgeForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            this.badgeTableAdapter.Fill(this.gA_Gideon_ConvDataSet.Badge, m_RegID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    string sTemp = string.Empty;
                    if (dr.IsNewRow)
                    {
                        try
                        {
                            if (dr.Cells[2].Value != null)
                            {
                                sTemp = dr.Cells["firstName"].Value.ToString();
                                // add badge code goes here
                            }
                        }
                        catch (NullReferenceException ex)
                        {
                            MessageBox.Show("Missing Data:" + ex.Message);
                        }
                    }
                    else
                    {
                        string sBadgeID = dr.Cells[0].Value.ToString();
                        sTemp = dr.Cells[1].Value.ToString();
                        sTemp = dr.Cells["oldBadgeName"].Value.ToString();
                        string sTitle = dr.Cells["title"].Value.ToString();
                        string sFirstName = dr.Cells["firstName"].Value.ToString();
                        string sMidName = dr.Cells["middleName"].Value.ToString();
                        string sLastName = dr.Cells["lastName"].Value.ToString();
                        string sBadgeName = dr.Cells["badgeName"].Value.ToString();
                        string sCity = dr.Cells["City"].Value.ToString();
                        if (sBadgeName != sTemp)
                            BadgeDAL.UpdateBadge(m_conn, sBadgeID, sTitle, sFirstName, sMidName, sLastName, sBadgeName, sCity, false);
                    }
                }
            }
            catch(NoNullAllowedException ex)
            {
                MessageBox.Show("Badge" + ex.Message);
            }
            return;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int BadgeId = (m_RegID * 100) + dataGridView1.Rows.Count;
            BadgeDAL.AddEmptyBadge(m_conn, BadgeId, m_RegID);
            LoadData();
        }

         

        
    }
}

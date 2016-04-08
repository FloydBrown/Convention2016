using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConventionRegistration
{
    public partial class FindMember : Form
    {
        private string m_LastName;
        public FindMember( string sName)
        {
            InitializeComponent();
            m_LastName = sName;
        }

        private void FindMember_Load(object sender, EventArgs e)
        {
            members1TableAdapter.Fill(this.gA_Gideon_ConvDataSet.Members1, m_LastName + '%');
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int MemberID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            return;
        }
    }
}

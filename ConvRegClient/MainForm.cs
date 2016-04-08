using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RegistrationData;
using RegistrationObjects;

namespace ConventionRegistration
{
    public partial class Form1 : Form
    {
        RegistrationObjects.Config cfg;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cfg = new RegistrationObjects.Config();
            if (!cfg.SetConfiguration(ConfigurationManager.AppSettings))
                MessageBox.Show("Configuration Error: " + cfg.sqlErrorMsg, "Convention Registration 2015");



        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*************************************88
            textBox1.Text = "Select Roster File to be Imported.";
            OpenFileDialog dlgOpen = new OpenFileDialog();
            bool bOK = (dlgOpen.ShowDialog() == DialogResult.OK);
            if (bOK)
            {
                textBox1.Text = "Import in Progress: " + dlgOpen.FileName;
                RegistrationData.Attendee attend = new RegistrationData.Attendee();
                textBox1.Text = "Starting Import: " + dlgOpen.FileName;
                if (attend.ImportRoster(cfg, dlgOpen.FileName))
                    textBox1.Text = "Success";
                else
                    MessageBox.Show("Error: " + attend.errorMsg);

            }***********************************************************/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Georgia Gideons Convention Registration - (C) 2015 - ELBA Systems LLC");
        }

        private void btnAddReg_Click(object sender, EventArgs e)
        {
            if ((cfg.sqlDbConnection == null) || (cfg.sqlDbConnection.State != ConnectionState.Open))
                cfg.OpenSqlDBConnection(cfg.sqlServer, cfg.sDatabase);
            AddRegistration(Convert.ToInt32(txMemberID.Text));
        }

        private void btnCheckIN_Click(object sender, EventArgs e)
        {
            int regID = Convert.ToInt32(txRegID.Text);
            if ((cfg.sqlDbConnection == null) || (cfg.sqlDbConnection.State != ConnectionState.Open))
                cfg.OpenSqlDBConnection(cfg.sqlServer, cfg.sDatabase);
            CheckInForm(regID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindMember find = new FindMember(txLastName.Text);
            find.Show();
        }

        private bool AddRegistration(int memberID)
        {
            bool addSpouse = false;
            try
            {
                Member newMem = MemberDAL.GetMember(cfg.sqlDbConnection, memberID);
                Member spouse = new Member();
                string sConfirmText = string.Format("New Registration for: {0} Camp: {1}", newMem.FullName, newMem.CampName);
                if (newMem.SpouseID > 0)
                {
                    spouse = MemberDAL.GetMember(cfg.sqlDbConnection, newMem.SpouseID);
                    sConfirmText += " Add " + spouse.FirstName + "?";
                    addSpouse = true;
                }
                MessageBoxButtons mbb = MessageBoxButtons.OKCancel;
                if (addSpouse)
                    mbb = MessageBoxButtons.YesNoCancel;
                DialogResult drConfirm = MessageBox.Show(sConfirmText, "Confirm New Registration", mbb);
                if (drConfirm == DialogResult.Cancel)
                    return false;
                if (drConfirm == DialogResult.No)
                    addSpouse = false;
                // else if Yes keep addSpouse true
                Registration reg = new Registration();
                reg.DateRegistered = DateTime.Now;
                reg.FirstName = newMem.FirstName;
                reg.LastName = newMem.LastName;
                reg.MemberID = newMem.MemberID;
                reg.sBadgeID = "0";     // update after reg_id is assigned
                if (addSpouse)
                    reg.SpouseID = newMem.SpouseID;
                // first timers?
                drConfirm = MessageBox.Show("First time at a State Convention?", "New Registration", MessageBoxButtons.YesNoCancel);
                if (drConfirm == DialogResult.Cancel)
                    return false;   // last chance to cancel
                // add the registration object
                int regID = RegistrationDAL.AddRegistration(cfg.sqlDbConnection, reg);
                if (regID == 0)
                    return false;
                // add the badges
                int badgeId = regID * 100;
                bool bFirstTime = (drConfirm == DialogResult.Yes);
                BadgeDAL.AddBadgeFromMember(cfg.sqlDbConnection, newMem, regID, badgeId, bFirstTime);
                if (addSpouse)
                {
                    badgeId++;
                    BadgeDAL.AddBadgeFromMember(cfg.sqlDbConnection, spouse, regID, badgeId, bFirstTime);    // assume both first time
                }
                // done
                string sBadgeNames = string.Format("Registration Added - Badge Name(s) defaulted to {0}", newMem.PrefName);
                if (addSpouse)
                    sBadgeNames += " and " + spouse.PrefName;
                MessageBox.Show(sBadgeNames, "Registration ID:" + regID.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "New Registration Error");
            }
            return true;
        }

        private bool CheckInForm(int regID)
        {
            try
            {
                Registration reg = RegistrationDAL.GetRegistrationByRegID(cfg.sqlDbConnection, regID);
                if (reg.RegistrationID == 0)
                {
                    MessageBox.Show("Registration NUmber: " + regID.ToString() + " was not found.", "Checkin Error");
                    return false;
                }

                CheckinFrm checkin = new CheckinFrm(cfg.sqlDbConnection, reg);
                checkin.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Registration Checkin Error");
            }
            return true;

        }

        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((cfg.sqlDbConnection == null) || (cfg.sqlDbConnection.State != ConnectionState.Open))
                cfg.OpenSqlDBConnection(cfg.sqlServer, cfg.sDatabase);
            PaymentBatchForm pbForm = new PaymentBatchForm(cfg.sqlDbConnection);
            pbForm.Show();
        }

        private void badgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Select Roster File to be Imported.";
            OpenFileDialog dlgOpen = new OpenFileDialog();
            bool bOK = (dlgOpen.ShowDialog() == DialogResult.OK);
            if (bOK)
            {
                textBox1.Text = "Import in Progress: " + dlgOpen.FileName;
                RegistrationData.Attendee attend = new RegistrationData.Attendee();
                textBox1.Text = "Starting Import: " + dlgOpen.FileName;
                if (attend.ImportRoster(cfg, dlgOpen.FileName))
                    textBox1.Text = "Success";
                else
                    MessageBox.Show("Error: " + attend.errorMsg);

            }
        }

        private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Select Roster File to Update all Events.";
            OpenFileDialog dlgOpen = new OpenFileDialog();
            bool bOK = (dlgOpen.ShowDialog() == DialogResult.OK);
            if (bOK)
            {
                textBox1.Text = "Import in Progress: " + dlgOpen.FileName;
                EventDAL events = new EventDAL();

                textBox1.Text = "Starting Import: " + dlgOpen.FileName;
                if (events.DeleteAllTickets(cfg))
                {
                    textBox1.Text = "Delete All Tickets - OK";
                    if (events.ImportAllEvents(cfg, dlgOpen.FileName))
                        textBox1.Text = "Success";
                    else
                        MessageBox.Show("Error: " + events.ErrorMessage);
                }
                else
                    MessageBox.Show("Error: " + events.ErrorMessage);
            }
        }
    }
}

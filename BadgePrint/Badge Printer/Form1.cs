using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Convention_ReportDataObjects;

namespace Badge_Printer
{
    public partial class Form1 : Form
    {
        BadgeData dbBadge = new BadgeData();
        BadgePrint bPrint = new BadgePrint();
        DataTable dtBadge = null;
        Font pf;
        int nBadge, nBadgeOffsetX, nBadgeOffsetY, nPage;
        string _ImagePath = string.Empty;

        public Form1()
        {
            InitializeComponent();

            // show badges ready to print
            dbBadge.OpenSqlDBConnection(ConfigurationManager.AppSettings["dbServer"].ToString(),
                                        ConfigurationManager.AppSettings["dbName"].ToString());
            dataGridView1.DataSource = dbBadge.GetUnprintedBadges();
            comboBox1.SelectedIndex = 0;
            _ImagePath = ConfigurationManager.AppSettings["ImagePath"].ToString();
            nBadgeOffsetX = Convert.ToInt32(ConfigurationManager.AppSettings["BadgeOffsetLeft"]);
            nBadgeOffsetY = Convert.ToInt32(ConfigurationManager.AppSettings["BadgeOffsetTop"]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbBadge.GetUnprintedBadges();
            comboBox1.SelectedIndex = 0;
            _ImagePath = ConfigurationManager.AppSettings["ImagePath"].ToString();
            nBadgeOffsetX = Convert.ToInt32(ConfigurationManager.AppSettings["BadgeOffsetLeft"]);
            nBadgeOffsetY = Convert.ToInt32(ConfigurationManager.AppSettings["BadgeOffsetTop"]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dtBadge = dbBadge.GetUnprintedBadges();
                if (comboBox1.SelectedIndex == 0)
                    bPrint.BadgePerPage = 3;
                else
                    bPrint.BadgePerPage = 6;
                nBadge = 0;
                nPage = 1;

                DataTable dtInfo = dbBadge.GetBadgeInfo();

                bPrint.Initialize(nBadgeOffsetX, nBadgeOffsetY, _ImagePath, dtInfo);

                pf = new Font("Arial", 12);
                PrintDialog pDlg = new PrintDialog();
                PrintDocument pDoc = new PrintDocument();
                pDoc.PrintPage += new PrintPageEventHandler(this.PrintPage);
                pDlg.Document = pDoc;
                pDlg.AllowSomePages = true;
                pDlg.ShowDialog();
                pDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            float lm = ev.MarginBounds.Left;
            float tm = ev.MarginBounds.Top;
            float center = (ev.PageBounds.Width / 2);

            SizeF pSize = ev.PageSettings.PrintableArea.Size;
            // Page location markers
            float aboveBadgeY = nBadgeOffsetY - 50;
            ev.Graphics.DrawString("[Left", pf, Brushes.Black, nBadgeOffsetX, aboveBadgeY);
            ev.Graphics.DrawString("Page: " + nPage.ToString(), pf, Brushes.Black, 200, nBadgeOffsetY + 925);
            float x = nBadgeOffsetX + 400 - ev.Graphics.MeasureString("Right]", pf).Width;
            ev.Graphics.DrawString("Right]", pf, Brushes.Black, x, aboveBadgeY);
                
            int nBadgePosition = 0;
            while ((nBadgePosition < bPrint.BadgePerPage)&&(nBadge<dtBadge.Rows.Count))
            {
                DataRow dr = dtBadge.Rows[nBadge++];
                string sBadgeID = dr["Badge_ID"].ToString();
                bPrint.PrintOneBadge(ev, dr, nBadgePosition++);
                dbBadge.UpdateBadge(sBadgeID);
            }
            ev.HasMorePages = true;
            if (nBadge >= dtBadge.Rows.Count)
                ev.HasMorePages = false;
            if (nPage++ >= ev.PageSettings.PrinterSettings.ToPage)
                ev.HasMorePages = false;
        }

        // cancel form and program
        private void button2_Click(object sender, EventArgs e)
        {
            
            Close();
        }
    }
}

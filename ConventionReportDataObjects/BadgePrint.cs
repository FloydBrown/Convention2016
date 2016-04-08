using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convention_ReportDataObjects
{
    public class BadgePrint
    {
        private int _badgesPerPage = 3;
        private float _badgeX, _badgeY;
        private int _marginX = 25;  // 1/4 inch from left endg
        private int _marginY = 100; // 1.0 inch from top
        private Image _auxLogo;
        private Image _gidLogo;
        public string _ErrorMsg;
        private string _ImagePath = string.Empty;
        private string _sConvTitle = "Badge Info Missing";
        private string _sConvDates = string.Empty;
        private string _sConvLocation = string.Empty;

        //public SqlConnection sqlDbConn;

        public int BadgePerPage
        {
            get { return _badgesPerPage; }
            set {
                _badgesPerPage = value;
                _badgeX = _marginX;
                _badgeY = _marginY;
            }
        }

        public string ErrorMessage
        {
            get { return _ErrorMsg;  }
        }

        public bool Initialize(int marginX, int marginY,string path,DataTable dtBadgeInfo)
        {
            try
            {
                _marginX = marginX;
                _marginY = marginY;
                _ImagePath = path;
                _auxLogo = Image.FromFile(_ImagePath + "\\AuxLogo.jpg");
                _gidLogo = Image.FromFile(_ImagePath + "\\GidLogo.jpg");

                DataRow drBadgeInfo = dtBadgeInfo.Rows[0];
                _sConvDates = drBadgeInfo["Dates"].ToString();
                _sConvLocation = drBadgeInfo["Location"].ToString();
                _sConvTitle = drBadgeInfo["Title"].ToString();

                return true;
            }
            catch (Exception ex)
            {
                _ErrorMsg = ex.Message;
                return false;
            }
        }

        public bool PrintOneBadge(PrintPageEventArgs pea, DataRow drBadge, int badgePosition)
        {
            // set badge position on 8.5 x 11 page
            _badgeX = _marginX;
            if (_badgesPerPage == 3)
                _badgeY = _marginY + (badgePosition * 300);
            else
            {
                _badgeX = _marginX + (badgePosition % 2) * 400;
                _badgeY = _marginY + ((badgePosition / 2) * 300);
            }
            float x = _badgeX + 20;
            float y = _badgeY + 20;
            float center = _badgeX + 200;
            _ErrorMsg = string.Empty;
            string sBadgeTitle = "The Gideons International";

            Font pf = new Font("Arial",10);
            Brush br = Brushes.Black;

            pea.Graphics.DrawImage(_gidLogo, x, y, 50, 50);
            x = _badgeX + 330;
            pea.Graphics.DrawImage(_auxLogo, x, y, 50, 50);

            //Print Title centered between the Logos
            pf = new Font("Arial", 14);
            x = center - (pea.Graphics.MeasureString(sBadgeTitle, pf).Width / 2);
            pea.Graphics.DrawString(sBadgeTitle, pf, br, x, y);
            y = y + pf.Height;

            // print conv Title
            pf = new Font("Arial", 10);
            x = center - (pea.Graphics.MeasureString(_sConvTitle, pf).Width / 2);
            pea.Graphics.DrawString(_sConvTitle, pf, br, x, y);
            y = y + pf.Height;

            // print convention location
            pf = new Font("Arial", 10);
            x = center - (pea.Graphics.MeasureString(_sConvLocation, pf).Width / 2);
            pea.Graphics.DrawString(_sConvLocation, pf, br, x, y);
            y = y + pf.Height;

            // print conv Dates
            pf = new Font("Arial", 10);
            x = center - (pea.Graphics.MeasureString(_sConvDates, pf).Width / 2);
            pea.Graphics.DrawString(_sConvDates, pf, br, x, y);
            y = y + pf.Height + 25;

            // Print BadgeName
            pf = new Font("Arial", 24, FontStyle.Bold);
            string sText = drBadge["Badge_Name"].ToString().ToUpper();
            x = center - (pea.Graphics.MeasureString(sText, pf).Width / 2);
            pea.Graphics.DrawString(sText, pf, br, x, y);
            y = y + pf.Height + 20;

            //Print Personalization Line2
            pf = new Font("Arial", 14);
            sText = drBadge["Line2"].ToString();
            x = center - (pea.Graphics.MeasureString(sText, pf).Width / 2);
            pea.Graphics.DrawString(sText, pf, br, x, y);
            y = y + pf.Height;

            //Print Personalization Line3
            pf = new Font("Arial", 12);
            sText = drBadge["Line3"].ToString();
            x = center - (pea.Graphics.MeasureString(sText, pf).Width / 2);
            pea.Graphics.DrawString(sText, pf, br, x, y);
            y = y + pf.Height;

            //Print Camp Name and Number
            pf = new Font("Arial", 11);
            sText = drBadge["Camp_Name"].ToString() + "  " + drBadge["Camp_Number"].ToString();
            x = center - (pea.Graphics.MeasureString(sText, pf).Width / 2);
            pea.Graphics.DrawString(sText, pf, br, x, y);
            y = y + pf.Height + 25;

            //Registration Number
            pf = new Font("Arial", 8);
            sText = "Registration: " + drBadge["Reg_ID"].ToString();
            x = _badgeX + 30;
            pea.Graphics.DrawString(sText, pf, br, x, y);
            //y = y + pf.Height;

            //First Time
            sText = drBadge["First_Time"].ToString().Trim();
            if(sText =="True")
            {
                sText = "First Time";
                x = center - (pea.Graphics.MeasureString(sText, pf).Width / 2);
                pea.Graphics.DrawString(sText, pf, br, x, y);
            }

            //Member ID
            sText = drBadge["Member_ID"].ToString().Trim();
            if (sText == "0")
            {
                sText = drBadge["Member_Type"].ToString();
                x = _badgeX + 340;
            }
            else
            {
                sText = "Member: " + sText;
                x = _badgeX + 290;
            }
            pea.Graphics.DrawString(sText, pf, br, x, y);
            y = y + pf.Height;

            return true;
        }

        public bool PrintPage()
        {
            return false;
        }
    }
}

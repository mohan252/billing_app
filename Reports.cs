using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BillingApplication
{
    public partial class Reports : Form
    {
        DAL dalObj = new DAL();
        string currAccYear = "";
        string runningYear = "";
        static ReportConfiguration reportConfigObj;
        public Reports()
        {
            InitializeComponent();
            //Read config xml file and store it in cache
            reportConfigObj = dalObj.CacheConfigDom();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            BuildReportsTabs();
            this.Bounds = MdiParent.ClientRectangle;
            this.WindowState = FormWindowState.Maximized;
            tabReport.SelectedTab = tabReport.TabPages[0];
            SetAccoutingYear();
            Initialize();
        }
        private void Initialize()
        {
            Report report = (Report)tabReport.SelectedTab.Tag;
            if (report.ChartType.Length > 1)
            {
                SetRadioButtons(report);
                SetRadioButtonSelected();
            }
            else
            {
                radioPanel.Height = 0;
                InitializeFilters(report.ChartType[0], report);
            }
        }
        private void SetRadioButtonSelected()
        {
            foreach (Control ctrl in splitContainer1.Panel1.Controls)
            {
                Panel filterPanel = ctrl as Panel;
                if (filterPanel != null)
                {
                    foreach (Control ctl in filterPanel.Controls)
                    {
                        RadioButton btn = ctl as RadioButton;
                        if (btn != null)
                        {
                            btn.Checked = true;
                            break;
                        }
                    }
                }
            }
        }
        private void tabReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Initialize();
            Cursor.Current = Cursors.Default;
        }
        private void SetAccoutingYear()
        {
            DataTable dt = dalObj.GetAccountingYear();
            DataRow dr = dt.NewRow();
            //Get Current Year
            int currMonth = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            if (currMonth >= 4)
                currAccYear = year + "-" + (year + 1);
            else
                currAccYear = (year - 1) + "-" + year;
            runningYear = currAccYear;
            dr[0] = currAccYear;
            dt.Rows.InsertAt(dr, cbAccYear.Items.Count);
            //Remove 2006 - 2007 from it as we can't show this bill
            DataRow[] drs = dt.Select("ACCOUNTINGYEAR = '" + "2006-2007" + "'");
            if (drs != null && drs.Length > 0)
                dt.Rows.Remove(drs[0]);
            cbAccYear.DataSource = dt;
            cbAccYear.ValueMember = "ACCOUNTINGYEAR";
            cbAccYear.DisplayMember = "ACCOUNTINGYEAR";
            cbAccYear.SelectedIndex = cbAccYear.Items.Count - 1;
        }

        private void cbAccYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAccYear.Text.Length <= 11)
            {
                currAccYear = cbAccYear.Text;
                partyWiseStamp_YearChanged();
            }
        }

        private void bkButton_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void partyWiseStamp_YearChanged()
        {
            Report report = (Report)tabReport.SelectedTab.Tag;
            if (report.Name == "Partywise Item Stamp")
            {
                tabReport_SelectedIndexChanged(null, null);
            }
        }
    }
}
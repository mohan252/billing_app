using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Infragistics.Win.UltraWinGrid;
//using Excel = Microsoft.Office.Interop.Excel;

namespace BillingApplication
{
    public partial class PendingList : Form
    {
        string fDate = "";
        string tDate = "";
        string address = "";
        DAL dalObj = new DAL();
        global::BillingApplication.Properties.Settings settings = global::BillingApplication.Properties.Settings.Default;
        public PendingList()
        {
            InitializeComponent();
        }

        private void PendingList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'companyDS.ADDRESS',
            // companyDS.AGENTS,companyDS.PARTIES table. 
            this.aDDRESSTableAdapter.Fill(this.companyDS.ADDRESS);
            //this.aGENTSTableAdapter.Fill(this.companyDS.AGENTS);
            //this.pARTIESTableAdapter.GetPartyNames(this.companyDS.PARTIES);

            this.Bounds = MdiParent.ClientRectangle;
            this.WindowState = FormWindowState.Maximized;
            dpFrom.CustomFormat = "dd/MM/yyyy";
            dpFrom.Format = DateTimePickerFormat.Custom;
            dpTo.CustomFormat = "dd/MM/yyyy";
            dpTo.Format = DateTimePickerFormat.Custom;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            Cursor original = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string party = "";
            string agent = "";
            if (ckParty.Checked)
                party = cbParty.Text;
            address = cbAddress.Text;
            if (ckDate.Checked)
            {
                fDate = dpFrom.Value.ToShortDateString();
                tDate = dpTo.Value.AddDays(1).ToShortDateString();
            }
            else
            {
                fDate = "";
                tDate = "";
            }
            if (!ckBillWise.Checked)
                agent = cbAgent.Text;
            System.Data.DataTable dt = dalObj.GetPendingListData(cbAddress.Text, fDate, tDate);
            dt.Columns.Add("SR.NO", typeof(Int32));
            dt.Columns["SR.NO"].SetOrdinal(0);
            if (dt != null && dt.Rows.Count > 0)
                AddSerialNoColumn(dt.Rows);
            foreach (DataColumn col in dt.Columns)
                col.ReadOnly = true;
            ClearGrid();
            dgBills.DataSource = dt;
            dgBills.DisplayLayout.Bands[0].Columns["BILLNO"].Width = 100;
            dgBills.DisplayLayout.Bands[0].Columns["PARTY"].Width = 200;
            dgBills.DisplayLayout.Bands[0].Columns["AGENT"].Width = 200;
            dgBills.DisplayLayout.Bands[0].Columns["BILLDATE"].Width = 100;
            //Set summaries
            dgBills.DisplayLayout.Bands[0].Columns["TOTALWOCD"].AllowRowSummaries = AllowRowSummaries.True;
            if (dgBills.Rows.Count > 0)
            {
                txtBillNo.Enabled = true;
                dgBills.ActiveRow = dgBills.Rows[0];
                txtBillNo.Text = Convert.ToString(dgBills.Rows[0].Cells["BILLNO"].Value);
            }
            else
                txtBillNo.Enabled = false;
            this.Cursor = original;
        }
        private void AddSerialNoColumn(DataRow[] drs)
        {
            if (drs != null && drs.Length > 0)
            {
                int i = 1;
                foreach (DataRow dr in drs)
                    dr["SR.NO"] = i++;
            }
        }
        private void AddSerialNoColumn(DataRowCollection drs)
        {
            if (drs != null && drs.Count > 0)
            {
                int i = 1;
                foreach (DataRow dr in drs)
                    dr["SR.NO"] = i++;
            }
        }
        private void ClearGrid()
        {
            dgBills.DataSource = null;
            dgBills.DataBind();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            Cursor original = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            //Set the path and file name for excel file
            string path = cbAddress.Text.Replace("/", "") + "_";
            string date = "";
            if (ckDate.Checked)
                date = GetDateString(dpFrom.Value) + "_TO_" + GetDateString(dpTo.Value);
            else
                date = GetDateString(DateTime.Now);
            path = path + date + ".xls";
            if (!Directory.Exists(settings.PLDefaultFileLocation))
                Directory.CreateDirectory(settings.PLDefaultFileLocation);
            path = settings.PLDefaultFileLocation + "\\" + path;

            //Start building the data
            System.Data.DataTable dt = null;
            string fromDate = "";
            string toDate = "";
            if (ckDate.Checked)
            {
                fromDate = dpFrom.Value.ToShortDateString();
                toDate = dpTo.Value.AddDays(1).ToShortDateString();
            }
            if (fromDate == fDate && toDate == tDate && address == cbAddress.Text && dgBills.DataSource != null)
            {
                dt = (System.Data.DataTable)dgBills.DataSource;
                //dt.Columns["SR.NO"].ReadOnly = false;
            }
            else
            {
                dt = dalObj.GetPendingListData(cbAddress.Text, fromDate, toDate);
                dt.Columns.Add("SR.NO", typeof(Int32));
                dt.Columns["SR.NO"].SetOrdinal(0);
            }
            //if (dt.Rows != null && dt.Rows.Count > 0)
            //{
            //    if(ckDate.Checked)
            //        Common.ExportToExcel(path, dt, aGENTSTableAdapter.GetData(), cbAddress.Text, dpTo.Value,"PENDINGAMT","");
            //    else
            //        Common.ExportToExcel(path, dt, aGENTSTableAdapter.GetData(), cbAddress.Text, DateTime.MinValue,"PENDINGAMT","");
            //}
            MessageBox.Show("Exported to " + path + " successfully");
            //change cursor to normal
            this.Cursor = original;
        }
        
        private string GetDateString(DateTime date)
        {
            return Convert.ToString(date.Day) + "_" + Convert.ToString(date.Month) + "_" + Convert.ToString(date.Year);
        }
        
        private void ckDate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDate.Checked)
            {
                dpFrom.Enabled = true;
                dpTo.Enabled = true;
            }
            else
            {
                dpFrom.Enabled = false;
                dpTo.Enabled = false;
            }
        }
        private void ckParty_CheckedChanged(object sender, EventArgs e)
        {
            cbParty.Enabled = ckParty.Checked;
        }

        private void getPartyNamesToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.pARTIESTableAdapter.GetPartyNames(this.companyDS.PARTIES);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void ckBillWise_CheckedChanged(object sender, EventArgs e)
        {
            cbAgent.Enabled = !ckBillWise.Checked;
        }

        private void dgBills_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            dgBills.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.RowFilterMode = RowFilterMode.SiblingRowsOnly;
            e.Layout.Override.DefaultRowHeight = 20;
        }
        private void SetRowIndicator()
        {
            int billNo = Convert.ToInt32(this.txtBillNo.Text);
            System.Data.DataTable dt = (System.Data.DataTable)dgBills.DataSource;
            DataRow[] drows = dt.Select("BILLNO = " + billNo);
            int index = 0;
            if (drows != null && drows.Length > 0)
            {
                int i = dt.Rows.IndexOf(drows[0]);
                index = i;
                dgBills.ActiveRow = null;
                dgBills.ActiveRow = dgBills.Rows[index];
                txtBillNo.Text = Convert.ToString(dgBills.Rows[index].Cells["BILLNO"].Value);
            }
            else
                MessageBox.Show("Bill No : " + txtBillNo.Text + " is not present in PendingList.\nCheck DDEntry form and enter the payment details.\nThen Click 'Get' button in Pending List form to reflect the changes made in DDEntry form");
        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SetRowIndicator();
            }
        }
    }
}
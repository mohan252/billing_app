using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Infragistics.Win.UltraWinGrid;

namespace BillingApplication
{
    public partial class DDEntry : Form
    {
        string fDate = "";
        string tDate = "";
        string address = "";
        UltraGridRow deletedParentRow = null;
        DAL dalObj = new DAL();
        global::BillingApplication.Properties.Settings settings = global::BillingApplication.Properties.Settings.Default;
        public DDEntry()
        {
            InitializeComponent();
        }

        private void DDEntry_Load(object sender, EventArgs e)
        {
            this.Bounds = MdiParent.ClientRectangle;
            this.WindowState = FormWindowState.Maximized;
            // TODO: This line of code loads data into the 'companyDS.AGENTS' table. You can move, or remove it, as needed.
            //this.aGENTSTableAdapter.Fill(this.companyDS.AGENTS);
            // TODO: This line of code loads data into the 'companyDS.ADDRESS' table. You can move, or remove it, as needed.
            this.aDDRESSTableAdapter.Fill(this.companyDS.ADDRESS);
            dpFrom.CustomFormat = "dd/MM/yyyy";
            dpFrom.Format = DateTimePickerFormat.Custom;
            dpTo.Format = DateTimePickerFormat.Custom;
            dpTo.CustomFormat = "dd/MM/yyyy";
        }
        private void ClearGrid()
        {
            dgBills.DataSource = null;
            //dgBills.Columns.Clear();
            //dgBills.Rows.Clear();
        }
        private void fnDisplayPosition()
        {
            //this.labelPosition.Text = this.bILLSBindingSource.Position + 1 + " of " + this.bnBills.Count;
        }
        private void SetReadOnly(DataSet ds)
        {
            System.Data.DataTable dt = ds.Tables["BILLS"];
            dt.Columns["BILLNO"].ReadOnly = true;
            dt.Columns["ADDRESS"].ReadOnly = true;
            dt.Columns["BILLDATE"].ReadOnly = true;
            dt.Columns["CITY"].ReadOnly = true;
            dt.Columns["PARTY"].ReadOnly = true;
            dt.Columns["AGENT"].ReadOnly = true;
            dt.Columns["TOTALWOCD"].ReadOnly = true;
            dt = ds.Tables["BILLPAYMENTS"];
            dt.Columns["BILLNO"].ReadOnly = true;
            dt.Columns["ADDRESS"].ReadOnly = true;
        }
        private void SetVisibility()
        {
            dgBills.DisplayLayout.Bands[0].Columns["ADDRESS"].Hidden = true;
            dgBills.DisplayLayout.Bands[0].Columns["BALANCE"].Hidden = true;
            dgBills.DisplayLayout.Bands[0].Columns["TABLENAME"].Hidden = true;
            dgBills.DisplayLayout.Bands[1].Columns["ADDRESS"].Hidden = true;
            dgBills.DisplayLayout.Bands[1].Columns["BILLNO"].Hidden = true;
            dgBills.DisplayLayout.Bands[1].Columns["PARENTTABLENAME"].Hidden = true;
            dgBills.DisplayLayout.Bands[1].Columns["MODE"].Hidden = true;
        }
        private void SetColumnTypes()
        {
            dgBills.DisplayLayout.Bands[0].Columns["BILLDATE"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            dgBills.DisplayLayout.Bands[0].Columns["BILLDATE"].MaskInput = "dd/mm/yyyy";
            dgBills.DisplayLayout.Bands[1].Columns["DATE"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            dgBills.DisplayLayout.Bands[1].Columns["DATE"].MaskInput = "dd/mm/yyyy";
            dgBills.DisplayLayout.Bands[1].Columns["CHDATE"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            dgBills.DisplayLayout.Bands[1].Columns["CHDATE"].MaskInput = "dd/mm/yyyy";
            //Retrieve radio button items from settings file
            if (modeOptionSet.Items.Count == 0)
            {
                string[] items = global::BillingApplication.Properties.Settings.Default.DDEntryPaymentMode.Split(',');
                for (int i = 0; i < items.Length; i++)
                    modeOptionSet.Items.Add(items[i], items[i]);
            }
            dgBills.DisplayLayout.Bands[1].Columns.Add("PAYMENT MODE");
            dgBills.DisplayLayout.Bands[1].Columns["PAYMENT MODE"].DataType = typeof(string);
            dgBills.DisplayLayout.Bands[1].Columns["PAYMENT MODE"].EditorControl = this.modeOptionSet;
            //Set the value as per mode column
            foreach (UltraGridRow row in this.dgBills.Rows)
            {
                if (row.ChildBands != null && row.ChildBands[0].Rows.Count > 0)
                {
                    UltraGridRow childRow = row.ChildBands[0].Rows[0];
                    childRow.Cells["PAYMENT MODE"].Value = childRow.Cells["MODE"].Value;
                }
            }
            dgBills.DisplayLayout.Bands[1].Columns["REMARKS"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            if (!this.dgBills.DisplayLayout.ValueLists.Exists("PAYMENTREMARKS"))
            {
                Infragistics.Win.ValueList objValueList = this.dgBills.DisplayLayout.ValueLists.Add("PAYMENTREMARKS");
                BillingApplication.CompanyDS.PAYMENTREMARKSDataTable payDt = paymentremarksTableAdapter.GetData();
                objValueList.ValueListItems.Add(DBNull.Value);
                foreach (BillingApplication.CompanyDS.PAYMENTREMARKSRow row in payDt)
                    objValueList.ValueListItems.Add(row.REMARKS);
                //objValueList.ValueListItems.Insert(0,DBNull.Value);
            }
            dgBills.DisplayLayout.Bands[1].Columns["REMARKS"].ValueList = this.dgBills.DisplayLayout.ValueLists["PAYMENTREMARKS"];
            //Set width
            dgBills.DisplayLayout.Bands[0].Columns["AGENT"].Width = 150;
            dgBills.DisplayLayout.Bands[0].Columns["PARTY"].Width = 200;
            dgBills.DisplayLayout.Bands[1].Columns["CHBRANCH"].Width = 50;
            dgBills.DisplayLayout.Bands[0].Columns["TOTALWOCD"].Width = 150;
            //Set summaries
            dgBills.DisplayLayout.Bands[0].Columns["TOTALWOCD"].AllowRowSummaries = AllowRowSummaries.True;
            dgBills.DisplayLayout.Bands[0].Columns["TOTALBEFORETAX"].AllowRowSummaries = AllowRowSummaries.True;
            dgBills.DisplayLayout.Bands[0].Columns["TOTALAFTERTAX"].AllowRowSummaries = AllowRowSummaries.True;
            dgBills.DisplayLayout.Bands[0].Columns["IGST"].AllowRowSummaries = AllowRowSummaries.True;
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            Cursor original = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string fDate = "", tDate = "", agent = "";
            DataSet ds = new DataSet();
            if (ckDate.Checked)
            {
                fDate = dpFrom.Value.ToShortDateString();
                tDate = dpTo.Value.AddDays(1).ToShortDateString();
            }
            //if (!ckBillBo.Checked)
            //    agent = cbAgent.Text;
            ds = dalObj.GetDDEntryBillData(cbAddress.Text, fDate, tDate);
            SetReadOnly(ds);
            ClearGrid();
            dgBills.DataSource = ds;
            dgBills.DataMember = "BILLS";
            dgBills.DataBind();
            SetVisibility();
            SetColumnTypes();
            if(dgBills.Rows != null && dgBills.Rows.Count > 0)
                dgBills.ActiveRow = dgBills.Rows[0];
            this.Cursor = original;
            /*
            //If agent is included in selection criteria , then hide agent column in the grid
            if (!ckBillBo.Checked)
                dgBills.Columns["AGENT"].Visible = false;
            MessageBox.Show("Records fetched successfully");
             */
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private bool IsRowEmpty(DataRow row)
        {
            for (int i = 3; i < row.ItemArray.Length; i++)
            {
                object obj = row.ItemArray[i];
                if (obj != null && Convert.ToString(obj) != "")
                    return false;
            }
            return true;
        }
        private void SetModeField(System.Data.DataTable dt)
        {
            //Set the value as per mode column
            foreach (UltraGridRow row1 in this.dgBills.Rows)
            {
                UltraGridRow row = null;
                //If group by is selected, then set the band 1 row as the parent row
                if (row1.Cells == null)
                    row = row1.ChildBands[0].Rows[0];
                else
                    row = row1;
                if (row.ChildBands != null && row.ChildBands[0].Rows.Count > 0)
                {
                    UltraGridRow childRow = row.ChildBands[0].Rows[0];
                    string val = Convert.ToString(childRow.Cells["PAYMENT MODE"].Value);
                    string billno = Convert.ToString(childRow.Cells["BILLNO"].Value);
                    string address = Convert.ToString(childRow.Cells["ADDRESS"].Value);
                    string table = Convert.ToString(childRow.Cells["PARENTTABLENAME"].Value);
                    DataRow[] drows = dt.Select("BILLNO = " + billno + " AND ADDRESS = '" + address + "' AND PARENTTABLENAME = '" + table + "'");
                    if (drows != null && drows.Length > 0)
                    {
                        if (IsRowEmpty(drows[0]))
                            dt.Rows.Remove(drows[0]);
                        else if (val != "" && Convert.ToString(drows[0]["MODE"]) != val)
                            drows[0]["MODE"] = val;
                    }
                }
            }
        }
        private void Save()
        {
            Cursor original = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            DataSet ds = (DataSet)dgBills.DataSource;
            System.Data.DataTable dt = ds.Tables["BILLPAYMENTS"];
            SetModeField(dt);
            try
            {
                dalObj.UpdateDDEntry(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = original;
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
        /*
        private void SetRowIndicator()
        {
            int billNo = Convert.ToInt32(this.txtBillNo.Text);
            DataSet ds = (DataSet)dgBills.DataSource;
            System.Data.DataTable dt = ds.Tables["BILLS"];
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
                MessageBox.Show("Bill No : " + txtBillNo.Text + " is not present in DDEntry.\nPlease check the Bill No and Address.");
        }
        */
        private void dgBills_AfterRowExpanded(object sender, RowEventArgs e)
        {
            if (e.Row.ChildBands[0].Rows.Count == 0)
            {
                e.Row.ChildBands[0].Rows.Band.AddNew();
            }
            dgBills.ActiveRow = e.Row.ChildBands[0].Rows[0];
        }
        private void dgBills_BeforeRowExpanded(object sender, CancelableRowEventArgs e)
        {
            dgBills.ActiveRow = e.Row;
        }

        private void dgBills_AfterRowsDeleted(object sender, EventArgs e)
        {
            dgBills.ActiveRow = deletedParentRow;
            dgBills.ActiveRow.ChildBands[0].Rows.Band.AddNew();
            dgBills.ActiveRow = deletedParentRow;
            dgBills.ActiveRow.Expanded = false;
        }

        private void dgBills_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (e.Rows[0].Band.ParentBand == null)
                e.Cancel = true;
            else
                deletedParentRow = e.Rows[0].ParentRow;
        }

        private void dgBills_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            dgBills.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.RowFilterMode = RowFilterMode.SiblingRowsOnly;
            e.Layout.Override.DefaultRowHeight = 20;
            e.Layout.Override.MaxSelectedRows = 1;
        }

        private void dgBills_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (dgBills.ActiveRow != null)
            {
                this.dgBills.AfterSelectChange -= new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.dgBills_AfterSelectChange);
                UltraGridRow activeRow = dgBills.ActiveRow;
                if (dgBills.Selected.Rows != null && dgBills.Selected.Rows.Count > 0)
                {
                    foreach (UltraGridRow row in dgBills.Selected.Rows)
                        row.Selected = false;
                }
                activeRow.Selected = true;
                dgBills.ActiveRow = activeRow;
                this.dgBills.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.dgBills_AfterSelectChange);
            }
            else if (dgBills.ActiveCell != null)
            {
                int rowIndex = dgBills.ActiveCell.Row.Index;
            }
        }

        private void DDEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgBills.DataSource != null)
            {
                dgBills.PerformAction(UltraGridAction.ExitEditMode);
                DataSet ds = (DataSet)dgBills.DataSource;
                if (ds.HasChanges())
                {
                    //if (MessageBox.Show("Changes are not saved.\r\nDo you want to save now?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //    Save();
                }
            }
        }
        private string GetDateString(DateTime date)
        {
            return Convert.ToString(date.Day) + "_" + Convert.ToString(date.Month) + "_" + Convert.ToString(date.Year);
        }
        private void btnCS_Click(object sender, EventArgs e)
        {
            Cursor original = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            //Set the path and file name for excel file
            string path = cbAddress.Text.Replace("/", "") + "_";
            path += "CS_";
            string date = "";
            if (ckDate.Checked)
                date = GetDateString(dpFrom.Value) + "_TO_" + GetDateString(dpTo.Value);
            else
                date = GetDateString(DateTime.Now);
            path = path + date + ".xls";
            if (!Directory.Exists(settings.PLDefaultFileLocation))
                Directory.CreateDirectory(settings.PLDefaultFileLocation);
            path = settings.PLDefaultFileLocation + "\\" + path;
            string amtColumn = settings.CSColumnName;
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
                dt = dalObj.GetDDEntryBillData(cbAddress.Text, fromDate, toDate).Tables[0];
                dt.Columns.Add("SR.NO", typeof(Int32));
                dt.Columns["SR.NO"].SetOrdinal(0);
            }
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                dt.Columns["BILLNO"].SetOrdinal(1);
                dt.Columns["BILLDATE"].SetOrdinal(2);
                dt.Columns["CITY"].SetOrdinal(3);
                dt.Columns["PARTY"].SetOrdinal(4);
                dt.Columns["AGENT"].SetOrdinal(5);
                dt.Columns[amtColumn].SetOrdinal(6);
                if (dt.Rows != null && dt.Rows.Count > 0)
                {
                    if (ckDate.Checked)
                        Common.ExportToExcel(path, dt, aGENTSTableAdapter.GetData(), cbAddress.Text, dpTo.Value, amtColumn, "COMISSIONSTMT");
                    else
                        Common.ExportToExcel(path, dt, aGENTSTableAdapter.GetData(), cbAddress.Text, DateTime.MinValue, amtColumn, "COMISSIONSTMT");
                }

                //if (ckDate.Checked)
                //    Common.ExportToExcel(path, dt, aGENTSTableAdapter.GetData(), cbAddress.Text, dpTo.Value, amtColumn, "COMISSIONSTMT");
                //else
                //    Common.ExportToExcel(path, dt, aGENTSTableAdapter.GetData(), cbAddress.Text, DateTime.MinValue, amtColumn, "COMISSIONSTMT");
            }
            MessageBox.Show("Exported to " + path + " successfully");
            //change cursor to normal
            this.Cursor = original;
        }
    }
}
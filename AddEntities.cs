using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BillingApplication;
using Infragistics.Win.UltraWinGrid;

namespace BillingApplication
{
    public partial class AddEntities : Form
    {
        DataTable dsTable = null;
        public AddEntities()
        {
            InitializeComponent();
        }

        private void AddEntities_Load(object sender, EventArgs e)
        {
            this.Bounds = MdiParent.ClientRectangle;
            this.WindowState = FormWindowState.Maximized;
            tabEntities.SelectedTab = tabEntities.TabPages[0];
            tabEntities_SelectedIndexChanged(null, null);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                switch (tabEntities.SelectedIndex)
                {
                    case 0:
                        CompanyDS.PARTIESDataTable pDt = (CompanyDS.PARTIESDataTable)grdEntities.DataSource;
                        partiesTableAdapter.Update(pDt);
                        break;
                    case 2:
                        CompanyDS.ITEMSDataTable iDt = (CompanyDS.ITEMSDataTable)grdEntities.DataSource;
                        itemsTableAdapter.Update(iDt);
                        break;
                    case 1:
                        CompanyDS.PAYMENTREMARKSDataTable payDt = (CompanyDS.PAYMENTREMARKSDataTable)grdEntities.DataSource;
                        paymentremarksTableAdapter.Update(payDt);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                FillDataGrid();
            }
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)grdEntities.DataSource;
            dt.RejectChanges();
        }

        private void grdEntities_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdEntities.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            grdEntities.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
            grdEntities.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.FixedAddRowOnTop;
            //grdEntities.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            grdEntities.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.RowFilterMode = RowFilterMode.SiblingRowsOnly;
            e.Layout.Override.DefaultRowHeight = 20;
        }
        private void tabEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FillDataGrid();
            tabEntities.SelectedTab.Controls.Clear();
            tabEntities.SelectedTab.Controls.Add(grdEntities);
            grdEntities.Dock = DockStyle.Fill;
            grdEntities.Visible = true;
            this.Cursor = Cursors.Default;
        }
        private void FillDataGrid()
        {
            grdEntities.DataBindings.Clear();
            //Parties
            if (tabEntities.SelectedIndex == 0)
            {
                CompanyDS.PARTIESDataTable pDt = new CompanyDS.PARTIESDataTable();
                partiesTableAdapter.Fill(pDt);
                grdEntities.DataSource = pDt;
                grdEntities.DataBind();
                if (grdEntities.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    grdEntities.DisplayLayout.Bands[0].Columns["NAME"].Width = 250;
                    grdEntities.DisplayLayout.Bands[0].Columns["ADDR1"].Width = 100;
                    grdEntities.DisplayLayout.Bands[0].Columns["ADDR2"].Width = 200;
                    grdEntities.DisplayLayout.Bands[0].Columns["ADDR3"].Width = 150;
                    grdEntities.DisplayLayout.Bands[0].Columns["DISTRICT"].Width = 150;
                    grdEntities.DisplayLayout.Bands[0].Columns["STATE"].Width = 150;
                }
            }
            //Items
            else if (tabEntities.SelectedIndex == 2)
            {
                CompanyDS.ITEMSDataTable iDt = new CompanyDS.ITEMSDataTable();
                itemsTableAdapter.Fill(iDt);
                iDt.CALCTYPColumn.ReadOnly = true;
                iDt.TYPEColumn.ReadOnly = true;
                grdEntities.DataSource = iDt;
                grdEntities.DataBind();
                if (grdEntities.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    grdEntities.DisplayLayout.Bands[0].Columns["NAME"].Width = 300;
                }
            }
            //Payment Remarks
            else if (tabEntities.SelectedIndex == 1)
            {
                CompanyDS.PAYMENTREMARKSDataTable payDt = new CompanyDS.PAYMENTREMARKSDataTable();
                paymentremarksTableAdapter.Fill(payDt);
                grdEntities.DataSource = payDt;
                grdEntities.DataBind();
                dsTable = payDt;
            }
        }

        private void grdEntities_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (tabEntities.SelectedTab.Text == "Payment Remarks")
            {
                if (IsUsed(e.Rows[0].Cells["REMARKS"].Text))
                {
                    MessageBox.Show("The remarks is already used.Please delete from the bill payments table and try deleting again");
                    e.Cancel = true;
                    e.DisplayPromptMsg = false;
                }
            }
        }

        private void grdEntities_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (tabEntities.SelectedTab.Text == "Payment Remarks")
            {
                if (dsTable != null)
                {
                    DataRow[] rows = dsTable.Select("ID = " + e.Cell.Row.Cells["ID"].Text);
                    if (rows != null && rows.Length > 0)
                    {
                        string oldValue = Convert.ToString(rows[0]["REMARKS"]);
                        if (IsUsed(oldValue))
                        {
                            MessageBox.Show("The remarks is already used.Please delete from the bill payments table and try updating again");
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
        private bool IsUsed(string val)
        {
            DAL dalObj = new DAL();
            int rslt = (int)dalObj.GetScalarData("SELECT COUNT(REMARKS) FROM BILLPAYMENTS WHERE REMARKS = '" + val + "'","","");
            if (rslt > 0)
                return true;
            else
                return false;
        }
    }
}
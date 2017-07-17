using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Shared;

namespace BillingApplication
{
    public enum BillState
    {
        New,
        Old
    }
    public partial class BillForm : Form
    {
        string currAccYear = "";
        string runningYear = "";
        int deletedRow = 0;
        NumberToEnglish num = new NumberToEnglish();
        BillState state = BillState.New;
        BillingApplication.CompanyDS.BILLSDataTable billDt = null;
        BillingApplication.CompanyDS.BILLDISCOUNTSDataTable bDist = null;
        DataTable dtFwdBy = new DataTable("FWDBY");
        DataTable dtFwdTo = new DataTable("FWDTO");
        int rowErrorCount = 0;
        DAL dalObj = new DAL();
        public BillForm()
        {
            InitializeComponent();
        }
        private void changetb()
        {
            BillingApplication.CompanyDS.PARTIESDataTable dt = new CompanyDS.PARTIESDataTable();
            dt = partiesTA.GetDataBy();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["DISTRICT"] != System.DBNull.Value)
                {
                    string dt1 = Convert.ToString(dr["DISTRICT"]);
                    dt1 = dt1.Substring(dt1.IndexOf(':') + 1);
                    dr["DISTRICT"] = dt1.Trim();
                }
            }
            partiesTA.Update(dt);
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
            //dt.Rows.InsertAt(dr, cbAccYear.Items.Count);
            dt.Rows.InsertAt(dr, 0);
            //Remove 2006 - 2007 from it as we can't show this bill
            DataRow[] drs = dt.Select("ACCOUNTINGYEAR = '" + "2006-2007" + "'");
            if (drs != null && drs.Length > 0)
                dt.Rows.Remove(drs[0]);
            //Disable combo select change event - This will disable the SetNewbill call again
            this.cbAccYear.SelectedIndexChanged -= new System.EventHandler(this.cbAccYear_SelectedIndexChanged);
            cbAccYear.DataSource = dt;
            cbAccYear.ValueMember = "ACCOUNTINGYEAR";
            cbAccYear.DisplayMember = "ACCOUNTINGYEAR";
            cbAccYear.SelectedIndex = cbAccYear.Items.Count - 1;
            //Enable combo select change event
            this.cbAccYear.SelectedIndexChanged += new System.EventHandler(this.cbAccYear_SelectedIndexChanged);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
            SetAccoutingYear();
            dtpOrderDate.CustomFormat = "dd/MM/yyyy";
            dtpOrderDate.Format = DateTimePickerFormat.Custom;
            dtpBillDt.CustomFormat = "dd/MM/yyyy";
            dtpBillDt.Format = DateTimePickerFormat.Custom;
            dtpLRDate.CustomFormat = "dd/MM/yyyy";
            dtpLRDate.Format = DateTimePickerFormat.Custom;
            pDoc.OriginAtMargins = false;
            //this.Bounds = MdiParent.ClientRectangle;
            this.WindowState = FormWindowState.Maximized;
            menuStrip1.Visible = false;
            state = BillState.New;
            InitializeBottomGrid();
            FillData();
            BindDataSources();
            SetNewBill(false);
            //Forwarding charges - not read only
            btmGrid[2, 7].ReadOnly = false;
            btmGrid[1, 1].ValueType = typeof(float);
            btmGrid[1, 2].ValueType = typeof(float);
            btmGrid[1, 3].ValueType = typeof(float);
            btmGrid[1, 4].ValueType = typeof(float);
            //Set default doc sent to as party
            cbCourier.SelectedIndex = 0;
            txtBaleno.Focus();
        }
        private void SetBillNo()
        {
            int bill = dalObj.GetBillNo(currAccYear, runningYear, cbCoy.Text);
            string billNo = Convert.ToString(bill + 1);
            this.txtInvno.Text = billNo;
            this.txtBaleno.Text = billNo;
            //set the find numeric drop down
            nddFind.Maximum = bill;
            nddFind.Value = bill;
            if (currAccYear == "2007-2008")
            {
                switch (cbCoy.Text)
                {
                    case "KUMUDAM TEXTILES":
                        nddFind.Minimum = global::BillingApplication.Properties.Settings.Default.KumudamMin;
                        break;
                    case "M/S M.KOLANDAIVEL MUDALIAR":
                        nddFind.Minimum = global::BillingApplication.Properties.Settings.Default.MKMin;
                        break;
                    case "VIKAS FABRICS":
                        nddFind.Minimum = global::BillingApplication.Properties.Settings.Default.VikasMin;
                        break;
                }
            }
            else
            {
                nddFind.Minimum = 1;
            }
            if (bill == 0 || bill < 0)
            {
                nddFind.Enabled = false;
                btnFind.Enabled = false;

            }
            else
            {
                nddFind.Enabled = true;
                btnFind.Enabled = true;
            }
        }
        private void FillData()
        {
            string myConn = ConfigurationManager.ConnectionStrings["BillingApplication.Properties.Settings.companyConn"].ConnectionString;
            SqlDataAdapter myAdap = new SqlDataAdapter();
            SqlCommand myCmd = new SqlCommand();
            myCmd.Connection = new SqlConnection(myConn);
            myAdap.SelectCommand = myCmd;
            coDs = new CompanyDS();
            //coDs.EnforceConstraints = false;
            //Fill Items
            myCmd.CommandText = "SELECT * FROM ITEMS";
            myAdap.Fill(coDs, "ITEMS");
            //Agents
            myCmd.CommandText = "SELECT * FROM ADDRESS";
            myAdap.Fill(coDs, "ADDRESS");
            //Address
            myCmd.CommandText = "SELECT * FROM AGENTS";
            myAdap.Fill(coDs, "AGENTS");
            //parties
            myCmd.CommandText = "SELECT ID,NAME,ADDR1,ADDR2,CITY,STATE,PIN FROM PARTIES";
            myAdap.Fill(coDs, "PARTIES");
        }
        private void FillItemsData()
        {
            string myConn = ConfigurationManager.ConnectionStrings["BillingApplication.Properties.Settings.companyConn"].ConnectionString;
            SqlDataAdapter myAdap = new SqlDataAdapter();
            SqlCommand myCmd = new SqlCommand();
            myCmd.Connection = new SqlConnection(myConn);
            myAdap.SelectCommand = myCmd;
            myCmd.CommandText = "SELECT * FROM ITEMS";
            if (coDs != null)
                coDs.ITEMS.Clear();
            else
                coDs = new CompanyDS();
            myAdap.Fill(coDs, "ITEMS");
        }
        private void FillPartiesData(String table)
        {
            string myConn = ConfigurationManager.ConnectionStrings["BillingApplication.Properties.Settings.companyConn"].ConnectionString;
            SqlDataAdapter myAdap = new SqlDataAdapter();
            SqlCommand myCmd = new SqlCommand();
            myCmd.Connection = new SqlConnection(myConn);
            myAdap.SelectCommand = myCmd;
            coDs = new CompanyDS();
            myCmd.CommandText = "SELECT ID,NAME,ADDR1,ADDR2,CITY,STATE,PIN FROM PARTIES";
            myAdap.Fill(coDs, table);
        }
        private void FillFwdTables(string colName)
        {
            if (colName == "FWDBY")
                dalObj.GetBillData(dtFwdBy, "FWDBY", "FWDBY");
            else if (colName == "FWDTO")
                dalObj.GetBillData(dtFwdTo, "FWDTO", "FWDTO");
        }
        private void BindAutoCompleteCustomSources(string table)
        {
            if (table == "PARTIES")
            {
                //Party list
                if (coDs.PARTIES != null && coDs.PARTIES.Count > 0)
                {
                    StringCollection strColl = new StringCollection();
                    foreach (BillingApplication.CompanyDS.PARTIESRow pR in coDs.PARTIES)
                        strColl.Add(pR.NAME);
                    string[] partyNames = new string[strColl.Count];
                    strColl.CopyTo(partyNames, 0);
                    this.txtPartyName.AutoCompleteCustomSource.Clear();
                    this.txtPartyName.AutoCompleteCustomSource.AddRange(partyNames);
                }
            }
            else if (table == "FWDBY")
            {
                if (dtFwdBy.Rows != null && dtFwdBy.Rows.Count > 0)
                {
                    StringCollection strTo = new StringCollection();
                    foreach (DataRow dr in dtFwdBy.Rows)
                        strTo.Add(Convert.ToString(dr[0]));
                    string[] strToa = new string[strTo.Count];
                    strTo.CopyTo(strToa, 0);
                    this.txtFwdBy.AutoCompleteCustomSource.AddRange(strToa);
                }
            }
            else if (table == "FWDTO")
            {
                if (dtFwdTo.Rows != null && dtFwdTo.Rows.Count > 0)
                {
                    StringCollection strTo = new StringCollection();
                    foreach (DataRow dr in dtFwdTo.Rows)
                        strTo.Add(Convert.ToString(dr[0]));
                    string[] strToa = new string[strTo.Count];
                    strTo.CopyTo(strToa, 0);
                    this.txtOrderTo.AutoCompleteCustomSource.AddRange(strToa);
                }
            }
            else if (table == "ITEMS")
            {
                if (coDs.ITEMS.Rows != null && coDs.ITEMS.Rows.Count > 0)
                {
                    StringCollection strTo = new StringCollection();
                    foreach (DataRow dr in coDs.ITEMS.Rows)
                        strTo.Add(Convert.ToString(dr[0]));
                    string[] strToa = new string[strTo.Count];
                    strTo.CopyTo(strToa, 0);
                    this.txtItemName.AutoCompleteCustomSource.AddRange(strToa);
                }
            }
        }
        private void BindDataSources(params string[] commmand)
        {
            BindAutoCompleteCustomSources("PARTIES");
            if (commmand != null && commmand.Length > 0 && commmand[0] == "Refresh")
            {

            }
            else
            {
                //Agent List
                cbAgtName.DataSource = null;
                cbAgtName.DataSource = this.coDs;
                cbAgtName.DisplayMember = "AGENTS.NAME";
                cbAgtName.ValueMember = "AGENTS.NAME";
                //Clear all datasources
                this.cbCoy.DataSource = null;
                //Company
                this.cbCoy.SelectedIndexChanged -= new System.EventHandler(this.cbCoy_SelectedIndexChanged);
                this.cbCoy.DataSource = this.coDs.ADDRESS;
                this.cbCoy.DisplayMember = "NAME";
                this.cbCoy.ValueMember = "NAME";
                this.cbCoy.SelectedIndexChanged += new System.EventHandler(this.cbCoy_SelectedIndexChanged);
            }
        }
        private void InitializeBottomGrid()
        {
            //Disable grid cell value change event
            EnableBottomGridEvents(false);

            btmGrid.Rows.Clear();
            string[] values = new string[2] { "Total", "----" };
            btmGrid.Rows.Add(values);

            btmGrid.Rows[0].Cells[0].ReadOnly = true;
            btmGrid.Rows[0].Cells[1].ReadOnly = true;
            btmGrid.Rows[0].Cells[2].ValueType = Type.GetType("System.Double");

            values = new string[1] { "Pinning Less" };
            btmGrid.Rows.Add(values);
            btmGrid.Rows[1].Cells[0].ReadOnly = true;
            btmGrid.Rows[1].Cells[2].ValueType = Type.GetType("System.Double");

            values = new string[1] { "Less Rate/Mtr" };
            btmGrid.Rows.Add(values);
            btmGrid.Rows[2].Cells[0].ReadOnly = true;
            btmGrid.Rows[2].Cells[2].ValueType = Type.GetType("System.Double");

            values = new string[1] { "Less Rate/Pair" };
            btmGrid.Rows.Add(values);
            btmGrid.Rows[3].Cells[0].ReadOnly = true;
            btmGrid.Rows[3].Cells[2].ValueType = Type.GetType("System.Double");

            values = new string[1] { global::BillingApplication.Properties.Settings.Default.Discount1 };
            btmGrid.Rows.Add(values);
            btmGrid.Rows[4].Cells[2].ValueType = Type.GetType("System.Double");

            values = new string[1] { "Discount2 %" };
            btmGrid.Rows.Add(values);
            btmGrid.Rows[5].Cells[2].ValueType = Type.GetType("System.Double");


            values = new string[2] { "Cash Discount %", "4" };
            btmGrid.Rows.Add(values);
            btmGrid.Rows[6].Cells[0].ReadOnly = true;
            btmGrid.Rows[6].Cells[1].ValueType = Type.GetType("System.Double");
            btmGrid.Rows[6].Cells[2].ValueType = Type.GetType("System.Double");

            values = new string[2] { "Forwarding Charges", "----" };
            btmGrid.Rows.Add(values);
            btmGrid.Rows[7].Cells[0].ReadOnly = true;
            btmGrid.Rows[7].Cells[1].ReadOnly = true;

            values = new string[2] { "Rounding off", "----" };
            btmGrid.Rows.Add(values);
            btmGrid.Rows[8].Cells[0].ReadOnly = true;
            btmGrid.Rows[8].Cells[1].ReadOnly = true;

            values = new string[2] { "Total Before Tax", "----" };
            btmGrid.Rows.Add(values);

            values = new string[2] { "SGST @ %", "" };
            btmGrid.Rows.Add(values);
            btmGrid.Rows[10].Cells[0].ReadOnly = true;
            btmGrid.Rows[10].Cells[1].ValueType = Type.GetType("System.Double");
            btmGrid.Rows[10].Cells[2].ValueType = Type.GetType("System.Double");

            values = new string[2] { "CGST @ %", "" };
            btmGrid.Rows.Add(values);
            btmGrid.Rows[11].Cells[0].ReadOnly = true;
            btmGrid.Rows[11].Cells[1].ValueType = Type.GetType("System.Double");
            btmGrid.Rows[11].Cells[2].ValueType = Type.GetType("System.Double");

            values = new string[2] { "IGST @ %", "" };
            btmGrid.Rows.Add(values);
            btmGrid.Rows[12].Cells[0].ReadOnly = true;
            btmGrid.Rows[12].Cells[1].ValueType = Type.GetType("System.Double");
            btmGrid.Rows[12].Cells[2].ValueType = Type.GetType("System.Double");

            values = new string[2] { "Total After Tax", "----" };
            btmGrid.Rows.Add(values);

            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            row.Cells.Add(cell);
            cell = new DataGridViewTextBoxCell();
            row.Cells.Add(cell);
            //DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
            //btnCell.Value = "Save Bill";
            //row.Cells.Add(btnCell);
            btmGrid.Rows.Add(row);


            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btmGrid.Columns[1].DefaultCellStyle = style;

            btmGrid.Rows[9].Cells[0].ReadOnly = true;
            btmGrid.Rows[9].Cells[1].ReadOnly = true;
            //Enable grid cell value change event
            EnableBottomGridEvents(true);
        }
        private void cbCoy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCoy.SelectedItem is DataRowView)
            {
                SetNewBill(false);
            }
        }
        private void AutoFillPartyAddress()
        {
            string partyName = txtPartyName.Text;
            DataRow[] dr = this.coDs.PARTIES.Select("NAME = '" + partyName + "'");
            if (dr != null && dr.Length > 0)
            {
                BillingApplication.CompanyDS.PARTIESRow partyRow = (BillingApplication.CompanyDS.PARTIESRow)dr[0];
                //store the id in tag, so that use it when saving the bill
                txtPartyName.Tag = partyRow.ID;
                try
                {
                    if (partyRow.ADDR1 != "")
                        txtPartyAddr1.Text = partyRow.ADDR1;
                    else
                        txtPartyAddr1.Text = "";
                }
                catch { txtPartyAddr1.Text = ""; }
                try
                {
                    if (partyRow.ADDR2 != "")
                        txtPartyAddr2.Text = partyRow.ADDR2;
                    else
                        txtPartyAddr2.Text = "";
                }
                catch { txtPartyAddr2.Text = ""; }
                try
                {
                    if (partyRow.CITY != "")
                        txtPartyCity.Text = partyRow.CITY;
                    else
                        txtPartyCity.Text = "";
                }
                catch { txtPartyCity.Text = ""; }
                try
                {
                    if (partyRow.STATE != "")
                        txtPartyState.Text = partyRow.STATE;
                    else
                        txtPartyState.Text = "";
                }
                catch { txtPartyState.Text = ""; }
                try
                {
                    if (Convert.ToString(partyRow.PIN) != "")
                        txtPartyPin.Text = Convert.ToString(partyRow.PIN);
                    else
                        txtPartyPin.Text = "";
                }
                catch { txtPartyPin.Text = ""; }
            }
        }
        private void txtPartyName_TextChanged(object sender, EventArgs e)
        {
            AutoFillPartyAddress();
        }
        private decimal GetRowTotal(int r)
        {
            string itemName = Convert.ToString(grdItem.Rows[r].Cells["ITEMNAME"].Value);
            DataRow[] rows = coDs.ITEMS.Select("NAME = '" + itemName + "'");
            decimal rate = Convert.ToDecimal(grdItem.Rows[r].Cells["RATE"].Value);
            decimal qty = Convert.ToDecimal(grdItem.Rows[r].Cells["QTY"].Value);
            decimal mts = -1;
            decimal tAmt = 0;
            if (Convert.ToString(grdItem.Rows[r].Cells["METRS"].Value) != "")
                mts = Convert.ToDecimal(grdItem.Rows[r].Cells["METRS"].Value);
            int calTyp = GetItemCalculationType(itemName);
            if (calTyp == 0)
                tAmt = rate * qty;
            else if (calTyp == 1)
                tAmt = rate * mts;
            return System.Math.Round(tAmt, 2, MidpointRounding.AwayFromZero);
        }
        private void UpdateRow(int r)
        {
            string itemName = Convert.ToString(grdItem.Rows[r].Cells["ITEMNAME"].Value);
            DataRow[] rows = coDs.ITEMS.Select("NAME = '" + itemName + "'");
            if (rows != null && rows.Length > 0)
            {
                if (grdItem.Rows[r].Cells["ITEMNO"].Value == null || Convert.ToString(grdItem.Rows[r].Cells["ITEMNO"].Value).Trim() == ""
                    || Convert.ToInt32(grdItem.Rows[r].Cells["ITEMNO"].Value) != r + 1)
                    grdItem.Rows[r].Cells["ITEMNO"].Value = r + 1;
                grdItem.Rows[r].Cells["ACCOUNTINGYEAR"].Value = GetAccountingYear();
                decimal tAmt = GetRowTotal(r);
                if (ckItemPin.Checked && Convert.ToString(grdItem.Rows[r].Cells["PINNINGLESS"].Value) != "")
                {
                    decimal pl = Convert.ToDecimal(grdItem.Rows[r].Cells["PINNINGLESS"].Value);
                    tAmt -= System.Math.Round(((pl / 100) * tAmt), 2, MidpointRounding.AwayFromZero);
                }
                this.grdItem.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdItem_AfterCellUpdate);
                grdItem.Rows[r].Cells["AMT"].Value = PadDigits(tAmt);
                //Update mrts field. This will happend when user just enters the value into
                // meters cell and doesn't use the meters popup
                if (grdItem.Rows[r].Cells["METRS"].Value != null)
                {
                    string totalMts = Convert.ToString(grdItem.Rows[r].Cells["METRS"].Value).Trim();
                    //visible METRS field has value but the hidden xml field MTRS doesn't have value then
                    //fill the xml field MTRS with the xml
                    if (grdItem.Rows[r].Cells["MTRS"].Value == null || Convert.ToString(grdItem.Rows[r].Cells["MTRS"].Value).Trim().Length == 0)
                    {
                        totalMts = "<Meters><Meter>" + totalMts + "</Meter><Total>" +
                                                    totalMts + "</Total></Meters>";
                        grdItem.Rows[r].Cells["MTRS"].Value = totalMts;
                    }
                    else
                    {
                        //check the total in cell is equal to total in tag(prev value)
                        string tagXml = Convert.ToString(grdItem.ActiveRow.Cells["MTRS"].Value);
                        XmlDocument inpDom = new XmlDocument();
                        inpDom.LoadXml(tagXml);
                        string tagTotal = inpDom.SelectSingleNode("/Meters/Total").InnerText;
                        //if total is not the same , then update the xml with the value in cell
                        if (tagTotal != totalMts)
                        {
                            totalMts = "<Meters><Meter>" + totalMts + "</Meter><Total>" +
                                                    totalMts + "</Total></Meters>";
                            grdItem.Rows[r].Cells["MTRS"].Value = totalMts;
                        }
                    }
                }
                this.grdItem.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdItem_AfterCellUpdate);
                UpdateBalance();
            }
            else
            {
                if (!IsEmptyRow(grdItem.ActiveRow))
                    MessageBox.Show("The Item not exists in db.\n" +
                                    "Add the item to db by entering down arrow in the empty item name cell");
            }
        }
        private void UpdateTotal()
        {
            decimal total = 0;
            decimal totalMeters = 0;
            int totalQty = 0;
            //Total mtrs textbox update
            for (int i = 0; i < grdItem.Rows.Count; i++)
            {
                UltraGridRow uiRow = grdItem.Rows[i];
                if (uiRow.Cells["METRS"].Value != null && uiRow.Cells["METRS"].Value.ToString().Trim() != "")
                    totalMeters += Convert.ToDecimal(uiRow.Cells["METRS"].Value);
                if (uiRow.Cells["QTY"].Value != null && uiRow.Cells["QTY"].Value.ToString().Trim() != "")
                    totalQty += Convert.ToInt32(uiRow.Cells["QTY"].Value);
                if (uiRow.Cells["AMT"].Value != null && uiRow.Cells["AMT"].Value.ToString().Trim() != "")
                    total += Convert.ToDecimal(uiRow.Cells["AMT"].Value);
            }
            txtTotalmtrs.Text = totalMeters + "";
            txtNetqty.Text = totalQty + "";
            total = System.Math.Round(total, 2, MidpointRounding.AwayFromZero);
            btmGrid[2, 0].Value = btmGrid[2, 9].Value = total.ToString();
        }
        private bool IsEmptyRow(UltraGridRow row)
        {
            bool isEmpty = true;
            foreach (UltraGridCell cell in row.Cells)
            {
                if (cell.Value != null && Convert.ToString(cell.Value).Trim().Length > 0)
                {
                    isEmpty = false;
                }
            }
            return isEmpty;
        }
        private string PadDigits(decimal val)
        {
            string outp = Convert.ToString(val);
            if (outp.IndexOf(".") != -1)
            {
                if (outp.Length - outp.IndexOf(".") < 3)
                    outp = outp + "0";
            }
            else
                outp = outp + ".00";
            return outp;
        }
        private string PadDigits(string outp)
        {
            if (outp.IndexOf(".") != -1)
            {
                if (outp.Length - outp.IndexOf(".") < 3)
                    outp = outp + "0";
            }
            else
                outp = outp + ".00";
            return outp;
        }
        private decimal GetBalance(int rowIndex)
        {
            decimal bal = Convert.ToDecimal(btmGrid[2, 0].Value);
            int i = 1;
            while (i < rowIndex)
            {
                if (btmGrid[1, i].Value != null && Convert.ToString(btmGrid[1, i].Value) != "")
                {
                    bal -= Convert.ToDecimal(btmGrid[2, i].Value);
                }
                i++;
            }
            return bal;
        }
        private decimal LessRatePerMeter()
        {
            if (Convert.ToString(btmGrid[1, 2].Value) != "" && txtTotalmtrs.Text != "")
            {
                decimal lessRate = Convert.ToDecimal(btmGrid[1, 2].Value);
                decimal tMters = Convert.ToDecimal(txtTotalmtrs.Text);
                decimal lessAmt = tMters * lessRate;
                lessAmt = System.Math.Round(lessAmt, 2, MidpointRounding.AwayFromZero);
                btmGrid[2, 2].Value = PadDigits(lessAmt);
                return lessAmt;
            }
            else
            {
                btmGrid[2, 2].Value = "";
                return 0;
            }
        }
        private decimal LessRatePerPair()
        {
            if (Convert.ToString(btmGrid[1, 3].Value) != "" && txtNetqty.Text != "")
            {
                decimal lessRate = Convert.ToDecimal(btmGrid[1, 3].Value);
                decimal tQty = Convert.ToDecimal(txtNetqty.Text);
                decimal lessAmt = tQty * lessRate;
                lessAmt = System.Math.Round(lessAmt, 2, MidpointRounding.AwayFromZero);
                btmGrid[2, 3].Value = PadDigits(lessAmt);
                return lessAmt;
            }
            else
            {
                btmGrid[2, 3].Value = "";
                return 0;
            }
        }
        private decimal LessDiscount(int rowIndex)
        {
            if (Convert.ToString(btmGrid[1, rowIndex].Value) != "")
            {
                decimal discount = Convert.ToDecimal(btmGrid[1, rowIndex].Value);
                decimal bal = 0;
                if (rowIndex == 1)
                    bal = Convert.ToDecimal(btmGrid[2, 0].Value);
                else
                    bal = GetBalance(rowIndex);
                decimal val = System.Math.Round(((discount / 100) * bal), 2, MidpointRounding.AwayFromZero);
                //disable grid cell value change event
                EnableBottomGridEvents(false);
                btmGrid[2, rowIndex].Value = PadDigits(val);
                //Enable grid cell value change event
                EnableBottomGridEvents(true);
                return val;
            }
            else
            {
                //disable grid cell value change event
                EnableBottomGridEvents(false);
                btmGrid[2, rowIndex].Value = "";
                //Enable grid cell value change event
                EnableBottomGridEvents(true);
                return 0;
            }
        }
        private void UpdateBalance()
        {
            //Disable grid cell value change event
            EnableBottomGridEvents(false);
            UpdateTotal();
            decimal total = Convert.ToDecimal(btmGrid[2, 0].Value);
            total -= LessRatePerMeter();
            total -= LessRatePerPair();
            total -= LessDiscount(1);//pinning less
            total -= LessDiscount(4);//discount 1
            total -= LessDiscount(5);//discount 4
            //adding forward charges
            if (Convert.ToString(btmGrid[2, 7].Value) != "")
                total += Convert.ToDecimal(btmGrid[2, 7].Value);
            // for printing only
            decimal printTotal = System.Math.Round(total, 2, MidpointRounding.AwayFromZero);
            printBalance = System.Math.Round(printTotal, 0);
            //printRountOff = printBalance - printTotal;

            //Less cash discount for storing into db and display in the screen
            total -= LessDiscount(6);
            total = System.Math.Round(total, 2, MidpointRounding.AwayFromZero);
            decimal whole = System.Math.Round(total, 0, MidpointRounding.AwayFromZero);
            decimal roundOff = whole - total;
            btmGrid[2, 9].Value = PadDigits(whole);
            btmGrid[2, 8].Value = PadDigits(roundOff);
            for (int i = 10; i <= 12; i++)
            {
                UpdateTotalAfterTax(i);
            }
            //Enable grid cell value change event
            EnableBottomGridEvents(true);
        }

        private decimal getBotomRowValue(int rowIndex, int colIndex)
        {
            if (btmGrid[colIndex, rowIndex].Value != null && Convert.ToString(btmGrid[colIndex, rowIndex].Value).Trim() != "")
            {
                return Convert.ToDecimal(btmGrid[colIndex, rowIndex].Value);
            }
            return 0;
        }

        private void UpdateTotalAfterTax(int rowIndex)
        {
            decimal totalBeforeTax = Convert.ToDecimal(btmGrid[2, 9].Value);
            decimal taxAmount = 0;
            decimal percent = getBotomRowValue(rowIndex, 1);
            if (percent > 0)
            {
                taxAmount = totalBeforeTax * percent / 100;
                btmGrid[2, rowIndex].Value = taxAmount;
            }
            decimal totalAfterTax = totalBeforeTax;
            for (int i = 10; i <= 12; i++)
            {
                totalAfterTax += getBotomRowValue(i, 2);
            }
            btmGrid[2, 13].Value = totalAfterTax;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveBill(false);
        }
        private void SaveBill(bool isCopyBill)
        {
            //Change cursor
            Cursor original = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            for (int i = 0; i <= 7; i++)
            {
                UpdateBottomGridValues(i);
            }
            for (int i = 10; i <= 12; i++)
            {
                UpdateBottomGridValues(i);
            }
            int billNo = Convert.ToInt32(txtInvno.Text);
            string address = cbCoy.Text;
            UpdateBalance();
            if (SaveMainBill(billNo, address))
            {
                SaveDiscounts(billNo, address);
                SaveItems(billNo, address);
                SetNewBill(isCopyBill);
            }
            //change cursor to normal
            this.Cursor = original;
        }
        private void FillDiscountsRow(int billno, string address, string name, double value)
        {
            if (bDist == null)
                bDist = new CompanyDS.BILLDISCOUNTSDataTable();
            BillingApplication.CompanyDS.BILLDISCOUNTSRow billDiscountRow = bDist.NewBILLDISCOUNTSRow();
            billDiscountRow.ACCOUNTINGYEAR = GetAccountingYear();
            billDiscountRow.NAME = name;
            billDiscountRow.VALUE = value;
            billDiscountRow.BILLNO = billno;
            billDiscountRow.ADDRESS = address;
            bDist.Rows.Add(billDiscountRow);
        }
        private void FillDiscountsData(int billno, string address, string name, double value)
        {
            if (state == BillState.Old)
            {
                if (bDist != null)
                {
                    BillingApplication.CompanyDS.BILLDISCOUNTSRow[] rows = null;
                    string filter = "BILLNO = " + billno + " AND ADDRESS = '" + address + "' AND NAME ='" + name + "'";
                    rows = (BillingApplication.CompanyDS.BILLDISCOUNTSRow[])bDist.Select(filter);
                    //if already discount name is there, update it
                    if (rows != null && rows.Length > 0)
                    {
                        rows[0].VALUE = value;
                    }
                    //else add the new row for pinning less
                    else
                    {
                        FillDiscountsRow(billno, address, name, value);
                    }
                }
                else
                {
                    FillDiscountsRow(billno, address, name, value);
                }
            }
            else
            {
                FillDiscountsRow(billno, address, name, value);
            }
        }
        private bool IsDiscountPresent(string discount)
        {
            foreach (DataGridViewRow row in btmGrid.Rows)
            {
                string discName = Convert.ToString(row.Cells[0].Value);
                string discValue = Convert.ToString(row.Cells[1].Value);
                if (discName == discount)
                    if (discValue != "")
                        return true;
                    else
                        return false;
            }
            return false;
        }
        private void SaveDiscounts(int billNo, string address)
        {
            //If any discount is deleted , then remove it from database
            if (state == BillState.Old)
            {
                BillingApplication.CompanyDS.BILLDISCOUNTSRow[] rows = null;
                string filter = "BILLNO = " + billNo + " AND ADDRESS = '" + address + "'";
                rows = (BillingApplication.CompanyDS.BILLDISCOUNTSRow[])bDist.Select(filter);
                if (rows != null && rows.Length > 0)
                {
                    foreach (BillingApplication.CompanyDS.BILLDISCOUNTSRow row in rows)
                    {
                        if (!IsDiscountPresent(row.NAME))
                        {
                            int index = bDist.Rows.IndexOf(row);
                            bDist.Rows[index].Delete();
                        }
                    }
                }
                try
                {
                    if (btmGrid[1, 1].Value == null || Convert.ToString(btmGrid[1, 1].Value).Trim() == "")
                    {

                    }
                }
                catch { }
            }
            //Pinning Less
            if (btmGrid[1, 1].Value != null && Convert.ToString(btmGrid[1, 1].Value).Trim() != "")
            {
                FillDiscountsData(billNo, address, Convert.ToString(btmGrid[0, 1].Value).Trim(), Convert.ToDouble(btmGrid[1, 1].Value));
            }
            //less rate / mtr
            if (btmGrid[1, 2].Value != null && Convert.ToString(btmGrid[1, 2].Value).Trim() != "")
            {
                FillDiscountsData(billNo, address, Convert.ToString(btmGrid[0, 2].Value),
                    Convert.ToDouble(btmGrid[1, 2].Value));
            }
            //less rate / pair
            if (btmGrid[1, 3].Value != null && Convert.ToString(btmGrid[1, 3].Value).Trim() != "")
            {
                FillDiscountsData(billNo, address, Convert.ToString(btmGrid[0, 3].Value),
                    Convert.ToDouble(btmGrid[1, 3].Value));
            }
            //discount 1
            if (btmGrid[1, 4].Value != null && Convert.ToString(btmGrid[1, 4].Value).Trim() != "")
            {
                FillDiscountsData(billNo, address, Convert.ToString(btmGrid[0, 4].Value),
                    Convert.ToDouble(btmGrid[1, 4].Value));
            }
            //discount 2
            if (btmGrid[1, 5].Value != null && Convert.ToString(btmGrid[1, 5].Value).Trim() != "")
            {
                FillDiscountsData(billNo, address, Convert.ToString(btmGrid[0, 5].Value),
                    Convert.ToDouble(btmGrid[1, 5].Value));
            }
            if (bDist != null && bDist.Rows != null && bDist.Rows.Count > 0)
                billdiscountsTA.Update(bDist);
        }
        private void SaveItems(int billNo, string address)
        {
            BillingApplication.CompanyDS.BILLITEMSDataTable dt = (BillingApplication.CompanyDS.BILLITEMSDataTable)grdItem.DataSource;
            billitemsTA.Update(dt);
        }
        private void UpdateFwdCtrlAutoCompleteDS(string colName)
        {
            if (colName == "FWDBY")
            {
                if (txtFwdBy.Text != "")
                {
                    DataRow[] drs = dtFwdBy.Select("FWDBY ='" + txtFwdBy.Text + "'");
                    if (drs != null && drs.Length > 0)
                    {
                    }
                    else
                        BindAutoCompleteCustomSources("FWDBY");
                }
            }
            else
            {
                if (txtOrderTo.Text != "")
                {
                    DataRow[] drs = dtFwdTo.Select("FWDTO ='" + txtOrderTo.Text + "'");
                    if (drs != null && drs.Length > 0)
                    {
                    }
                    else
                        BindAutoCompleteCustomSources("FWDTO");
                }
            }
        }
        private bool SaveMainBill(int billNo, string address)
        {
            BillingApplication.CompanyDS.BILLSRow billRow = null;
            if (state == BillState.New)
            {
                billDt = new CompanyDS.BILLSDataTable();
                billRow = billDt.NewBILLSRow();
            }
            else
            {
                DataRow[] rows = billDt.Select("BILLNO = " + billNo + " AND ADDRESS ='" +
                    address + "'");
                billRow = (BillingApplication.CompanyDS.BILLSRow)rows[0];
            }
            if (currAccYear.Equals(runningYear))
                billRow.ACCOUNTINGYEAR = "";
            else
                billRow.ACCOUNTINGYEAR = currAccYear;
            billRow.BILLNO = billNo;
            billRow.ADDRESS = address;
            billRow.BILLDATE = dtpBillDt.Value;
            if (txtBaleno.Text.Trim() != "")
                billRow.BALENO = txtBaleno.Text.Trim();
            else
            {
                MessageBox.Show("Bale No field is mandatory");
                txtBaleno.Focus();
                return false;
            }
            //Get party id from party name
            if (txtPartyName.Tag != null)
                billRow.PARTYID = Convert.ToInt32(txtPartyName.Tag);
            else
            {
                int partyId = GetPartyId();
                if (partyId == 0)
                {
                    MessageBox.Show("Party is not in database.\r\nAdd the party using New button and click Save");
                    return false;
                }
                else
                    billRow.PARTYID = partyId;
            }
            billRow.ORDERNO = txtOrderNo.Text != "" ? txtOrderNo.Text : null;
            if (ckOrderDate.Checked)
                billRow.ORDERDATE = dtpOrderDate.Value;
            if (txtFwdBy.Text != "")
                UpdateFwdCtrlAutoCompleteDS("FWDBY");
            if (txtOrderTo.Text != "")
                UpdateFwdCtrlAutoCompleteDS("FWDTO");
            billRow.FWDBY = txtFwdBy.Text != "" ? txtFwdBy.Text : null;
            billRow.FWDTO = txtOrderTo.Text != "" ? txtOrderTo.Text : null;
            if (cbAgtName.FindStringExact(cbAgtName.Text) != -1)
                billRow.AGENT = cbAgtName.Text;
            else
            {
                MessageBox.Show("Agent is not in database.\r\nAdd the Agent using Database studio,press CTRL + R and click Save");
                return false;
            }
            billRow.LRNO = txtLR.Text != "" ? txtLR.Text : null;
            billRow.LRDATE = dtpLRDate.Value;
            billRow.DOCSENTMODE = cbCourier.Text;
            billRow.TOTALWOCD = Convert.ToDouble(printBalance);
            if (txtTotalmtrs.Text != "")
                billRow.TOTALMTRS = Convert.ToDouble(txtTotalmtrs.Text);
            else if (state == BillState.Old)
                billRow.TOTALMTRS = 0;
            billRow.TOTALQTY = Convert.ToInt32(txtNetqty.Text);
            if (btmGrid.Rows[7].Cells[2].Value != null && btmGrid.Rows[7].Cells[2].Value.ToString() != "")
                billRow.FWDCHARGES = Convert.ToDouble(btmGrid.Rows[7].Cells[2].Value);
            else if (state == BillState.Old)
                billRow.FWDCHARGES = 0;
            billRow.BALANCE = Convert.ToDouble(btmGrid.Rows[9].Cells[2].Value);
            if (btmGrid.Rows[10].Cells[1].Value != null && btmGrid.Rows[10].Cells[1].Value.ToString() != "")
                billRow.SGST = Convert.ToDouble(btmGrid.Rows[10].Cells[1].Value);
            if (btmGrid.Rows[11].Cells[1].Value != null && btmGrid.Rows[11].Cells[1].Value.ToString() != "")
                billRow.CGST = Convert.ToDouble(btmGrid.Rows[11].Cells[1].Value);
            if (btmGrid.Rows[12].Cells[1].Value != null && btmGrid.Rows[12].Cells[1].Value.ToString() != "")
                billRow.IGST = Convert.ToDouble(btmGrid.Rows[12].Cells[1].Value);
            if (btmGrid.Rows[13].Cells[2].Value != null && btmGrid.Rows[13].Cells[2].Value.ToString() != "")
                billRow.TOTALAFTERTAX = Convert.ToDouble(btmGrid.Rows[13].Cells[2].Value);

            if (txtCddays.Text != "")
                billRow.CDDAYS = Convert.ToInt32(txtCddays.Text);
            else if (state == BillState.Old)
                billRow.CDDAYS = 0;
            if (btmGrid.Rows[6].Cells[1].Value != null && btmGrid.Rows[6].Cells[1].Value.ToString() != "")
                billRow.CDPERCENT = Convert.ToDouble(btmGrid.Rows[6].Cells[1].Value);
            else if (state == BillState.Old)
                billRow.CDPERCENT = 0;
            if (txtPin.Text != "")
                billRow.PIN = Convert.ToDouble(txtPin.Text);
            billRow.ITEMPIN = ckItemPin.Checked;
            if (txtCd.Text != "")
                billRow.CDTXT = Convert.ToDouble(txtCd.Text);
            else if (state == BillState.Old)
                billRow.CDTXT = 0;

            if (state == BillState.New)
                billDt.Rows.Add(billRow);
            billsTA.Update(billDt);
            return true;
        }
        private int GetPartyId()
        {
            string whereStr = "";
            if (txtPartyName.Text != "")
                whereStr = "NAME = '" + txtPartyName.Text + "'";
            if (txtPartyAddr1.Text != "")
                whereStr = whereStr + " AND ADDR1 = '" + txtPartyAddr1.Text + "'";
            if (txtPartyAddr2.Text != "")
                whereStr = whereStr + " AND ADDR2 = '" + txtPartyAddr2.Text + "'";
            if (txtPartyCity.Text != "")
                whereStr = whereStr + " AND CITY = '" + txtPartyCity.Text + "'";
            if (txtPartyState.Text != "")
                whereStr = whereStr + " AND STATE = '" + txtPartyState.Text + "'";
            if (txtPartyPin.Text != "")
                whereStr = whereStr + " AND PIN = '" + txtPartyPin.Text + "'";
            DataRow[] dr = this.coDs.PARTIES.Select(whereStr);
            int partyId = 0;
            if (dr != null && dr.Length > 0)
                partyId = ((CompanyDS.PARTIESRow)(dr[0])).ID;
            return partyId;
        }
        private int GetItemCalculationType(string item)
        {
            DataRow[] dr = coDs.ITEMS.Select("NAME = '" + item + "'");
            if (dr != null && dr.Length > 0)
            {
                string calTyp = ((BillingApplication.CompanyDS.ITEMSRow)dr[0]).CALCTYP;
                if (calTyp == "QTY")
                    return 0;
                if (calTyp == "MTR")
                    return 1;
            }
            return -1;
        }
        //xml format
        //<Meters>
        //<Meter>100</Meter>
        //<Meter>200</Meter>
        //<Total>300</Total>
        //</Meters>
        private void UpdateBottomGridValues(int rowIndex)
        {
            //Pinning less, discount 1, discount 2, cd
            if ((rowIndex == 1 || rowIndex == 4 || rowIndex == 5 || rowIndex == 6))
            //&& btmGrid.Rows[rowIndex].Cells.IndexOf(btmGrid.SelectedCells[0]) == 1)
            {
                LessDiscount(rowIndex);
                UpdateBalance();
            }
            else if (rowIndex == 2)
                LessRatePerMeter();
            else if (rowIndex == 3)
                LessRatePerPair();
            //fwd charges
            else if (rowIndex == 7 &&
                btmGrid.Rows[rowIndex].Cells.IndexOf(btmGrid.SelectedCells[0]) == 2)
            {
                UpdateBalance();
            }
            //if sgst, cgst, igst
            else if (rowIndex == 10 || rowIndex == 11 || rowIndex == 12)
            {
                UpdateTotalAfterTax(rowIndex);
            }
        }
        private void txtPin_TextChanged(object sender, EventArgs e)
        {
            if (txtPin.Text != "")
            {
                try
                {
                    decimal pin = Convert.ToDecimal(txtPin.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter numeric values");
                    txtPin.Text = "";
                }
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            int billno = (int)nddFind.Value;
            if (currAccYear.Equals(runningYear))
                billDt = billsTA.GetData(billno, cbCoy.Text, "");
            else
                billDt = billsTA.GetData(billno, cbCoy.Text, currAccYear);
            if (billDt != null && billDt.Rows.Count > 0)
            {
                state = BillState.Old;
                FillBillData(billDt);
            }
            else
                MessageBox.Show("The bill is not present in database");
        }
        private string GetItemName(string id)
        {
            DataRow[] drs = coDs.ITEMS.Select("ID = " + id);
            if (drs != null && drs.Length > 0)
            {
                return Convert.ToString(drs[0]["NAME"]);
            }
            else
                return null;
        }
        public string GetAccountingYear()
        {
            if (currAccYear.Equals(runningYear))
                return "";
            else
                return currAccYear;
        }
        private void FillUIGridItems(BillingApplication.CompanyDS.BILLITEMSDataTable bItemDt)
        {
            if (bItemDt != null && bItemDt.Rows.Count > 0)
            {
                //Fill Item Name column
                foreach (UltraGridRow grdRow in grdItem.Rows)
                {
                    BillingApplication.CompanyDS.ITEMSDataTable itemsDt = itemsTA.GetDataById(Convert.ToInt32(grdRow.Cells["ITEMID"].Value));
                    if (itemsDt != null && itemsDt.Rows.Count > 0)
                        grdRow.Cells["ITEMNAME"].Value = Convert.ToString(itemsDt.Rows[0]["NAME"]);
                    //Meters
                    if (grdRow.Cells["MTRS"].Value != null && Convert.ToString(grdRow.Cells["MTRS"].Value).Trim().Length > 0)
                    {
                        string tagXml = Convert.ToString(grdRow.Cells["MTRS"].Value);
                        XmlDocument inpDom = new XmlDocument();
                        inpDom.LoadXml(tagXml);
                        string tagTotal = inpDom.SelectSingleNode("/Meters/Total").InnerText;
                        grdRow.Cells["METRS"].Value = tagTotal;
                    }
                }
            }
        }
        private void FillBillData(BillingApplication.CompanyDS.BILLSDataTable dt)
        {
            BillingApplication.CompanyDS.BILLSRow row = (BillingApplication.CompanyDS.BILLSRow)dt.Rows[0];
            if (currAccYear.Equals(runningYear))
                row.ACCOUNTINGYEAR = "";
            else
                row.ACCOUNTINGYEAR = currAccYear;
            txtBaleno.Text = row.BALENO + "";
            txtInvno.Text = row.BILLNO + "";
            dtpBillDt.Value = row.BILLDATE;
            BillingApplication.CompanyDS.PARTIESDataTable pDt = partiesTA.GetDataById(row.PARTYID);
            if (pDt != null && pDt.Rows.Count > 0)
            {
                BillingApplication.CompanyDS.PARTIESRow pRow = (BillingApplication.CompanyDS.PARTIESRow)pDt.Rows[0];
                txtPartyName.Text = pRow.NAME;
                try { txtPartyAddr1.Text = pRow.ADDR1; }
                catch { txtPartyAddr1.Text = ""; }
                try { txtPartyAddr2.Text = pRow.ADDR2; }
                catch { txtPartyAddr2.Text = ""; }
                try { txtPartyCity.Text = pRow.CITY; }
                catch { txtPartyCity.Text = ""; }
                try { txtPartyState.Text = pRow.STATE; }
                catch { txtPartyState.Text = ""; }
                try { txtPartyPin.Text = Convert.ToString(pRow.PIN); }
                catch { txtPartyPin.Text = ""; }
            }
            try { txtOrderNo.Text = row.ORDERNO + ""; }
            catch { txtOrderNo.Text = ""; }
            try { txtOrderTo.Text = row.FWDTO; }
            catch { txtOrderTo.Text = ""; }
            try { dtpOrderDate.Value = row.ORDERDATE; }
            catch // if date is null, then disable the check box
            {
                ckOrderDate.Checked = false;
            }
            try { txtFwdBy.Text = row.FWDBY; }
            catch { txtFwdBy.Text = ""; }
            try { txtLR.Text = row.LRNO; }
            catch { txtLR.Text = ""; }
            dtpLRDate.Value = row.LRDATE;
            cbAgtName.SelectedValue = row.AGENT;
            try { txtPin.Text = row.PIN + ""; }
            catch { txtPin.Text = ""; }
            ckItemPin.Checked = row.ITEMPIN;
            cbCourier.SelectedValue = row.DOCSENTMODE;
            try { txtTotalmtrs.Text = row.TOTALMTRS + ""; }
            catch { txtTotalmtrs.Text = ""; }
            txtNetqty.Text = row.TOTALQTY + "";
            try
            {
                txtCd.Text = row.CDTXT + "";
            }
            catch
            {
                try { txtCd.Text = Convert.ToString(row.CDPERCENT); }
                catch { txtCd.Text = ""; }
            }
            try { txtCddays.Text = row.CDDAYS + ""; }
            catch { txtCddays.Text = ""; }
            //Fill Items Grid
            BillingApplication.CompanyDS.BILLITEMSDataTable bItemDt = new CompanyDS.BILLITEMSDataTable();
            if (currAccYear.Equals(runningYear))
                bItemDt = billitemsTA.GetData(row.BILLNO, row.ADDRESS, "");
            else
                bItemDt = billitemsTA.GetData(row.BILLNO, row.ADDRESS, currAccYear);
            grdItem.DataSource = bItemDt;
            grdItem.DataBind();
            FillUIGridItems(bItemDt);
            //Fill bottom gird
            InitializeBottomGrid();
            //Disable grid cell value change event
            EnableBottomGridEvents(false);
            try { btmGrid[2, 7].Value = Convert.ToString(row.FWDCHARGES); }
            catch { btmGrid[2, 7].Value = ""; }
            try { btmGrid[1, 6].Value = Convert.ToString(row.CDPERCENT); }
            catch { btmGrid[1, 6].Value = ""; }
            try { btmGrid[1, 10].Value = Convert.ToString(row.SGST); }
            catch { btmGrid[1, 10].Value = ""; }
            try { btmGrid[1, 11].Value = Convert.ToString(row.CGST); }
            catch { btmGrid[1, 11].Value = ""; }
            try { btmGrid[1, 12].Value = Convert.ToString(row.IGST); }
            catch { btmGrid[1, 12].Value = ""; }
            if (currAccYear.Equals(runningYear))
                bDist = billdiscountsTA.GetData(row.BILLNO, row.ADDRESS, "");
            else
                bDist = billdiscountsTA.GetData(row.BILLNO, row.ADDRESS, currAccYear);
            if (bDist != null && bDist.Rows.Count > 0)
            {
                int discountRowNum = 4;
                foreach (BillingApplication.CompanyDS.BILLDISCOUNTSRow bDiscountRow in
                    bDist.Rows)
                {
                    switch (bDiscountRow.NAME)
                    {
                        case "Pinning Less":
                            btmGrid[1, 1].Value = Convert.ToString(bDiscountRow.VALUE);
                            break;
                        case "Less Rate/Mtr":
                            btmGrid[1, 2].Value = Convert.ToString(bDiscountRow.VALUE);
                            break;
                        case "Less Rate/Pair":
                            btmGrid[1, 3].Value = Convert.ToString(bDiscountRow.VALUE);
                            break;
                        default:
                            btmGrid[0, discountRowNum].Value = bDiscountRow.NAME;
                            btmGrid[1, discountRowNum++].Value = Convert.ToString(bDiscountRow.VALUE);
                            break;
                    }
                }
            }
            //Enable event handler after filled in all the values
            //Enable grid cell value change event
            EnableBottomGridEvents(true);
            UpdateBalance();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetNewBill(false);
        }
        private void SetNewBill(bool isCopyBill)
        {
            state = BillState.New;
            //fwd by
            dalObj.GetBillData(dtFwdBy, "FWDBY", "FWDBY");
            BindAutoCompleteCustomSources("FWDBY");
            //fwd to
            dalObj.GetBillData(dtFwdTo, "FWDTO", "FWDTO");
            BindAutoCompleteCustomSources("FWDTO");
            billDt = null;
            bDist = null;
            SetBillNo();
            if (!isCopyBill)
                SetNewBillControls();
            else
            {
                BillingApplication.CompanyDS.BILLITEMSDataTable newDt = new CompanyDS.BILLITEMSDataTable();
                BillingApplication.CompanyDS.BILLITEMSDataTable dt = (BillingApplication.CompanyDS.BILLITEMSDataTable)grdItem.DataSource;
                foreach (DataRow dr in dt.Rows)
                    dr["BILLNO"] = Convert.ToInt32(txtInvno.Text);
                foreach (DataRow dr1 in dt.Rows)
                    newDt.Rows.Add(dr1.ItemArray);
                grdItem.DataSource = newDt;
                grdItem.DataBind();
                FillUIGridItems(newDt);
            }
            txtBaleno.Focus();
        }
        private void SetNewBillControls()
        {
            //Disable combo select change event
            this.cbAccYear.SelectedIndexChanged -= new System.EventHandler(this.cbAccYear_SelectedIndexChanged);
            cbAccYear.SelectedIndex = cbAccYear.FindString(currAccYear);
            this.cbAccYear.SelectedIndexChanged += new System.EventHandler(this.cbAccYear_SelectedIndexChanged);
            lblBale.Text = cbCoy.Text;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                dtpBillDt.Value = DateTime.Now.AddDays(2);
            }
            else
            {
                dtpBillDt.Value = DateTime.Now.AddDays(1);
            }
            txtPartyAddr1.Text = "";
            txtPartyAddr2.Text = "";
            txtPartyCity.Text = "";
            txtPartyState.Text = "";
            txtPartyPin.Text = "";
            //Disable events
            this.txtPartyName.Leave -= new System.EventHandler(this.txtPartyName_TextChanged);
            this.txtPartyName.TextChanged -= new System.EventHandler(this.txtPartyName_TextChanged);
            txtPartyName.Text = "";
            //Enable events
            this.txtPartyName.Leave += new System.EventHandler(this.txtPartyName_TextChanged);
            this.txtPartyName.TextChanged += new System.EventHandler(this.txtPartyName_TextChanged);
            txtOrderNo.Text = "";
            dtpLRDate.Value = DateTime.Now;
            dtpOrderDate.Value = DateTime.Now;
            ckOrderDate.Checked = true;
            txtFwdBy.Text = "";
            txtOrderTo.Text = "";
            txtLR.Text = "";
            txtPin.Text = "";
            ckItemPin.Checked = false;
            BillingApplication.CompanyDS.BILLITEMSDataTable dt = new CompanyDS.BILLITEMSDataTable();
            grdItem.DataSource = dt;
            grdItem.DataBind();
            InitializeBottomGrid();
            //cd default value
            //Disable grid cell value change event
            EnableBottomGridEvents(false);
            btmGrid[1, 6].Value = "4";
            //Enable grid cell value change event
            EnableBottomGridEvents(true);
            txtTotalmtrs.Text = "";
            txtNetqty.Text = "";
            txtCd.Text = "4";
            txtCddays.Text = "15";
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillData();
            BindDataSources("Refresh");
        }

        private void btmGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateBottomGridValues(e.RowIndex);
        }
        private void EnableBottomGridEvents(bool val)
        {
            if (val)
                btmGrid.CellValueChanged += new DataGridViewCellEventHandler(btmGrid_CellValueChanged);
            else
                btmGrid.CellValueChanged -= new DataGridViewCellEventHandler(btmGrid_CellValueChanged);
        }

        private void ckItemPin_CheckedChanged(object sender, EventArgs e)
        {
            txtPin.Enabled = !ckItemPin.Checked;
            EnableBottomGridEvents(false);
            btmGrid[1, 1].Value = "";
            btmGrid[2, 1].Value = "";
            EnableBottomGridEvents(true);
            btmGrid[1, 1].ReadOnly = ckItemPin.Checked;
            btmGrid[2, 1].ReadOnly = ckItemPin.Checked;
            grdItem.DisplayLayout.Bands[0].Columns["PIN"].Hidden = !ckItemPin.Checked;
            grdItem.DisplayLayout.Bands[0].Columns["PINNINGLESS"].Hidden = !ckItemPin.Checked;
            if (ckItemPin.Checked)
            {
                grdItem.DisplayLayout.Bands[0].Columns["ITEMNAME"].Width = 250;
                grdItem.DisplayLayout.Bands[0].Columns["STAMP"].Width = 250;
            }
            else
            {
                grdItem.DisplayLayout.Bands[0].Columns["STAMP"].Width = 300;
                grdItem.DisplayLayout.Bands[0].Columns["ITEMNAME"].Width = 250;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //if (preDialog.ShowDialog() == DialogResult.OK)
            pDoc.Print();
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveBill(false);
        }
        private void btmGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            int rowIndex = btmGrid.SelectedCells[0].RowIndex;
            if (e.KeyChar == '\r')
            {
                //if (rowIndex == 6 && btmGrid[1, 6].Value != null)
                //  txtCd.Text = Convert.ToString(btmGrid[1, 6].Value);
                UpdateBottomGridValues(rowIndex);
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox ctrl = (TextBox)sender;
            ctrl.Text = ctrl.Text.ToUpper();
        }

        private void btnNewParty_Click(object sender, EventArgs e)
        {
            NewPArty partyForm = new NewPArty();
            if (partyForm.ShowDialog() == DialogResult.OK)
            {
                txtPartyName.Text = partyForm.partyName;
                txtPartyAddr1.Text = partyForm.partyAddr1;
                txtPartyAddr2.Text = partyForm.partyAddr2;
                txtPartyCity.Text = partyForm.partyCity;
                txtPartyState.Text = partyForm.partyState;
                txtPartyPin.Text = partyForm.partyPin;
                FillPartiesData("PARTIES");
                BindAutoCompleteCustomSources("PARTIES");
                txtPartyName.Tag = GetPartyId();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNewBill(false);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (currAccYear.Equals(runningYear))
                    billDt.Rows[0]["ACCOUNTINGYEAR"] = "";
                else
                    billDt.Rows[0]["ACCOUNTINGYEAR"] = currAccYear;
                int p = dalObj.DeleteBill(Convert.ToString(billDt.Rows[0]["ADDRESS"]), Convert.ToInt32(billDt.Rows[0]["BILLNO"]),
                    Convert.ToString(billDt.Rows[0]["ACCOUNTINGYEAR"]));
                if (p > 0)
                    SetNewBill(false);
                else
                    MessageBox.Show("Bill can not be deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdItem_Enter(object sender, EventArgs e)
        {
            if (grdItem.Rows.Count == 0)
            {
                UltraGridRow newRow = grdItem.DisplayLayout.Bands[0].AddNew();
                if (newRow.Cells["ITEMNAME"].CanEnterEditMode)
                {
                    grdItem.ActiveCell = newRow.Cells["ITEMNAME"];
                    grdItem.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            else
            {
                grdItem.ActiveCell = grdItem.Rows[0].Cells["ITEMNAME"];
                if (grdItem.ActiveCell.CanEnterEditMode)
                    grdItem.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        private void txtPartyName_Leave(object sender, EventArgs e)
        {
            AutoFillPartyAddress();
            txtOrderNo.Focus();
        }

        private void grdItem_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            if (!grdItem.DisplayLayout.Bands[0].Columns.Exists("ITEMNAME"))
                grdItem.DisplayLayout.Bands[0].Columns.Insert(0, "ITEMNAME");
            if (!grdItem.DisplayLayout.Bands[0].Columns.Exists("METRS"))
                grdItem.DisplayLayout.Bands[0].Columns.Insert(3, "METRS");
            grdItem.DisplayLayout.Override.DefaultRowHeight = 20;
            grdItem.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdItem.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            grdItem.DisplayLayout.Override.CellAppearance.TextTrimming = Infragistics.Win.TextTrimming.Default;
            if (ckItemPin.Checked)
            {
                grdItem.DisplayLayout.Bands[0].Columns["ITEMNAME"].Width = 250;
                grdItem.DisplayLayout.Bands[0].Columns["STAMP"].Width = 250;
            }
            else
            {
                grdItem.DisplayLayout.Bands[0].Columns["ITEMNAME"].Width = 400;
                grdItem.DisplayLayout.Bands[0].Columns["STAMP"].Width = 300;
            }
            grdItem.DisplayLayout.Bands[0].Columns["ITEMNAME"].Header.Caption = "Item Name";

            grdItem.DisplayLayout.Bands[0].Columns["STAMP"].Header.Caption = "Stamp";

            grdItem.DisplayLayout.Bands[0].Columns["METRS"].Width = 100;
            grdItem.DisplayLayout.Bands[0].Columns["METRS"].Header.Caption = "Mtrs";

            grdItem.DisplayLayout.Bands[0].Columns["RATE"].Width = 100;
            grdItem.DisplayLayout.Bands[0].Columns["RATE"].Header.Caption = "Rate";

            grdItem.DisplayLayout.Bands[0].Columns["QTY"].Width = 100;
            grdItem.DisplayLayout.Bands[0].Columns["QTY"].Header.Caption = "Qty";

            grdItem.DisplayLayout.Bands[0].Columns["PIN"].Width = 50;
            grdItem.DisplayLayout.Bands[0].Columns["PINNINGLESS"].Width = 50;
            grdItem.DisplayLayout.Bands[0].Columns["PINNINGLESS"].Header.Caption = "PL";
            grdItem.DisplayLayout.Bands[0].Columns["AMT"].Header.Caption = "Amount";
            grdItem.DisplayLayout.Bands[0].Columns["AMT"].CellActivation = Activation.NoEdit;

            grdItem.DisplayLayout.Bands[0].Columns["ACCOUNTINGYEAR"].Hidden = true;
            grdItem.DisplayLayout.Bands[0].Columns["ITEMNO"].Hidden = true;
        }
        private void grdItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                grdItem.PerformAction(UltraGridAction.ExitEditMode);
            }
            else if (e.KeyData == Keys.Delete)
            {
                deletedRow = grdItem.ActiveRow.Index;
            }
            else if (e.KeyData == Keys.Down)
            {
                if (grdItem.ActiveCell != null && grdItem.ActiveCell.Column.Key == "ITEMNAME")
                {
                    string itemName = Convert.ToString(grdItem.ActiveCell.Text);
                    DataRow[] drs = coDs.ITEMS.Select("NAME like '" + itemName + "%'");
                    if (drs != null && drs.Length > 0)
                    {
                        System.Collections.Generic.List<string> items = new List<string>();
                        foreach (DataRow dr in drs)
                        {
                            items.Add(Convert.ToString(dr["NAME"]));
                        }
                        items.Sort();
                        ItemPopUp popUp = new ItemPopUp(items);
                        if (popUp.ShowDialog() == DialogResult.OK)
                        {
                            if (popUp.IsNewItem)
                                FillItemsData();
                            drs = coDs.ITEMS.Select("NAME = '" + popUp.selValue + "'");
                            grdItem.ActiveRow.Cells["ITEMID"].Value = drs[0]["ID"];
                            grdItem.ActiveRow.Cells["BILLNO"].Value = Convert.ToInt32(txtInvno.Text);
                            grdItem.ActiveRow.Cells["ADDRESS"].Value = cbCoy.Text;
                            grdItem.ActiveRow.Cells["HSN"].Value = drs[0]["HSN"];
                            grdItem.ActiveCell.Value = popUp.selValue;
                        }
                    }
                    else
                    {
                        ItemPopUp popUp = new ItemPopUp(null);
                        popUp.NewItemName = itemName;
                        if (popUp.ShowDialog() == DialogResult.OK)
                        {
                            grdItem.ActiveCell.Value = popUp.selValue;
                            if (popUp.IsNewItem)
                                FillItemsData();
                            drs = coDs.ITEMS.Select("NAME = '" + popUp.selValue + "'");
                            grdItem.ActiveRow.Cells["ITEMID"].Value = drs[0]["ID"];
                            grdItem.ActiveRow.Cells["BILLNO"].Value = Convert.ToInt32(txtInvno.Text);
                            grdItem.ActiveRow.Cells["ADDRESS"].Value = cbCoy.Text;
                            grdItem.ActiveRow.Cells["HSN"].Value = drs[0]["HSN"];
                            grdItem.ActiveCell.Value = popUp.selValue;
                        }
                    }
                }
                else if (grdItem.ActiveCell != null && grdItem.ActiveCell.Column.Key == "METRS")
                {
                    MetersPopUp mtsPopup = null;
                    if (grdItem.ActiveCell.Text == null || grdItem.ActiveCell.Text.Trim().Length == 0)
                    {
                        mtsPopup = new MetersPopUp(null);
                    }
                    else
                    {
                        XmlDocument inpDom = null;
                        string totalMts = Convert.ToString(grdItem.ActiveCell.Text.Trim());
                        if (grdItem.ActiveRow.Cells["MTRS"].Value != null && Convert.ToString(grdItem.ActiveRow.Cells["MTRS"].Value).Trim().Length > 0)
                        {
                            //check the total in cell is equal to total in tag(prev value)
                            string tagXml = Convert.ToString(grdItem.ActiveRow.Cells["MTRS"].Value);
                            inpDom = new XmlDocument();
                            inpDom.LoadXml(tagXml);
                            string tagTotal = inpDom.SelectSingleNode("/Meters/Total").InnerText;
                            if (tagTotal == totalMts)
                                mtsPopup = new MetersPopUp(inpDom);
                            ///if user changes the value calculated through popup
                            ///then the tag total won't be equal to cell total.
                            ///so treat the user entered new total as the initial metered value
                            else
                            {
                                grdItem.ActiveRow.Cells["MTRS"].Value = null;
                                inpDom = new XmlDocument();
                                inpDom.LoadXml("<Meters><Meter>" + totalMts + "</Meter><Total>" +
                                                        totalMts + "</Total></Meters>");
                                mtsPopup = new MetersPopUp(inpDom);
                            }
                        }
                        //This case occurs when some value has been entered into cell and then down arrow is
                        // pressed. Pass the value as the only item in the list
                        else
                        {
                            inpDom = new XmlDocument();
                            inpDom.LoadXml("<Meters><Meter>" + totalMts + "</Meter><Total>" +
                                                    totalMts + "</Total></Meters>");
                            mtsPopup = new MetersPopUp(inpDom);
                        }
                    }
                    if (mtsPopup.ShowDialog() == DialogResult.OK)
                    {
                        if (mtsPopup.output != null)
                        {
                            grdItem.ActiveCell.Value = mtsPopup.output.SelectSingleNode("/Meters/Total").InnerText;
                            grdItem.ActiveRow.Cells["MTRS"].Value = mtsPopup.output.OuterXml;
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.End)
                if (IsEmptyRow(grdItem.ActiveRow) || (
                    IsRowValid(grdItem.ActiveRow) && ValidateUpdateItems(grdItem.ActiveRow.Index)))
                {
                    btmGrid.Focus();
                }
                else if (grdItem.ActiveCell.CanEnterEditMode)
                    grdItem.PerformAction(UltraGridAction.EnterEditMode);
        }
        private bool IsRowValid(UltraGridRow row)
        {
            grdItem.PerformAction(UltraGridAction.ExitEditMode);
            if (row.Cells["RATE"].Value == null || Convert.ToString(row.Cells["RATE"].Value).Trim().Equals(string.Empty))
            {
                MessageBox.Show("Unable to update the row:\r\nRATE cannot be empty.",
                       "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (row.Cells["QTY"].Value == null || Convert.ToString(row.Cells["QTY"].Value).Trim().Equals(string.Empty))
            {
                MessageBox.Show("Unable to update the row:\r\nQty cannot be empty.",
                       "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }
        private bool ValidateUpdateItems(int rowIndex)
        {
            grdItem.PerformAction(UltraGridAction.ExitEditMode);
            if (grdItem.Rows[rowIndex].Cells["METRS"].Value == null || grdItem.Rows[rowIndex].Cells["METRS"].Value == System.DBNull.Value || Convert.ToString(grdItem.Rows[rowIndex].Cells["METRS"].Value).Trim().Equals(string.Empty))
            {
                //Meters checking
                int calType = GetItemCalculationType(Convert.ToString(grdItem.Rows[rowIndex].Cells["ITEMNAME"].Value));
                if (calType == 1)
                {
                    MessageBox.Show("Unable to update the row:\r\nColumn Meters does not allow nulls for selected item.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grdItem.ActiveRow = grdItem.Rows[rowIndex];
                    grdItem.ActiveCell = grdItem.Rows[rowIndex].Cells["MTRS"];
                    if (grdItem.ActiveCell.CanEnterEditMode)
                    {
                        grdItem.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    return false;
                }
                //Item wise pin checking
                if (ckItemPin.Checked)
                {
                    if (grdItem.Rows[rowIndex].Cells["PIN"].Value == null || grdItem.Rows[rowIndex].Cells["PIN"].Value == System.DBNull.Value || Convert.ToString(grdItem.Rows[rowIndex].Cells["PIN"].Value).Trim().Equals(string.Empty))
                    {
                        MessageBox.Show("Please enter the pin for the item no " + (rowIndex + 1));
                        grdItem.Rows[rowIndex].Cells["PIN"].Selected = true;
                        return false;
                    }
                }
                UpdateRow(rowIndex);
            }
            else
                UpdateRow(rowIndex);
            return true;
        }
        private void grdItem_AfterCellUpdate(object sender, CellEventArgs e)
        {
            //When new row is added, last entered value is qty
            if (e.Cell.Column.Key == "PINNINGLESS" || e.Cell.Column.Key == "QTY")// || (this.state == BillState.Old && grdItem.ActiveRow != null)) //&& IsRowValid(grdItem.ActiveRow)
            {
                if (ValidateUpdateItems(e.Cell.Row.Index))
                    grdItem.PerformAction(UltraGridAction.NextRowByTab);
            }
            else //Check if all the values are present and update the cell
            {

            }
        }
        private void grdItem_Error(object sender, ErrorEventArgs e)
        {
            if (IsEmptyRow(grdItem.ActiveRow))
            {
                e.Cancel = true;
                return;
            }
            if (e.ErrorType == ErrorType.Data && rowErrorCount == 0)
            {
                if (e.ErrorText.Contains("ITEMID"))
                {
                    MessageBox.Show("Unable to update the row:\r\nItem with the same name and rate already entered.",
                        "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;

                }
                rowErrorCount++;
            }
            else
            {
                e.Cancel = true;
                rowErrorCount = 0;
            }
            if (grdItem.ActiveCell != null && grdItem.ActiveCell.CanEnterEditMode)
                grdItem.PerformAction(UltraGridAction.EnterEditMode);
        }
        private void grdItem_BeforeRowDeactivate(object sender, CancelEventArgs e)
        {
            if (!IsEmptyRow(grdItem.ActiveRow) && !ValidateUpdateItems(grdItem.ActiveRow.Index))
                e.Cancel = true;
        }

        private void grdItem_AfterRowsDeleted(object sender, EventArgs e)
        {
            if (grdItem.Rows.Count > deletedRow)
            {
                for (int i = deletedRow; i < grdItem.Rows.Count; i++)
                {
                    //grdItem.Rows[i].Cells["ITEMNO"].Value = i + 1;
                    BillingApplication.CompanyDS.BILLITEMSDataTable dt = ((BillingApplication.CompanyDS.BILLITEMSDataTable)(grdItem.DataSource));
                    DataRow[] drs = dt.Select("ITEMNO = " + (i + 2));
                    if (drs != null && drs.Length > 0)
                        drs[0]["ITEMNO"] = i + 1;
                }
            }
            UpdateBalance();
        }

        private void ckOrderDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpOrderDate.Enabled = ckOrderDate.Checked;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            SaveBill(true);
        }

        private void btnNewAgent_Click(object sender, EventArgs e)
        {
            if (cbAgtName.FindString(cbAgtName.Text) == -1)
            {
                string newAgent = cbAgtName.Text;
                newAgent = newAgent.ToUpper().Trim();
                if (MessageBox.Show("Please check the spelling of the newly entered Agent,\nYou can not change it later.\n\nAre you sure to update Agents?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    agentsTA.Insert(newAgent);
                    FillData();
                    BindDataSources();
                    cbAgtName.SelectedIndex = cbAgtName.FindString(newAgent);
                }
            }
            else
                MessageBox.Show("Agent is already exists in db");
        }

        private void cbAccYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAccYear.Text.Length <= 11)
            {
                currAccYear = cbAccYear.Text;
                SetNewBill(false);
            }
        }
    }
}
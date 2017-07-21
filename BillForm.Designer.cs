namespace BillingApplication
{
    partial class BillForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillForm));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BILLITEMS", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ITEMID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STAMP");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MTRS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RATE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("QTY");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PIN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PINNINGLESS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AMT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BILLNO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ADDRESS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ACCOUNTINGYEAR");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ITEMNO", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HSN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PARTICULARS", 0);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cbAccYear = new System.Windows.Forms.ComboBox();
            this.lblBale = new System.Windows.Forms.Label();
            this.cbCoy = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpBillDt = new System.Windows.Forms.DateTimePicker();
            this.txtBaleno = new System.Windows.Forms.TextBox();
            this.txtInvno = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.btnNewParty = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPartyPin = new System.Windows.Forms.TextBox();
            this.txtPartyState = new System.Windows.Forms.TextBox();
            this.txtPartyCity = new System.Windows.Forms.TextBox();
            this.txtPartyAddr2 = new System.Windows.Forms.TextBox();
            this.txtPartyAddr1 = new System.Windows.Forms.TextBox();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNewAgent = new System.Windows.Forms.Button();
            this.ckOrderDate = new System.Windows.Forms.CheckBox();
            this.ckItemPin = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.cbCourier = new System.Windows.Forms.ComboBox();
            this.cbAgtName = new System.Windows.Forms.ComboBox();
            this.dtpLRDate = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.txtLR = new System.Windows.Forms.TextBox();
            this.txtOrderTo = new System.Windows.Forms.TextBox();
            this.txtFwdBy = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.grdItem = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bILLITEMSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coDs = new BillingApplication.CompanyDS();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.txtParticulars = new System.Windows.Forms.TextBox();
            this.btnPrintPartyAddr = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.nddFind = new System.Windows.Forms.NumericUpDown();
            this.btmGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCddays = new System.Windows.Forms.TextBox();
            this.txtCd = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalmtrs = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNetqty = new System.Windows.Forms.TextBox();
            this.pDoc = new System.Drawing.Printing.PrintDocument();
            this.preDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pPartyAddr = new System.Drawing.Printing.PrintDocument();
            this.addressTA = new BillingApplication.CompanyDSTableAdapters.ADDRESSTableAdapter();
            this.agentsTA = new BillingApplication.CompanyDSTableAdapters.AGENTSTableAdapter();
            this.billdiscountsTA = new BillingApplication.CompanyDSTableAdapters.BILLDISCOUNTSTableAdapter();
            this.billitemsTA = new BillingApplication.CompanyDSTableAdapters.BILLITEMSTableAdapter();
            this.billsTA = new BillingApplication.CompanyDSTableAdapters.BILLSTableAdapter();
            this.itemsTA = new BillingApplication.CompanyDSTableAdapters.ITEMSTableAdapter();
            this.partiesTA = new BillingApplication.CompanyDSTableAdapters.PARTIESTableAdapter();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bILLITEMSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coDs)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nddFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btmGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbAccYear);
            this.panel1.Controls.Add(this.lblBale);
            this.panel1.Controls.Add(this.cbCoy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.menuStrip1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cbAccYear
            // 
            resources.ApplyResources(this.cbAccYear, "cbAccYear");
            this.cbAccYear.FormattingEnabled = true;
            this.cbAccYear.Items.AddRange(new object[] {
            resources.GetString("cbAccYear.Items"),
            resources.GetString("cbAccYear.Items1")});
            this.cbAccYear.Name = "cbAccYear";
            this.cbAccYear.TabStop = false;
            this.cbAccYear.SelectedIndexChanged += new System.EventHandler(this.cbAccYear_SelectedIndexChanged);
            // 
            // lblBale
            // 
            resources.ApplyResources(this.lblBale, "lblBale");
            this.lblBale.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblBale.Name = "lblBale";
            // 
            // cbCoy
            // 
            this.cbCoy.FormattingEnabled = true;
            resources.ApplyResources(this.cbCoy, "cbCoy");
            this.cbCoy.Name = "cbCoy";
            this.cbCoy.TabStop = false;
            this.cbCoy.SelectedIndexChanged += new System.EventHandler(this.cbCoy_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            resources.ApplyResources(this.refreshToolStripMenuItem, "refreshToolStripMenuItem");
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dtpBillDt);
            this.panel2.Controls.Add(this.txtBaleno);
            this.panel2.Controls.Add(this.txtInvno);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // dtpBillDt
            // 
            this.dtpBillDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpBillDt, "dtpBillDt");
            this.dtpBillDt.Name = "dtpBillDt";
            // 
            // txtBaleno
            // 
            resources.ApplyResources(this.txtBaleno, "txtBaleno");
            this.txtBaleno.Name = "txtBaleno";
            // 
            // txtInvno
            // 
            resources.ApplyResources(this.txtInvno, "txtInvno");
            this.txtInvno.Name = "txtInvno";
            this.txtInvno.ReadOnly = true;
            this.txtInvno.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.splitContainer1);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtItemName);
            this.splitContainer1.Panel1.Controls.Add(this.btnNewParty);
            this.splitContainer1.Panel1.Controls.Add(this.label21);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartyPin);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartyState);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartyCity);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartyAddr2);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartyAddr1);
            this.splitContainer1.Panel1.Controls.Add(this.txtPartyName);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnNewAgent);
            this.splitContainer1.Panel2.Controls.Add(this.ckOrderDate);
            this.splitContainer1.Panel2.Controls.Add(this.ckItemPin);
            this.splitContainer1.Panel2.Controls.Add(this.label20);
            this.splitContainer1.Panel2.Controls.Add(this.label19);
            this.splitContainer1.Panel2.Controls.Add(this.txtPin);
            this.splitContainer1.Panel2.Controls.Add(this.cbCourier);
            this.splitContainer1.Panel2.Controls.Add(this.cbAgtName);
            this.splitContainer1.Panel2.Controls.Add(this.dtpLRDate);
            this.splitContainer1.Panel2.Controls.Add(this.dtpOrderDate);
            this.splitContainer1.Panel2.Controls.Add(this.txtLR);
            this.splitContainer1.Panel2.Controls.Add(this.txtOrderTo);
            this.splitContainer1.Panel2.Controls.Add(this.txtFwdBy);
            this.splitContainer1.Panel2.Controls.Add(this.label13);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.txtOrderNo);
            // 
            // txtItemName
            // 
            this.txtItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.txtItemName, "txtItemName");
            this.txtItemName.Name = "txtItemName";
            // 
            // btnNewParty
            // 
            resources.ApplyResources(this.btnNewParty, "btnNewParty");
            this.btnNewParty.Name = "btnNewParty";
            this.btnNewParty.TabStop = false;
            this.btnNewParty.UseVisualStyleBackColor = true;
            this.btnNewParty.Click += new System.EventHandler(this.btnNewParty_Click);
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // txtPartyPin
            // 
            resources.ApplyResources(this.txtPartyPin, "txtPartyPin");
            this.txtPartyPin.Name = "txtPartyPin";
            this.txtPartyPin.ReadOnly = true;
            this.txtPartyPin.TabStop = false;
            // 
            // txtPartyState
            // 
            resources.ApplyResources(this.txtPartyState, "txtPartyState");
            this.txtPartyState.Name = "txtPartyState";
            this.txtPartyState.ReadOnly = true;
            this.txtPartyState.TabStop = false;
            // 
            // txtPartyCity
            // 
            resources.ApplyResources(this.txtPartyCity, "txtPartyCity");
            this.txtPartyCity.Name = "txtPartyCity";
            this.txtPartyCity.ReadOnly = true;
            this.txtPartyCity.TabStop = false;
            // 
            // txtPartyAddr2
            // 
            resources.ApplyResources(this.txtPartyAddr2, "txtPartyAddr2");
            this.txtPartyAddr2.Name = "txtPartyAddr2";
            this.txtPartyAddr2.ReadOnly = true;
            this.txtPartyAddr2.TabStop = false;
            // 
            // txtPartyAddr1
            // 
            resources.ApplyResources(this.txtPartyAddr1, "txtPartyAddr1");
            this.txtPartyAddr1.Name = "txtPartyAddr1";
            this.txtPartyAddr1.ReadOnly = true;
            this.txtPartyAddr1.TabStop = false;
            // 
            // txtPartyName
            // 
            this.txtPartyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPartyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.txtPartyName, "txtPartyName");
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.TextChanged += new System.EventHandler(this.txtPartyName_TextChanged);
            this.txtPartyName.Leave += new System.EventHandler(this.txtPartyName_Leave);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // btnNewAgent
            // 
            resources.ApplyResources(this.btnNewAgent, "btnNewAgent");
            this.btnNewAgent.Name = "btnNewAgent";
            this.btnNewAgent.TabStop = false;
            this.btnNewAgent.UseVisualStyleBackColor = true;
            this.btnNewAgent.Click += new System.EventHandler(this.btnNewAgent_Click);
            // 
            // ckOrderDate
            // 
            resources.ApplyResources(this.ckOrderDate, "ckOrderDate");
            this.ckOrderDate.Name = "ckOrderDate";
            this.ckOrderDate.UseVisualStyleBackColor = true;
            this.ckOrderDate.CheckedChanged += new System.EventHandler(this.ckOrderDate_CheckedChanged);
            // 
            // ckItemPin
            // 
            resources.ApplyResources(this.ckItemPin, "ckItemPin");
            this.ckItemPin.Name = "ckItemPin";
            this.ckItemPin.TabStop = false;
            this.ckItemPin.UseVisualStyleBackColor = true;
            this.ckItemPin.CheckedChanged += new System.EventHandler(this.ckItemPin_CheckedChanged);
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Name = "label20";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // txtPin
            // 
            this.txtPin.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("txtPin.AutoCompleteCustomSource"),
            resources.GetString("txtPin.AutoCompleteCustomSource1"),
            resources.GetString("txtPin.AutoCompleteCustomSource2"),
            resources.GetString("txtPin.AutoCompleteCustomSource3"),
            resources.GetString("txtPin.AutoCompleteCustomSource4"),
            resources.GetString("txtPin.AutoCompleteCustomSource5")});
            this.txtPin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.txtPin, "txtPin");
            this.txtPin.Name = "txtPin";
            this.txtPin.TextChanged += new System.EventHandler(this.txtPin_TextChanged);
            // 
            // cbCourier
            // 
            this.cbCourier.FormattingEnabled = true;
            this.cbCourier.Items.AddRange(new object[] {
            resources.GetString("cbCourier.Items"),
            resources.GetString("cbCourier.Items1")});
            resources.ApplyResources(this.cbCourier, "cbCourier");
            this.cbCourier.Name = "cbCourier";
            // 
            // cbAgtName
            // 
            this.cbAgtName.FormattingEnabled = true;
            resources.ApplyResources(this.cbAgtName, "cbAgtName");
            this.cbAgtName.Name = "cbAgtName";
            // 
            // dtpLRDate
            // 
            this.dtpLRDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpLRDate, "dtpLRDate");
            this.dtpLRDate.Name = "dtpLRDate";
            // 
            // dtpOrderDate
            // 
            resources.ApplyResources(this.dtpOrderDate, "dtpOrderDate");
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Name = "dtpOrderDate";
            // 
            // txtLR
            // 
            resources.ApplyResources(this.txtLR, "txtLR");
            this.txtLR.Name = "txtLR";
            this.txtLR.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtOrderTo
            // 
            this.txtOrderTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtOrderTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.txtOrderTo, "txtOrderTo");
            this.txtOrderTo.Name = "txtOrderTo";
            this.txtOrderTo.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // txtFwdBy
            // 
            this.txtFwdBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtFwdBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.txtFwdBy, "txtFwdBy");
            this.txtFwdBy.Name = "txtFwdBy";
            this.txtFwdBy.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("txtOrderNo.AutoCompleteCustomSource"),
            resources.GetString("txtOrderNo.AutoCompleteCustomSource1")});
            this.txtOrderNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtOrderNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.txtOrderNo, "txtOrderNo");
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.TabStop = false;
            this.txtOrderNo.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.grdItem);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // grdItem
            // 
            this.grdItem.DataSource = this.bILLITEMSBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdItem.DisplayLayout.Appearance = appearance1;
            this.grdItem.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.VisiblePosition = 11;
            ultraGridColumn12.Header.VisiblePosition = 12;
            ultraGridColumn13.Header.VisiblePosition = 1;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14});
            this.grdItem.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdItem.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdItem.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grdItem.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grdItem.DisplayLayout.MaxColScrollRegions = 1;
            this.grdItem.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdItem.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdItem.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grdItem.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.grdItem.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grdItem.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.grdItem.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdItem.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdItem.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdItem.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdItem.DisplayLayout.Override.CellPadding = 0;
            this.grdItem.DisplayLayout.Override.ColumnSizingArea = Infragistics.Win.UltraWinGrid.ColumnSizingArea.HeadersOnly;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            resources.ApplyResources(appearance10, "appearance10");
            this.grdItem.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdItem.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdItem.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.grdItem.DisplayLayout.Override.RowAppearance = appearance11;
            this.grdItem.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.grdItem.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdItem.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grdItem.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdItem.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            resources.ApplyResources(this.grdItem, "grdItem");
            this.grdItem.Name = "grdItem";
            this.grdItem.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdItem_AfterCellUpdate);
            this.grdItem.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdItem_InitializeLayout);
            this.grdItem.AfterRowsDeleted += new System.EventHandler(this.grdItem_AfterRowsDeleted);
            this.grdItem.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.grdItem_BeforeRowDeactivate);
            this.grdItem.Error += new Infragistics.Win.UltraWinGrid.ErrorEventHandler(this.grdItem_Error);
            this.grdItem.Enter += new System.EventHandler(this.grdItem_Enter);
            this.grdItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdItem_KeyDown);
            // 
            // bILLITEMSBindingSource
            // 
            this.bILLITEMSBindingSource.DataMember = "BILLITEMS";
            this.bILLITEMSBindingSource.DataSource = this.coDs;
            // 
            // coDs
            // 
            this.coDs.DataSetName = "CompanyDS";
            this.coDs.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label22);
            this.panel5.Controls.Add(this.txtParticulars);
            this.panel5.Controls.Add(this.btnPrintPartyAddr);
            this.panel5.Controls.Add(this.btnCopy);
            this.panel5.Controls.Add(this.btnDelete);
            this.panel5.Controls.Add(this.btnNew);
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Controls.Add(this.btnPrint);
            this.panel5.Controls.Add(this.btnFind);
            this.panel5.Controls.Add(this.nddFind);
            this.panel5.Controls.Add(this.btmGrid);
            this.panel5.Controls.Add(this.txtCddays);
            this.panel5.Controls.Add(this.txtCd);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.txtTotalmtrs);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.txtNetqty);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // txtParticulars
            // 
            this.txtParticulars.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.txtParticulars, "txtParticulars");
            this.txtParticulars.Name = "txtParticulars";
            this.txtParticulars.TabStop = false;
            // 
            // btnPrintPartyAddr
            // 
            resources.ApplyResources(this.btnPrintPartyAddr, "btnPrintPartyAddr");
            this.btnPrintPartyAddr.Name = "btnPrintPartyAddr";
            this.btnPrintPartyAddr.TabStop = false;
            this.btnPrintPartyAddr.UseVisualStyleBackColor = true;
            this.btnPrintPartyAddr.Click += new System.EventHandler(this.btnPrintPartyAddr_Click);
            // 
            // btnCopy
            // 
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.TabStop = false;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabStop = false;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Name = "btnNew";
            this.btnNew.TabStop = false;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.TabStop = false;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnFind
            // 
            resources.ApplyResources(this.btnFind, "btnFind");
            this.btnFind.Name = "btnFind";
            this.btnFind.TabStop = false;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // nddFind
            // 
            resources.ApplyResources(this.nddFind, "nddFind");
            this.nddFind.Name = "nddFind";
            this.nddFind.TabStop = false;
            // 
            // btmGrid
            // 
            this.btmGrid.AllowUserToAddRows = false;
            this.btmGrid.AllowUserToDeleteRows = false;
            this.btmGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.btmGrid.ColumnHeadersVisible = false;
            this.btmGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            resources.ApplyResources(this.btmGrid, "btmGrid");
            this.btmGrid.Name = "btmGrid";
            this.btmGrid.RowHeadersVisible = false;
            this.btmGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.btmGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.btmGrid_CellValueChanged);
            this.btmGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btmGrid_KeyPress);
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle9;
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // txtCddays
            // 
            resources.ApplyResources(this.txtCddays, "txtCddays");
            this.txtCddays.Name = "txtCddays";
            this.txtCddays.Tag = "";
            // 
            // txtCd
            // 
            this.txtCd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.txtCd, "txtCd");
            this.txtCd.Name = "txtCd";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // txtTotalmtrs
            // 
            this.txtTotalmtrs.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.txtTotalmtrs, "txtTotalmtrs");
            this.txtTotalmtrs.Name = "txtTotalmtrs";
            this.txtTotalmtrs.ReadOnly = true;
            this.txtTotalmtrs.TabStop = false;
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // txtNetqty
            // 
            this.txtNetqty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.txtNetqty, "txtNetqty");
            this.txtNetqty.Name = "txtNetqty";
            this.txtNetqty.ReadOnly = true;
            this.txtNetqty.TabStop = false;
            // 
            // pDoc
            // 
            this.pDoc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.pDoc_BeginPrint);
            this.pDoc.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.pDoc_EndPrint);
            this.pDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pDoc_PrintPage);
            this.pDoc.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.pDoc_QueryPageSettings);
            // 
            // preDialog
            // 
            resources.ApplyResources(this.preDialog, "preDialog");
            this.preDialog.Document = this.pDoc;
            this.preDialog.Name = "preDialog";
            this.preDialog.UseAntiAlias = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle10;
            resources.ApplyResources(this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle11;
            resources.ApplyResources(this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle12;
            resources.ApplyResources(this.dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // pPartyAddr
            // 
            this.pPartyAddr.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.pPartyAddr_BeginPrint);
            this.pPartyAddr.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.pPartyAddr_EndPrint);
            this.pPartyAddr.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pPartyAddr_PrintPage);
            // 
            // addressTA
            // 
            this.addressTA.ClearBeforeFill = true;
            // 
            // agentsTA
            // 
            this.agentsTA.ClearBeforeFill = true;
            // 
            // billdiscountsTA
            // 
            this.billdiscountsTA.ClearBeforeFill = true;
            // 
            // billitemsTA
            // 
            this.billitemsTA.ClearBeforeFill = true;
            // 
            // billsTA
            // 
            this.billsTA.ClearBeforeFill = true;
            // 
            // itemsTA
            // 
            this.itemsTA.ClearBeforeFill = true;
            // 
            // partiesTA
            // 
            this.partiesTA.ClearBeforeFill = true;
            // 
            // BillForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BillForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bILLITEMSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coDs)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nddFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btmGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBaleno;
        private System.Windows.Forms.TextBox txtInvno;
        private System.Windows.Forms.TextBox txtPartyCity;
        private System.Windows.Forms.TextBox txtPartyAddr2;
        private System.Windows.Forms.TextBox txtPartyAddr1;
        private System.Windows.Forms.TextBox txtPartyName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLR;
        private System.Windows.Forms.TextBox txtOrderTo;
        private System.Windows.Forms.TextBox txtFwdBy;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotalmtrs;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNetqty;
        private System.Windows.Forms.TextBox txtCd;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCddays;
        private System.Windows.Forms.DataGridView btmGrid;
        private System.Drawing.Printing.PrintDocument pDoc;
        private System.Windows.Forms.PrintPreviewDialog preDialog;
        private System.Windows.Forms.ComboBox cbCoy;
        private System.Windows.Forms.DateTimePicker dtpBillDt;
        private System.Windows.Forms.DateTimePicker dtpLRDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.ComboBox cbAgtName;
        private System.Windows.Forms.TextBox txtPartyState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ComboBox cbCourier;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtPin;
        private CompanyDS coDs;
        private BillingApplication.CompanyDSTableAdapters.ADDRESSTableAdapter addressTA;
        private BillingApplication.CompanyDSTableAdapters.AGENTSTableAdapter agentsTA;
        private BillingApplication.CompanyDSTableAdapters.BILLDISCOUNTSTableAdapter billdiscountsTA;
        private BillingApplication.CompanyDSTableAdapters.BILLITEMSTableAdapter billitemsTA;
        private BillingApplication.CompanyDSTableAdapters.BILLSTableAdapter billsTA;
        private BillingApplication.CompanyDSTableAdapters.ITEMSTableAdapter itemsTA;
        private BillingApplication.CompanyDSTableAdapters.PARTIESTableAdapter partiesTA;
        private System.Windows.Forms.NumericUpDown nddFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtPartyPin;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.CheckBox ckItemPin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Button btnNewParty;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblBale;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdItem;
        private System.Windows.Forms.BindingSource bILLITEMSBindingSource;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.CheckBox ckOrderDate;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnNewAgent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbAccYear;
        private System.Windows.Forms.Button btnPrintPartyAddr;
        private System.Drawing.Printing.PrintDocument pPartyAddr;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtParticulars;
    }
}


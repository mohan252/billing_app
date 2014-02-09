namespace BillingApplication
{
    partial class PendingList
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
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
            this.companyDS = new BillingApplication.CompanyDS();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAddress = new System.Windows.Forms.ComboBox();
            this.aDDRESSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bILLSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bILLSTableAdapter = new BillingApplication.CompanyDSTableAdapters.BILLSTableAdapter();
            this.cbAgent = new System.Windows.Forms.ComboBox();
            this.aGENTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnGet = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgBills = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.ckBillWise = new System.Windows.Forms.CheckBox();
            this.ckParty = new System.Windows.Forms.CheckBox();
            this.cbParty = new System.Windows.Forms.ComboBox();
            this.pARTIESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ckDate = new System.Windows.Forms.CheckBox();
            this.ckExport = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aGENTSTableAdapter = new BillingApplication.CompanyDSTableAdapters.AGENTSTableAdapter();
            this.aDDRESSTableAdapter = new BillingApplication.CompanyDSTableAdapters.ADDRESSTableAdapter();
            this.pARTIESTableAdapter = new BillingApplication.CompanyDSTableAdapters.PARTIESTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.companyDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDDRESSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bILLSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aGENTSBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBills)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pARTIESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // companyDS
            // 
            this.companyDS.DataSetName = "CompanyDS";
            this.companyDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address";
            // 
            // cbAddress
            // 
            this.cbAddress.DataSource = this.aDDRESSBindingSource;
            this.cbAddress.DisplayMember = "NAME";
            this.cbAddress.FormattingEnabled = true;
            this.cbAddress.Location = new System.Drawing.Point(50, 20);
            this.cbAddress.Name = "cbAddress";
            this.cbAddress.Size = new System.Drawing.Size(134, 21);
            this.cbAddress.TabIndex = 1;
            this.cbAddress.ValueMember = "NAME";
            // 
            // aDDRESSBindingSource
            // 
            this.aDDRESSBindingSource.DataMember = "ADDRESS";
            this.aDDRESSBindingSource.DataSource = this.companyDS;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(650, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Agent";
            // 
            // bILLSBindingSource
            // 
            this.bILLSBindingSource.DataMember = "BILLS";
            this.bILLSBindingSource.DataSource = this.companyDS;
            // 
            // bILLSTableAdapter
            // 
            this.bILLSTableAdapter.ClearBeforeFill = true;
            // 
            // cbAgent
            // 
            this.cbAgent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbAgent.DataSource = this.aGENTSBindingSource;
            this.cbAgent.DisplayMember = "NAME";
            this.cbAgent.Enabled = false;
            this.cbAgent.FormattingEnabled = true;
            this.cbAgent.Location = new System.Drawing.Point(702, 89);
            this.cbAgent.Name = "cbAgent";
            this.cbAgent.Size = new System.Drawing.Size(190, 21);
            this.cbAgent.TabIndex = 2;
            this.cbAgent.ValueMember = "NAME";
            // 
            // aGENTSBindingSource
            // 
            this.aGENTSBindingSource.DataMember = "AGENTS";
            this.aGENTSBindingSource.DataSource = this.companyDS;
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Location = new System.Drawing.Point(801, 20);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 5;
            this.btnGet.Text = "&Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 266);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgBills);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1015, 209);
            this.panel3.TabIndex = 2;
            // 
            // dgBills
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgBills.DisplayLayout.Appearance = appearance1;
            this.dgBills.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.dgBills.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgBills.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.dgBills.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgBills.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.dgBills.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgBills.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.dgBills.DisplayLayout.MaxColScrollRegions = 1;
            this.dgBills.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgBills.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgBills.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.dgBills.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.dgBills.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.dgBills.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgBills.DisplayLayout.Override.CellAppearance = appearance8;
            this.dgBills.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgBills.DisplayLayout.Override.CellPadding = 0;
            this.dgBills.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.dgBills.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.dgBills.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.dgBills.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgBills.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.dgBills.DisplayLayout.Override.RowAppearance = appearance11;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgBills.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.dgBills.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgBills.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgBills.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBills.Location = new System.Drawing.Point(0, 0);
            this.dgBills.Name = "dgBills";
            this.dgBills.Size = new System.Drawing.Size(1015, 209);
            this.dgBills.TabIndex = 0;
            this.dgBills.Text = "ultraGrid1";
            this.dgBills.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgBills_InitializeLayout);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtBillNo);
            this.panel2.Controls.Add(this.ckBillWise);
            this.panel2.Controls.Add(this.ckParty);
            this.panel2.Controls.Add(this.cbParty);
            this.panel2.Controls.Add(this.ckDate);
            this.panel2.Controls.Add(this.ckExport);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnGet);
            this.panel2.Controls.Add(this.dpTo);
            this.panel2.Controls.Add(this.dpFrom);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbAgent);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbAddress);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1015, 57);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Bill No";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Enabled = false;
            this.txtBillNo.Location = new System.Drawing.Point(276, 20);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(58, 20);
            this.txtBillNo.TabIndex = 14;
            this.txtBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBillNo_KeyPress);
            // 
            // ckBillWise
            // 
            this.ckBillWise.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ckBillWise.AutoSize = true;
            this.ckBillWise.Checked = true;
            this.ckBillWise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBillWise.Location = new System.Drawing.Point(347, 89);
            this.ckBillWise.Name = "ckBillWise";
            this.ckBillWise.Size = new System.Drawing.Size(83, 17);
            this.ckBillWise.TabIndex = 13;
            this.ckBillWise.Text = "Bill No Wise";
            this.ckBillWise.UseVisualStyleBackColor = true;
            this.ckBillWise.CheckedChanged += new System.EventHandler(this.ckBillWise_CheckedChanged);
            // 
            // ckParty
            // 
            this.ckParty.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ckParty.AutoSize = true;
            this.ckParty.Location = new System.Drawing.Point(445, 89);
            this.ckParty.Name = "ckParty";
            this.ckParty.Size = new System.Drawing.Size(50, 17);
            this.ckParty.TabIndex = 12;
            this.ckParty.Text = "Party";
            this.ckParty.UseVisualStyleBackColor = true;
            this.ckParty.CheckedChanged += new System.EventHandler(this.ckParty_CheckedChanged);
            // 
            // cbParty
            // 
            this.cbParty.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbParty.DataSource = this.pARTIESBindingSource;
            this.cbParty.DisplayMember = "NAME";
            this.cbParty.Enabled = false;
            this.cbParty.FormattingEnabled = true;
            this.cbParty.Location = new System.Drawing.Point(506, 84);
            this.cbParty.Name = "cbParty";
            this.cbParty.Size = new System.Drawing.Size(190, 21);
            this.cbParty.TabIndex = 11;
            this.cbParty.ValueMember = "NAME";
            // 
            // pARTIESBindingSource
            // 
            this.pARTIESBindingSource.DataMember = "PARTIES";
            this.pARTIESBindingSource.DataSource = this.companyDS;
            // 
            // ckDate
            // 
            this.ckDate.AutoSize = true;
            this.ckDate.Location = new System.Drawing.Point(396, 25);
            this.ckDate.Name = "ckDate";
            this.ckDate.Size = new System.Drawing.Size(49, 17);
            this.ckDate.TabIndex = 9;
            this.ckDate.Text = "From";
            this.ckDate.UseVisualStyleBackColor = true;
            this.ckDate.CheckedChanged += new System.EventHandler(this.ckDate_CheckedChanged);
            // 
            // ckExport
            // 
            this.ckExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ckExport.AutoSize = true;
            this.ckExport.Location = new System.Drawing.Point(805, 49);
            this.ckExport.Name = "ckExport";
            this.ckExport.Size = new System.Drawing.Size(70, 17);
            this.ckExport.TabIndex = 7;
            this.ckExport.Text = "Export All";
            this.ckExport.UseVisualStyleBackColor = true;
            this.ckExport.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(908, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "&Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dpTo
            // 
            this.dpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dpTo.Enabled = false;
            this.dpTo.Location = new System.Drawing.Point(605, 20);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(107, 20);
            this.dpTo.TabIndex = 4;
            // 
            // dpFrom
            // 
            this.dpFrom.Enabled = false;
            this.dpFrom.Location = new System.Drawing.Point(447, 20);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(107, 20);
            this.dpFrom.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(577, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "To";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "From";
            // 
            // aGENTSTableAdapter
            // 
            this.aGENTSTableAdapter.ClearBeforeFill = true;
            // 
            // aDDRESSTableAdapter
            // 
            this.aDDRESSTableAdapter.ClearBeforeFill = true;
            // 
            // pARTIESTableAdapter
            // 
            this.pARTIESTableAdapter.ClearBeforeFill = true;
            // 
            // PendingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 266);
            this.Controls.Add(this.panel1);
            this.Name = "PendingList";
            this.Text = "PendingList";
            this.Load += new System.EventHandler(this.PendingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.companyDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDDRESSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bILLSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aGENTSBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBills)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pARTIESBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CompanyDS companyDS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bILLSBindingSource;
        private BillingApplication.CompanyDSTableAdapters.BILLSTableAdapter bILLSTableAdapter;
        private System.Windows.Forms.ComboBox cbAgent;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dpTo;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource aGENTSBindingSource;
        private BillingApplication.CompanyDSTableAdapters.AGENTSTableAdapter aGENTSTableAdapter;
        private System.Windows.Forms.BindingSource aDDRESSBindingSource;
        private BillingApplication.CompanyDSTableAdapters.ADDRESSTableAdapter aDDRESSTableAdapter;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox ckExport;
        private System.Windows.Forms.CheckBox ckDate;
        private System.Windows.Forms.CheckBox ckParty;
        private System.Windows.Forms.ComboBox cbParty;
        private System.Windows.Forms.BindingSource pARTIESBindingSource;
        private BillingApplication.CompanyDSTableAdapters.PARTIESTableAdapter pARTIESTableAdapter;
        private System.Windows.Forms.CheckBox ckBillWise;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgBills;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBillNo;
    }
}
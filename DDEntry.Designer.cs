namespace BillingApplication
{
    partial class DDEntry
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgBills = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.modeOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCS = new System.Windows.Forms.Button();
            this.ckDate = new System.Windows.Forms.CheckBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aGENTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyDS = new BillingApplication.CompanyDS();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAddress = new System.Windows.Forms.ComboBox();
            this.aDDRESSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bILLSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bILLSTableAdapter = new BillingApplication.CompanyDSTableAdapters.BILLSTableAdapter();
            this.aDDRESSTableAdapter = new BillingApplication.CompanyDSTableAdapters.ADDRESSTableAdapter();
            this.aGENTSTableAdapter = new BillingApplication.CompanyDSTableAdapters.AGENTSTableAdapter();
            this.paymentremarksTableAdapter = new BillingApplication.CompanyDSTableAdapters.PAYMENTREMARKSTableAdapter();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeOptionSet)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aGENTSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDDRESSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bILLSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 332);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1284, 279);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgBills);
            this.panel5.Controls.Add(this.modeOptionSet);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1284, 279);
            this.panel5.TabIndex = 9;
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
            this.dgBills.Size = new System.Drawing.Size(1284, 279);
            this.dgBills.TabIndex = 2;
            this.dgBills.Text = "dgBills";
            this.dgBills.AfterRowExpanded += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.dgBills_AfterRowExpanded);
            this.dgBills.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.dgBills_AfterSelectChange);
            this.dgBills.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgBills_InitializeLayout);
            this.dgBills.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgBills_BeforeRowsDeleted);
            this.dgBills.BeforeRowExpanded += new Infragistics.Win.UltraWinGrid.CancelableRowEventHandler(this.dgBills_BeforeRowExpanded);
            this.dgBills.AfterRowsDeleted += new System.EventHandler(this.dgBills_AfterRowsDeleted);
            // 
            // modeOptionSet
            // 
            this.modeOptionSet.Location = new System.Drawing.Point(0, 0);
            this.modeOptionSet.Name = "modeOptionSet";
            this.modeOptionSet.Size = new System.Drawing.Size(96, 32);
            this.modeOptionSet.TabIndex = 1;
            this.modeOptionSet.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCS);
            this.panel2.Controls.Add(this.ckDate);
            this.panel2.Controls.Add(this.btnGet);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.dpTo);
            this.panel2.Controls.Add(this.dpFrom);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbAddress);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1284, 53);
            this.panel2.TabIndex = 1;
            // 
            // btnCS
            // 
            this.btnCS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCS.Location = new System.Drawing.Point(1035, 23);
            this.btnCS.Name = "btnCS";
            this.btnCS.Size = new System.Drawing.Size(75, 23);
            this.btnCS.TabIndex = 12;
            this.btnCS.Text = "&ComStmt";
            this.btnCS.UseVisualStyleBackColor = true;
            this.btnCS.Click += new System.EventHandler(this.btnCS_Click);
            // 
            // ckDate
            // 
            this.ckDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ckDate.AutoSize = true;
            this.ckDate.Location = new System.Drawing.Point(389, 25);
            this.ckDate.Name = "ckDate";
            this.ckDate.Size = new System.Drawing.Size(49, 17);
            this.ckDate.TabIndex = 8;
            this.ckDate.Text = "From";
            this.ckDate.UseVisualStyleBackColor = true;
            this.ckDate.CheckedChanged += new System.EventHandler(this.ckDate_CheckedChanged);
            // 
            // btnGet
            // 
            this.btnGet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGet.Location = new System.Drawing.Point(751, 22);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 5;
            this.btnGet.Text = "&Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(897, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dpTo
            // 
            this.dpTo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dpTo.Enabled = false;
            this.dpTo.Location = new System.Drawing.Point(584, 22);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(100, 20);
            this.dpTo.TabIndex = 4;
            // 
            // dpFrom
            // 
            this.dpFrom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dpFrom.Enabled = false;
            this.dpFrom.Location = new System.Drawing.Point(439, 22);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(100, 20);
            this.dpFrom.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "To";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(878, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "From";
            this.label3.Visible = false;
            // 
            // aGENTSBindingSource
            // 
            this.aGENTSBindingSource.DataMember = "AGENTS";
            this.aGENTSBindingSource.DataSource = this.companyDS;
            // 
            // companyDS
            // 
            this.companyDS.DataSetName = "CompanyDS";
            this.companyDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Agent";
            this.label2.Visible = false;
            // 
            // cbAddress
            // 
            this.cbAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbAddress.DataSource = this.aDDRESSBindingSource;
            this.cbAddress.DisplayMember = "NAME";
            this.cbAddress.FormattingEnabled = true;
            this.cbAddress.Location = new System.Drawing.Point(182, 20);
            this.cbAddress.Name = "cbAddress";
            this.cbAddress.Size = new System.Drawing.Size(152, 21);
            this.cbAddress.TabIndex = 1;
            this.cbAddress.ValueMember = "NAME";
            // 
            // aDDRESSBindingSource
            // 
            this.aDDRESSBindingSource.DataMember = "ADDRESS";
            this.aDDRESSBindingSource.DataSource = this.companyDS;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address";
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
            // aDDRESSTableAdapter
            // 
            this.aDDRESSTableAdapter.ClearBeforeFill = true;
            // 
            // aGENTSTableAdapter
            // 
            this.aGENTSTableAdapter.ClearBeforeFill = true;
            // 
            // paymentremarksTableAdapter
            // 
            this.paymentremarksTableAdapter.ClearBeforeFill = true;
            // 
            // DDEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 332);
            this.Controls.Add(this.panel1);
            this.Name = "DDEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DDEntry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DDEntry_FormClosing);
            this.Load += new System.EventHandler(this.DDEntry_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeOptionSet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aGENTSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDDRESSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bILLSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbAddress;
        private System.Windows.Forms.Label label1;
        private CompanyDS companyDS;
        private BillingApplication.CompanyDSTableAdapters.BILLSTableAdapter bILLSTableAdapter;
        private System.Windows.Forms.BindingSource aDDRESSBindingSource;
        private BillingApplication.CompanyDSTableAdapters.ADDRESSTableAdapter aDDRESSTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource aGENTSBindingSource;
        private BillingApplication.CompanyDSTableAdapters.AGENTSTableAdapter aGENTSTableAdapter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dpTo;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.BindingSource bILLSBindingSource;
        private System.Windows.Forms.CheckBox ckDate;
        private System.Windows.Forms.Panel panel5;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet modeOptionSet;
        private Infragistics.Win.UltraWinGrid.UltraGrid dgBills;
        private System.Windows.Forms.Button btnCS;
        private BillingApplication.CompanyDSTableAdapters.PAYMENTREMARKSTableAdapter paymentremarksTableAdapter;
    }
}
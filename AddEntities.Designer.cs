namespace BillingApplication
{
    partial class AddEntities
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
            this.itemsTableAdapter = new BillingApplication.CompanyDSTableAdapters.ITEMSTableAdapter();
            this.partiesTableAdapter = new BillingApplication.CompanyDSTableAdapters.PARTIESTableAdapter();
            this.agentsTableAdapter = new BillingApplication.CompanyDSTableAdapters.AGENTSTableAdapter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabEntities = new System.Windows.Forms.TabControl();
            this.tabParties = new System.Windows.Forms.TabPage();
            this.tabremarks = new System.Windows.Forms.TabPage();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.grdEntities = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.paymentremarksTableAdapter = new BillingApplication.CompanyDSTableAdapters.PAYMENTREMARKSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabEntities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // partiesTableAdapter
            // 
            this.partiesTableAdapter.ClearBeforeFill = true;
            // 
            // agentsTableAdapter
            // 
            this.agentsTableAdapter.ClearBeforeFill = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabEntities);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdEntities);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnUpdate);
            this.splitContainer1.Size = new System.Drawing.Size(641, 411);
            this.splitContainer1.SplitterDistance = 348;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabEntities
            // 
            this.tabEntities.Controls.Add(this.tabParties);
            this.tabEntities.Controls.Add(this.tabremarks);
            this.tabEntities.Controls.Add(this.tabItems);
            this.tabEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEntities.Location = new System.Drawing.Point(0, 0);
            this.tabEntities.Name = "tabEntities";
            this.tabEntities.SelectedIndex = 0;
            this.tabEntities.Size = new System.Drawing.Size(641, 348);
            this.tabEntities.TabIndex = 0;
            this.tabEntities.SelectedIndexChanged += new System.EventHandler(this.tabEntities_SelectedIndexChanged);
            // 
            // tabParties
            // 
            this.tabParties.Location = new System.Drawing.Point(4, 22);
            this.tabParties.Name = "tabParties";
            this.tabParties.Padding = new System.Windows.Forms.Padding(3);
            this.tabParties.Size = new System.Drawing.Size(633, 322);
            this.tabParties.TabIndex = 0;
            this.tabParties.Text = "Parties";
            this.tabParties.UseVisualStyleBackColor = true;
            // 
            // tabremarks
            // 
            this.tabremarks.Location = new System.Drawing.Point(4, 22);
            this.tabremarks.Name = "tabremarks";
            this.tabremarks.Size = new System.Drawing.Size(633, 322);
            this.tabremarks.TabIndex = 2;
            this.tabremarks.Text = "Payment Remarks";
            this.tabremarks.UseVisualStyleBackColor = true;
            // 
            // tabItems
            // 
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(633, 322);
            this.tabItems.TabIndex = 1;
            this.tabItems.Text = "Items";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // grdEntities
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdEntities.DisplayLayout.Appearance = appearance1;
            this.grdEntities.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdEntities.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdEntities.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdEntities.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdEntities.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grdEntities.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdEntities.DisplayLayout.GroupByBox.Hidden = true;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdEntities.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grdEntities.DisplayLayout.MaxColScrollRegions = 1;
            this.grdEntities.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdEntities.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdEntities.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grdEntities.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdEntities.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdEntities.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grdEntities.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdEntities.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdEntities.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdEntities.DisplayLayout.Override.CellPadding = 0;
            this.grdEntities.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdEntities.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.grdEntities.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdEntities.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdEntities.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.grdEntities.DisplayLayout.Override.RowAppearance = appearance11;
            this.grdEntities.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdEntities.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grdEntities.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdEntities.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdEntities.Location = new System.Drawing.Point(417, -41);
            this.grdEntities.Name = "grdEntities";
            this.grdEntities.Size = new System.Drawing.Size(212, 124);
            this.grdEntities.TabIndex = 0;
            this.grdEntities.Text = "ultraGrid1";
            this.grdEntities.Visible = false;
            this.grdEntities.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdEntities_InitializeLayout);
            this.grdEntities.BeforeCellUpdate += new Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler(this.grdEntities_BeforeCellUpdate);
            this.grdEntities.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.grdEntities_BeforeRowsDeleted);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(352, 24);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(207, 24);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // paymentremarksTableAdapter
            // 
            this.paymentremarksTableAdapter.ClearBeforeFill = true;
            // 
            // AddEntities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 411);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AddEntities";
            this.Text = "Entities";
            this.Load += new System.EventHandler(this.AddEntities_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabEntities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEntities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BillingApplication.CompanyDSTableAdapters.ITEMSTableAdapter itemsTableAdapter;
        private BillingApplication.CompanyDSTableAdapters.PARTIESTableAdapter partiesTableAdapter;
        private BillingApplication.CompanyDSTableAdapters.AGENTSTableAdapter agentsTableAdapter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabEntities;
        private System.Windows.Forms.TabPage tabParties;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdEntities;
        private System.Windows.Forms.TabPage tabremarks;
        private BillingApplication.CompanyDSTableAdapters.PAYMENTREMARKSTableAdapter paymentremarksTableAdapter;
    }
}
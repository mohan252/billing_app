namespace BillingApplication
{
    partial class Reports
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
            this.Panelbase = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radioPanel = new System.Windows.Forms.Panel();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.lblFilterText = new System.Windows.Forms.Label();
            this.tabReport = new System.Windows.Forms.TabControl();
            this.ultraGridExcelExporter = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.accYearPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cbAccYear = new System.Windows.Forms.ComboBox();
            this.bkButton = new System.Windows.Forms.Button();
            this.Panelbase.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.accYearPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panelbase
            // 
            this.Panelbase.Controls.Add(this.splitContainer1);
            this.Panelbase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panelbase.Location = new System.Drawing.Point(0, 0);
            this.Panelbase.Name = "Panelbase";
            this.Panelbase.Size = new System.Drawing.Size(787, 529);
            this.Panelbase.TabIndex = 0;
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
            this.splitContainer1.Panel1.Controls.Add(this.accYearPanel);
            this.splitContainer1.Panel1.Controls.Add(this.radioPanel);
            this.splitContainer1.Panel1.Controls.Add(this.filterPanel);
            this.splitContainer1.Panel1.Controls.Add(this.lblFilterText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.tabReport);
            this.splitContainer1.Size = new System.Drawing.Size(787, 529);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.TabIndex = 0;
            // 
            // radioPanel
            // 
            this.radioPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioPanel.Location = new System.Drawing.Point(0, 0);
            this.radioPanel.Name = "radioPanel";
            this.radioPanel.Size = new System.Drawing.Size(787, 11);
            this.radioPanel.TabIndex = 6;
            // 
            // filterPanel
            // 
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPanel.Location = new System.Drawing.Point(0, 0);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(787, 60);
            this.filterPanel.TabIndex = 5;
            // 
            // lblFilterText
            // 
            this.lblFilterText.AutoSize = true;
            this.lblFilterText.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterText.Location = new System.Drawing.Point(678, 37);
            this.lblFilterText.Name = "lblFilterText";
            this.lblFilterText.Size = new System.Drawing.Size(50, 16);
            this.lblFilterText.TabIndex = 3;
            this.lblFilterText.Text = "label1";
            //
            // tabReport
            // 
            this.tabReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReport.Location = new System.Drawing.Point(0, 0);
            this.tabReport.Name = "tabReport";
            this.tabReport.SelectedIndex = 0;
            this.tabReport.Size = new System.Drawing.Size(787, 465);
            this.tabReport.TabIndex = 2;
            this.tabReport.SelectedIndexChanged += new System.EventHandler(this.tabReport_SelectedIndexChanged);
            // 
            // accYearPanel
            // 
            this.accYearPanel.Controls.Add(this.bkButton);
            this.accYearPanel.Controls.Add(this.label8);
            this.accYearPanel.Controls.Add(this.cbAccYear);
            this.accYearPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.accYearPanel.Location = new System.Drawing.Point(497, 11);
            this.accYearPanel.Name = "accYearPanel";
            this.accYearPanel.Size = new System.Drawing.Size(290, 49);
            this.accYearPanel.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(4, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 119;
            this.label8.Text = "Accounting Year";
            // 
            // cbAccYear
            // 
            this.cbAccYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAccYear.FormattingEnabled = true;
            this.cbAccYear.Items.AddRange(new object[] {
            "Party",
            "Agent"});
            this.cbAccYear.Location = new System.Drawing.Point(98, 14);
            this.cbAccYear.Name = "cbAccYear";
            this.cbAccYear.Size = new System.Drawing.Size(99, 21);
            this.cbAccYear.TabIndex = 118;
            this.cbAccYear.TabStop = false;
            this.cbAccYear.SelectedIndexChanged += new System.EventHandler(this.cbAccYear_SelectedIndexChanged);
            // 
            // bkButton
            // 
            this.bkButton.Location = new System.Drawing.Point(214, 13);
            this.bkButton.Name = "bkButton";
            this.bkButton.Size = new System.Drawing.Size(64, 23);
            this.bkButton.TabIndex = 120;
            this.bkButton.Text = "Back";
            this.bkButton.UseVisualStyleBackColor = true;
            this.bkButton.Click += new System.EventHandler(this.bkButton_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 529);
            this.Controls.Add(this.Panelbase);
            this.Name = "Reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.Panelbase.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.accYearPanel.ResumeLayout(false);
            this.accYearPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panelbase;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabReport;
        private System.Windows.Forms.Label lblFilterText;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Panel radioPanel;
        private System.Windows.Forms.Panel accYearPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbAccYear;
        private System.Windows.Forms.Button bkButton;
        
    }
}
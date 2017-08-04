namespace BillingApplication
{
    partial class Delivery
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Band 1");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 1", 0);
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
            Infragistics.Win.UltraWinDataSource.UltraDataBand ultraDataBand1 = new Infragistics.Win.UltraWinDataSource.UltraDataBand("Band 1");
            this.gridDelivery = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDelivery
            // 
            this.gridDelivery.DataSource = this.ultraDataSource1;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridDelivery.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1});
            this.gridDelivery.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridDelivery.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.gridDelivery.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridDelivery.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridDelivery.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridDelivery.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.gridDelivery.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridDelivery.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.gridDelivery.DisplayLayout.MaxColScrollRegions = 1;
            this.gridDelivery.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDelivery.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridDelivery.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.gridDelivery.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridDelivery.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.gridDelivery.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridDelivery.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridDelivery.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridDelivery.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.gridDelivery.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.gridDelivery.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.gridDelivery.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridDelivery.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.gridDelivery.DisplayLayout.Override.RowAppearance = appearance11;
            this.gridDelivery.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridDelivery.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.gridDelivery.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridDelivery.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridDelivery.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridDelivery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDelivery.Location = new System.Drawing.Point(0, 0);
            this.gridDelivery.Name = "gridDelivery";
            this.gridDelivery.Size = new System.Drawing.Size(670, 529);
            this.gridDelivery.TabIndex = 0;
            this.gridDelivery.Text = "ultraGrid1";
            // 
            // ultraDataSource1
            // 
            this.ultraDataSource1.Band.ChildBands.AddRange(new object[] {
            ultraDataBand1});
            // 
            // Delivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 529);
            this.Controls.Add(this.gridDelivery);
            this.Name = "Delivery";
            this.Text = "Delivery";
            this.Load += new System.EventHandler(this.Delivery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid gridDelivery;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource1;
    }
}
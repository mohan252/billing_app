namespace BillingApplication
{
    partial class ItemPopUp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lItems = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCalcType = new System.Windows.Forms.ComboBox();
            this.cALCTYPESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyDS = new BillingApplication.CompanyDS();
            this.label3 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.iTEMTYPESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.ckNew = new System.Windows.Forms.CheckBox();
            this.iTEMTYPESTableAdapter = new BillingApplication.CompanyDSTableAdapters.ITEMTYPESTableAdapter();
            this.cALCTYPESTableAdapter = new BillingApplication.CompanyDSTableAdapters.CALCTYPESTableAdapter();
            this.itemsTableAdapter = new BillingApplication.CompanyDSTableAdapters.ITEMSTableAdapter();
            this.txtHsn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cALCTYPESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTEMTYPESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bCancel);
            this.panel1.Controls.Add(this.bOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 405);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 42);
            this.panel1.TabIndex = 0;
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(171, 13);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 7;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bOk
            // 
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(62, 13);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 6;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lItems);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 234);
            this.panel2.TabIndex = 1;
            // 
            // lItems
            // 
            this.lItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lItems.FormattingEnabled = true;
            this.lItems.Location = new System.Drawing.Point(0, 0);
            this.lItems.Name = "lItems";
            this.lItems.Size = new System.Drawing.Size(382, 234);
            this.lItems.TabIndex = 1;
            this.lItems.SelectedIndexChanged += new System.EventHandler(this.lItems_SelectedIndexChanged);
            this.lItems.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lItems_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtHsn);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbCalcType);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cbType);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.ckNew);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 234);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(382, 171);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name";
            // 
            // cbCalcType
            // 
            this.cbCalcType.DataSource = this.cALCTYPESBindingSource;
            this.cbCalcType.DisplayMember = "CALCTYPE";
            this.cbCalcType.FormattingEnabled = true;
            this.cbCalcType.Location = new System.Drawing.Point(99, 94);
            this.cbCalcType.Name = "cbCalcType";
            this.cbCalcType.Size = new System.Drawing.Size(83, 21);
            this.cbCalcType.TabIndex = 5;
            this.cbCalcType.ValueMember = "CALCTYPE";
            // 
            // cALCTYPESBindingSource
            // 
            this.cALCTYPESBindingSource.DataMember = "CALCTYPES";
            this.cALCTYPESBindingSource.DataSource = this.companyDS;
            // 
            // companyDS
            // 
            this.companyDS.DataSetName = "CompanyDS";
            this.companyDS.Locale = new System.Globalization.CultureInfo("en-GB");
            this.companyDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Type";
            // 
            // cbType
            // 
            this.cbType.DataSource = this.iTEMTYPESBindingSource;
            this.cbType.DisplayMember = "TYPE";
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(99, 65);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(272, 21);
            this.cbType.TabIndex = 4;
            this.cbType.ValueMember = "TYPE";
            // 
            // iTEMTYPESBindingSource
            // 
            this.iTEMTYPESBindingSource.DataMember = "ITEMTYPES";
            this.iTEMTYPESBindingSource.DataSource = this.companyDS;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Calculation Type";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(98, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(274, 20);
            this.txtName.TabIndex = 2;
            // 
            // ckNew
            // 
            this.ckNew.AutoSize = true;
            this.ckNew.Location = new System.Drawing.Point(12, 8);
            this.ckNew.Name = "ckNew";
            this.ckNew.Size = new System.Drawing.Size(48, 17);
            this.ckNew.TabIndex = 1;
            this.ckNew.Text = "New";
            this.ckNew.UseVisualStyleBackColor = true;
            this.ckNew.CheckedChanged += new System.EventHandler(this.ckNew_CheckedChanged);
            // 
            // iTEMTYPESTableAdapter
            // 
            this.iTEMTYPESTableAdapter.ClearBeforeFill = true;
            // 
            // cALCTYPESTableAdapter
            // 
            this.cALCTYPESTableAdapter.ClearBeforeFill = true;
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // txtHsn
            // 
            this.txtHsn.Location = new System.Drawing.Point(99, 39);
            this.txtHsn.Name = "txtHsn";
            this.txtHsn.Size = new System.Drawing.Size(274, 20);
            this.txtHsn.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "HSN/ACS Code";
            // 
            // ItemPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(382, 447);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemPopUp";
            this.Text = "ItemPopUp";
            this.Load += new System.EventHandler(this.ItemPopUp_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cALCTYPESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTEMTYPESBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lItems;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbCalcType;
        private System.Windows.Forms.Label label1;
        private CompanyDS companyDS;
        private System.Windows.Forms.BindingSource iTEMTYPESBindingSource;
        private BillingApplication.CompanyDSTableAdapters.ITEMTYPESTableAdapter iTEMTYPESTableAdapter;
        private System.Windows.Forms.BindingSource cALCTYPESBindingSource;
        private BillingApplication.CompanyDSTableAdapters.CALCTYPESTableAdapter cALCTYPESTableAdapter;
        private BillingApplication.CompanyDSTableAdapters.ITEMSTableAdapter itemsTableAdapter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHsn;
    }
}
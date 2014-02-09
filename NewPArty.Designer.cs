namespace BillingApplication
{
    partial class NewPArty
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddr4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddr3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddr2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddr1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCl = new System.Windows.Forms.Button();
            this.partiesTableAdapter = new BillingApplication.CompanyDSTableAdapters.PARTIESTableAdapter();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(268, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtAddr4
            // 
            this.txtAddr4.Location = new System.Drawing.Point(79, 137);
            this.txtAddr4.Name = "txtAddr4";
            this.txtAddr4.Size = new System.Drawing.Size(268, 20);
            this.txtAddr4.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "District";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(79, 166);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(268, 20);
            this.txtCity.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "City";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(79, 196);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(268, 20);
            this.txtState.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "State";
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(79, 226);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(268, 20);
            this.txtPin.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Pin";
            // 
            // txtAddr3
            // 
            this.txtAddr3.Location = new System.Drawing.Point(79, 105);
            this.txtAddr3.Name = "txtAddr3";
            this.txtAddr3.Size = new System.Drawing.Size(268, 20);
            this.txtAddr3.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Addr3";
            // 
            // txtAddr2
            // 
            this.txtAddr2.Location = new System.Drawing.Point(79, 76);
            this.txtAddr2.Name = "txtAddr2";
            this.txtAddr2.Size = new System.Drawing.Size(268, 20);
            this.txtAddr2.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Addr2";
            // 
            // txtAddr1
            // 
            this.txtAddr1.Location = new System.Drawing.Point(79, 50);
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.Size = new System.Drawing.Size(268, 20);
            this.txtAddr1.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Addr1";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(80, 269);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCl
            // 
            this.btnCl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCl.Location = new System.Drawing.Point(192, 269);
            this.btnCl.Name = "btnCl";
            this.btnCl.Size = new System.Drawing.Size(75, 23);
            this.btnCl.TabIndex = 10;
            this.btnCl.Text = "Cancel";
            this.btnCl.UseVisualStyleBackColor = true;
            // 
            // partiesTableAdapter
            // 
            this.partiesTableAdapter.ClearBeforeFill = true;
            // 
            // NewPArty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCl;
            this.ClientSize = new System.Drawing.Size(376, 326);
            this.Controls.Add(this.btnCl);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtAddr1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAddr2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAddr3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddr4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "NewPArty";
            this.Text = "NewParty";
            this.Load += new System.EventHandler(this.NewPArty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddr4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddr3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddr2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddr1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCl;
        private BillingApplication.CompanyDSTableAdapters.PARTIESTableAdapter partiesTableAdapter;
    }
}
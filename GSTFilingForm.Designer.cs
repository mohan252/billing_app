namespace BillingApplication
{
    partial class GSTFilingForm
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
            this.cbAddress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilingMonth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrentTurnover = new System.Windows.Forms.TextBox();
            this.txtPrevTurnOver = new System.Windows.Forms.TextBox();
            this.btnJson = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbAddress
            // 
            this.cbAddress.FormattingEnabled = true;
            this.cbAddress.Location = new System.Drawing.Point(232, 26);
            this.cbAddress.Name = "cbAddress";
            this.cbAddress.Size = new System.Drawing.Size(224, 21);
            this.cbAddress.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ADDRESS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "FILING MONTH";
            // 
            // txtFilingMonth
            // 
            this.txtFilingMonth.Location = new System.Drawing.Point(230, 97);
            this.txtFilingMonth.Name = "txtFilingMonth";
            this.txtFilingMonth.Size = new System.Drawing.Size(100, 20);
            this.txtFilingMonth.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CURRENT PERIOD TURNOVER";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "PREVIOUS YEAR TURNOVER";
            // 
            // txtCurrentTurnover
            // 
            this.txtCurrentTurnover.Location = new System.Drawing.Point(229, 132);
            this.txtCurrentTurnover.Name = "txtCurrentTurnover";
            this.txtCurrentTurnover.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentTurnover.TabIndex = 6;
            // 
            // txtPrevTurnOver
            // 
            this.txtPrevTurnOver.Location = new System.Drawing.Point(229, 169);
            this.txtPrevTurnOver.Name = "txtPrevTurnOver";
            this.txtPrevTurnOver.Size = new System.Drawing.Size(100, 20);
            this.txtPrevTurnOver.TabIndex = 7;
            // 
            // btnJson
            // 
            this.btnJson.Location = new System.Drawing.Point(232, 214);
            this.btnJson.Name = "btnJson";
            this.btnJson.Size = new System.Drawing.Size(128, 23);
            this.btnJson.TabIndex = 8;
            this.btnJson.Text = "GENERATE JSON";
            this.btnJson.UseVisualStyleBackColor = true;
            this.btnJson.Click += new System.EventHandler(this.btnJson_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "FROM";
            // 
            // dpFrom
            // 
            this.dpFrom.Location = new System.Drawing.Point(232, 63);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(124, 20);
            this.dpFrom.TabIndex = 11;
            // 
            // dpTo
            // 
            this.dpTo.Location = new System.Drawing.Point(406, 62);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(124, 20);
            this.dpTo.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(377, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "TO";
            // 
            // GSTFilingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 283);
            this.Controls.Add(this.dpTo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dpFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnJson);
            this.Controls.Add(this.txtPrevTurnOver);
            this.Controls.Add(this.txtCurrentTurnover);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilingMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAddress);
            this.Name = "GSTFilingForm";
            this.Text = "GSTFilingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilingMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurrentTurnover;
        private System.Windows.Forms.TextBox txtPrevTurnOver;
        private System.Windows.Forms.Button btnJson;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.DateTimePicker dpTo;
        private System.Windows.Forms.Label label7;
    }
}
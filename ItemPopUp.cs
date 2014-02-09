using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BillingApplication
{
    public partial class ItemPopUp : Form
    {
        public string selValue = "";
        public bool IsNewItem = false;
        public string NewItemName
        {
            get { return txtName.Text; }
            set
            {
                txtName.Text = value;
            }
        }
        public ItemPopUp(System.Collections.Generic.List<string> items)
        {
            InitializeComponent();
            Font oriFont = lItems.Font;
            lItems.Font = new Font(oriFont.FontFamily, 10);
            if (items != null)
                lItems.DataSource = items;
            else
            {
                ckNew.Checked = true;
            }
        }

        private void lItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            selValue = Convert.ToString(lItems.SelectedValue);
        }

        private void ItemPopUp_Load(object sender, EventArgs e)
        {
            if (!ckNew.Checked)
            {
                txtName.Enabled = false;
                cbCalcType.Enabled = false;
                cbType.Enabled = false;
                lItems.Select();
            }
            else
                txtName.Focus();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (ckNew.Checked)
            {
                if (txtName.Text != "")
                {
                    selValue = txtName.Text.ToUpper().Trim();
                    int i = itemsTableAdapter.Insert(selValue, cbType.Text, cbCalcType.Text);
                    if (i > 0)
                        IsNewItem = true;
                }
                else
                {
                    MessageBox.Show("Please enter the new item name");
                    return;
                }
            }
        }

        private void lItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                selValue = Convert.ToString(lItems.SelectedValue);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ckNew_CheckedChanged(object sender, EventArgs e)
        {
            if (ckNew.Checked)
            {
                // TODO: This line of code loads data into the 'companyDS.CALCTYPES' table. You can move, or remove it, as needed.
                this.cALCTYPESTableAdapter.Fill(this.companyDS.CALCTYPES);
                // TODO: This line of code loads data into the 'companyDS.ITEMTYPES' table. You can move, or remove it, as needed.
                this.iTEMTYPESTableAdapter.Fill(this.companyDS.ITEMTYPES);
                txtName.Enabled = true;
                cbCalcType.Enabled = true;
                cbType.Enabled = true;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BillingApplication
{
    public partial class NewPArty : Form
    {
        public string partyName = "";
        public string partyGst = "";
        public string partyAddr1 = "";
        public string partyAddr2 = "";
        public string partyAddr3 = "";
        public string partyAddr4 = "";
        public string partyCity = "";
        public string partyState = "";
        public string partyPin = "";

        public NewPArty()
        {
            InitializeComponent();
        }

        private bool ValidatePin()
        {
            string name = txtPin.Text.Trim().ToUpper();
            //if (name == "")
            //{
            //    MessageBox.Show("Pin Name cannot be empty");
            //    txtPin.Focus();
            //    return false;
            //}
            //else
            if (name != "")
            {
                try
                {
                    decimal pin = Convert.ToDecimal(name);
                    if (Convert.ToString(pin).Length != 6)
                    {
                        MessageBox.Show("Pin must be 6 digits long");
                        return false;
                    }
                    else
                        return true;
                }
                catch
                {
                    MessageBox.Show("Pin must be numeric value");
                    return false;
                }
            }
            else
                return true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateName() && ValidateGst() && ValidatePin())
            {
                BillingApplication.CompanyDS.PARTIESDataTable dt = new CompanyDS.PARTIESDataTable();
                BillingApplication.CompanyDS.PARTIESRow pr = dt.NewPARTIESRow();
                pr.NAME = txtName.Text.Trim().ToUpper();
                pr.GST = txtGst.Text.Trim();
                partyName = pr.NAME;
                partyGst = pr.GST;
                if (txtAddr1.Text.Trim() != "")
                {
                    pr.ADDR1 = txtAddr1.Text.Trim().ToUpper();
                    partyAddr1 = pr.ADDR1;
                }
                if (txtAddr2.Text.Trim() != "")
                {
                    pr.ADDR2 = txtAddr2.Text.Trim().ToUpper();
                    partyAddr2 = pr.ADDR2;
                }
                if (txtAddr3.Text.Trim() != "")
                {
                    pr.ADDR3 = txtAddr3.Text.Trim().ToUpper();
                    partyAddr3 = pr.ADDR3;
                }
                if (txtAddr4.Text.Trim() != "")
                {
                    pr.DISTRICT = txtAddr4.Text.Trim().ToUpper();
                    partyAddr4 = pr.DISTRICT;
                }
                if (txtCity.Text.Trim() != "")
                {
                    pr.CITY = txtCity.Text.Trim().ToUpper();
                    partyCity = pr.CITY;
                }
                if (txtState.Text.Trim() != "")
                {
                    pr.STATE = txtState.Text.Trim().ToUpper();
                    partyState = pr.STATE;
                }
                if (txtPin.Text.Trim() != "")
                {
                    pr.PIN = Convert.ToDecimal(txtPin.Text);
                    partyPin = txtPin.Text.Trim();
                }
                dt.Rows.Add(pr);
                partiesTableAdapter.Update(dt);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateGst()
        {
            string gst = txtGst.Text.Trim();
            if (gst == "")
            {
                MessageBox.Show("Gst cannot be empty");
                txtGst.Focus();
                return false;
            }
            return true;
        }
        private bool ValidateName()
        {
            string name = txtName.Text.Trim().ToUpper();
            if (name == "")
            {
                MessageBox.Show("Party Name cannot be empty");
                txtName.Focus();
                return false;
            }
            else if (Convert.ToInt32(partiesTableAdapter.IsPartyExists(name)) > 0)
            {
                MessageBox.Show("Party with the entered name already exists in db \nPlease enter another name");
                txtName.Focus();
                return false;
            }
            else
                return true;
        }

        private void NewPArty_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

    }
}
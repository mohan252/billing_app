using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BillingApplication
{
    public partial class MetersPopUp : Form
    {
        public XmlDocument output = null;
        private XmlDocument inputDom = null;
        public MetersPopUp(XmlDocument input)
        {
            InitializeComponent();
            inputDom = input;
            dgView.Columns[0].ValueType = typeof(string);
        }

        private void MetersPopUp_Load(object sender, EventArgs e)
        {
            dgView[0, 0].ValueType = typeof(decimal);
            dgView.Columns[0].Width = this.Width - 50;
            dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgView.Rows[0].Selected = true;
            if (inputDom != null)
            {
                XmlNodeList list = inputDom.SelectNodes("//Meter");
                if (list != null && list.Count > 0)
                {
                    foreach (XmlNode node in list)
                    {
                        string[] vals = new string[1];
                        vals[0] = node.InnerText;
                        dgView.Rows.Add(vals);
                    }
                    SetTotal();
                }
            }
        }

        private void dgView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetTotal();
        }
        private void SetTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgView.Rows)
            {
                total += Convert.ToDecimal(row.Cells[0].Value);
            }
            total = Math.Round(total, 2);
            txtTotal.Text = Convert.ToString(total);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgView.Rows.Count > 0)
            {
                string outputXml = "<Meters>";
                foreach (DataGridViewRow row in dgView.Rows)
                {
                    if(row.Cells[0].Value != null && Convert.ToString(row.Cells[0].Value) != "")
                        outputXml += "<Meter>" + Convert.ToString(row.Cells[0].Value) + "</Meter>";
                }
                outputXml += "<Total>" + txtTotal.Text.Trim() + "</Total>";
                outputXml += "</Meters>";
                output = new XmlDocument();
                output.LoadXml(outputXml);
            }
        }
    }
}
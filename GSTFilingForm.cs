using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillingApplication.Models;
using Newtonsoft.Json;
using System.IO;

namespace BillingApplication
{

    public partial class GSTFilingForm : Form
    {
        DAL dal = new DAL();
        public GSTFilingForm()
        {
            InitializeComponent();

            BindAddressList();

            var today = DateTime.Now;
            if (DateTime.Now.Month < 10)
            {
                txtFilingMonth.Text = "0" + today.Month + "" + today.Year + "";
            }
            else
            {
                txtFilingMonth.Text = today.Month + "" + today.Year + "";
            }

            if (today.Day < 11)
            {
                dpFrom.Value = new DateTime(today.Year, today.Month - 1, 11);
                dpTo.Value = new DateTime(today.Year, today.Month, 10);
            }
            else
            {
                dpFrom.Value = new DateTime(today.Year, today.Month, 11);
                dpTo.Value = new DateTime(today.Year, today.Month + 1, 10);
            }
        }
        public void BindAddressList()
        {
            var addresses = dal.GetAddresses();
            this.cbAddress.DataSource = addresses;
            this.cbAddress.DisplayMember = "NAME";
            this.cbAddress.ValueMember = "GST";
        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            var gstItems = dal.GetGstDetailsByParty(dpFrom.Value, dpTo.Value).ToList();
            var gstItemGroups = gstItems.GroupBy(c => c.PartyGst).ToArray();
            FilingParty[] b2b = new FilingParty[gstItemGroups.Length];
            for (int i = 0; i < gstItemGroups.Count(); i++)
            {
                b2b[i] = new FilingParty
                {
                    PartyGst = gstItemGroups[i].Key,
                    Invoices = gstItemGroups[i].Select(g => new FilingInvoice
                    {
                        InvoiceNumber = g.InvoiceNumber,
                        InvoiceDate = g.InvoiceDate,
                        TotalAfterTax = Convert.ToInt32(g.TotalAfterTax),
                        PartyStateCode = gstItemGroups[i].Key.Substring(0,2),
                        InvoiceItems = new FilingInvoiceItem[1] {
                            new FilingInvoiceItem{
                                InvoiceDetail = new FilingInvoiceItemDetail{
                                    TotalBeforeTax = Convert.ToInt32(g.TotalBeforeTax),
                                    IgstRate = Convert.ToDecimal(g.IgstRate),
                                    IgstAmount = Convert.ToDecimal(g.IgstAmount)
                                }
                            }
                        }
                    }).ToArray()
                };
            }
            var gstItem = new GSTJson
            {
                MerchantGst = Convert.ToString(cbAddress.SelectedValue),
                CurrentFilingMonth = txtFilingMonth.Text,
                GrossTurnOver4CurrentFilingMonth = Convert.ToInt32(txtCurrentTurnover.Text),
                GrossTurnOver4PreviousFinanicalYear = Convert.ToInt32(txtPrevTurnOver.Text),
                GstVersion = "GST1.00",
                Hash = "hash",
                B2B = b2b
            };
            var jsonString = JsonConvert.SerializeObject(gstItem);


            string path = cbAddress.Text.Replace("/", "") + "_";
            path += "GST_";
            string date = GetDateString(dpFrom.Value) + "_TO_" + GetDateString(dpTo.Value);
            path = path + date + ".json";
            global::BillingApplication.Properties.Settings settings = global::BillingApplication.Properties.Settings.Default;
            if (!Directory.Exists(settings.PLDefaultFileLocation))
                Directory.CreateDirectory(settings.PLDefaultFileLocation);
            path = settings.PLDefaultFileLocation + "\\" + path;

            File.WriteAllText(path,jsonString);

            MessageBox.Show("Exported to " + path + " successfully");
        }

        private string GetDateString(DateTime date)
        {
            return Convert.ToString(date.Day) + "_" + Convert.ToString(date.Month) + "_" + Convert.ToString(date.Year);
        }
    }
}

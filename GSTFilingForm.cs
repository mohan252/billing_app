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
using Infragistics.Win.UltraWinGrid;

namespace BillingApplication
{

    public partial class GSTFilingForm : Form
    {
        DAL dal = new DAL();
        IEnumerable<GstItem> gstItems;
        CheckBoxOnHeader_CreationFilter aCheckBoxOnHeader_CreationFilter = new CheckBoxOnHeader_CreationFilter();
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

            this.ugGst.CreationFilter = aCheckBoxOnHeader_CreationFilter;
            this.ugGst.DisplayLayout.Override.DefaultRowHeight = 25;

        }
        public void BindAddressList()
        {
            var addresses = dal.GetAddresses();
            this.cbAddress.DataSource = addresses;
            this.cbAddress.DisplayMember = "NAME";
            this.cbAddress.ValueMember = "GST";
        }

        private int ParseInt(string val)
        {
            int result = 0;
            int.TryParse(val, out result);
            return result;
        }

        private decimal ParseDecimal(string val)
        {
            decimal result = 0;
            decimal.TryParse(val, out result);
            return result;
        }
        private void btnJson_Click(object sender, EventArgs e)
        {
            if (txtCurrentTurnover.Text.Trim() == "" || txtFilingMonth.Text.Trim() == "")
            {
                MessageBox.Show("Current Turnover and Previous Year Turnover cannot be empty");
                return;
            }
            if (gstItems == null)
            {
                MessageBox.Show("First get data and verify. Then Generate Json");
                return;
            }
            if(gstItems.Any(g => string.IsNullOrEmpty(g.PartyGst)))
            {
                MessageBox.Show("Json will be generated only for the bills having non empty party gst");
            }
            var gstItemGroups = gstItems.Where(g => g.IsSelected && !string.IsNullOrEmpty(g.PartyGst)).GroupBy(c => c.PartyGst).ToArray();
            if(gstItemGroups.Count() == 0)
            {
                MessageBox.Show("Cannot generate json. All the selected bills are not having party gst");
                return;
            }
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
                        //TotalAfterTax_InvoiceValue = g.TotalAfterTax,
                        TotalAfterTax_InvoiceValue = g.TotalBeforeTax,
                        PartyStateCode_PlaceOfSupply = gstItemGroups[i].Key.Substring(0, 2),
                        InvoiceItems = new FilingInvoiceItem[1] {
                            new FilingInvoiceItem{
                                InvoiceDetail = new FilingInvoiceItemDetail{
                                    TotalBeforeTax_TaxableValue = g.TotalBeforeTax,
                                    IgstRate = g.IgstRate == null || g.IgstAmount.Value == 0 ? g.CgstRate.Value + g.SgstRate.Value : g.IgstRate.Value,
                                    IgstAmount = g.IgstAmount == null || g.IgstAmount.Value == 0 ? null : g.IgstAmount, 
                                    SgstAmount = g.SgstAmount == null || g.SgstAmount.Value == 0 ? null : g.SgstAmount,
                                    CgstAmount = g.CgstAmount == null || g.CgstAmount.Value == 0 ? null : g.CgstAmount
                                }
                            }
                        }
                    }).ToArray()
                };
            }

            var gstItemsByMeters = gstItems.Where(g => g.IsSelected && !string.IsNullOrEmpty(g.PartyGst) && g.TotalMeters != 0).ToList();
            var filingHsnDataList = new List<FilingHsnData>();
            if (gstItemsByMeters.Count > 0)
            {
                filingHsnDataList.Add(new FilingHsnData
                {
                    SerialNumber = 1,
                    HsnCode = "5208",
                    Description = "COTTON CLOTH",
                    UQCUnits = "MTR",
                    TotalQuantity = gstItemsByMeters.Sum(g => g.TotalMeters),
                    TotalValue = gstItemsByMeters.Sum(g => g.TotalAfterTax),
                    TaxableValue = gstItemsByMeters.Sum(g => g.TotalBeforeTax),
                    IgstTaxAmount = gstItemsByMeters.Where(g => g.IgstAmount != null).Sum(g => g.IgstAmount.Value),
                    SgstTaxAmount = gstItemsByMeters.Where(g => g.SgstAmount != null).Sum(g => g.SgstAmount.Value),
                    CgstTaxAmount = gstItemsByMeters.Where(g => g.CgstAmount != null).Sum(g => g.CgstAmount.Value),
                });
            }
            var gstItemsByQty = gstItems.Where(g => g.TotalMeters == 0).ToList();
            if (gstItemsByQty.Count > 0)
            {
                filingHsnDataList.Add(new FilingHsnData
                {
                    SerialNumber = 1,
                    HsnCode = "5208",
                    Description = "COTTON CLOTH",
                    UQCUnits = "MTR",
                    TotalQuantity = gstItemsByQty.Sum(g => g.TotalBillQty),
                    TotalValue = gstItemsByQty.Sum(g => g.TotalAfterTax),
                    TaxableValue = gstItemsByQty.Sum(g => g.TotalBeforeTax),
                    IgstTaxAmount = gstItemsByMeters.Where(g => g.IgstAmount != null).Sum(g => g.IgstAmount.Value),
                    SgstTaxAmount = gstItemsByMeters.Where(g => g.SgstAmount != null).Sum(g => g.SgstAmount.Value),
                    CgstTaxAmount = gstItemsByMeters.Where(g => g.CgstAmount != null).Sum(g => g.CgstAmount.Value)
                });
            }

            FilingHsn Hsn = new FilingHsn
            {
                Data = filingHsnDataList.ToArray()
            };
            var gstItem = new GSTJson
            {
                MerchantGst = Convert.ToString(cbAddress.SelectedValue),
                CurrentFilingMonth = txtFilingMonth.Text,
                GrossTurnOver4CurrentFilingMonth = ParseDecimal(txtCurrentTurnover.Text),
                GrossTurnOver4PreviousFinanicalYear = ParseDecimal(txtPrevTurnOver.Text),
                GstVersion = "GST1.00",
                Hash = "hash",
                B2B = b2b,
                Hsn = Hsn
            };
            var jsonString = JsonConvert.SerializeObject(gstItem,
                                                        Formatting.Indented, 
                                                        new JsonSerializerSettings
                                                        {
                                                            NullValueHandling = NullValueHandling.Ignore
                                                        });


            string path = cbAddress.Text.Replace("/", "") + "_";
            path += "GST_";
            string date = GetDateString(dpFrom.Value) + "_TO_" + GetDateString(dpTo.Value);
            path = path + date + ".json";
            global::BillingApplication.Properties.Settings settings = global::BillingApplication.Properties.Settings.Default;
            if (!Directory.Exists(settings.PLDefaultFileLocation))
                Directory.CreateDirectory(settings.PLDefaultFileLocation);
            path = settings.PLDefaultFileLocation + "\\" + path;

            File.WriteAllText(path, jsonString);

            MessageBox.Show("Exported to " + path + " successfully");
        }

        private string GetDateString(DateTime date)
        {
            return Convert.ToString(date.Day) + "_" + Convert.ToString(date.Month) + "_" + Convert.ToString(date.Year);
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            gstItems = dal.GetGstDetailsByParty(dpFrom.Value, dpTo.Value, cbAddress.Text).ToList();
            txtCurrentTurnover.Text = gstItems.Select(g => Convert.ToDecimal(g.TotalAfterTax)).Sum() + "";
            ugGst.DataSource = gstItems;

            var checkColumn = ugGst.DisplayLayout.Bands[0].Columns["ISSELECTED"];
            checkColumn.CellActivation = Activation.AllowEdit;
            checkColumn.Header.VisiblePosition = 0;
            ugGst.DisplayLayout.Bands[0].Columns["PARTYGST"].Header.VisiblePosition = 2;
            ugGst.DisplayLayout.Bands[0].Columns["PARTYNAME"].Width = 200;
            ugGst.DisplayLayout.Bands[0].Columns["PARTYGST"].Width = 150;

            ugGst.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.SingleSummaryBasedOnDataType;
        }
    }
}

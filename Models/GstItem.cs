using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingApplication.Models
{
    public class GstItem
    {
        public bool IsSelected { get; set; }
        public string PartyGst { get; set; }
        public string PartyName { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public decimal TotalBeforeTax { get; set; }
        public decimal? IgstRate { get; set; }
        public decimal? IgstAmount { get; set; }
        public decimal? SgstRate { get; set; }
        public decimal? SgstAmount { get; set; }
        public decimal? CgstRate { get; set; }
        public decimal? CgstAmount { get; set; }
        public decimal TotalAfterTax { get; set; }
        public decimal TotalMeters { get; set; }
        public decimal TotalBillQty { get; set; }

    }
}

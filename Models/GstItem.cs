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
        public string TotalBeforeTax { get; set; }
        public string IgstRate { get; set; }
        public string IgstAmount { get; set; }
        public string TotalAfterTax { get; set; }
    }
}

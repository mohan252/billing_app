using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BillingApplication.Models
{
    public class GSTJson
    {
        [JsonProperty(PropertyName = "gstin", Order = 1)]
        public string MerchantGst { get; set; }
        //082017
        [JsonProperty(PropertyName = "fp", Order = 2)]
        public string CurrentFilingMonth { get; set; }
        [JsonProperty(PropertyName = "cur_gt", Order = 4)]
        public int GrossTurnOver4CurrentFilingMonth { get; set; }
        [JsonProperty(PropertyName = "gt", Order = 3)]
        public int GrossTurnOver4PreviousFinanicalYear { get; set; }
        [JsonProperty(PropertyName = "version", Order = 5)]
        public string GstVersion { get; set; }
        [JsonProperty(PropertyName = "hash", Order = 6)]
        public string Hash { get; set; }
        //Each Party will have one item
        [JsonProperty(PropertyName = "b2b", Order = 7)]
        public FilingParty[] B2B { get; set; }
    }

    public class FilingParty
    {
        [JsonProperty(PropertyName = "ctin", Order = 1)]
        public string PartyGst { get; set; }
        [JsonProperty(PropertyName = "inv", Order = 2)]
        public FilingInvoice[] Invoices { get; set; }
    }

    public class FilingInvoice
    {
        [JsonProperty(PropertyName = "inum", Order = 1)]
        public string InvoiceNumber { get; set; }
        [JsonProperty(PropertyName = "idt", Order = 2)]
        public string InvoiceDate { get; set; }
        [JsonProperty(PropertyName = "val", Order = 3)]
        public int TotalAfterTax { get; set; }
        [JsonProperty(PropertyName = "pos", Order = 4)]
        public string PartyStateCode { get; set; }
        [JsonProperty(PropertyName = "rchrg", Order = 5)]
        public string ReverseCharge = "N";
        [JsonProperty(PropertyName = "inv_typ", Order = 6)]
        public string InvoiceType = "R";
        [JsonProperty(PropertyName = "itms", Order = 7)]
        public FilingInvoiceItem[] InvoiceItems { get; set; }
    }

    public class FilingInvoiceItem
    {
        [JsonProperty(PropertyName = "num", Order = 1)]
        public int Number = 1;
        [JsonProperty(PropertyName = "itm_det", Order = 2)]
        public FilingInvoiceItemDetail InvoiceDetail {get;set;}
    }

    public class FilingInvoiceItemDetail{
        [JsonProperty(PropertyName = "txval", Order = 1)]
        public int TotalBeforeTax { get; set; }
        [JsonProperty(PropertyName = "rt", Order = 2)]
        public decimal IgstRate { get; set; }
        [JsonProperty(PropertyName = "iamt", Order = 3)]
        public decimal IgstAmount { get; set; }
    }
}

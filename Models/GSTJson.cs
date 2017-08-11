using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BillingApplication.Models
{
    public class GSTJson
    {
        [JsonProperty(PropertyName = "gstin")]
        public string MerchantGst { get; set; }
        //082017
        [JsonProperty(PropertyName = "fp")]
        public string CurrentFilingMonth { get; set; }
        [JsonProperty(PropertyName = "cur_gt")]
        public string GrossTurnOver4CurrentFilingMonth { get; set; }
        [JsonProperty(PropertyName = "gt")]
        public string GrossTurnOver4PreviousFinanicalYear { get; set; }
        [JsonProperty(PropertyName = "FooBar")]
        public string SupplierGst { get; set; }
        [JsonProperty(PropertyName = "version")]
        public string GstVersion { get; set; }
        [JsonProperty(PropertyName = "hash")]
        public string Hash { get; set; }
        //Each Party will have one item
        [JsonProperty(PropertyName = "b2b")]
        public FilingParty[] B2B { get; set; }
    }

    public class FilingParty
    {
        [JsonProperty(PropertyName = "ctin")]
        public string PartyGst { get; set; }
        [JsonProperty(PropertyName = "inv")]
        public FilingInvoice[] Invoices { get; set; }
    }

    public class FilingInvoice
    {
        [JsonProperty(PropertyName = "inum")]
        public string InvoiceNumber { get; set; }
        [JsonProperty(PropertyName = "idt")]
        public string InvoiceDate { get; set; }
        [JsonProperty(PropertyName = "val")]
        public string TotalAfterTax { get; set; }
        [JsonProperty(PropertyName = "pos")]
        public string PartyGst { get; set; }
        [JsonProperty(PropertyName = "rchrg")]
        public string ReverseCharge { get; set; }
        [JsonProperty(PropertyName = "inv_typ")]
        public string InvoiceType { get; set; }
        [JsonProperty(PropertyName = "itms")]
        public FilingInvoiceItem[] InvoiceItems { get; set; }
    }

    public class FilingInvoiceItem
    {
        [JsonProperty(PropertyName = "num")]
        public string Number { get; set; }
        [JsonProperty(PropertyName = "itm_det")]
        public FilingInvoiceItemDetail InvoiceDetail {get;set;}
    }

    public class FilingInvoiceItemDetail{
        [JsonProperty(PropertyName = "txval")]
        public string TotalBeforeTax { get; set; }
        [JsonProperty(PropertyName = "rt")]
        public string IgstRate { get; set; }
        [JsonProperty(PropertyName = "iamt")]
        public string IgstAmount { get; set; }
    }
}

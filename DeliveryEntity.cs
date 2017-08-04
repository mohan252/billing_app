using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingApplication
{
    public static class Delimiters
    {
        public static string DeliveryGrid = " :: ";
    }
    public class Party
    {
        public string Name { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string State  { get; set; }
        public string Pin { get; set; }
        public string Gst { get; set; }
        public override string ToString()
        {
            return Name + Delimiters.DeliveryGrid + City + Delimiters.DeliveryGrid + Gst;
        }
    }
    public class Invoice
    {
        public string Number { get; set; }
        public string Date { get; set; }
        public override string ToString()
        {
            return Number + Delimiters.DeliveryGrid + Date;
        }
    }
    public class Particulars
    {
        public string Description { get; set; }
        public string TotalPairsMtrsKey { get; set; }
        public string TotalPairsMtrsValue { get; set; }
        public string HSN { get; set; }
        public string TotalAmount { get; set; }
        public string IgstPercent { get; set; }
        public string IgstAmount { get; set; }
        public string TotalBillValue { get; set; }
        public override string ToString()
        {
            return Description + Delimiters.DeliveryGrid + HSN + Delimiters.DeliveryGrid + TotalBillValue;
        }
    }
    public class DeliveryEntity
    {
        public string MerchantName { get; set; }
        public string Gst { get; set; }
        public Party Party { get; set; }
        public Invoice Invoice { get; set; }
        public string BaleNo { get; set; }
        public string Transport { get; set; }
        public string BookedTo { get; set; }
        public Particulars Particulars { get; set; }
    }
}

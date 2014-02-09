using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace BillingApplication
{
    public partial class BillForm
    {
        float lineHeight = 0;
        float charWidth = 10;
        int totalDigits = 0;

        decimal printBalance = 0;
        int lineY = 0;
        float itemX = 0;
        float itemY = 0;
        Font itemFont;
        Font printFont;
        private float X(string setting)
        {
            string p = (string)global::BillingApplication.Properties.Settings.Default[setting];
            string[] ps = p.Split(',');
            return charWidth * float.Parse((ps[0]));
        }
        private float Y(string setting)
        {
            string p = (string)global::BillingApplication.Properties.Settings.Default[setting];
            string[] ps = p.Split(',');
            return lineHeight * float.Parse((ps[1]));
        }
        private void PrintTestPage(Graphics gdiPage, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float i = lineHeight;
            int j = 0;
            float k = charWidth;
            int l = 2;
            while (i < e.MarginBounds.Height)
            {
                i = lineHeight * j;
                gdiPage.DrawString(Convert.ToString(j++), printFont, Brushes.Black, 0, i);
                while (k < e.MarginBounds.Width)
                {
                    k = charWidth * l;
                    gdiPage.DrawString(Convert.ToString("8"), printFont, Brushes.Black, k, i);
                    l++;
                }
                k = charWidth;
                l = 2;
            }
        }
        private void PrintBillDiscounts(ref Graphics gdiPage)
        {
            decimal total = Convert.ToDecimal(btmGrid[2, 0].Value);
            //pinning less, less rate/mtr, less rate/pair, discount 1, discount 2
            // cd shouldn't get printed in the bill
            for (int rowIndex = 1; rowIndex < 6; rowIndex++)
            {
                if (btmGrid[1, rowIndex] != null && btmGrid[1, rowIndex].Value != null && !btmGrid[1, rowIndex].Value.ToString().Equals(string.Empty))
                {
                    string text = btmGrid[0, rowIndex].Value.ToString() + " : " + btmGrid[1, rowIndex].Value.ToString();
                    if (rowIndex == 2 || rowIndex == 3)
                        text += " Rs";
                    else
                        text += " %";
                    gdiPage.DrawString(text, printFont, Brushes.Black,
                               itemX, itemY + (lineY * lineHeight));
                    gdiPage.DrawString(AddSpace(btmGrid[2, rowIndex].Value.ToString()), itemFont, Brushes.Black,
                               X("Amount"), itemY + (lineY++ * lineHeight));
                    gdiPage.DrawString("-----------", printFont, Brushes.Black,
                       X("Amount"), itemY + (lineY++ * lineHeight));
                    if (rowIndex == 1)//Pinning less
                    {
                        total -= LessDiscount(1);//pinning less
                        total = System.Math.Round(total, 2);
                        string strTota1 = PadDigits(total);
                        gdiPage.DrawString(strTota1, itemFont, Brushes.Black,
                       X("Amount"), itemY + (lineY++ * lineHeight));
                       // gdiPage.DrawString("-----------", printFont, Brushes.Black,
                       //X("Amount"), itemY + (lineY++ * lineHeight));
                    }
                    if (rowIndex == 2)//LessRatePerMeter
                    {
                        total -= LessRatePerMeter();
                        total = System.Math.Round(total, 2);
                        string strTota1 = PadDigits(total);
                        gdiPage.DrawString(strTota1, itemFont, Brushes.Black,
                            X("Amount"), itemY + (lineY++ * lineHeight));
                        //gdiPage.DrawString("-----------", printFont, Brushes.Black,
                        //    X("Amount"), itemY + (lineY++ * lineHeight));
                    }
                    if (rowIndex == 3)//LessRatePerPair
                    {
                        total -= LessRatePerPair();
                        total = System.Math.Round(total, 2);
                        string strTota1 = PadDigits(total);
                        gdiPage.DrawString(strTota1, itemFont, Brushes.Black,
                            X("Amount"), itemY + (lineY++ * lineHeight));
                        //gdiPage.DrawString("-----------", printFont, Brushes.Black,
                        //    X("Amount"), itemY + (lineY++ * lineHeight));
                    }
                    if (rowIndex == 4 || rowIndex == 5)//discount 1 & 2
                    {
                        total -= LessDiscount(rowIndex);
                        total = System.Math.Round(total, 2);
                        string strTota1 = PadDigits(total);
                        gdiPage.DrawString(strTota1, itemFont, Brushes.Black,
                            X("Amount"), itemY + (lineY++ * lineHeight));
                        //gdiPage.DrawString("-----------", printFont, Brushes.Black,
                        //    X("Amount"), itemY + (lineY++ * lineHeight));
                    }
                }
            }
            printBalance = System.Math.Round(total, 0);
            decimal RoundOff = printBalance - total;
            //print roundoff
            gdiPage.DrawString("   " + AddSpace(Convert.ToString(RoundOff)), itemFont, Brushes.Black,
                               X("Amount"), itemY + (lineY++ * lineHeight));
            gdiPage.DrawString("-----------", printFont, Brushes.Black,
                       X("Amount"), itemY + (lineY++ * lineHeight));
            //Print final total
            gdiPage.DrawString(PadDigits(printBalance), itemFont, Brushes.Black,
                               X("Amount"), itemY + (lineY++ * lineHeight));
            gdiPage.DrawString("-----------", printFont, Brushes.Black,
                       X("Amount"), itemY + (lineY++ * lineHeight));

        }
        private void pDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics gdiPage = e.Graphics;
            lineHeight = printFont.GetHeight(gdiPage);
            string address = cbCoy.Text;
            //Tin no
            string tinNo = ((BillingApplication.CompanyDS.ADDRESSRow)
                           coDs.ADDRESS.Select("NAME = '" + address + "'")[0]).TIN;
            //gdiPage.DrawString(tinNo, printFont, Brushes.Black, X("TinNo"), Y("TinNo"));
            gdiPage.DrawString(tinNo, printFont, Brushes.Black, X("TinNo"), Y("TinNo"));
            //Company Name
            Font companyFont = new Font("Book Antiqua", 20);
            float center = e.MarginBounds.Width / 2 - (charWidth * address.Length);
            gdiPage.DrawString(address, companyFont, Brushes.Black, center, Y("Address"));
            //Invoice Details
            gdiPage.DrawString(txtInvno.Text, printFont, Brushes.Black, X("Invoice"), Y("Invoice"));
            gdiPage.DrawString(txtBaleno.Text, printFont, Brushes.Black, X("BaleNo"), Y("BaleNo"));
            gdiPage.DrawString(dtpBillDt.Value.ToShortDateString(), printFont, Brushes.Black,
                        X("BillDate"), Y("BillDate"));
            //To Details
            float partyX = X("PartyName");
            float partyY = Y("PartyName");
            gdiPage.DrawString(txtPartyName.Text, printFont, Brushes.Black,
                        partyX, partyY);
            BillingApplication.CompanyDS.PARTIESDataTable pDt = this.partiesTA.GetData(Convert.ToInt32(txtPartyName.Tag));
            int partyAddrLineNo = 1;
            if (pDt != null && pDt.Rows.Count > 0)
            {
                BillingApplication.CompanyDS.PARTIESRow pr = (BillingApplication.CompanyDS.PARTIESRow)pDt.Rows[0];
                try
                {
                    if (pr.ADDR1 != "")
                    {
                        gdiPage.DrawString(pr.ADDR1, printFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo++ * lineHeight));
                    }
                }
                catch { }
                try
                {
                    if (pr.ADDR2 != "")
                    {
                        gdiPage.DrawString(pr.ADDR2, printFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo++ * lineHeight));
                    }
                }
                catch { }
                try
                {
                    if (pr.ADDR3 != "")
                    {
                        gdiPage.DrawString(pr.ADDR3, printFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo++ * lineHeight));
                    }
                }
                catch { }
                try
                {
                    if (pr.ADDR4 != "")
                    {
                        gdiPage.DrawString(pr.ADDR4, printFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo++ * lineHeight));
                    }
                }
                catch { }
                try
                {
                    if (pr.CITY != "")
                    {
                        gdiPage.DrawString(pr.CITY, printFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo * lineHeight));
                        try
                        {
                            gdiPage.DrawString(" - " + pr.PIN, printFont, Brushes.Black,
                                partyX + (charWidth * pr.CITY.Length), partyY + (partyAddrLineNo++ * lineHeight));
                        }
                        catch { partyAddrLineNo++; }
                    }
                }
                catch { }
                try
                {
                    if (pr.STATE != "")
                    {
                        gdiPage.DrawString(pr.STATE, printFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo * lineHeight));
                    }
                }
                catch { }
            }
            //OrderNo
            gdiPage.DrawString(txtOrderNo.Text, printFont, Brushes.Black,
                        X("OrderNo"), Y("OrderNo"));
            //OrderDt
            gdiPage.DrawString(dtpOrderDate.Value.ToShortDateString(), printFont, Brushes.Black,
                        X("OrderDate"), Y("OrderDate"));
            //OrderFwd
            gdiPage.DrawString(txtFwdBy.Text, printFont, Brushes.Black,
                        X("FwdBy"), Y("FwdBy"));
            //OrderFwdTo
            gdiPage.DrawString(txtOrderTo.Text, printFont, Brushes.Black,
                        X("FwdTo"), Y("FwdTo"));
            //OrderLR
            gdiPage.DrawString(txtLR.Text, printFont, Brushes.Black,
                        X("LRno"), Y("LRno"));
            //OrderLRDt
            gdiPage.DrawString(dtpLRDate.Value.ToShortDateString(), printFont, Brushes.Black,
                        X("LRDate"), Y("LRDate"));
            //OrderAgent
            gdiPage.DrawString(cbAgtName.Text, printFont, Brushes.Black,
                        X("Agent"), Y("Agent"));
            //OrderCourier
            gdiPage.DrawString(cbCourier.Text, printFont, Brushes.Black,
                        X("DocTo"), Y("DocTo"));
            //Pinning
            if (!ckItemPin.Checked)
                gdiPage.DrawString("Pinning " + txtPin.Text + " Cm", printFont, Brushes.Black,
                        X("Pin"), Y("Pin"));
            //Item grid
            //Initialise
            itemX = X("Item");
            itemY = Y("Item");
            lineY = 0;
            int r = 0;
            int rowCount = grdItem.Rows.Count;
            for (r = 0; r < rowCount; r++)
            {
                if (grdItem["item", r] != null && !grdItem["item", r].Value.ToString().Equals(string.Empty))
                {
                    //Item Name
                    gdiPage.DrawString(grdItem["item", r].Value.ToString(), printFont, Brushes.Black,
                                itemX, itemY + (lineY * lineHeight));
                    //Rate
                    gdiPage.DrawString(PadDigits(Convert.ToDecimal(grdItem["Rate", r].Value)), itemFont, Brushes.Black,
                                X("Rate"), itemY + (lineY * lineHeight));
                    //Meters
                    if (grdItem["Meters", r] != null && grdItem["Meters", r].Value != null && !grdItem["Meters", r].Value.ToString().Equals(string.Empty))
                        gdiPage.DrawString(PadDigits(Convert.ToDecimal(grdItem["Meters", r].Value)), itemFont, Brushes.Black,
                                X("Meters"), itemY + (lineY * lineHeight));
                    //Quantity
                    if (grdItem["Quantity", r] != null && grdItem["Quantity", r].Value != null && !grdItem["Quantity", r].Value.ToString().Equals(string.Empty))
                        gdiPage.DrawString(grdItem["Quantity", r].Value.ToString(), itemFont, Brushes.Black,
                                X("Qty"), itemY + (lineY * lineHeight));
                    //Amount
                    if (grdItem["Total", r] != null && !grdItem["Total", r].Value.ToString().Equals(string.Empty))
                    {
                        //Increment line as nothing to be printed in the current line
                        // after amount
                        gdiPage.DrawString(grdItem["Total", r].Value.ToString(), itemFont, Brushes.Black,
                                X("Amount"), itemY + (lineY++ * lineHeight));
                    }
                    //Stamp 
                    if (grdItem["Stamping", r] != null && grdItem["Stamping", r].Value != null)
                        gdiPage.DrawString("Stamp : " + grdItem["Stamping", r].Value.ToString(), printFont, Brushes.Black,
                            //Increment line as nothing to be printed in the current line after stamp
                                itemX, itemY + (lineY++ * lineHeight));
                }
                else
                    break;
            }
            //Fwd charges
            if (btmGrid[2, 7] != null && btmGrid[2, 7].Value != null && !btmGrid[2, 7].Value.ToString().Equals(string.Empty))
            {
                gdiPage.DrawString("Forwarding Charges", printFont, Brushes.Black,
                               itemX, itemY + (lineY * lineHeight));
                gdiPage.DrawString(btmGrid[2, 7].Value.ToString(), itemFont, Brushes.Black,
                               X("Amount"), itemY + (lineY++ * lineHeight));
            }
            gdiPage.DrawString("----------------------------", printFont, Brushes.Black,
                       X("Qty"), itemY + (lineY++ * lineHeight));
            //Total qty
            gdiPage.DrawString(txtNetqty.Text, itemFont, Brushes.Black,
                       X("Qty"), itemY + (lineY * lineHeight));
            //Total
            gdiPage.DrawString("Total", printFont, Brushes.Black,
                       itemX, itemY + (lineY * lineHeight));
            totalDigits = btmGrid[2, 0].Value.ToString().Length;
            gdiPage.DrawString(btmGrid[2, 0].Value.ToString(), itemFont, Brushes.Black,
                       X("Amount"), itemY + (lineY++ * lineHeight));
            PrintBillDiscounts(ref gdiPage);
            //Less cd
            if (txtCd.Text != "" && txtCddays.Text != "")
                gdiPage.DrawString("LESS " + txtCd.Text + "% CASH DISCOUNT WITHIN " + txtCddays.Text + " DAYS FROM BILL DATE", printFont, Brushes.Black,
                        X("Cd"), Y("Cd"));
            //Custom Text
            string customTxt = ((BillingApplication.CompanyDS.ADDRESSRow)
                           coDs.ADDRESS.Select("NAME = '" + address + "'")[0]).CUSTOM_1;
            string[] customText = customTxt.Split(':');
            gdiPage.DrawString(customText[0], itemFont, Brushes.Black,
                        X("Custom"), Y("Custom"));
            gdiPage.DrawString(customText[1], itemFont, Brushes.Black,
                        X("BOB"), Y("BOB"));
            printFont = new Font("Book Antiqua", 10);
            //Rupees
            string balance = Convert.ToString(printBalance);
            balance = num.changeNumericToWords(balance) + "Only";
            //Rupess in words
            gdiPage.DrawString(balance, printFont, Brushes.Black,
                        X("Rupees"), Y("Rupees"));

            //for
            gdiPage.DrawString("For " + address, printFont, Brushes.Black,
                        X("For"), Y("For"));
            //gdiPage.DrawString(tinNo, printFont, Brushes.Black, X("TinNo"), e.PageSettings.Bounds.Height - (lineHeight * 3));
        }
        private string AddSpace(string val)
        {
            while (val.Length < totalDigits + 1)
            {
                val = " " + val;
            }
            return val;
        }
        private void pDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            itemFont = new Font("Book Antiqua", 12);
            printFont = new Font("Book Antiqua", 10);
        }
        private void pDoc_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            printFont.Dispose();
            itemFont.Dispose();
        }
        private void pDoc_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {
            e.PageSettings.Margins.Left = 0;
            e.PageSettings.Margins.Right = 0;
            e.PageSettings.Margins.Top = 0;
            e.PageSettings.Margins.Bottom = 0;
            int i = 0;
            while (i < e.PageSettings.PrinterSettings.PaperSizes.Count)
                if (e.PageSettings.PrinterSettings.PaperSizes[i].PaperName == "A4")
                    break;
                else
                    i++;
            System.Drawing.Printing.PaperSize pSize = new System.Drawing.Printing.PaperSize();
            pSize.Width = e.PageSettings.PrinterSettings.PaperSizes[i].Width;
            pSize.Height = 1215;
            e.PageSettings.PaperSize = pSize;
        }
    }
}

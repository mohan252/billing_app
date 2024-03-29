using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Infragistics.Win.UltraWinGrid;
using System.Linq;
using BillingApplication.Models;

namespace BillingApplication
{
    public partial class BillForm
    {
        float lineHeight = 0;
        float itemLineHeight = 0;
        float charWidth = 10;
        float totalWidth = 0;
        int dashLineAdjt = 10;
        decimal totalAmountAfterTax = 0;
        int lineY = 0;
        float itemX = 0;
        float itemY = 0;
        Font itemFont;
        Font printFont;
        Font gstFont;
        Font printInvRightFont;
        Font coverFont;
        string invoicePrefix = "G-";
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
            //return lineHeight * float.Parse((ps[1]));
            return float.Parse((ps[1]));
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
        private int GetMaxValueWidth(int gridColIndex, Font ft)
        {
            string result = "";
            foreach (UltraGridRow row in grdItem.Rows)
            {
                if (Convert.ToString(row.Cells[gridColIndex].Value).Length > result.Length)
                    result = Convert.ToString(row.Cells[gridColIndex].Value);
            }
            return Common.GetWidth(result, ft, this.CreateGraphics());
        }
        private string GetCurrencyFormat(decimal amt)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("hi-IN");
            string amt1 = String.Format(culture, "{0:c}", amt);
            amt1 = amt1.Substring(2);
            //if(amt1.StartsWith("-"))
            //{
            //    amt1 = amt1.Substring(2, amt1.Length - 2);
            //    amt1 = "-" + amt1;
            //}
            //else
            //    amt1 = amt1.Substring(1, amt1.Length - 1);
            amt1 = Common.PadDigits(amt1);
            return amt1;
        }
        private void PrintBillItems(Graphics gdiPage)
        {
            float xRate = GetMaxValueWidth(5, itemFont) + X("Rate");
            float xMts = GetMaxValueWidth(3, itemFont) + X("Meters");
            System.Collections.Specialized.StringCollection amtColl = new System.Collections.Specialized.StringCollection();
            //Pinning
            if (!ckItemPin.Checked && txtPin.Text.Trim() != "")
                gdiPage.DrawString("Pinning " + txtPin.Text + " Cm", itemFont, Brushes.Black,
                        X("Pin"), Y("Pin"));
            //Item grid
            //Initialise
            itemX = X("Item");
            itemY = Y("Item");
            lineY = 0;
            int r = 0;
            decimal tAmt = 0;
            int rowCount = grdItem.Rows.Count;
            //Get the width of the total to calculate right aligned position
            totalWidth = X("Amount") + Common.GetWidth(btmGrid[2, Grid.Balance].Value.ToString(), itemFont, gdiPage);

            for (r = 0; r < rowCount; r++)
            {
                if (grdItem.Rows[r].Cells["ITEMNAME"] != null && !grdItem.Rows[r].Cells["ITEMNAME"].Value.ToString().Equals(string.Empty))
                {
                    //Item Name
                    gdiPage.DrawString(grdItem.Rows[r].Cells["ITEMNAME"].Value.ToString(), itemFont, Brushes.Black,
                                itemX, itemY + (lineY * itemLineHeight));
                    //Rate
                    gdiPage.DrawString(PadDigits(Convert.ToDecimal(grdItem.Rows[r].Cells["RATE"].Value)), itemFont, Brushes.Black,
                                xRate - Common.GetWidth(PadDigits(Convert.ToDecimal(grdItem.Rows[r].Cells["RATE"].Value)), itemFont,gdiPage),
                                itemY + (lineY * itemLineHeight));
                    //Meters
                    if (grdItem.Rows[r].Cells["METRS"] != null && grdItem.Rows[r].Cells["METRS"].Value != null && !grdItem.Rows[r].Cells["METRS"].Value.ToString().Equals(string.Empty))
                        gdiPage.DrawString(PadDigits(Convert.ToDecimal(grdItem.Rows[r].Cells["METRS"].Value)), itemFont, Brushes.Black,
                                xMts - Common.GetWidth(PadDigits(Convert.ToDecimal(grdItem.Rows[r].Cells["METRS"].Value)), itemFont,gdiPage),
                                itemY + (lineY * itemLineHeight));
                    //Quantity
                    if (grdItem.Rows[r].Cells["QTY"] != null && grdItem.Rows[r].Cells["QTY"].Value != null && !grdItem.Rows[r].Cells["QTY"].Value.ToString().Equals(string.Empty))
                        gdiPage.DrawString(grdItem.Rows[r].Cells["QTY"].Value.ToString(), itemFont, Brushes.Black,
                                X("Qty"), itemY + (lineY * itemLineHeight));
                    //Amount
                    if (grdItem.Rows[r].Cells["AMT"] != null && !grdItem.Rows[r].Cells["AMT"].Value.ToString().Equals(string.Empty))
                    {
                        //Increment line as nothing to be printed in the current line
                        // after amount
                        if (!ckItemPin.Checked)
                        {
                            string amt = GetCurrencyFormat(Convert.ToDecimal(grdItem.Rows[r].Cells["AMT"].Value.ToString()));
                            gdiPage.DrawString(amt, itemFont, Brushes.Black,
                                    totalWidth - Common.GetWidth(amt, itemFont,gdiPage),
                                        itemY + (lineY++ * itemLineHeight));
                        }
                        else
                        {
                            tAmt = GetRowTotal(r);
                            string amt = GetCurrencyFormat(tAmt);
                            gdiPage.DrawString(amt, itemFont, Brushes.Black,
                                totalWidth - Common.GetWidth(amt, itemFont,gdiPage),
                                    itemY + (lineY++ * itemLineHeight));
                            if (grdItem.Rows[r].Cells["PINNINGLESS"].Value == null || grdItem.Rows[r].Cells["PINNINGLESS"].Value.ToString().Trim() == "")
                                amtColl.Add(PadDigits(tAmt));
                        }
                    }
                    //Stamp 
                    if (grdItem.Rows[r].Cells["STAMP"] != null && grdItem.Rows[r].Cells["STAMP"].Value != null && !grdItem.Rows[r].Cells["STAMP"].Value.ToString().Equals(string.Empty))
                        gdiPage.DrawString("Stamping : " + grdItem.Rows[r].Cells["STAMP"].Value.ToString(), itemFont, Brushes.Black,
                            //Increment line as nothing to be printed in the current line after stamp
                                itemX, itemY + (lineY++ * itemLineHeight));
                    //Item HSC Code'. print only once at the end
                    if (r == rowCount - 1)
                    {
                        if (grdItem.Rows[r].Cells["HSN"] != null && grdItem.Rows[r].Cells["HSN"].Value != null && !grdItem.Rows[r].Cells["HSN"].Value.ToString().Equals(string.Empty))
                        {
                            var hsnCodeToBePrinted = "HSN/ASC Code : " + grdItem.Rows[r].Cells["HSN"].Value.ToString();
                            gdiPage.DrawString(hsnCodeToBePrinted, itemFont, Brushes.Black,
                                //Increment line as nothing to be printed in the current line after stamp
                                    itemX, itemY + (lineY++ * itemLineHeight));
                        }
                    }
                    //If itemwise pin, then print the pinning details in the next line
                    if (ckItemPin.Checked && grdItem.Rows[r].Cells["PINNINGLESS"] != null && grdItem.Rows[r].Cells["PINNINGLESS"].Value != null && !grdItem.Rows[r].Cells["PINNINGLESS"].Value.ToString().Equals(string.Empty))
                    {
                        String pin = grdItem.Rows[r].Cells["PIN"].Value.ToString().Equals(string.Empty) ? "" : grdItem.Rows[r].Cells["PIN"].Value.ToString();
                        String pinLess = grdItem.Rows[r].Cells["PINNINGLESS"].Value.ToString();
                        gdiPage.DrawString("Pin : " + pin + "Cm    Pinning Less" + pinLess + "%", itemFont, Brushes.Black,
                            itemX, itemY + (lineY * itemLineHeight));
                        decimal pl = Convert.ToDecimal(pinLess);
                        decimal totalPl = System.Math.Round(((pl / 100) * tAmt), 2, MidpointRounding.AwayFromZero);
                        string amt = GetCurrencyFormat(totalPl);
                        gdiPage.DrawString(amt, itemFont, Brushes.Black,
                                totalWidth - Common.GetWidth(amt, itemFont,gdiPage),
                                    itemY + (lineY++ * itemLineHeight));
                        gdiPage.DrawString("----------------", itemFont, Brushes.Black,
                            X("Amount") - dashLineAdjt, itemY + (lineY++ * itemLineHeight));
                        amt = GetCurrencyFormat(Convert.ToDecimal(grdItem.Rows[r].Cells["AMT"].Value));
                        gdiPage.DrawString(Common.PadDigits(amt), itemFont, Brushes.Black,
                                totalWidth - Common.GetWidth(amt, itemFont,gdiPage),
                                    itemY + (lineY++ * itemLineHeight));
                        gdiPage.DrawString("----------------", itemFont, Brushes.Black,
                            X("Amount") - dashLineAdjt, itemY + (lineY++ * itemLineHeight));
                        amt = GetCurrencyFormat(Convert.ToDecimal(grdItem.Rows[r].Cells["AMT"].Value));
                        amtColl.Add(amt);
                    }
                }
                else
                    break;
            }
            if (amtColl.Count > 1)
            {
                foreach (string amt in amtColl)
                    gdiPage.DrawString(amt, itemFont, Brushes.Black,
                               totalWidth - Common.GetWidth(amt, itemFont,gdiPage), itemY + (lineY++ * itemLineHeight));
            }
            //more than one item then only print item total
            if (rowCount > 1)
            {
                gdiPage.DrawString("----------------------------------", itemFont, Brushes.Black,
                       X("Qty"), itemY + (lineY++ * itemLineHeight));
                //Total qty
                gdiPage.DrawString(txtNetqty.Text, itemFont, Brushes.Black,
                           X("Qty"), itemY + (lineY * itemLineHeight));
                //Total
                gdiPage.DrawString("Total", itemFont, Brushes.Black,
                       itemX, itemY + (lineY * itemLineHeight));
                string amt1 = GetCurrencyFormat(Convert.ToDecimal(btmGrid[2, Grid.Balance].Value));
                gdiPage.DrawString(amt1, itemFont, Brushes.Black,
                           totalWidth - Common.GetWidth(amt1, itemFont,gdiPage),
                           itemY + (lineY++ * itemLineHeight));
            }
            PrintBillDiscounts(gdiPage);
        }
        
        private void PrintBillDiscounts(Graphics gdiPage)
        {

            decimal total = Convert.ToDecimal(btmGrid[2, Grid.Balance].Value);
            //pinning less, discount 1, cd
            for (int rowIndex = 1; rowIndex < 4; rowIndex++)
            {
                if (btmGrid[1, rowIndex] != null && btmGrid[1, rowIndex].Value != null && !btmGrid[1, rowIndex].Value.ToString().Equals(string.Empty))
                {
                    string discountName = btmGrid[0, rowIndex].Value.ToString();
                    string discountValue = btmGrid[1, rowIndex].Value.ToString();
                    var discountTextToBePrinted = "";
                    if (discountName.Contains("%"))
                    {
                        discountTextToBePrinted = discountName + " : " + discountValue;
                    }
                    else
                    {
                        discountTextToBePrinted = discountName + " : " + discountValue + " %";
                    }
                    gdiPage.DrawString(discountTextToBePrinted, itemFont, Brushes.Black,
                               itemX, itemY + (lineY * itemLineHeight));
                    string amt = GetCurrencyFormat(Convert.ToDecimal(btmGrid[2, rowIndex].Value));
                    gdiPage.DrawString(amt, itemFont, Brushes.Black,
                               totalWidth - Common.GetWidth(amt, itemFont,gdiPage),
                               itemY + (lineY++ * itemLineHeight));
                    gdiPage.DrawString("----------------", itemFont, Brushes.Black,
                       X("Amount") - dashLineAdjt, itemY + (lineY++ * itemLineHeight));
                    total -= LessDiscount(rowIndex);
                    total = System.Math.Round(total, 2, MidpointRounding.AwayFromZero);
                    string strTota1 = GetCurrencyFormat(total);
                    gdiPage.DrawString(strTota1, itemFont, Brushes.Black,
                        totalWidth - Common.GetWidth(strTota1, itemFont,gdiPage),
                        itemY + (lineY++ * itemLineHeight));
                }
            }
            //Fwd charges
            if (btmGrid[2, Grid.Fwd] != null && btmGrid[2, Grid.Fwd].Value != null && !btmGrid[2, Grid.Fwd].Value.ToString().Equals(string.Empty) && Convert.ToDecimal(btmGrid[2, Grid.Fwd].Value) != 0)
            {
                gdiPage.DrawString("Forwarding Charges", itemFont, Brushes.Black,
                               itemX, itemY + (lineY * itemLineHeight));
                string amt = GetCurrencyFormat(Convert.ToDecimal(btmGrid[2, Grid.Fwd].Value));
                gdiPage.DrawString(amt, itemFont, Brushes.Black,
                               totalWidth - Common.GetWidth(amt, itemFont,gdiPage),
                               itemY + (lineY++ * itemLineHeight));
                total += Convert.ToDecimal(btmGrid[2, Grid.Fwd].Value.ToString());
            }
            
            Dictionary<string, int> nameIndex = new Dictionary<string, int>
            {
                {"SGST",Grid.Sgst},{"CGST",Grid.Cgst},{"IGST",Grid.Igst}
            };
            var leftPaddingForSpace = 3;
            foreach (var item in nameIndex)
            {
                decimal val = getBotomRowValue(item.Value, 1);
                if (val > 0)
                {
                    var textToBePrinted = item.Key + " @" + val + "%  " + getBotomRowValue(item.Value, 2);
                    gdiPage.DrawString(textToBePrinted, itemFont, Brushes.Black,
                               totalWidth - Common.GetWidth(textToBePrinted, itemFont,gdiPage) + leftPaddingForSpace, itemY + (lineY++ * itemLineHeight));
                }
            }
            totalAmountAfterTax = getBotomRowValue(Grid.TotalAfterTax, 2);
            var totalAfterTaxToBePrinted = "Total After Tax  " + totalAmountAfterTax;
            gdiPage.DrawString(totalAfterTaxToBePrinted, itemFont, Brushes.Black,
                       totalWidth - Common.GetWidth(totalAfterTaxToBePrinted, itemFont,gdiPage) + leftPaddingForSpace, itemY + (lineY++ * itemLineHeight));
            gdiPage.DrawString("----------------", itemFont, Brushes.Black,
                       X("Amount") - dashLineAdjt, itemY + (lineY++ * itemLineHeight));

            var interestText = "Interest should be added @15% for payment after 30 days from Bill Date";
            gdiPage.DrawString(interestText,
                    itemFont, Brushes.Black, X("Cd"), Y("Cd"));
        }
        private void PrintPartyAddress(Graphics gdiPage)
        {
            //To Details
            float partyX = X("PartyName");
            float partyY = Y("PartyName");
            gdiPage.DrawString(txtPartyName.Text, printInvRightFont, Brushes.Black,
                        partyX, partyY);
            BillingApplication.CompanyDS.PARTIESDataTable pDt = this.partiesTA.GetDataById(Convert.ToInt32(txtPartyName.Tag));
            int partyAddrLineNo = 1;
            if (pDt != null && pDt.Rows.Count > 0)
            {
                BillingApplication.CompanyDS.PARTIESRow pr = (BillingApplication.CompanyDS.PARTIESRow)pDt.Rows[0];
                try
                {
                    if (pr.ADDR1 != "")
                    {
                        var txtToBePrinted = pr.ADDR1;
                        if (pr.ADDR2 != "")
                        {
                            txtToBePrinted += ", " + pr.ADDR2;
                        }
                        gdiPage.DrawString(txtToBePrinted, printInvRightFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo++ * lineHeight));
                    }
                }
                catch { }
                try
                {
                    if (pr.ADDR3 != "")
                    {
                        gdiPage.DrawString(pr.ADDR3, printInvRightFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo++ * lineHeight));
                    }
                }
                catch { }
                try
                {
                    var cityToBePrinted = "";
                    if (pr.CITY != "")
                    {
                        cityToBePrinted += pr.CITY;
                    }
                    if (pr.PIN + "" != "")
                    {
                        cityToBePrinted += " - " + pr.PIN;
                    }
                    if (pr.STATE != "")
                    {
                        cityToBePrinted += " (" + pr.STATE + ")";
                    }

                    gdiPage.DrawString(cityToBePrinted, printInvRightFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo++ * lineHeight));
                }
                catch { }
                
                try
                {
                    if (pr.GST != "")
                    {
                        var txtToBePrinted = "GSTIN: " + pr.GST + "      STATE CODE: " + pr.GST.Substring(0,2);
                        //partyAddrLineNo++;
                        gdiPage.DrawString(txtToBePrinted, printInvRightFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo * lineHeight));
                    }
                }
                catch { }
            }
        }
        private string GetRowValue(CompanyDS.PARTIESRow pr,string colName)
        {
            if (pr[colName] != null)
            {
                return Convert.ToString(pr[colName]);
            }
            else
                return "";
        }
        private void PrintOrderDetails(Graphics gdiPage)
        {
            //OrderNo
            gdiPage.DrawString(txtOrderNo.Text, printInvRightFont, Brushes.Black,
                        X("OrderNo"), Y("OrderNo"));
            //OrderDt
            gdiPage.DrawString(Common.GetDate(dtpOrderDate.Value), printInvRightFont, Brushes.Black,
                        X("OrderDate"), Y("OrderDate"));
            //OrderFwd
            gdiPage.DrawString(txtFwdBy.Text, printInvRightFont, Brushes.Black,
                        X("FwdBy"), Y("FwdBy"));
            //OrderFwdTo
            int fwdToWidth = Common.GetWidth(txtOrderTo.Text, printInvRightFont,gdiPage);
            if (X("FwdTo") + fwdToWidth > 900)
            {
            }
            else
            {
                gdiPage.DrawString(txtOrderTo.Text, printInvRightFont, Brushes.Black,
                            X("FwdTo"), Y("FwdTo"));
            }
            //OrderLR
            gdiPage.DrawString(txtLR.Text, printInvRightFont, Brushes.Black,
                        X("LRno"), Y("LRno"));
            //OrderLRDt
            gdiPage.DrawString(Common.GetDate(dtpLRDate.Value), printInvRightFont, Brushes.Black,
                        X("LRDate"), Y("LRDate"));
            //OrderAgent
            gdiPage.DrawString(cbAgtName.Text, printInvRightFont, Brushes.Black,
                        X("Agent"), Y("Agent"));
            //OrderCourier
            gdiPage.DrawString(cbCourier.Text, printInvRightFont, Brushes.Black,
                        X("DocTo"), Y("DocTo"));
        }
        private void PrintTopPart(Graphics gdiPage, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string address = cbCoy.Text;
            //Gst
            string gst = ((BillingApplication.CompanyDS.ADDRESSRow)
                           coDs.ADDRESS.Select("NAME = '" + address + "'")[0]).GST;
            gdiPage.DrawString("GSTIN : " + gst, gstFont, Brushes.Black, X("TinNo"), Y("Address") - 20);
            //Company Name
            Font companyFont = new Font("Arial", 20);
            float center = e.MarginBounds.Width / 2 - (charWidth * address.Length);
            gdiPage.DrawString(address, companyFont, Brushes.Black, center, Y("Address"));
            //state code
            gdiPage.DrawString("STATE CODE : " + gst.Substring(0,2), gstFont, Brushes.Black, X("StateCode"), Y("StateCode"));

            //Invoice Details

            gdiPage.DrawString(invoicePrefix + txtInvno.Text, printFont, Brushes.Black, X("Invoice"), Y("Invoice"));
            gdiPage.DrawString(txtBaleno.Text, printFont, Brushes.Black, X("BaleNo"), Y("BaleNo"));
            gdiPage.DrawString(Common.GetDate(dtpBillDt.Value), printFont, Brushes.Black,
                        X("BillDate"), Y("BillDate"));
        }
        
        private void PrintBottomPart(Graphics gdiPage)
        {
            string address = cbCoy.Text;
            //Custom Text
            string customTxt = ((BillingApplication.CompanyDS.ADDRESSRow)
                           coDs.ADDRESS.Select("NAME = '" + address + "'")[0]).CUSTOM_1;
            string[] customText = customTxt.Split(':');
            //gdiPage.DrawString(customText[0], itemFont, Brushes.Black,
            //           X("Custom"), Y("Custom"));
            gdiPage.DrawString(customText[1], itemFont, Brushes.Black,
                        X("BOB"), Y("BOB"));
            //Rupees
            string balance = Convert.ToString(totalAmountAfterTax);
            balance = num.changeNumericToWords(balance) + "Only";
            //Rupess in words
            gdiPage.DrawString(balance, itemFont, Brushes.Black,
                        X("Rupees"), Y("Rupees"));
            //for
            gdiPage.DrawString("For " + address, itemFont, Brushes.Black,
                        X("For"), Y("For"));
        }
        private void PrintBillImage(Graphics gdiPage)
        {
            Image img = new Bitmap(@"D:\scan0003.bmp");
            // Create the source rectangle from the BackgroundImage Bitmap Dimensions
            RectangleF srcRect = new Rectangle(0, 0, img.Width, img.Height);
            // Create the destination rectangle from the printer settings holding printer page dimensions
            int nWidth = pDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width;
            int nHeight = pDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height;
            RectangleF destRect = new Rectangle(0, 0, nWidth, nHeight);
            // Draw the image scaled to fit on a printed page
            gdiPage.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
            gdiPage.DrawString(nWidth + " : " + nHeight, itemFont, Brushes.Black, 100, 100);
        }
        private void pDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics gdiPage = e.Graphics;
            lineHeight = printFont.GetHeight(gdiPage);
            itemLineHeight = itemFont.GetHeight(gdiPage);
            //PrintBillImage(gdiPage);
            PrintTopPart(gdiPage, e);
            PrintPartyAddress(gdiPage);
            PrintOrderDetails(gdiPage);
            PrintBillItems(gdiPage);
            PrintBottomPart(gdiPage);
            //gdiPage.DrawString("t", printFont, Brushes.Black, X("TinNo"), e.PageSettings.Bounds.Height - (lineHeight * 3));
        }
        private void pDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string itemFt = global::BillingApplication.Properties.Settings.Default.Font;
            int itemFtSize = global::BillingApplication.Properties.Settings.Default.PrintItemFontSize;
            int printFtSize = global::BillingApplication.Properties.Settings.Default.PrintFontSize;
            int printInvoiceRightFtSize = global::BillingApplication.Properties.Settings.Default.PrintInvoiceRightFontSize;
            itemFont = new Font(itemFt, itemFtSize, GraphicsUnit.Pixel);
            printFont = new Font(itemFt, printFtSize, GraphicsUnit.Pixel);
            gstFont = new Font(itemFt, printFtSize + 1, GraphicsUnit.Pixel);
            printInvRightFont = new Font(itemFt, printInvoiceRightFtSize, GraphicsUnit.Pixel);
            //pDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 600, 600);
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
            //int i = 0;
            //while (i < e.PageSettings.PrinterSettings.PaperSizes.Count)
            //    if (e.PageSettings.PrinterSettings.PaperSizes[i].PaperName == "A4")
            //        break;
            //    else
            //        i++;
            //System.Xml.XmlDocument dom = new System.Xml.XmlDocument();
            //dom.Load(@"C:\PrintPaperHeight.xml");
            //int height = Convert.ToInt32(dom.SelectSingleNode("//height").InnerText);
            //System.Drawing.Printing.PaperSize pSize = new System.Drawing.Printing.PaperSize("Custom", 855, height);
            
            //System.Drawing.Printing.PaperSize pSize = new System.Drawing.Printing.PaperSize("Custom", 855, 1016);
            int height = 1016;
            System.Drawing.Printing.PaperSize pSize = new System.Drawing.Printing.PaperSize("Custom", 855, height);
            e.PageSettings.PaperSize = pSize;
            e.PageSettings.PrinterSettings.DefaultPageSettings.PaperSize = pSize;
        }
        private void btnPrintPartyAddr_Click(object sender, EventArgs e)
        {
            pPartyAddr.Print();
        }
        
        private void pPartyAddr_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics gdiPage = e.Graphics;
            PrintCoverPartyAddress(gdiPage);
        }
        
        private void pPartyAddr_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            coverFont.Dispose();
        }
        private void pPartyAddr_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string coverFt = global::BillingApplication.Properties.Settings.Default.CoverFont;
            int converFtSize = global::BillingApplication.Properties.Settings.Default.CoverFontSize;
            coverFont = new Font(coverFt, converFtSize, GraphicsUnit.Pixel);
        }

        private void pDocDelivery_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics gdiPage = e.Graphics;
            string address = cbCoy.Text;
            BillingApplication.CompanyDS.PARTIESDataTable pDt = this.partiesTA.GetDataById(Convert.ToInt32(txtPartyName.Tag));
            var gst = ((BillingApplication.CompanyDS.PARTIESRow)pDt.Rows[0]).GST;
            var data = new DeliveryEntity
            {
                MerchantName = address,
                Gst = ((BillingApplication.CompanyDS.ADDRESSRow)
                           coDs.ADDRESS.Select("NAME = '" + address + "'")[0]).GST,
                BaleNo = txtBaleno.Text,
                Transport = txtFwdBy.Text,
                BookedTo = txtOrderTo.Text,
                Party = new Party
                {
                    Name = txtPartyName.Text,
                    Addr1 = txtPartyAddr1.Text,
                    Addr2 = txtPartyAddr2.Text,
                    City = txtPartyCity.Text,
                    State = txtPartyState.Text,
                    Pin = txtPartyPin.Text,
                    Gst = gst ?? ""
                },
                Invoice = new Invoice
                {
                    Number = invoicePrefix + txtInvno.Text,
                    Date = Common.GetDate(dtpBillDt.Value)
                },
                Particulars = new Particulars
                {
                    Description = txtParticulars.Text,
                    TotalPairsMtrsKey = txtTotalmtrs.Text != ""  && Convert.ToDecimal(txtTotalmtrs.Text) > 0 ? "Total Meters" : "Total Pairs ",
                    TotalPairsMtrsValue = txtTotalmtrs.Text != "" && Convert.ToDecimal(txtTotalmtrs.Text) > 0 ? txtTotalmtrs.Text : txtNetqty.Text,
                    HSN = grdItem.Rows[0].Cells["HSN"].Value.ToString(),
                    TotalAmount = btmGrid[2, Grid.TotalBeforeTax].Value.ToString(),
                    IgstAmount = btmGrid[2, Grid.Igst].Value != null ? btmGrid[2, Grid.Igst].Value.ToString() : "",
                    IgstPercent = btmGrid[1, Grid.Igst].Value != null ? btmGrid[1, Grid.Igst].Value.ToString() : "",
                    TotalBillValue = btmGrid[2, Grid.TotalAfterTax].Value.ToString(),
                }
            };

            Common.PrintDelivery(gdiPage, data);
            
        }

        

        
        private void pDocDelivery_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string coverFt = global::BillingApplication.Properties.Settings.Default.CoverFont;
            int converFtSize = global::BillingApplication.Properties.Settings.Default.CoverFontSize;
            coverFont = new Font(coverFt, converFtSize, GraphicsUnit.Pixel);
            //pDocDelivery.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 600, 600);
        }

        private void pDocDelivery_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            coverFont.Dispose();
        }

        private void PrintCoverPartyAddress(Graphics gdiPage)
        {
            //To Details
            float partyX = global::BillingApplication.Properties.Settings.Default.CoverPrintX;
            float partyY = global::BillingApplication.Properties.Settings.Default.CoverPrintY;
            lineHeight = coverFont.GetHeight(gdiPage);
            gdiPage.DrawString(txtPartyName.Text, coverFont, Brushes.Black,
                        partyX, partyY);
            BillingApplication.CompanyDS.PARTIESDataTable pDt = this.partiesTA.GetDataById(Convert.ToInt32(txtPartyName.Tag));
            int partyAddrLineNo = 1;
            if (pDt != null && pDt.Rows.Count > 0)
            {
                BillingApplication.CompanyDS.PARTIESRow pr = (BillingApplication.CompanyDS.PARTIESRow)pDt.Rows[0];
                try
                {
                    if (pr.ADDR1 != "")
                    {
                        gdiPage.DrawString(pr.ADDR1, coverFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo++ * lineHeight));
                    }
                }
                catch { }
                try
                {
                    if (pr.ADDR2 != "")
                    {
                        gdiPage.DrawString(pr.ADDR2, coverFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo++ * lineHeight));
                    }
                }
                catch { }
                try
                {
                    if (pr.ADDR3 != "")
                    {
                        gdiPage.DrawString(pr.ADDR3, coverFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo++ * lineHeight));
                    }
                }
                catch { }
                try
                {
                    if (pr.CITY != "")
                    {
                        gdiPage.DrawString(pr.CITY, coverFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo * lineHeight));
                        try
                        {
                            gdiPage.DrawString(" - " + pr.PIN, coverFont, Brushes.Black,
                                partyX + (charWidth * pr.CITY.Length), partyY + (partyAddrLineNo++ * lineHeight));
                            //If all five lines of address are completed here, 
                            //then add the remaining lines in this line itself
                            if (partyAddrLineNo == 5)
                            {
                                partyAddrLineNo--;
                                string dt = GetRowValue(pr, "DISTRICT");
                                string st = GetRowValue(pr, "STATE");
                                float pinLen = partyX + (charWidth * pr.CITY.Length) + (charWidth * (Convert.ToString(pr.PIN).Length + 2));
                                if (dt != "")
                                {
                                    gdiPage.DrawString(",DT : " + dt, coverFont, Brushes.Black,
                                     pinLen, partyY + (partyAddrLineNo * lineHeight));
                                    if (st != "")
                                    {
                                        float dtLen = pinLen + (charWidth * (dt.Length + 6));
                                        gdiPage.DrawString("," + st, coverFont, Brushes.Black,
                                            dtLen, partyY + (partyAddrLineNo * lineHeight));
                                        return;
                                    }
                                }
                                else if (st != "")
                                {
                                    float dtLen = pinLen + (charWidth * (dt.Length + 6));
                                    gdiPage.DrawString("," + st, coverFont, Brushes.Black,
                                        pinLen, partyY + (partyAddrLineNo * lineHeight));
                                    return;
                                }
                            }
                        }
                        catch { partyAddrLineNo++; }
                    }
                }
                catch { }
                try
                {
                    if (pr.DISTRICT != "")
                    {
                        gdiPage.DrawString("DISTRICT: " + pr.DISTRICT, coverFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo++ * lineHeight));
                        if (partyAddrLineNo == 5)
                        {
                            partyAddrLineNo--;
                            string st = GetRowValue(pr, "STATE");
                            float pinLen = partyX + (charWidth * (pr.DISTRICT.Length + 10));
                            if (st != "")
                            {
                                gdiPage.DrawString("," + st, coverFont, Brushes.Black,
                                    pinLen, partyY + (partyAddrLineNo * lineHeight));
                                return;
                            }
                        }
                    }
                }
                catch { }
                try
                {
                    if (pr.STATE != "")
                    {
                        gdiPage.DrawString(pr.STATE, coverFont, Brushes.Black,
                            partyX, partyY + (partyAddrLineNo * lineHeight));
                    }
                }
                catch { }
            }
        }
    }
}

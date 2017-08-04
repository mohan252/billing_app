using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.IO;
using System.Drawing;
using System.Linq;

namespace BillingApplication
{
    public static class Common
    {
        static ExcelPackage oXL;
        static ExcelWorksheet oSheet;
        static global::BillingApplication.Properties.Settings settings = global::BillingApplication.Properties.Settings.Default;
        public static DataSet GetOldBillsData(BillingApplication.CompanyDSTableAdapters.BILLSTableAdapter bILLSTableAdapter, string dataType, string address,string agent, string fDate,string tDate,string party)
        {
            string myConn = System.Configuration.ConfigurationManager.ConnectionStrings["BillingApplication.Properties.Settings.companyConn"].ConnectionString;
            SqlDataAdapter myAdap = new SqlDataAdapter();
            SqlCommand myCmd = new SqlCommand();
            myCmd.Connection = new SqlConnection(myConn);
            myAdap.SelectCommand = myCmd;
            CompanyDS coDs = new CompanyDS();
            //coDs.EnforceConstraints = false;
            //Fill Items
            myCmd.CommandText = "SELECT * FROM OLDBILLTABLES";
            myAdap.Fill(coDs, "OLDBILLTABLES");
            DataSet oldBillsDs = null;
            if (coDs.OLDBILLTABLES.Rows != null && coDs.OLDBILLTABLES.Rows.Count > 0)
            {
                foreach (DataRow row in coDs.OLDBILLTABLES.Rows)
                {
                    string billTable = Convert.ToString(row["BILLTABLE"]);
                    string billpaymentTable = Convert.ToString(row["BILLPAYMENTSTABLE"]);
                    DataSet ds = new DataSet();
                    //oldBillsDs = new DataSet();
                    if (dataType == "DDENTRY")
                    {
                        //bILLSTableAdapter.GetDDEntryBillData(ds, address, agent, fDate, tDate, billTable, billpaymentTable);
                        ds.Tables[0].TableName = "BILLS";
                        ds.Tables[1].TableName = "BILLPAYMENTS";
                    }
                    else if (dataType == "PENDINGLIST")
                        //bILLSTableAdapter.GetPendingListData(ds, address, agent, party, fDate, tDate, billpaymentTable,billTable);
                    if (ds.Tables != null && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
                    {
                        if (oldBillsDs == null)
                            oldBillsDs = ds;
                        else
                            oldBillsDs.Merge(ds);
                    }
                }
            }
            return oldBillsDs;
        }
        
        public static void ExportToExcel(string path, System.Data.DataTable dt, BillingApplication.CompanyDS.AGENTSDataTable agentDt, string address, DateTime dpTo, string dataCol, string dataType)
        {
            ExcelPackage oXL = new ExcelPackage();
            oXL.Workbook.Worksheets.Add("Pending List");
            oSheet = oXL.Workbook.Worksheets[1];

            int rowNum = 1;
            foreach (DataRow dr in agentDt.Rows)
            {
                string agent = Convert.ToString(dr["NAME"]);
                DataRow[] drs = dt.Select("AGENT = '" + agent + "'");
                if (drs != null && drs.Length > 0)
                {
                    //AddSerialNoColumn(drs);
                    rowNum = SetAgentWiseData(agent, rowNum, drs, address, dpTo, dataCol, dataType);
                    if (dataType == "COMISSIONSTMT")
                    {

                    }
                }
            }
            Common.SetExcelFileFormat(rowNum);
            Byte[] bin = oXL.GetAsByteArray();
            string file = path + ".xlsx";
            File.WriteAllBytes(file, bin);            
        }

        public static DateTime NextBusinessDay()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                return DateTime.Now.AddDays(2);
            }
            return DateTime.Now.AddDays(1);
        }
        public static void SetExcelFileFormat(int rowNum)
        {
            oSheet.PrinterSettings.TopMargin = Convert.ToDecimal(settings.PLTopMargin);
            oSheet.PrinterSettings.RightMargin = Convert.ToDecimal(settings.PLRightMargin);
            oSheet.PrinterSettings.BottomMargin = Convert.ToDecimal(settings.PLBottonMargin);
            oSheet.PrinterSettings.LeftMargin = Convert.ToDecimal(settings.PLLeftMargin);
            oSheet.PrinterSettings.PrintArea = oSheet.Cells[1,1, rowNum + 10,6];
            oSheet.Cells[rowNum, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            oSheet.Cells[rowNum, 3].Style.Numberformat.Format = "dd/mm/yy";

            oSheet.Cells["A:F"].Style.Font.Name = settings.PLFont;
            oSheet.Cells["A:F"].Style.Font.Size = settings.PLFontSize;

            oSheet.Cells["A:F"].AutoFitColumns();

            oSheet.Column(5).Width = settings.PLPartyColumnWidth;
            oSheet.Column(4).Width = settings.PLPlaceColumnWidth;            
        }

        static Font coverFont;
        public static void PrintDelivery(Graphics gdiPage, DeliveryEntity data)
        {
            string coverFt = global::BillingApplication.Properties.Settings.Default.CoverFont;
            int converFtSize = global::BillingApplication.Properties.Settings.Default.CoverFontSize;
            coverFont = new Font(coverFt, converFtSize, GraphicsUnit.Pixel);

            string dashHeader = "---------------------------------------------------------------------------------------------";
            var noOfBales = "";
            gdiPage.DrawString("Invoice Copy to Transporter", coverFont, Brushes.Black,
                        X("DJurisdiction"), Y("DJurisdiction"));
            var senderAddress = new List<string>{
                "Consiner", data.MerchantName,"19 Kasianna Street, Erode","GSTIN: " + data.Gst + "  STATE CODE: " + data.Gst.Substring(0,2)
            };
            PrintSection(senderAddress, "DConsineeAddress", gdiPage);
            var senderContact = new List<string>
            {
                "0424-2259168", "99949 50150"
            };
            PrintSection(senderContact, "DConsineeContact", gdiPage);
            gdiPage.DrawString(dashHeader, coverFont, Brushes.Black,
                        X("DParticularsValue"), 110);
            var receiverAddress = new List<string>
            {
                "Consinee", data.Party.Name, data.Party.Addr1, data.Party.Addr2,data.Party.City
            };
            var partyGst = "";
            if (data.Party.Gst != "")
            {
                partyGst = "GSTIN: " + data.Party.Gst + "  STATE CODE: " + data.Party.Gst.Substring(0, 2);
                receiverAddress.Add(partyGst);
            }
            PrintSection(receiverAddress, "DReceiverAddress", gdiPage);
            var pipe = "|  ";
            var invoice = new List<string>
            {
                "Invoice No: " + data.Invoice.Number, "Invoice Date: " + data.Invoice.Date, "Bale No: " + data.BaleNo
            };
            if (data.BaleNo.Contains("/"))
            {
                noOfBales = data.BaleNo.Substring(data.BaleNo.LastIndexOf("/") + 1);
                invoice.Add("No of Bales: " + noOfBales);
            }
            invoice.Add("Transport: " + data.Transport);
            invoice.Add("Booked To: " + data.BookedTo);
            invoice = invoice.Select(i => pipe + i).ToList();
            PrintSection(invoice, "DInvoice", gdiPage);
            //Particulars
            var startParticularsY = Y("DParticulars");
            gdiPage.DrawString(dashHeader, coverFont, Brushes.Black,
                        X("DParticularsValue"), startParticularsY);
            var lineIncrement = 25;
            startParticularsY += 15;
            gdiPage.DrawString("Particulars", coverFont, Brushes.Black,
                        X("DParticulars"), startParticularsY);
            gdiPage.DrawString(data.Particulars.TotalPairsMtrsKey, coverFont, Brushes.Black,
                        X("DTotalPairs"), startParticularsY);
            gdiPage.DrawString("Hsn Code", coverFont, Brushes.Black,
                        X("DHsnCode"), startParticularsY);
            gdiPage.DrawString("Amount", coverFont, Brushes.Black,
                        X("DAmount"), startParticularsY);
            startParticularsY += 15;
            gdiPage.DrawString(dashHeader, coverFont, Brushes.Black,
                        X("DParticularsValue"), startParticularsY);
            var startParticularsValueY = startParticularsY + 35;
            gdiPage.DrawString(data.Particulars.Description, coverFont, Brushes.Black,
                        X("DParticularsValue"), startParticularsValueY);
            gdiPage.DrawString(data.Particulars.TotalPairsMtrsValue, coverFont, Brushes.Black,
                        X("DTotalPairsValue"), startParticularsValueY);
            gdiPage.DrawString(data.Particulars.HSN, coverFont, Brushes.Black,
                        X("DHsnCodeValue"), startParticularsValueY);
            gdiPage.DrawString(data.Particulars.TotalAmount, coverFont, Brushes.Black,
                        X("DAmountValue"), startParticularsValueY);
            var lineIncrementDash = 15;
            var igstY = startParticularsValueY + lineIncrement;
            gdiPage.DrawString("IGST " + data.Particulars.IgstPercent + "%  " + data.Particulars.IgstAmount, coverFont, Brushes.Black,
                       X("DIGST"), igstY);
            var dash1Y = igstY + lineIncrementDash;
            gdiPage.DrawString("--------------", coverFont, Brushes.Black,
                       X("DDash1"), dash1Y);
            var totalBillValueY = dash1Y + lineIncrementDash;
            gdiPage.DrawString("Total Amount After Tax  " + data.Particulars.TotalBillValue, coverFont, Brushes.Black,
                       X("DTotalBillValue"), totalBillValueY);
            var dash2Y = totalBillValueY + lineIncrementDash;
            gdiPage.DrawString("--------------", coverFont, Brushes.Black,
                       X("DDash2"), dash2Y);
            var balesOfClothY = dash2Y + lineIncrementDash;
            var balesOfClothX = X("DConsineeAddress");
            if (noOfBales != "")
            {
                gdiPage.DrawString(noOfBales + " Bales of Cotton Cloth", coverFont, Brushes.Black,
                       balesOfClothX, balesOfClothY);
            }
            else
            {
                gdiPage.DrawString("One Bale of Cotton Cloth", coverFont, Brushes.Black,
                       balesOfClothX, balesOfClothY);
            }
            var forTextY = balesOfClothY + lineIncrementDash;
            gdiPage.DrawString("For " + data.MerchantName, coverFont, Brushes.Black,
                        X("DTotalPairs"), forTextY);
        }

        private static void PrintSection(List<string> data, string sectionName, Graphics graphics)
        {
            float startXLocation = X(sectionName);
            float startYLocation = Y(sectionName);
            var lineHt = coverFont.GetHeight(graphics);
            var currentConsineeLineNo = 1;
            foreach (var item in data)
            {
                graphics.DrawString(item, coverFont, Brushes.Black,
                        startXLocation, startYLocation + currentConsineeLineNo++ * lineHt);
            }
        }

        private static float X(string setting)
        {
            string p = (string)global::BillingApplication.Properties.Settings.Default[setting];
            string[] ps = p.Split(',');
            float charWidth = 10;
            return charWidth * float.Parse((ps[0]));
        }
        private static float Y(string setting)
        {
            string p = (string)global::BillingApplication.Properties.Settings.Default[setting];
            string[] ps = p.Split(',');
            //return lineHeight * float.Parse((ps[1]));
            return float.Parse((ps[1]));
        }

        private static int SetAgentWiseData(string agent, int rowNum, DataRow[] drs, string address, DateTime dpTo, string dataCol, string dataType)
        {
            rowNum = SetAddressRow(rowNum, address, agent);
            rowNum = SetHeaderRow(rowNum, dpTo);
            rowNum = SetDataRows(rowNum + 1, drs, dataCol, dataType);
            return rowNum;
        }
        private static int SetAddressRow(int rowNum, string address, string agent)
        {
            oSheet.Cells[rowNum, 2].Value = "From";
            oSheet.Cells[rowNum, 5].Value = "To";
            rowNum++;
            oSheet.Cells[rowNum, 2].Value = "    " + address;
            //Merge address cells
            oSheet.Cells[rowNum, 2, rowNum, 4].Merge = true;
            oSheet.Cells[rowNum, 5].Value = "  " + agent;
            //Merge agent name cells
            oSheet.Cells[rowNum, 5, rowNum, 6].Merge = true;
            rowNum++;
            oSheet.Cells[rowNum, 2].Value = "    " + "Erode";
            //Merge city cells
            oSheet.Cells[rowNum, 2, rowNum, 4].Merge = true;
            oSheet.Cells[rowNum, 5, rowNum, 6].Merge = true;        
            return ++rowNum;
        }
        private static int SetHeaderRow(int rowNum, DateTime dpTo)
        {
            oSheet.Cells[rowNum, 1, rowNum, 6].Merge = true;
            oSheet.Cells[rowNum, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            if (!dpTo.Equals(DateTime.MinValue))
                oSheet.Cells[rowNum, 1].Value = "Pending List Upto " + dpTo.Day + "/" + dpTo.Month + "/" + dpTo.Year;
            else
                oSheet.Cells[rowNum, 1].Value = "Pending List";
            rowNum++;
            oSheet.Cells[rowNum, 2].Value = "Bill No";
            oSheet.Cells[rowNum, 3].Value = "Date";
            oSheet.Cells[rowNum, 4].Value = "Place";
            oSheet.Cells[rowNum, 5].Value = "Party";
            oSheet.Cells[rowNum, 6].Value = "Amt";
            return rowNum;
        }

        private static int SetDataRows(int rowNum, DataRow[] drs, string dataCol, string dataType)
        {
            int serialNo = 1;
            double totalValue = 0;
            foreach (DataRow dr in drs)
            {
                int opColIndex = 1;
                oSheet.Cells[rowNum, opColIndex].Value = Convert.ToString(serialNo++);
                opColIndex++;
                for (int i = 1; i < 7; i++)
                {
                    if (i != 5) // skip agent value
                    {
                        object dvalue = dr.ItemArray[i];
                        if (i == 6 && dr[dataCol] != System.DBNull.Value)
                        {
                            oSheet.Cells[rowNum, opColIndex].Value = Convert.ToString(dr[dataCol]);
                            if (dataType == "COMISSIONSTMT")
                                totalValue += Convert.ToDouble(dr[dataCol]);
                        }
                        else
                            oSheet.Cells[rowNum, opColIndex].Value = Convert.ToString(dvalue);
                        opColIndex++;
                    }
                }
                rowNum++;
            }
            if (dataType == "COMISSIONSTMT")
            {
                float csCdPercent = settings.CSCDPercent;
                float csAgentComission = settings.CSCommissionPercent;
                oSheet.Cells[rowNum, 5].Value = "Total";
                oSheet.Cells[rowNum++, 6].Value = Convert.ToString(Math.Round(totalValue, 2));
                oSheet.Cells[rowNum, 5].Value = csCdPercent + "% CD";
                double cdLessValue = totalValue * (csCdPercent / 100);
                oSheet.Cells[rowNum++, 6].Value = Convert.ToString(Math.Round(cdLessValue, 2));
                double totalAfterCD = totalValue - cdLessValue;
                oSheet.Cells[rowNum, 5].Value = "Total After CD Less";
                oSheet.Cells[rowNum++, 6].Value = Convert.ToString(Math.Round(totalAfterCD, 2));
                double agentComission = totalAfterCD * (csAgentComission / 100);
                oSheet.Cells[rowNum, 5].Value = "Commision " + csAgentComission + "%";
                oSheet.Cells[rowNum++, 6].Value = Convert.ToString(Math.Round(agentComission, 2));
            }
            return rowNum;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.IO;

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

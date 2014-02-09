using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace BillingApplication
{
    public static class Common
    {
        //static Excel.Application oXL;
        //static Excel._Workbook oWB;
        //static Excel._Worksheet oSheet;
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
        //public static void SetExcelFileFormat(int rowNum)
        //{
        //    oSheet.PageSetup.TopMargin = settings.PLTopMargin * 100;
        //    oSheet.PageSetup.RightMargin = settings.PLRightMargin * 100;
        //    oSheet.PageSetup.BottomMargin = settings.PLBottonMargin * 100;
        //    oSheet.PageSetup.LeftMargin = settings.PLLeftMargin * 100;
        //    oSheet.PageSetup.PrintArea = "$A$1:$F$" + (rowNum + 10);
        //    ((Range)oSheet.Cells[rowNum, 3]).EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
        //    ((Range)oSheet.Cells[rowNum, 3]).EntireColumn.NumberFormat = "dd/mm/yy";
        //    oSheet.get_Range("A" + rowNum, "F" + rowNum).EntireColumn.Font.Name = settings.PLFont;
        //    oSheet.get_Range("A" + rowNum, "F" + rowNum).EntireColumn.Font.Size = settings.PLFontSize;
        //    oSheet.get_Range("A" + rowNum, "F" + rowNum).EntireColumn.AutoFit();
        //    oSheet.get_Range("A" + rowNum, "F" + rowNum).EntireColumn.ShrinkToFit = true;
        //    ((Range)oSheet.Cells[rowNum, 5]).EntireColumn.ColumnWidth = settings.PLPartyColumnWidth;
        //    ((Range)oSheet.Cells[rowNum, 4]).EntireColumn.ColumnWidth = settings.PLPlaceColumnWidth;
        //}
        //public static void ExportToExcel(string path, System.Data.DataTable dt, BillingApplication.CompanyDS.AGENTSDataTable agentDt,string address,DateTime dpTo,string dataCol,string dataType)
        //{
        //    //Start Excel and get Application object.
        //    oXL = new Excel.Application();
        //    //oXL.Visible = true;
        //    //Get a new workbook.
        //    oWB = (Excel._Workbook)(oXL.Workbooks.Add(true));
        //    oSheet = (Excel._Worksheet)oWB.ActiveSheet;
        //    //row number to keep track of tables exporting
        //    int rowNum = 1;
        //    foreach (DataRow dr in agentDt.Rows)
        //    {
        //        string agent = Convert.ToString(dr["NAME"]);
        //        DataRow[] drs = dt.Select("AGENT = '" + agent + "'");
        //        if (drs != null && drs.Length > 0)
        //        {
        //            //AddSerialNoColumn(drs);
        //            rowNum = SetAgentWiseData(agent, rowNum, drs, address, dpTo, dataCol, dataType);
        //            if (dataType == "COMISSIONSTMT")
        //            {

        //            }
        //        }
        //    }
        //    Common.SetExcelFileFormat(rowNum);
        //    oWB.Close(true, path, null);
        //    oXL.Quit();
        //    //Free the excel resources
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
        //    }
        //    catch { }
        //    finally
        //    {
        //        oXL = null;
        //        oWB = null;
        //        oSheet = null;
        //        GC.Collect();
        //    }
        //}
        //private static int SetAgentWiseData(string agent, int rowNum, DataRow[] drs, string address, DateTime dpTo, string dataCol, string dataType)
        //{
        //    rowNum = SetAddressRow(rowNum, address, agent);
        //    rowNum = SetHeaderRow(rowNum,dpTo);
        //    rowNum = SetDataRows(rowNum + 1, drs, dataCol, dataType);
        //    return rowNum;
        //}
        //private static int SetAddressRow(int rowNum, string address, string agent)
        //{
        //    oSheet.Cells[rowNum, 2] = "From";
        //    oSheet.Cells[rowNum, 5] = "To";
        //    rowNum++;
        //    oSheet.Cells[rowNum, 2] = "    " + address;
        //    //Merge address cells
        //    oSheet.get_Range("B" + rowNum, "D" + rowNum).Merge(null);
        //    oSheet.Cells[rowNum, 5] = "  " + agent;
        //    //Merge agent name cells
        //    oSheet.get_Range("E" + rowNum, "F" + rowNum).Merge(null);
        //    rowNum++;
        //    oSheet.Cells[rowNum, 2] = "    " + "Erode";
        //    //Merge city cells
        //    oSheet.get_Range("B" + rowNum, "D" + rowNum).Merge(null);
        //    oSheet.get_Range("E" + rowNum, "F" + rowNum).Merge(null);
        //    return ++rowNum;
        //}
        //private static int SetHeaderRow(int rowNum, DateTime dpTo)
        //{
        //    oSheet.get_Range("A" + rowNum, "F" + rowNum).Merge(null);
        //    ((Range)oSheet.Cells[rowNum, 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        //    if (!dpTo.Equals(DateTime.MinValue))
        //        oSheet.Cells[rowNum, 1] = "Pending List Upto " + dpTo.Day + "/" + dpTo.Month + "/" + dpTo.Year;
        //    else
        //        oSheet.Cells[rowNum, 1] = "Pending List";
        //    rowNum++;
        //    oSheet.Cells[rowNum, 2] = "Bill No";
        //    oSheet.Cells[rowNum, 3] = "Date";
        //    oSheet.Cells[rowNum, 4] = "Place";
        //    oSheet.Cells[rowNum, 5] = "Party";
        //    oSheet.Cells[rowNum, 6] = "Amt";
        //    return rowNum;
        //}
        //private static int SetDataRows(int rowNum, DataRow[] drs, string dataCol, string dataType)
        //{
        //    int serialNo = 1;
        //    double totalValue = 0;
        //    foreach (DataRow dr in drs)
        //    {
        //        int opColIndex = 1;
        //        oSheet.Cells[rowNum, opColIndex] = Convert.ToString(serialNo++);
        //        opColIndex++;
        //        for (int i = 1; i < 7; i++)
        //        {
        //            if (i != 5) // skip agent value
        //            {
        //                object dvalue = dr.ItemArray[i];
        //                if (i == 6 && dr[dataCol] != System.DBNull.Value)
        //                {
        //                    oSheet.Cells[rowNum, opColIndex] = Convert.ToString(dr[dataCol]);
        //                    if (dataType == "COMISSIONSTMT")
        //                        totalValue += Convert.ToDouble(dr[dataCol]);
        //                }
        //                else
        //                    oSheet.Cells[rowNum, opColIndex] = Convert.ToString(dvalue);
        //                opColIndex++;
        //            }
        //        }
        //        rowNum++;
        //    }
        //    if (dataType == "COMISSIONSTMT")
        //    {
        //        float csCdPercent = settings.CSCDPercent;
        //        float csAgentComission = settings.CSCommissionPercent;
        //        oSheet.Cells[rowNum, 5] = "Total";
        //        oSheet.Cells[rowNum++, 6] = Convert.ToString(Math.Round(totalValue,2));
        //        oSheet.Cells[rowNum, 5] = csCdPercent + "% CD";
        //        double cdLessValue = totalValue * (csCdPercent / 100);
        //        oSheet.Cells[rowNum++, 6] = Convert.ToString(Math.Round(cdLessValue,2));
        //        double totalAfterCD = totalValue - cdLessValue;
        //        oSheet.Cells[rowNum, 5] = "Total After CD Less";
        //        oSheet.Cells[rowNum++, 6] = Convert.ToString(Math.Round(totalAfterCD,2));
        //        double agentComission = totalAfterCD * (csAgentComission / 100);
        //        oSheet.Cells[rowNum, 5] = "Commision " + csAgentComission + "%";
        //        oSheet.Cells[rowNum++, 6] = Convert.ToString(Math.Round(agentComission,2));
        //    }
        //    return rowNum;
        //}
    }
}

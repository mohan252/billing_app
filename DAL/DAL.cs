using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.IO;
using System.Collections.Specialized;
using BillingApplication.Models;
using System.Linq;

namespace BillingApplication
{
    public class DAL
    {
        string myConn = "";
        SqlDataAdapter myAdap = null;
        SqlCommand myCmd = null;
        public DAL()
        {
            myConn = System.Configuration.ConfigurationManager.ConnectionStrings["BillingApplication.Properties.Settings.companyConn"].ConnectionString;
            myAdap = new SqlDataAdapter();
            myCmd = new SqlCommand();
            myCmd.Connection = new SqlConnection(myConn);
            myAdap.SelectCommand = myCmd;
        }
        public int GetBillData(DataTable dataTable, string COLUMNNAME, string ORDERBY)
        {
            myCmd.CommandText = "dbo.SP_GETBILLDATA";
            myCmd.CommandType = System.Data.CommandType.StoredProcedure;
            myAdap.SelectCommand.Parameters.Clear();
            myCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            myCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COLUMNNAME", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 0, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            myCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ORDERBY", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 0, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            myAdap.SelectCommand = myCmd;
            if ((COLUMNNAME == null))
            {
                myAdap.SelectCommand.Parameters[1].Value = System.DBNull.Value;
            }
            else
            {
                myAdap.SelectCommand.Parameters[1].Value = ((string)(COLUMNNAME));
            }
            if ((ORDERBY == null))
            {
                myAdap.SelectCommand.Parameters[2].Value = System.DBNull.Value;
            }
            else
            {
                myAdap.SelectCommand.Parameters[2].Value = ((string)(ORDERBY));
            }
            int returnValue = myAdap.Fill(dataTable);
            return returnValue;
        }
        public DataTable GetAccountingYear()
        {
            DataTable dt = new DataTable();
            myCmd.CommandText = "SELECT ACCOUNTINGYEAR FROM OLDBILLTABLES ORDER BY ACCOUNTINGYEAR ASC";
            myCmd.CommandType = CommandType.Text;
            myAdap.Fill(dt);
            return dt;
        }
        public List<Address> GetAddresses()
        {
            DataTable dt = new DataTable();
            myCmd.CommandText = "SELECT NAME,GST FROM ADDRESS";
            myCmd.CommandType = CommandType.Text;
            myAdap.Fill(dt);
            List<Address> addresses = new List<Address>();
            foreach (DataRow dr in dt.Rows)
            {
                addresses.Add(new Address{ Name = Convert.ToString(dr["NAME"]), Gst= Convert.ToString(dr["GST"])} );
            }
            return addresses;
        }

        public IEnumerable<GstItem> GetGstDetailsByParty(DateTime fromDate, DateTime toDate)
        {
            var query = "";
            if (fromDate.Month != 4)
            {
                query = @"SELECT P.GST AS PARTYGST, P.NAME
                            'G-' + CONVERT(VARCHAR(10),B.BILLNO) AS INVOICENUMBER, 
                            CONVERT(VARCHAR(100),B.BILLDATE,105) AS INVOICEDATE, 
                            B.TOTALAFTERTAX, B.TOTALBEFORETAX, 
                            B.IGST, 
                            ROUND((B.IGST/100) * B.TOTALBEFORETAX,2) AS IGSTAMOUNT 
                            FROM BILLS B INNER JOIN PARTIES P ON B.PARTYID = P.ID
                            where b.BILLDATE >= @FROMDATE AND b.BILLDATE <= @TODATE
                            ORDER BY PARTYGST";
            }
            DataTable dt = new DataTable();
            myCmd.Parameters.Clear();
            myCmd.CommandText = query;
            myCmd.CommandType = CommandType.Text;
            var parameter = new SqlParameter("@FROMDATE", SqlDbType.DateTime);
            parameter.Value = fromDate;
            myCmd.Parameters.Add(parameter);
            parameter = new SqlParameter("@TODATE", SqlDbType.DateTime);
            parameter.Value = toDate;
            myCmd.Parameters.Add(parameter);
            myAdap.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows.Cast<DataRow>().Select(dr => new GstItem
                {
                    PartyGst = dr.Get("PARTYGST"),
                    InvoiceNumber = dr.Get("INVOICENUMBER"),
                    InvoiceDate = dr.Get("INVOICEDATE"),
                    TotalBeforeTax = dr.Get("TOTALBEFORETAX"),
                    IgstRate = dr.Get("IGST"),
                    IgstAmount = dr.Get("IGSTAMOUNT"),
                    TotalAfterTax = dr.Get("TOTALAFTERTAX")
                });
            }
            return null;
        }

        public int GetBillNo(string currAccYear, string runningYear, string address)
        {
            if (address != "")
            {
                if (currAccYear.Equals(runningYear))
                    myCmd.CommandText = "SELECT MAX(BILLNO) FROM BILLS WHERE ADDRESS ='" + address + "'";
                else
                    myCmd.CommandText = "SELECT MAX(BILLNO) FROM [BILLS" + currAccYear + "] WHERE ADDRESS ='" + address + "'";
                myCmd.CommandType = CommandType.Text;
                if (myCmd.Connection.State == ConnectionState.Closed)
                    myCmd.Connection.Open();
                object billnoObj = myCmd.ExecuteScalar();
                int billno = 0;
                if (!billnoObj.Equals(System.DBNull.Value))
                    billno = Convert.ToInt32(billnoObj);
                myCmd.Connection.Close();
                return billno;
            }
            else
                return 0;
        }
        public bool IsArchiveDone()
        {
            int currYear = DateTime.Now.Year;
            string prevAccYear = (currYear - 1) + "-" + currYear;
            myCmd.CommandText = "select count(1) from sys.tables where name = 'BILLS" + prevAccYear + "'";
            if (myCmd.Connection.State == ConnectionState.Closed)
                myCmd.Connection.Open();
            myCmd.CommandType = CommandType.Text;
            object tableCountCmdOutput = myCmd.ExecuteScalar();
            int tableCount = 0;
            if (!tableCountCmdOutput.Equals(System.DBNull.Value))
                tableCount = Convert.ToInt32(tableCountCmdOutput);
            if (tableCount > 0)
                return true;
            else
                return false;

        }
        public bool IsArchiveDone_old()
        {
            myCmd.CommandText = "SELECT MAX(BILLNO) FROM BILLS";
            if (myCmd.Connection.State == ConnectionState.Closed)
                myCmd.Connection.Open();
            myCmd.CommandType = CommandType.Text;
            object billnoObj = myCmd.ExecuteScalar();
            int billno = 0;
            if (!billnoObj.Equals(System.DBNull.Value))
                billno = Convert.ToInt32(billnoObj);
            myCmd.Connection.Close();
            if (billno > 0)
            {
                myCmd.CommandText = "SELECT BILLDATE FROM BILLS WHERE BILLNO = " + billno;
                myCmd.CommandType = CommandType.Text;
                if (myCmd.Connection.State == ConnectionState.Closed)
                    myCmd.Connection.Open();
                DateTime billDate = Convert.ToDateTime(myCmd.ExecuteScalar());
                myCmd.Connection.Close();
                if (billDate < DateTime.Parse("04/01/" + DateTime.Now.Year))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }
        public void CreateNewAccountingYear(string prevAccYear)
        {
            myCmd.CommandText = "[dbo].[SET_NEWACCOUNTINGYEARTABLES]";
            myCmd.CommandType = CommandType.StoredProcedure;
            if (myCmd.Parameters != null)
                myCmd.Parameters.Clear();
            SqlParameter param = new SqlParameter("ACCOUNTINGYEAR", SqlDbType.NVarChar, 50);
            param.Value = prevAccYear;
            myCmd.Parameters.Add(param);
            if (myCmd.Connection.State == ConnectionState.Closed)
                myCmd.Connection.Open();
            myCmd.ExecuteNonQuery();
            myCmd.Connection.Close();
        }
        public DataSet GetDDEntryBillData(string ADDRESS, string FROMDATE, string TODATE)//, string BILLTABLENAME, string BILLPAYMENTSTABLENAME)
        {
            myCmd.CommandText = "[dbo].[GET_DDENTRYBILLDATA]";
            myCmd.CommandType = CommandType.StoredProcedure;
            if (myCmd.Parameters != null)
                myCmd.Parameters.Clear();
            SqlParameter param = new SqlParameter("ADDRESS", SqlDbType.NVarChar, 50);
            param.Value = ADDRESS;
            myCmd.Parameters.Add(param);
            param = new SqlParameter("FROMDATE", SqlDbType.NVarChar, 50);
            param.Value = FROMDATE;
            myCmd.Parameters.Add(param);
            param = new SqlParameter("TODATE", SqlDbType.NVarChar, 50);
            param.Value = TODATE;
            myCmd.Parameters.Add(param);
            if (myCmd.Connection.State == ConnectionState.Closed)
                myCmd.Connection.Open();
            myAdap.SelectCommand = myCmd;
            DataSet ds = new DataSet();
            myAdap.Fill(ds);
            myCmd.Connection.Close();
            if (ds != null && ds.Tables.Count == 2)
            {
                ds.Tables[0].TableName = "BILLS";
                ds.Tables[1].TableName = "BILLPAYMENTS";
                DataColumn[] parentColumns = new DataColumn[3];
                parentColumns[0] = ds.Tables["BILLS"].Columns["BILLNO"];
                parentColumns[1] = ds.Tables["BILLS"].Columns["ADDRESS"];
                parentColumns[2] = ds.Tables["BILLS"].Columns["TABLENAME"];
                DataColumn[] childColumns = new DataColumn[3];
                childColumns[0] = ds.Tables["BILLPAYMENTS"].Columns["BILLNO"];
                childColumns[1] = ds.Tables["BILLPAYMENTS"].Columns["ADDRESS"];
                childColumns[2] = ds.Tables["BILLPAYMENTS"].Columns["PARENTTABLENAME"];
                ds.Relations.Add("FK_BILLS_BILLPAYMENTS", parentColumns, childColumns, false);
            }
            return ds;
        }
        public DataTable GetPendingListData(string ADDRESS, string FROMDATE, string TODATE)//, string BILLTABLENAME, string BILLPAYMENTSTABLENAME)
        {
            myCmd.CommandText = "[dbo].[GET_PENDINGLISTDATA]";
            myCmd.CommandType = CommandType.StoredProcedure;
            if (myCmd.Parameters != null)
                myCmd.Parameters.Clear();
            SqlParameter param = new SqlParameter("ADDRESS", SqlDbType.NVarChar, 50);
            param.Value = ADDRESS;
            myCmd.Parameters.Add(param);
            param = new SqlParameter("FROMDATE", SqlDbType.NVarChar, 50);
            param.Value = FROMDATE;
            myCmd.Parameters.Add(param);
            param = new SqlParameter("TODATE", SqlDbType.NVarChar, 50);
            param.Value = TODATE;
            myCmd.Parameters.Add(param);
            if (myCmd.Connection.State == ConnectionState.Closed)
                myCmd.Connection.Open();
            myAdap.SelectCommand = myCmd;
            DataTable dt = new DataTable();
            myAdap.Fill(dt);
            dt.Columns["BILLDT"].ColumnName = "BILLDATE";
            myCmd.Connection.Close();
            return dt;
        }
        public SqlCommand GetUpdateDDEntryCmd()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(myConn);
            cmd.CommandText = "dbo.SET_INSERTUPDATEBILLPAYMENTS";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BILLNO", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, "BILLNO", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ADDRESS", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "ADDRESS", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATE", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, 23, 3, "DATE", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@REMARKS", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "REMARKS", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MODE", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "MODE", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PARENTTABLENAME", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "PARENTTABLENAME", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PENDINGAMT", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, 53, 0, "PENDINGAMT", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CHNO", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, "CHNO", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CHDATE", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, 23, 3, "CHDATE", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CHBRANCH", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "CHBRANCH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CHAMOUNT", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, 53, 0, "CHAMOUNT", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            return cmd;
        }
        public SqlCommand GetInsertDDEntryCmd()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(myConn);
            cmd.CommandText = "dbo.SET_INSERTUPDATEBILLPAYMENTS";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BILLNO", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, "BILLNO", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ADDRESS", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "ADDRESS", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATE", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, 23, 3, "DATE", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@REMARKS", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "REMARKS", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MODE", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "MODE", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PARENTTABLENAME", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "PARENTTABLENAME", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PENDINGAMT", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, 53, 0, "PENDINGAMT", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CHNO", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, "CHNO", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CHDATE", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, 23, 3, "CHDATE", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CHBRANCH", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "CHBRANCH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CHAMOUNT", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, 53, 0, "CHAMOUNT", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            return cmd;
        }
        public SqlCommand GetDeleteDDEntryCmd()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(myConn);
            cmd.CommandText = "dbo.SET_DELETEBILLPAYMENTS";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BILLNO", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, "BILLNO", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ADDRESS", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "ADDRESS", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PARENTTABLENAME", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "PARENTTABLENAME", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            return cmd;
        }
        public void UpdateDDEntry(DataTable dt)
        {
            myAdap.UpdateCommand = GetUpdateDDEntryCmd();
            myAdap.InsertCommand = GetInsertDDEntryCmd();
            myAdap.DeleteCommand = GetDeleteDDEntryCmd();
            try
            {
                object affected = myAdap.Update(dt);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int DeleteBill(string address, int billno, string accountingYear)
        {
            myCmd.CommandText = "[dbo].[SET_DELETEBILLDATA]";
            myCmd.CommandType = CommandType.StoredProcedure;
            if (myCmd.Parameters != null)
                myCmd.Parameters.Clear();
            SqlParameter param = new SqlParameter("ADDRESS", SqlDbType.NVarChar, 50);
            param.Value = address;
            myCmd.Parameters.Add(param);
            param = new SqlParameter("BILLNO", SqlDbType.NVarChar, 50);
            param.Value = billno;
            myCmd.Parameters.Add(param);
            param = new SqlParameter("ACCOUNTINGYEAR", SqlDbType.NVarChar, 50);
            param.Value = accountingYear;
            myCmd.Parameters.Add(param);
            if (myCmd.Connection.State == ConnectionState.Closed)
                myCmd.Connection.Open();
            int val = myCmd.ExecuteNonQuery();
            myCmd.Connection.Close();
            return val;
        }
        private string TransformQuery(string query, string runningYear, string currAccYear)
        {
            if (query != "")
            {
                if (currAccYear == runningYear)
                {
                    query = query.Replace("BILLSTBL", "BILLS");
                    query = query.Replace("BILLPAYMENTSTBL", "BILLPAYMENTS");
                    query = query.Replace("BILLITEMSTBL", "BILLITEMS");
                }
                else
                {
                    query = query.Replace("BILLSTBL", "[BILLS" + currAccYear + "]");
                    query = query.Replace("BILLPAYMENTSTBL", "[BILLPAYMENTS" + currAccYear + "]");
                    query = query.Replace("BILLITEMSTBL", "[BILLITEMS" + currAccYear + "]");
                }
            }
            return query;
        }
        public DataTable GetQueryData(string query, string runningYear, string currAccYear)
        {
            query = TransformQuery(query, runningYear, currAccYear);
            myCmd.CommandText = query;
            myCmd.CommandType = CommandType.Text;
            if (myCmd.Connection.State == ConnectionState.Closed)
                myCmd.Connection.Open();
            myAdap.SelectCommand = myCmd;
            DataTable dt = new DataTable();
            myAdap.Fill(dt);
            myCmd.Connection.Close();
            return dt;
        }
        public object GetScalarData(string query, string runningYear, string currAccYear)
        {
            query = TransformQuery(query, runningYear, currAccYear);
            myCmd.CommandText = query;
            myCmd.CommandType = CommandType.Text;
            if (myCmd.Connection.State == ConnectionState.Closed)
                myCmd.Connection.Open();
            object rslt = myCmd.ExecuteScalar();
            myCmd.Connection.Close();
            return rslt;
        }
        public ReportConfiguration CacheConfigDom()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(ReportConfiguration));
            // To read the file, create a FileStream.
            FileStream myFileStream = new FileStream("ReportsConfig.xml", FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            ReportConfiguration configObj = (ReportConfiguration)mySerializer.Deserialize(myFileStream);
            if (configObj != null)
            {
                BuildLinks(configObj);
            }
            return configObj;
        }

        private void BuildLinks(ReportConfiguration configObj)
        {
            foreach (Report reportObj in configObj.Report)
            {
                foreach (ChartType chartObj in reportObj.ChartType)
                {
                    SetParent(chartObj);
                }
            }
        }
        private void SetParent(ChartType chart)
        {
            if (chart.ChartType1 != null)
            {
                chart.ChartType1.Parent = chart;
                SetParent(chart.ChartType1);
            }
            else
                return;
        }
    }
}

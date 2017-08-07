using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BillingApplication.Models;
using System.Data.SqlClient;

namespace BillingApplication
{
    public class DeliveryItemsDataContext
    {
        static string myConn = "";
        static SqlDataAdapter myAdap = null;
        static SqlCommand myCmd = null;

        static DeliveryItemsDataContext()
        {
            myConn = System.Configuration.ConfigurationManager.ConnectionStrings["BillingApplication.Properties.Settings.companyConn"].ConnectionString;
            myAdap = new SqlDataAdapter();
            myCmd = new SqlCommand();
            myCmd.Connection = new SqlConnection(myConn);
            myAdap.SelectCommand = myCmd;
        }

        public static string GetAccountingYearFromDate(DateTime deliveryDate)
        {
            if (deliveryDate.Year == DateTime.Now.Year && deliveryDate.Month > 3)
            {
                return "";
            }
            if (deliveryDate.Month > 3)
            {
                return deliveryDate.Year + "-" + deliveryDate.Year + 1;
            }
            return deliveryDate.Year -1 + "-" + deliveryDate.Year;
        }

        public static List<DeliveryEntity> GetDeliveryItems(DateTime? deliveryDate1)
        {
            var deliveryDate = Common.NextBusinessDay();
            if (deliveryDate1.HasValue)
                deliveryDate = deliveryDate1.Value;
            var query = @";WITH CTE AS
                            (
	                            SELECT *, ROW_NUMBER() OVER (PARTITION BY BILLNO ORDER BY ITEMNO) AS RN
	                            FROM [BILLITEMS" + GetAccountingYearFromDate(deliveryDate) + @"]
                            )
                            SELECT B.BILLNO, B.ADDRESS, A.GST, B.BALENO, B.FWDBY, B.FWDTO, P.NAME AS PARTYNAME, P.ADDR1 AS PARTYADDR1, P.ADDR2 AS PARTYADDR2, P.CITY AS PARTYCITY,P.STATE AS PARTYSTATE,P.PIN AS PARTYPIN, P.GST AS PARTYGST,
                            B.BILLNO AS INVOICENUMBER, B.BILLDATE AS INVOICEDATE,
                            B.PARTICULARS AS PARTICULARSDESCR, B.TOTALMTRS AS PARTICULARSTOTALMTRS , B.TOTALQTY AS PARTICULARSNETQTY,B.TOTALBEFORETAX AS TOTALAMOUNTBEFORETAX, B.IGST, (B.TOTALBEFORETAX * (B.IGST/100)) AS IGSTAMOUNT, B.TOTALAFTERTAX AS TOTALBILLVALUE,
                            CTE.HSN AS HSN
                            FROM [BILLS" + GetAccountingYearFromDate(deliveryDate) + @"] B
                            INNER JOIN ADDRESS A ON B.ADDRESS = A.NAME 
                            INNER JOIN PARTIES P ON P.ID = B.PARTYID
                            INNER JOIN CTE ON CTE.BILLNO = B.BILLNO AND CTE.RN = 1
                            WHERE CONVERT(VARCHAR(10), B.BILLDATE, 103) = CONVERT(VARCHAR(10), @BILLDATE, 103)
                            ORDER BY b.ADDRESS, b.BILLNO";
            myCmd.CommandText = query;
            myCmd.CommandType = CommandType.Text;
            if (myCmd.Parameters != null)
                myCmd.Parameters.Clear();
            SqlParameter param = new SqlParameter("BILLDATE", SqlDbType.DateTime);
            param.Value = deliveryDate;
            myCmd.Parameters.Add(param);
            if (myCmd.Connection.State == ConnectionState.Closed)
                myCmd.Connection.Open();
            myAdap.SelectCommand = myCmd;
            DataTable dt = new DataTable();
            myAdap.Fill(dt);
            myCmd.Connection.Close();
            List<DeliveryEntity> deliveryEntries = new List<DeliveryEntity>();
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var totalMtrsPairsHeader = "";
                    if (dr["PARTICULARSTOTALMTRS"] != null && dr["PARTICULARSTOTALMTRS"].ToString().Trim() != "" && Convert.ToDecimal(dr["PARTICULARSTOTALMTRS"]) > 0)
                    {
                        totalMtrsPairsHeader = "Total Meters";
                    }
                    else
                    {
                        totalMtrsPairsHeader = "Total Pairs ";
                    }
                    var totalMtrsPairsValue = "";
                    if (dr["PARTICULARSTOTALMTRS"] != null && dr["PARTICULARSTOTALMTRS"].ToString().Trim() != "" && Convert.ToDecimal(dr["PARTICULARSTOTALMTRS"]) > 0)
                    {
                        totalMtrsPairsValue = Convert.ToString(dr["PARTICULARSTOTALMTRS"]);
                    }
                    else
                    {
                        totalMtrsPairsValue = Convert.ToString(dr["PARTICULARSNETQTY"]);
                    }
                    var data = new DeliveryEntity
                    {
                        IsSelected = true,
                        MerchantName = Convert.ToString(dr["ADDRESS"]),
                        Gst = Convert.ToString(dr["GST"]),
                        BaleNo = Convert.ToString(dr["BALENO"]),
                        Transport = Convert.ToString(dr["FWDBY"]),
                        BookedTo = Convert.ToString(dr["FWDTO"]),
                        Party = new Party
                        {
                            Name = Convert.ToString(dr["PARTYNAME"]),
                            Addr1 = Convert.ToString(dr["PARTYADDR1"]),
                            Addr2 = Convert.ToString(dr["PARTYADDR2"]),
                            City = Convert.ToString(dr["PARTYCITY"]),
                            State = Convert.ToString(dr["PARTYSTATE"]),
                            Pin = Convert.ToString(dr["PARTYPIN"]),
                            Gst = Convert.ToString(dr["PARTYGST"])
                        },
                        Invoice = new Invoice
                        {
                            Number = "G-" + Convert.ToString(dr["BILLNO"]),
                            Date = Common.GetDate(deliveryDate)
                        },
                        Particulars = new Particulars
                        {
                            Description = Convert.ToString(dr["PARTICULARSDESCR"]),
                            TotalPairsMtrsKey = totalMtrsPairsHeader,
                            TotalPairsMtrsValue = totalMtrsPairsValue,
                            HSN = Convert.ToString(dr["HSN"]),
                            TotalAmount = Convert.ToString(dr["TOTALAMOUNTBEFORETAX"]),
                            IgstAmount = RoundOff(dr["IGSTAMOUNT"]),
                            IgstPercent = Convert.ToString(dr["IGST"]),
                            TotalBillValue = RoundOff(dr["TOTALBILLVALUE"]),
                        }
                    };
                    deliveryEntries.Add(data);
                };

            }
            return deliveryEntries;
        }

        public static string RoundOff(object val)
        {
            if (val.GetType() == typeof(DBNull))
                return "0";
            var valDecimal = Convert.ToDecimal(val);
            var roundedVal = Math.Round(valDecimal, 0, MidpointRounding.AwayFromZero);
            return Convert.ToString(roundedVal);
        }
    }
}

﻿USE [Company]
GO
/****** Object:  StoredProcedure [dbo].[SET_UPDATEBILLDATA]    Script Date: 07-08-2017 18:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mohan
-- Create date: 19-Dec-2007
-- Description:	Update the bill table
-- =============================================
ALTER PROCEDURE [dbo].[SET_UPDATEBILLDATA] @ACCOUNTINGYEAR NVARCHAR(50),@BILLNO INT,@ADDRESS NVARCHAR(50),@BILLDATE DATETIME,@PARTYID INT,
@LRDATE DATETIME,@TOTALWOCD FLOAT,@BALANCE FLOAT,@ITEMPIN BIT,@BALENO NVARCHAR(50),@ORDERNO NVARCHAR(50),@ORDERDATE DATETIME,@FWDBY NVARCHAR(50),
@FWDTO NVARCHAR(50),@AGENT NVARCHAR(50),@LRNO NVARCHAR(50),@DOCSENTMODE NVARCHAR(50),@TOTALMTRS FLOAT, @TOTALQTY INT, @FWDCHARGES FLOAT,@CDDAYS INT,
@CDPERCENT FLOAT,@PIN FLOAT,@CDTXT FLOAT, @SGST FLOAT, @CGST FLOAT, @IGST FLOAT, @TOTALAFTERTAX FLOAT, @PARTICULARS NVARCHAR(1000), @TOTALBEFORETAX FLOAT
AS
BEGIN
	DECLARE @SQLSTMT NVARCHAR(4000);
	DECLARE @CRACCOUNTINGYEAR INT;
	DECLARE @BILLTABLENAME NVARCHAR(50);
	SET @CRACCOUNTINGYEAR = LEN(RTRIM(LTRIM(@ACCOUNTINGYEAR)));
	IF(@CRACCOUNTINGYEAR > 0)
		SET @BILLTABLENAME = '[BILLS' + @ACCOUNTINGYEAR + ']';
	ELSE
		SET @BILLTABLENAME = 'BILLS';
	SET @SQLSTMT = 'UPDATE ' + @BILLTABLENAME + ' SET BILLDATE = ''' + CONVERT(NVARCHAR(10),@BILLDATE,101) + ''',PARTYID = ' + CONVERT(NVARCHAR(10),@PARTYID) +
				   ',LRDATE = ''' + CONVERT(NVARCHAR(10),@LRDATE,101) + ''',TOTALWOCD = ' + CONVERT(NVARCHAR(10),@TOTALWOCD) +
				   ',BALANCE = ' + CONVERT(NVARCHAR(10),@BALANCE) + ',ITEMPIN = ' + CONVERT(NVARCHAR(10),@ITEMPIN) + ',BALENO = ''' + @BALENO + '''';
	IF(@ORDERNO IS NOT NULL AND LEN(RTRIM(LTRIM(@ORDERNO))) > 0)
		SET @SQLSTMT = @SQLSTMT + ',ORDERNO = ''' + @ORDERNO + '''';
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',ORDERNO = NULL';
	IF(@ORDERDATE IS NOT NULL)
		SET @SQLSTMT = @SQLSTMT + ',ORDERDATE = ''' + CONVERT(NVARCHAR(10),@ORDERDATE,101) + '''';
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',ORDERDATE = NULL';
	IF(@FWDBY IS NOT NULL AND LEN(RTRIM(LTRIM(@FWDBY))) > 0)
		SET @SQLSTMT = @SQLSTMT + ',FWDBY = ''' + @FWDBY + '''';
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',FWDBY = NULL';
	IF(@FWDTO IS NOT NULL AND LEN(RTRIM(LTRIM(@FWDTO))) > 0)
		SET @SQLSTMT = @SQLSTMT + ',FWDTO = ''' + @FWDTO + '''';
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',FWDTO = NULL';
	IF(@AGENT IS NOT NULL AND LEN(RTRIM(LTRIM(@AGENT))) > 0)
		SET @SQLSTMT = @SQLSTMT + ',AGENT = ''' + @AGENT + '''';
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',AGENT = NULL';
	IF(@LRNO IS NOT NULL AND LEN(RTRIM(LTRIM(@LRNO))) > 0)
		SET @SQLSTMT = @SQLSTMT + ',LRNO = ''' + @LRNO + '''';
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',LRNO = NULL';
	IF(@DOCSENTMODE IS NOT NULL AND LEN(RTRIM(LTRIM(@DOCSENTMODE))) > 0)
		SET @SQLSTMT = @SQLSTMT + ',DOCSENTMODE = ''' + @DOCSENTMODE + '''';
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',DOCSENTMODE = NULL';
	IF(@TOTALMTRS IS NOT NULL AND @TOTALMTRS > 0)
		SET @SQLSTMT = @SQLSTMT + ',TOTALMTRS = ' + CONVERT(NVARCHAR(10),@TOTALMTRS);
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',TOTALMTRS = NULL';
	IF(@TOTALQTY IS NOT NULL AND @TOTALQTY > 0)
		SET @SQLSTMT = @SQLSTMT + ',TOTALQTY = ' + CONVERT(NVARCHAR(10),@TOTALQTY);
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',TOTALQTY = NULL';
	IF(@FWDCHARGES IS NOT NULL AND @FWDCHARGES > 0)
		SET @SQLSTMT = @SQLSTMT + ',FWDCHARGES = ' + CONVERT(NVARCHAR(10),@FWDCHARGES);
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',FWDCHARGES = NULL';
	IF(@CDDAYS IS NOT NULL AND @CDDAYS > 0)
		SET @SQLSTMT = @SQLSTMT + ',CDDAYS = ' + CONVERT(NVARCHAR(10),@CDDAYS);
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',CDDAYS = NULL';
	IF(@CDPERCENT IS NOT NULL AND @CDPERCENT > 0)
		SET @SQLSTMT = @SQLSTMT + ',CDPERCENT = ' + CONVERT(NVARCHAR(10),@CDPERCENT);
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',CDPERCENT = NULL';
	--
	IF(@SGST IS NOT NULL AND @SGST > 0)
		SET @SQLSTMT = @SQLSTMT + ',SGST = ' + CONVERT(NVARCHAR(10),@SGST);
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',SGST = NULL';
	IF(@CGST IS NOT NULL AND @CGST > 0)
		SET @SQLSTMT = @SQLSTMT + ',CGST = ' + CONVERT(NVARCHAR(10),@CGST);
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',CGST = NULL';
	IF(@IGST IS NOT NULL AND @IGST > 0)
		SET @SQLSTMT = @SQLSTMT + ',IGST = ' + CONVERT(NVARCHAR(10),@IGST);
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',IGST = NULL';
	IF(@TOTALAFTERTAX IS NOT NULL AND @TOTALAFTERTAX > 0)
		SET @SQLSTMT = @SQLSTMT + ',TOTALAFTERTAX = ' + CONVERT(NVARCHAR(10),@TOTALAFTERTAX);
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',TOTALAFTERTAX = NULL';
	IF(@TOTALBEFORETAX IS NOT NULL AND @TOTALBEFORETAX > 0)
		SET @SQLSTMT = @SQLSTMT + ',TOTALBEFORETAX = ' + CONVERT(NVARCHAR(10),@TOTALBEFORETAX);
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',TOTALBEFORETAX = NULL';
	--
	IF(@PIN IS NOT NULL AND @PIN > 0)
		SET @SQLSTMT = @SQLSTMT + ',PIN = ' + CONVERT(NVARCHAR(10),@PIN);
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',PIN = NULL';
	IF(@CDTXT IS NOT NULL AND @CDTXT > 0)
		SET @SQLSTMT = @SQLSTMT + ',CDTXT = ' + CONVERT(NVARCHAR(10),@CDTXT);
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',CDTXT = NULL';
	IF(@PARTICULARS IS NOT NULL AND LEN(RTRIM(LTRIM(@PARTICULARS))) > 0)
		SET @SQLSTMT = @SQLSTMT + ',PARTICULARS = ''' + @PARTICULARS + '''';
	ELSE
		SET @SQLSTMT = @SQLSTMT + ',PARTICULARS = NULL';
	SET @SQLSTMT = @SQLSTMT + ' WHERE BILLNO = ' + CONVERT(NVARCHAR(5),@BILLNO) + ' AND ADDRESS = ''' + @ADDRESS + '''';
	--insert into test (stmt) values (@SQLSTMT);
	EXECUTE sp_executesql @SQLSTMT;
END

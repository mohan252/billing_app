﻿USE [Company]
GO
/****** Object:  StoredProcedure [dbo].[GET_PENDINGLISTDATA]    Script Date: 11-08-2017 22:13:18 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER PROCEDURE [dbo].[GET_PENDINGLISTDATA]
(@ADDRESS varchar(50), @FROMDATE varchar(50), @TODATE varchar(50))--@AGENT varchar(50), @PARTY varchar(50),
AS
BEGIN

DECLARE @BILLSQLSTMT NVARCHAR(MAX);
DECLARE @BILLTABLENAME NVARCHAR(50);
DECLARE @BILLPAYMENTTABLENAME NVARCHAR(50);
DECLARE @TMPBILLSQLSTMT NVARCHAR(4000);
DECLARE @TMPBILLPAYMENTSSQLSTMT NVARCHAR(4000);
DECLARE CBILLS CURSOR READ_ONLY
FOR
SELECT BILLTABLE,BILLPAYMENTSTABLE FROM OLDBILLTABLES;

SET @BILLTABLENAME = 'BILLS';
SET @BILLPAYMENTTABLENAME = 'BILLPAYMENTS';
SET @BILLSQLSTMT = [dbo].[GET_PENDINGLISTQUERY](@ADDRESS,@FROMDATE, @TODATE,@BILLTABLENAME,@BILLPAYMENTTABLENAME);

OPEN CBILLS
FETCH NEXT FROM CBILLS INTO @BILLTABLENAME,@BILLPAYMENTTABLENAME
WHILE @@FETCH_STATUS = 0
BEGIN
	SET @TMPBILLSQLSTMT = [dbo].[GET_PENDINGLISTQUERY](@ADDRESS,@FROMDATE, @TODATE,@BILLTABLENAME,@BILLPAYMENTTABLENAME);
	SET @BILLSQLSTMT = @BILLSQLSTMT + ' UNION ' + @TMPBILLSQLSTMT;
	FETCH NEXT FROM CBILLS INTO @BILLTABLENAME,@BILLPAYMENTTABLENAME
END
CLOSE CBILLS
DEALLOCATE CBILLS

SET @BILLSQLSTMT = 'SELECT BS1.BILLNO,CONVERT(CHAR(10),BS1.BILLDATE,3) AS BILLDT,BS1.PLACE,BS1.PARTY,BS1.AGENT,BS1.TOTALWOCD,BS1.TOTALBEFORETAX, BS1.IGST, BS1.TOTALAFTERTAX,BS1.PENDINGAMT FROM(' 
					+ @BILLSQLSTMT + ') AS BS1 ORDER BY BILLDATE,BILLNO';
--INSERT INTO TEST (STMT) VALUES(@BILLSQLSTMT);
EXECUTE sp_executesql @BILLSQLSTMT;
END

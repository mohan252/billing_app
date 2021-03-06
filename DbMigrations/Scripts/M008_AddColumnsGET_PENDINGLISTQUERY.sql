﻿USE [Company]
GO
/****** Object:  UserDefinedFunction [dbo].[GET_PENDINGLISTQUERY]    Script Date: 11-08-2017 22:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mohan
-- Create date: 22 Dec 2007
-- Description:	get sql statement for bills table
-- =============================================
ALTER FUNCTION [dbo].[GET_PENDINGLISTQUERY]
(@ADDRESS varchar(50), @FROMDATE varchar(50), @TODATE varchar(50), @BILLSTABLENAME varchar(50),@BILLPAYMENTSTABLENAME varchar(50))--, @AGENT varchar(50), @PARTY varchar(50)
RETURNS NVARCHAR(4000)
AS
BEGIN
	DECLARE @SQLSTMT NVARCHAR(4000);
	SET @SQLSTMT = 'SELECT BS.BILLNO,BS.BILLDATE,BS.PLACE,BS.PARTY,BS.AGENT,BS.TOTALWOCD,BS.TOTALBEFORETAX, BS.IGST, BS.TOTALAFTERTAX,BP.PENDINGAMT FROM
	(SELECT B.BILLNO, B.BILLDATE, P.CITY AS PLACE,P.NAME as PARTY,B.AGENT,ROUND(B.TOTALWOCD,0) AS TOTALWOCD,B.TOTALBEFORETAX, B.IGST, B.TOTALAFTERTAX
	FROM ' + @BILLSTABLENAME + ' AS B,PARTIES P WHERE     
	(P.ID = B.PARTYID) AND 
	(B.ADDRESS = ''' + @ADDRESS + ''')'
	IF (@FROMDATE IS NOT NULL AND @FROMDATE != '')
		SET @SQLSTMT = @SQLSTMT + ' AND B.BILLDATE >= (CONVERT(datetime, ''' + @FROMDATE + ''', 103))';
	IF (@TODATE IS NOT NULL AND @TODATE != '')
		SET @SQLSTMT = @SQLSTMT + ' AND B.BILLDATE <= (CONVERT(datetime, ''' + @TODATE + ''', 103))';
	SET @SQLSTMT = @SQLSTMT + ' AND B.BILLNO NOT IN (SELECT BILLNO FROM ' + @BILLPAYMENTSTABLENAME + '  WHERE ADDRESS = ''' + @ADDRESS + ''' AND PENDINGAMT IS NULL)) AS BS
	LEFT OUTER JOIN 
	(SELECT BILLNO,PENDINGAMT FROM ' + @BILLPAYMENTSTABLENAME + ' WHERE PENDINGAMT IS NOT NULL AND ADDRESS = ''' + @ADDRESS + ''') AS BP
	ON BS.BILLNO = BP.BILLNO';
	RETURN @SQLSTMT;
END

USE [Company]
GO
/****** Object:  StoredProcedure [dbo].[GET_BILLITEMSDATA]    Script Date: 17-07-2017 04:22:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mohan
-- Create date: 19 Dec 2007
-- Description:	Get bill items data
-- =============================================
ALTER PROCEDURE [dbo].[GET_BILLITEMSDATA] @BILLNO INT,@ADDRESS NVARCHAR(50),@ACCOUNTINGYEAR NVARCHAR(50)
AS
BEGIN
	DECLARE @SQLSTMT NVARCHAR(4000);
	DECLARE @CRACCOUNTINGYEAR INT;
	DECLARE @BILLITEMSTABLENAME NVARCHAR(50);
	SET @CRACCOUNTINGYEAR = LEN(RTRIM(LTRIM(@ACCOUNTINGYEAR)));
	IF(@CRACCOUNTINGYEAR > 0)
		SET @BILLITEMSTABLENAME = '[BILLITEMS' + @ACCOUNTINGYEAR + ']';
	ELSE
		SET @BILLITEMSTABLENAME = 'BILLITEMS';
	SET @SQLSTMT = 'SELECT ITEMID,STAMP,RATE,QTY,MTRS,AMT,BILLNO, ADDRESS, PIN,PINNINGLESS,''' + @ACCOUNTINGYEAR  + ''' AS ACCOUNTINGYEAR,ITEMNO, HSN
					  FROM ' +  @BILLITEMSTABLENAME + ' 
					  WHERE     (BILLNO = ' + CONVERT(NVARCHAR(10),@BILLNO) + ') AND (ADDRESS = ''' + @ADDRESS + ''') ORDER BY ITEMNO'
	--insert into test (stmt) values (@SQLSTMT);
	EXECUTE sp_executesql @SQLSTMT;
END



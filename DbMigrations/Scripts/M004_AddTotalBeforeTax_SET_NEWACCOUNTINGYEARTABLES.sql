﻿USE [Company]
GO
/****** Object:  StoredProcedure [dbo].[SET_NEWACCOUNTINGYEARTABLES]    Script Date: 07-08-2017 18:00:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mohan
-- Create date: 18 Dec 2007
-- Description:	Archive the current accounting year tables
-- =============================================
ALTER PROCEDURE [dbo].[SET_NEWACCOUNTINGYEARTABLES] @ACCOUNTINGYEAR NVARCHAR(50)
AS
BEGIN TRY
DECLARE @SQLSTMT NVARCHAR(4000);
DECLARE @BILLTABLENAME NVARCHAR(50);
DECLARE @BILLITEMSTABLENAME NVARCHAR(50);
DECLARE @BILLDISCOUNTSTABLENAME NVARCHAR(50);
DECLARE @BILLPAYMENTSTABLENAME NVARCHAR(50);
SET @BILLTABLENAME = 'BILLS' + @ACCOUNTINGYEAR;
SET @BILLITEMSTABLENAME = 'BILLITEMS' + @ACCOUNTINGYEAR;
SET @BILLDISCOUNTSTABLENAME = 'BILLDISCOUNTS' + @ACCOUNTINGYEAR;
SET @BILLPAYMENTSTABLENAME = 'BILLPAYMENTS' + @ACCOUNTINGYEAR;
BEGIN TRANSACTION    -- Start the transaction
SET @SQLSTMT =
'CREATE TABLE [dbo].[' + @BILLTABLENAME + '] (
[BILLNO] int NOT NULL,
[ADDRESS] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[BILLDATE] datetime NOT NULL,
[PARTYID] int NOT NULL,
[ORDERNO] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ORDERDATE] datetime NULL,
[FWDBY] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FWDTO] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AGENT] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LRNO] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LRDATE] datetime NOT NULL,
[DOCSENTMODE] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TOTALWOCD] float NOT NULL,
[TOTALMTRS] float NULL,
[TOTALQTY] int NULL,
[FWDCHARGES] float NULL,
[BALANCE] float NOT NULL,
[CDDAYS] int NULL,
[CDPERCENT] float NULL,
[PIN] float NULL,
[SGST] float NULL,
[CGST] float NULL,
[IGST] float NULL,
[TOTALAFTERTAX] float NULL,
[TOTALBEFORETAX] float NULL,
[ITEMPIN] bit DEFAULT ((0)) NOT NULL,
[CDTXT] float NULL,
[PARTICULARS] nvarchar(1000) NULL,
[BALENO] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
PRIMARY KEY CLUSTERED ([BILLNO] ASC, [ADDRESS] ASC)
WITH ( PAD_INDEX = OFF,FILLFACTOR = 100,IGNORE_DUP_KEY = OFF,STATISTICS_NORECOMPUTE = OFF,ALLOW_ROW_LOCKS = ON,ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY],
FOREIGN KEY ([ADDRESS])
REFERENCES [dbo].[ADDRESS] ( [NAME] ),
FOREIGN KEY ([AGENT])
REFERENCES [dbo].[AGENTS] ( [NAME] ),
FOREIGN KEY ([PARTYID])
REFERENCES [dbo].[PARTIES] ( [ID] )
)
ON [PRIMARY]';
EXECUTE sp_executesql @SQLSTMT;
SET @SQLSTMT = 'INSERT INTO [' + @BILLTABLENAME + '] (BILLNO,ADDRESS,BILLDATE,PARTYID,ORDERNO,ORDERDATE,FWDBY,FWDTO,AGENT,LRNO,LRDATE,DOCSENTMODE,TOTALWOCD,TOTALMTRS,TOTALQTY,FWDCHARGES,BALANCE,CDDAYS,CDPERCENT,PIN,ITEMPIN,CDTXT,BALENO,PARTICULARS,CGST,SGST,IGST,TOTALAFTERTAX,TOTALBEFORETAX) SELECT BILLNO,ADDRESS,BILLDATE,PARTYID,ORDERNO,ORDERDATE,FWDBY,FWDTO,AGENT,LRNO,LRDATE,DOCSENTMODE,TOTALWOCD,TOTALMTRS,TOTALQTY,FWDCHARGES,BALANCE,CDDAYS,CDPERCENT,PIN,ITEMPIN,CDTXT,BALENO,PARTICULARS,CGST,SGST,IGST,TOTALAFTERTAX,TOTALBEFORETAX FROM BILLS';
EXECUTE sp_executesql @SQLSTMT;
print '1';
SET @SQLSTMT = '
CREATE TABLE [dbo].[' + @BILLITEMSTABLENAME + '] (
[ITEMID] int NOT NULL,
[STAMP] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[RATE] float NOT NULL,
[QTY] int NOT NULL,
[MTRS] ntext COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AMT] float NOT NULL,
[BILLNO] int NOT NULL,
[ADDRESS] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PIN] float NULL,
[PINNINGLESS] float NULL,
[ITEMNO] int NULL,
[HSN] nvarchar(100),
FOREIGN KEY ([ITEMID])
REFERENCES [dbo].[ITEMS] ( [ID] ),
FOREIGN KEY ([BILLNO], [ADDRESS])
REFERENCES [dbo].[' + @BILLTABLENAME + '] ( [BILLNO], [ADDRESS] ),
PRIMARY KEY CLUSTERED ([ITEMID] ASC,[RATE] ASC, [BILLNO] ASC, [ADDRESS] ASC)
WITH ( PAD_INDEX = OFF,FILLFACTOR = 100,IGNORE_DUP_KEY = OFF,STATISTICS_NORECOMPUTE = OFF,ALLOW_ROW_LOCKS = ON,ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY],
)ON [PRIMARY]';
EXECUTE sp_executesql @SQLSTMT;
SET @SQLSTMT = 'INSERT INTO [' + @BILLITEMSTABLENAME + '] (ITEMID,STAMP,RATE,QTY,MTRS,AMT,BILLNO,ADDRESS,PIN,PINNINGLESS,ITEMNO,HSN) SELECT ITEMID,STAMP,RATE,QTY,MTRS,AMT,BILLNO,ADDRESS,PIN,PINNINGLESS,ITEMNO,HSN FROM BILLITEMS';
EXECUTE sp_executesql @SQLSTMT;
print '2';
SET @SQLSTMT = '
CREATE TABLE [dbo].[' + @BILLDISCOUNTSTABLENAME + '] (
[NAME] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[VALUE] float NOT NULL,
[BILLNO] int NOT NULL,
[ADDRESS] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
PRIMARY KEY CLUSTERED ([NAME] ASC, [BILLNO] ASC, [ADDRESS] ASC),
FOREIGN KEY ([BILLNO], [ADDRESS])
REFERENCES [dbo].[' + @BILLTABLENAME + '] ( [BILLNO], [ADDRESS] )
)';
EXECUTE sp_executesql @SQLSTMT;
SET @SQLSTMT = 'INSERT INTO [' + @BILLDISCOUNTSTABLENAME + '] (NAME,VALUE,BILLNO,ADDRESS) SELECT NAME,VALUE,BILLNO,ADDRESS FROM BILLDISCOUNTS';
EXECUTE sp_executesql @SQLSTMT;
print '3';
SET @SQLSTMT = '
CREATE TABLE [dbo].['+ @BILLPAYMENTSTABLENAME + '] (
[BILLNO] int NOT NULL,
[ADDRESS] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DATE] datetime NULL,
[REMARKS] nvarchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MODE] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PENDINGAMT] float NULL,
[CHNO] int NULL,
[CHBRANCH] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CHDATE] datetime NULL,
[CHAMOUNT] float NULL,
PRIMARY KEY CLUSTERED ([BILLNO] ASC, [ADDRESS] ASC)
WITH ( PAD_INDEX = OFF,FILLFACTOR = 100,IGNORE_DUP_KEY = OFF,STATISTICS_NORECOMPUTE = OFF,ALLOW_ROW_LOCKS = ON,ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY],
FOREIGN KEY ([BILLNO], [ADDRESS])
REFERENCES [dbo].[' + @BILLTABLENAME + '] ( [BILLNO], [ADDRESS] )
) ON [PRIMARY]';
EXECUTE sp_executesql @SQLSTMT;
SET @SQLSTMT = 'INSERT INTO [' + @BILLPAYMENTSTABLENAME + '] (BILLNO,ADDRESS,DATE,REMARKS,MODE,PENDINGAMT,CHNO,CHBRANCH,CHDATE,CHAMOUNT) SELECT BILLNO,ADDRESS,DATE,REMARKS,MODE,PENDINGAMT,CHNO,CHBRANCH,CHDATE,CHAMOUNT FROM BILLPAYMENTS';
EXECUTE sp_executesql @SQLSTMT;
print '4';
SET @SQLSTMT = 'INSERT INTO OLDBILLTABLES (BILLTABLE,BILLITEMSTABLE,BILLDISCOUNTSTABLE,BILLPAYMENTSTABLE,ACCOUNTINGYEAR) VALUES(''['+ @BILLTABLENAME + ']'',''[' + @BILLITEMSTABLENAME + ']'',''[' + @BILLDISCOUNTSTABLENAME + ']'',''[' + @BILLPAYMENTSTABLENAME + ']'',''' + @ACCOUNTINGYEAR + ''')';
print @SQLSTMT;
--insert into test (stmt) values (@SQLSTMT);
EXECUTE sp_executesql @SQLSTMT;
print '5';
DELETE FROM BILLITEMS;
DELETE FROM BILLDISCOUNTS;
DELETE FROM BILLPAYMENTS;
DELETE FROM BILLS;
COMMIT
END TRY
BEGIN CATCH
  -- Whoops, there was an error
  IF @@TRANCOUNT > 0
    ROLLBACK
  -- Raise an error with the details of the exception
  DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
  SELECT @ErrMsg = ERROR_MESSAGE(),
         @ErrSeverity = ERROR_SEVERITY()
  INSERT INTO TEST (STMT) VALUES ('ERROR : '+ @ErrMsg + ':' + @ErrSeverity);
  RAISERROR(@ErrMsg, @ErrSeverity, 1)
END CATCH
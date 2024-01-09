USE [Company]
GO

/****** Object:  Table [dbo].[BILLITEMS]    Script Date: 9/17/2019 3:29:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DEBIT_NOTE_ITEMS](
	[ACCOUNTING_YEAR] [nvarchar](50) NOT NULL,
	[DEBITNOTENO] [int] not null,
	[ADDRESS] [nvarchar](50) NOT NULL,
	[ITEMID] [int] NOT NULL,
	[RATE] real NOT NULL,
	[QTY] [int] NOT NULL,
	[MTRS] real NULL
 CONSTRAINT [PK_DEBITNOTEITEMS] PRIMARY KEY CLUSTERED 
(	
	[ACCOUNTING_YEAR] ASC,
	[DEBITNOTENO] ASC,
	[ADDRESS] ASC,
	[ITEMID] ASC	
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DEBIT_NOTE_ITEMS]  WITH CHECK ADD  CONSTRAINT [FK_DEBIT_NOTE_ITEMS_DEBIT_NOTE] FOREIGN KEY([DEBITNOTENO],[ADDRESS],[ACCOUNTING_YEAR])
REFERENCES [dbo].[DEBIT_NOTE] ([NO], [ADDRESS], [ACCOUNTING_YEAR])
GO

ALTER TABLE [dbo].[DEBIT_NOTE_ITEMS] CHECK CONSTRAINT [FK_DEBIT_NOTE_ITEMS_DEBIT_NOTE]
GO

ALTER TABLE [dbo].[DEBIT_NOTE_ITEMS]  WITH CHECK ADD  CONSTRAINT [FK_dbo_DEBITE_NOTE_ITEMS_ITEMS] FOREIGN KEY([ITEMID])
REFERENCES [dbo].[ITEMS] ([ID])
GO

ALTER TABLE [dbo].[DEBIT_NOTE_ITEMS] CHECK CONSTRAINT [FK_dbo_DEBITE_NOTE_ITEMS_ITEMS]
GO


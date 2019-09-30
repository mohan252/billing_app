SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DEBIT_NOTE](
	[ACCOUNTING_YEAR] [nvarchar](50) NOT NULL,
	[NO] [int] NOT NULL,
	[ADDRESS] [nvarchar](50) NOT NULL,
	[DATE] [date] NOT NULL,
	[PARTYID] [int] NOT NULL,
	[SUPPLIER_REF] [nvarchar](50) NOT NULL,
	[SUPPLIER_DATE] [date] NOT NULL,
	[OTHER_REF] [nvarchar](50) NULL,
	[SGST] real NULL,
	[CGST] real NULL,
	[IGST] real NULL,		
	[NETTOTAL] real NOT NULL
 CONSTRAINT [PK_DEBITNOTE] PRIMARY KEY CLUSTERED 
(
	[NO] ASC,
	[ADDRESS] ASC,
	[ACCOUNTING_YEAR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DEBIT_NOTE]  WITH CHECK ADD  CONSTRAINT [FK_DEBITNOTE_ADDRESS] FOREIGN KEY([ADDRESS])
REFERENCES [dbo].[ADDRESS] ([NAME])
GO

ALTER TABLE [dbo].[DEBIT_NOTE] CHECK CONSTRAINT [FK_DEBITNOTE_ADDRESS]
GO

ALTER TABLE [dbo].[DEBIT_NOTE]  WITH CHECK ADD  CONSTRAINT [FK_DEBITNOTE_PARTIES] FOREIGN KEY([PARTYID])
REFERENCES [dbo].[PARTIES] ([ID])
GO

ALTER TABLE [dbo].[DEBIT_NOTE] CHECK CONSTRAINT [FK_DEBITNOTE_PARTIES]
GO



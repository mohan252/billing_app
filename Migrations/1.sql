alter table PARTIES add GST nvarchar(100);

alter table ADDRESS add GST nvarchar(100);
update ADDRESS set GST = '33AAEFK9909L1ZY' where NAME = 'KUMUDAM TEXTILES';
update ADDRESS set GST = '33AADFV5356R1ZJ' where NAME = 'VIKAS FABRICS';
update ADDRESS set GST = '33AACFK5825F1ZM' where NAME = 'M/S M.KOLANDAIVEL MUDALIAR';

alter table ITEMS add HSN nvarchar(100);

alter table BILLITEMS add HSN nvarchar(100);

alter table BILLS add SGST float;
alter table BILLS add CGST float;
alter table BILLS add IGST float;
alter table BILLS add TOTALAFTERTAX float;

exec [dbo].[ADD_GST_COLUMNS];
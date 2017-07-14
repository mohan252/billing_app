alter table PARTIES add GST nvarchar(100);
alter table ADDRESS add GST nvarchar(100);
update ADDRESS set GST = 'kumudam' where NAME = 'KUMUDAM TEXTILES';
update ADDRESS set GST = 'vikas' where NAME = 'VIKAS FABRICS';
update ADDRESS set GST = 'kolandavel' where NAME = 'M/S M.KOLANDAIVEL MUDALIAR';
SELECT TOP 5 NAME AS PARTY,SUM(
select top 5 NAME as PARTY,sum(balance) from bills inner join parties on partyid = id group by name order by sum(balance) desc

-- pie chart data top 5 filter
select * from
(select top 5 NAME as PARTY,sum(balance) as balance  from bills inner join parties on partyid = id group by name order by sum(balance) desc) as p1 
union
select * from
(select 'OTHERS' as PARTY, sum(balance) as balance  from bills
where bills.partyid not in (
select t12.partyid from (
select top 5 partyid,sum(balance) as balance from bills group by partyid order by sum(balance) desc) as t12)) as p2

-- pie chart party filter
select * from
(select NAME as PARTY,sum(balance) as balance from bills inner join parties on partyid = id where name = 'BABULAL MISHRIMAL' group by name) as p1 
union
select * from
(select 'OTHERS' as PARTY, sum(balance) as balance from bills
where bills.partyid not in (select id from parties where name = 'BABULAL MISHRIMAL')
) as p2
-- pie chart agent filter top 5
select * from
(select top 5 AGENT,sum(balance) as balance  from bills group by AGENT order by sum(balance) desc) as p1 
union
select * from
(select 'OTHERS' as AGENT, sum(balance) as balance  from bills
where bills.AGENT not in (
select t12.AGENT from (
select top 5 AGENT,sum(balance) as balance from bills group by AGENT order by sum(balance) desc) as t12)) as p2
-- pie chart agent filter bottom 5
select * from
(select top 5 AGENT,sum(balance) as balance  from bills group by AGENT order by sum(balance)) as p1 
union
select * from
(select 'OTHERS' as AGENT, sum(balance) as balance  from bills
where bills.AGENT not in (
select t12.AGENT from (
select top 5 AGENT,sum(balance) as balance from bills group by AGENT order by sum(balance)) as t12)) as p2

-- pie chart SPECIFI agent filter
select * from
(select AGENT,sum(balance) as balance  from bills where AGENT = 'BHAGYODAY AGENCIES' group by AGENT) as p1 
union
select * from
(select 'OTHERS' as AGENT, sum(balance) as balance  from bills
where bills.AGENT not in (
select t12.AGENT from (
select AGENT,sum(balance) as balance from bills where AGENT = 'BHAGYODAY AGENCIES' group by AGENT) as t12)) as p2

-- BARCHART PENDING AMOUNT TOP 5 FILTER
select top 5 name as PARTY ,sum(balance) as BALANCE  from bills
inner join parties on partyid = id
where billno not in (select billno from billpayments)
group by name
order by BALANCE desc

-- PIECHART PENDING AMOUNT TOP 5 FILTER
SELECT * FROM
(SELECT TOP 5 NAME AS PARTY,SUM(BALANCE) AS BALANCE FROM BILLS
INNER JOIN PARTIES ON PARTYID = ID
WHERE BILLNO NOT IN (SELECT BILLNO FROM BILLPAYMENTS)
GROUP BY NAME
ORDER BY BALANCE DESC) AS P1
UNION
SELECT * FROM
(SELECT 'OTHERS' AS PARTY,SUM(BALANCE) AS BALANCE FROM BILLS
WHERE PARTYID NOT IN(
SELECT T12.PARTYID FROM(
SELECT TOP 5 PARTYID,SUM(BALANCE) AS BALANCE FROM BILLS GROUP BY PARTYID ORDER BY BALANCE DESC) AS T12)) AS P2

-- PIE CHART PENDING AMOUNT FOR SPECIFIC PARTY

SELECT * FROM
(SELECT NAME AS PARTY,SUM(BALANCE) AS BALANCE FROM BILLS
INNER JOIN PARTIES ON PARTYID = ID
WHERE BILLNO NOT IN (SELECT BILLNO FROM BILLPAYMENTS)
AND NAME = '$VALUE'
GROUP BY NAME) AS P1
UNION
SELECT * FROM
(SELECT 'OTHERS' AS PARTY,SUM(BALANCE) AS BALANCE FROM BILLS
WHERE BILLNO NOT IN (SELECT BILLNO FROM BILLPAYMENTS)
AND PARTYID NOT IN(SELECT ID FROM PARTIES WHERE NAME = '$VALUE')
) AS P2

-- PIE CHART ITEMTURNOVER TOP 5
SELECT * FROM
(
SELECT TOP 5 NAME,SUM(AMT) AS AMOUNT FROM BILLITEMS INNER JOIN ITEMS ON ITEMID = ID
GROUP BY NAME
ORDER BY AMOUNT DESC) AS P1
UNION
SELECT * FROM
(SELECT 'OTHER ITEMS' AS NAME,SUM(AMT) AS AMOUNT FROM BILLITEMS INNER JOIN ITEMS ON ITEMID = ID
WHERE NAME NOT IN(
SELECT T12.NAME FROM(
SELECT TOP 5 NAME,SUM(AMT) AS AMOUNT FROM BILLITEMS INNER JOIN ITEMS ON ITEMID = ID
GROUP BY NAME
ORDER BY AMOUNT DESC) AS T12)) AS P2

-- PIE CHART ITEMTURNOVER SPECIFI ITEM
SELECT * FROM
(
SELECT NAME,SUM(AMT) AS AMOUNT FROM BILLITEMS INNER JOIN ITEMS ON ITEMID = ID
WHERE NAME = '$VALUE'
GROUP BY NAME) AS P1
UNION
SELECT * FROM
(SELECT 'OTHER ITEMS' AS NAME,SUM(AMT) AS AMOUNT FROM BILLITEMS INNER JOIN ITEMS ON ITEMID = ID
WHERE NAME NOT IN(
SELECT T12.NAME FROM(
SELECT NAME,SUM(AMT) AS AMOUNT FROM BILLITEMS INNER JOIN ITEMS ON ITEMID = ID
WHERE NAME = '$VALUE'
GROUP BY NAME) AS T12)) AS P2



-- pending list for past 3 months
select name as party ,sum(balance),agent  from bills
inner join parties on partyid = id
where billno not in (select billno from billpayments) and billdate > (SELECT DATEADD(Month, -3, getdate()) AS NewDate)
group by name,agent
order by sum(balance) desc
-- pending amount partywise / bar graph
select top 5 name as party ,sum(balance),agent  from bills
inner join parties on partyid = id
where billno not in (select billno from billpayments)
group by name,agent
order by sum(balance) desc
-- pending amount for specific party by monthwise / line graph
select NAME as PARTY,sum(balance),Left(convert(varchar,billdate,9),3) from bills inner join parties on partyid = id
where name = 'ABDUL HAI & SONS'
and billno not in (select billno from billpayments)
group by name,Left(convert(varchar,billdate,9),3)
-- pending bills for specific party in a particular month / grid
select NAME as PARTY,balance,billdate,billno from bills inner join parties on partyid = id
where name = 'ABDUL HAI & SONS'
and billno not in (select billno from billpayments)
and Left(convert(varchar,billdate,9),3) = 'Nov'
-- month as nos
select NAME as PARTY,sum(balance),month(billdate) from bills inner join parties on partyid = id
where name = 'ABDUL HAI & SONS'
and billno not in (select billno from billpayments)
group by name,month(billdate)

-- sales over entire year month wise line graph
select sum(balance) as SALES ,Left(convert(varchar,billdate,9),3) as MONTH from bills inner join parties on partyid = id
group by Left(convert(varchar,billdate,9),3)
-- sales over particular month
select NAME as PARTY,balance,billdate,billno from bills inner join parties on partyid = id
where Left(convert(varchar,billdate,9),3) = 'Dec' order by billdate
-- sales comparison for prev year same month
-- yet to be done

-- item turnover
select top 5 name ,sum(amt) as amount from billitems inner join items on itemid = id
group by name 
order by amount desc
-- item turover party
select parties.name as party,sum(amt) as amount from billitems inner join items on itemid = id
inner join bills on bills.billno = billitems.billno and bills.address = billitems.address
inner join parties on bills.partyid = parties.id
where items.name = '59" K.T. 5050 GREY KHADHI'
group by parties.name
order by amount desc
-- settlement days . same party settles one bill early but another bill late, how to tackle it.
select billpayments.BILLNO,billpayments.ADDRESS,DATE,bills.billdate,bills.balance,partyid from billpayments INNER JOIN BILLS ON BILLS.BILLNO = billpayments.BILLNO AND BILLS.ADDRESS = BILLPAYMENTS.ADDRESS
where datediff(month,billdate,date) < 1
-- less than one month
select name,datediff(day,billdate,date) as settlementdays from billpayments INNER JOIN BILLS ON BILLS.BILLNO = billpayments.BILLNO AND BILLS.ADDRESS = BILLPAYMENTS.ADDRESS
inner join parties on id = partyid
where datediff(month,billdate,date) < 1
order by datediff(day,billdate,date)
-- taking avg for each party
select name,avg(datediff(day,billdate,date)) as settlementdays from billpayments INNER JOIN BILLS ON BILLS.BILLNO = billpayments.BILLNO AND BILLS.ADDRESS = BILLPAYMENTS.ADDRESS
inner join parties on id = partyid
where datediff(month,billdate,date) < 2
group by name
order by avg(datediff(day,billdate,date)) desc

-- no of bills settled by party settlement days wise
create table settlement
(
settlementdays int not null,
noofbills int not null
)
insert into settlement (settlementdays,noofbills) values

select datediff(day,billdate,date) as settlementdays,count(bills.billno) as noofbills from billpayments INNER JOIN BILLS ON BILLS.BILLNO = billpayments.BILLNO AND BILLS.ADDRESS = BILLPAYMENTS.ADDRESS
inner join parties on id = partyid
where datediff(month,billdate,date) < 6 and name = 'MAHALAKSHMI HANDLOOM HOUSE,'
group by datediff(day,billdate,date)
order by datediff(day,billdate,date)


-- and convert(datetime,billdate,101) >= convert(datetime,'04/16/2007',101)
select Left(convert(varchar,getdate(),9),3) as newdate
-- BAR CHART / DAYS TAKEN FOR SUPPLY VS NO OF BILLS

SELECT DATEDIFF(DAY,ORDERDATE,BILLDATE) AS [DAYS TAKEN FOR SUPPLY],COUNT(*) AS [NO OF BILLS],SUM(BALANCE) AS [TOOLTIP:BILL VALUE] FROM BILLS 
WHERE ORDERDATE IS NOT NULL
AND DATEDIFF(DAY,ORDERDATE,BILLDATE) > 0
AND DATEDIFF(DAY,ORDERDATE,BILLDATE) < 50
GROUP BY DATEDIFF(DAY,ORDERDATE,BILLDATE)
ORDER BY [DAYS TAKEN FOR SUPPLY] DESC
-- GRID / BILLS FOR SPECIFY SUPPLY DAYS
SELECT BILLS.BILLNO,BILLDATE,ORDERDATE,PARTIES.NAME AS PARTY,ITEMS.NAME AS ITEM,BALANCE FROM BILLS INNER JOIN PARTIES ON ID = PARTYID
LEFT OUTER JOIN BILLITEMS ON BILLS.BILLNO = BILLITEMS.BILLNO AND BILLS.ADDRESS = BILLITEMS.ADDRESS
FULL OUTER JOIN ITEMS ON ITEMS.ID = BILLITEMS.ITEMID
WHERE ORDERDATE IS NOT NULL
AND DATEDIFF(DAY,ORDERDATE,BILLDATE) = 44
ORDER BY BILLS.BILLNO
-- DATA GRID FOR SUPPLY CHAING REPORT
SELECT BILLS.BILLNO,BILLDATE,ORDERDATE,DATEDIFF(DAY,ORDERDATE,BILLDATE) AS [NO OF SUPPLY DAYS],PARTIES.NAME AS PARTY,ITEMS.NAME AS ITEM,BALANCE FROM BILLS INNER JOIN PARTIES ON ID = PARTYID
LEFT OUTER JOIN BILLITEMS ON BILLS.BILLNO = BILLITEMS.BILLNO AND BILLS.ADDRESS = BILLITEMS.ADDRESS
FULL OUTER JOIN ITEMS ON ITEMS.ID = BILLITEMS.ITEMID
WHERE ORDERDATE IS NOT NULL
ORDER BY [NO OF SUPPLY DAYS]

-- PAYMENT REMARKS TABLE
USE [Company]
GO
/****** Object:  Table [dbo].[PAYMENTREMARKS]    Script Date: 03/12/2008 14:23:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAYMENTREMARKS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[REMARKS] [nchar](50) NOT NULL,
 CONSTRAINT [PK_PAYMENTREMARKS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
-- CLEAN UP BILLPAYMENTS TABLE
INSERT INTO PAYMENTREMARKS (REMARKS)
SELECT DISTINCT REMARKS FROM BILLPAYMENTS WHERE REMARKS IS NOT NULL
-- BAR CHART / NO OF BILLS VS REMARKS
SELECT REMARKS ,COUNT(*) AS [NO OF BILLS] FROM BILLPAYMENTS WHERE REMARKS IS NOT NULL
GROUP BY REMARKS
-- BILL DETAILS FOR PARTICULAR REMARK
SELECT BILLS.BILLNO,BILLS.ADDRESS,PARTIES.NAME AS PARTY,ITEMS.NAME AS ITEM  FROM BILLPAYMENTS 
INNER JOIN BILLS ON BILLPAYMENTS.BILLNO = BILLS.BILLNO AND BILLPAYMENTS.ADDRESS = BILLS.ADDRESS
INNER JOIN PARTIES ON ID = BILLS.PARTYID
LEFT OUTER JOIN BILLITEMS ON BILLITEMS.BILLNO = BILLS.BILLNO AND BILLITEMS.ADDRESS = BILLS.ADDRESS
LEFT JOIN ITEMS ON ITEMS.ID = BILLITEMS.ITEMID
WHERE REMARKS = 'Advance'
AND ITEMS.NAME IS NOT NULL

SELECT BILLS.BILLNO,BILLS.ADDRESS,PARTIES.NAME AS PARTY,REMARKS,ITEMS.NAME AS ITEM  FROM BILLPAYMENTS 
INNER JOIN BILLS ON BILLPAYMENTS.BILLNO = BILLS.BILLNO AND BILLPAYMENTS.ADDRESS = BILLS.ADDRESS
INNER JOIN PARTIES ON ID = BILLS.PARTYID
LEFT OUTER JOIN BILLITEMS ON BILLITEMS.BILLNO = BILLS.BILLNO AND BILLITEMS.ADDRESS = BILLS.ADDRESS
LEFT JOIN ITEMS ON ITEMS.ID = BILLITEMS.ITEMID
WHERE REMARKS IS NOT NULL
ORDER BY REMARKS








SELECT * FROM BILLPAYMENTS
WHERE REMARKS = 'Advance'

SELECT * FROM BILLITEMS WHERE BILLNO IN
SELECT * FROM BILLPAYMENTS WHERE BILLNO = 660
UPDATE BILLPAYMENTS SET REMARKS = 'Advance' WHERE BILLNO = 660

SELECT BILLS.BILLNO,BILLS.ADDRESS FROM BILLPAYMENTS 
INNER JOIN BILLS ON BILLPAYMENTS.BILLNO = BILLS.BILLNO AND BILLPAYMENTS.ADDRESS = BILLS.ADDRESS


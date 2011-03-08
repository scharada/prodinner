DECLARE @dbname sysname

SET @dbname = 'prodinner'

DECLARE @spid int
SELECT @spid = min(spid) from master.dbo.sysprocesses where dbid = db_id(@dbname)
WHILE @spid IS NOT NULL
BEGIN
EXECUTE ('KILL ' + @spid)
SELECT @spid = min(spid) from master.dbo.sysprocesses where dbid = db_id(@dbname) AND spid > @spid
END
drop database prodinner
go
create database prodinner
go
use prodinner
go

create table countries(
id int identity primary key,
name nvarchar(20) not null,
isdeleted bit default(0) not null
)

create table meals(
id int identity primary key,
name nvarchar(50) not null,
comments nvarchar(max),
haspic bit default(0),
isdeleted bit default(0) not null
)

create table chefs(
id int identity primary key,
fname nvarchar(15) not null,
lname nvarchar(15) not null,
countryid int references countries(id),
isdeleted bit default(0) not null
)

create table dinners(
id int identity primary key,
name nvarchar(50) not null,
countryid int references countries(id) not null,
chefid int references chefs(id) not null,
address nvarchar(50),
date datetime,
isdeleted bit default(0) not null
)

create table dinnermeals(
dinnerid int references dinners(id),
mealid int references meals(id),
unique(dinnerid, mealid)
)

insert countries(name) values('Moldova')
insert countries(name) values('USA')
insert countries(name) values('United Kingdom')
insert countries(name) values('Belgium')
insert countries(name) values('Germany')
insert countries(name) values('Mexico')
insert countries(name) values('Brazil')
insert countries(name) values('Japan')

insert meals(name,comments,haspic) values('broccoli', 'broccoli as is in its natural form',1)
insert meals(name,comments,haspic) values('broccoli with broccoli', 'broccoli, brocoli leaves, broccoli tree, water, salt and pepper',1)
insert meals(name,comments,haspic) values('broccoli soup', 'pro style broccoli soup',0)
insert meals(name,comments,haspic) values('banana', 'yellow fruit',0)
insert meals(name,comments,haspic) values('pineapple', 'apple with a poohawk',0)
insert meals(name,comments,haspic) values('roast beef', 'roasted beef',0)
insert meals(name,comments,haspic) values('beef steak', 'beef',0)
insert meals(name,comments,haspic) values('chiken soup', 'soup with chicken ',0)
insert meals(name,comments,haspic) values('sushi', 'sushi',0)


insert chefs(fname,lname,countryid) values('athene', 'wins', 4)
insert chefs(fname,lname,countryid) values('naked', 'chef', 3)
insert chefs(fname,lname,countryid) values('chef', 'chef', 2)

select * from chefs
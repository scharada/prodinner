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
insert countries(name) values('Rohan')
insert countries(name) values('Mordor')
insert countries(name) values('Gondor')
insert countries(name) values('Isengard')
insert countries(name) values('Stormwind')
insert countries(name) values('Redridge')
insert countries(name) values('Goldshire')
insert countries(name) values('Northshire')
insert countries(name) values('Duskwood')
insert countries(name) values('Elwynn Forest')
insert countries(name) values('Westfall')
insert countries(name) values('Northrend')
insert countries(name) values('Kalimdor')
insert countries(name) values('Eastern Kingdoms')
insert countries(name) values('Azeroth')
insert countries(name) values('Outland')
insert countries(name) values('Loch Modan')
insert countries(name) values('Teldrassil')
insert countries(name) values('Felwood')
insert countries(name) values('Durotar')
insert countries(name) values('Feralas')
insert countries(name) values('Tanaris')
insert countries(name) values('Moonglade')



insert meals(name,comments,haspic) values('broccoli', 'broccoli as is in its natural form',1)
insert meals(name,comments,haspic) values('broccoli with broccoli', 'broccoli, brocoli leaves, broccoli tree, water, salt and pepper',1)
insert meals(name,comments,haspic) values('broccoli soup', 'pro style broccoli soup',1)
insert meals(name,comments,haspic) values('banana', 'yellow fruit',1)
insert meals(name,comments,haspic) values('pineapple', 'apple with a poohawk',1)
insert meals(name,comments,haspic) values('roast beef', 'roasted beef',1)
insert meals(name,comments,haspic) values('beef steak', 'beef',1)
insert meals(name,comments,haspic) values('chiken soup', 'soup with chicken ',1)
insert meals(name,comments,haspic) values('korean carrot salad', 'salad made from carrots',1)
insert meals(name,comments,haspic) values('tomatoes', 'red tomatoes',1)
insert meals(name,comments,haspic) values('toamtoes & cucumber salad', 'very nice salad',1)
insert meals(name,comments,haspic) values('sushi', 'sushi',1)
insert meals(name,comments,haspic) values('melon', 'yellow melon',1)
insert meals(name,comments,haspic) values('watermelon', 'green, red on the inside',1)
insert meals(name,comments,haspic) values('orange juice', 'juice made from oranges',1)
insert meals(name,comments,haspic) values('strawberries', 'awesome',1)
insert meals(name,comments,haspic) values('coconut water', 'great drink',1)


insert chefs(fname,lname,countryid) values('athene', 'wins', 4)
insert chefs(fname,lname,countryid) values('naked', 'chef', 3)
insert chefs(fname,lname,countryid) values('chef', 'chef', 2)

select * from chefs



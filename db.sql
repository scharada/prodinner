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
firstname nvarchar(15) not null,
lastname nvarchar(15) not null,
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


insert chefs(firstname,lastname,countryid) values('athene', 'wins', 4)
insert chefs(firstname,lastname,countryid) values('naked', 'chef', 3)
insert chefs(firstname,lastname,countryid) values('chef', 'chef', 2)

insert dinners(name,countryid,chefid,address,date) values('Food Sensual',1,3,'Miorita 1 str.',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Romantic Mood',3,2,'Miorita 2 str.',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Latte Art',5,3,'Miorita 3 str.',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Beach Get-away',10,2,'Miorita 4 str.',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Memories of an Austrian Romance',13,1,'Miorita 5 str.',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Annie''s Spring Fever Lunch for 2',22,3,'Miorita 6 str.',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Blind Date.. with Your Sweetheart ',33,2,'Miorita 7 str.',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Italian Romantic Dinner for 2 ',4,1,'Miorita 8 str.',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Sloppy Joaquin',17,2,'Miorita 9 str.',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Rioja Stoup',19,3,'Miorita 10 str.',CURRENT_TIMESTAMP)

insert dinnermeals(dinnerid,mealid) values(1,1)
insert dinnermeals(dinnerid,mealid) values(1,2)
insert dinnermeals(dinnerid,mealid) values(1,3)
insert dinnermeals(dinnerid,mealid) values(1,4)
insert dinnermeals(dinnerid,mealid) values(2,13)
insert dinnermeals(dinnerid,mealid) values(2,11)
insert dinnermeals(dinnerid,mealid) values(2,14)
insert dinnermeals(dinnerid,mealid) values(3,4)
insert dinnermeals(dinnerid,mealid) values(3,5)
insert dinnermeals(dinnerid,mealid) values(3,8)
insert dinnermeals(dinnerid,mealid) values(4,1)
insert dinnermeals(dinnerid,mealid) values(4,11)
insert dinnermeals(dinnerid,mealid) values(4,13)
insert dinnermeals(dinnerid,mealid) values(4,3)
insert dinnermeals(dinnerid,mealid) values(5,9)
insert dinnermeals(dinnerid,mealid) values(5,10)
insert dinnermeals(dinnerid,mealid) values(5,7)
insert dinnermeals(dinnerid,mealid) values(5,12)
insert dinnermeals(dinnerid,mealid) values(5,6)
insert dinnermeals(dinnerid,mealid) values(6,1)
insert dinnermeals(dinnerid,mealid) values(6,7)
insert dinnermeals(dinnerid,mealid) values(6,3)
insert dinnermeals(dinnerid,mealid) values(6,4)
insert dinnermeals(dinnerid,mealid) values(6,5)
insert dinnermeals(dinnerid,mealid) values(6,8)
insert dinnermeals(dinnerid,mealid) values(7,14)
insert dinnermeals(dinnerid,mealid) values(7,3)
insert dinnermeals(dinnerid,mealid) values(7,2)
insert dinnermeals(dinnerid,mealid) values(7,12)
insert dinnermeals(dinnerid,mealid) values(10,8)
insert dinnermeals(dinnerid,mealid) values(10,7)
insert dinnermeals(dinnerid,mealid) values(10,10)
insert dinnermeals(dinnerid,mealid) values(10,9)
insert dinnermeals(dinnerid,mealid) values(8,9)
insert dinnermeals(dinnerid,mealid) values(8,2)
insert dinnermeals(dinnerid,mealid) values(8,1)
insert dinnermeals(dinnerid,mealid) values(8,13)
insert dinnermeals(dinnerid,mealid) values(8,15)
insert dinnermeals(dinnerid,mealid) values(9,15)
insert dinnermeals(dinnerid,mealid) values(9,13)
insert dinnermeals(dinnerid,mealid) values(9,11)
insert dinnermeals(dinnerid,mealid) values(9,4)
insert dinnermeals(dinnerid,mealid) values(9,7)

select * from chefs
select * from dinners

select * from (dinners
left join dinnermeals on  dinners.id = dinnermeals.dinnerid) 
left join meals on meals.id = dinnermeals.mealid 

select * from dinners, meals, dinnermeals
where meals.id = dinnermeals.mealid and dinners.id = dinnermeals.dinnerid 
or (dinnermeals.dinnerid = null and dinnermeals.mealid = null)


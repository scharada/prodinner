use master
go
--kill all connections to db prodinner
--you might get "Only user processes can be killed." it's ok
DECLARE @dbname sysname
SET @dbname = 'prodinner'
DECLARE @spid int
SELECT @spid = min(spid) from master.dbo.sysprocesses where dbid = db_id(@dbname)
WHILE @spid IS NOT NULL
BEGIN
EXECUTE ('KILL ' + @spid)
SELECT @spid = min(spid) from master.dbo.sysprocesses where dbid = db_id(@dbname) AND spid > @spid
END
go
--recreate the database
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

create table users(
id int identity primary key,
login nvarchar(15) not null unique,
password nvarchar(20) not null,
isdeleted bit default(0) not null
)

create table roles(
id int identity primary key,
name nvarchar(10)
)

create table userroles(
userid int references users(id) not null,
roleid int references roles(id) not null,
unique(userid, roleid)
)

insert roles values('admin')
insert roles values('role1')
insert roles values('role2')
insert roles values('role3')
insert roles values('role4')

insert users values('admin','1',0)
insert users values('super','1',0)
insert users values('pro','1',0)

insert userroles values(1,1)
insert userroles values(1,2)
insert userroles values(1,3)
insert userroles values(2,1)
insert userroles values(3,1)
insert userroles values(3,2)


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

insert dinners(name,countryid,chefid,address,date) values('Food Festival',1,3,'Pro 1337 str.',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Cool gathering',3,2,'doesn''t matter',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Latte Art',5,3,'31337 str.',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Beach Get-away',10,2,'Beach',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Dinner with The Man',13,1,'at home',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Annie''s Spring Fever Lunch',22,3,'picnic',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Blind Date..',27,2,'Location unknown',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Italian Romantic Dinner',4,1,'Antwerpen',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('Uber dinner',17,2,'in the Forest',CURRENT_TIMESTAMP)
insert dinners(name,countryid,chefid,address,date) values('L337 Dinner',19,1,'internetz',CURRENT_TIMESTAMP)

insert dinnermeals(dinnerid,mealid) values(1,1)
insert dinnermeals(dinnerid,mealid) values(1,2)
insert dinnermeals(dinnerid,mealid) values(1,3)
insert dinnermeals(dinnerid,mealid) values(1,4)
insert dinnermeals(dinnerid,mealid) values(1,12)
insert dinnermeals(dinnerid,mealid) values(2,13)
insert dinnermeals(dinnerid,mealid) values(2,11)
insert dinnermeals(dinnerid,mealid) values(2,14)
insert dinnermeals(dinnerid,mealid) values(2,17)
insert dinnermeals(dinnerid,mealid) values(3,4)
insert dinnermeals(dinnerid,mealid) values(3,5)
insert dinnermeals(dinnerid,mealid) values(3,8)
insert dinnermeals(dinnerid,mealid) values(3,16)
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
insert dinnermeals(dinnerid,mealid) values(7,10)
insert dinnermeals(dinnerid,mealid) values(7,2)
insert dinnermeals(dinnerid,mealid) values(7,12)
insert dinnermeals(dinnerid,mealid) values(8,9)
insert dinnermeals(dinnerid,mealid) values(8,2)
insert dinnermeals(dinnerid,mealid) values(8,10)
insert dinnermeals(dinnerid,mealid) values(8,13)
insert dinnermeals(dinnerid,mealid) values(8,3)
insert dinnermeals(dinnerid,mealid) values(9,17)
insert dinnermeals(dinnerid,mealid) values(7,15)
insert dinnermeals(dinnerid,mealid) values(9,12)
insert dinnermeals(dinnerid,mealid) values(9,11)
insert dinnermeals(dinnerid,mealid) values(9,7)
insert dinnermeals(dinnerid,mealid) values(9,1)
insert dinnermeals(dinnerid,mealid) values(9,14)
insert dinnermeals(dinnerid,mealid) values(10,1)
insert dinnermeals(dinnerid,mealid) values(10,2)
insert dinnermeals(dinnerid,mealid) values(10,3)
insert dinnermeals(dinnerid,mealid) values(10,4)
insert dinnermeals(dinnerid,mealid) values(10,5)

select * from chefs
select * from dinners
select * from meals

select * from (dinners
left join dinnermeals on  dinners.id = dinnermeals.dinnerid) 
left join meals on meals.id = dinnermeals.mealid 

select * from dinners, meals, dinnermeals
where meals.id = dinnermeals.mealid and dinners.id = dinnermeals.dinnerid 
or (dinnermeals.dinnerid = null and dinnermeals.mealid = null)



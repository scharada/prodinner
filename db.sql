create database prodinner
go
use prodinner
go

create table countries(
id int identity primary key,
name nvarchar(20) not null
)

create table meals(
id int identity primary key,
name nvarchar(50) not null,
comments nvarchar(max)
)

create table chefs(
id int identity primary key,
fname nvarchar(15) not null,
lname nvarchar(15) not null,
countryid int references countries(id)
)

create table dinners(
id int identity primary key,
name nvarchar(50) not null,
countryid int references countries(id) not null,
chefid int references chefs(id) not null,
address nvarchar(50),
date datetime
)

create table dinnermeals(
dinnerid int references dinners(id),
mealid int references meals(id),
unique(dinnerid, mealid)
)

insert countries values('Moldova')
insert countries values('USA')
insert countries values('United Kingdom')
insert countries values('Belgium')
insert countries values('Germany')
insert countries values('Mexico')
insert countries values('Brazil')
insert countries values('Japan')

insert meals values('broccoli', 'broccoli as is in its natural form')
insert meals values('broccoli with broccoli', 'broccoli, brocoli leaves, broccoli tree, water, salt and pepper')
insert meals values('broccoli soup', 'pro style broccoli soup')
insert meals values('banana', 'yellow fruit')
insert meals values('pineapple', 'apple with a poohawk')
insert meals values('strawberries', 'awesome fruits')

insert chefs values('athene', 'wins', 4)
insert chefs values('naked', 'chef', 3)
insert chefs values('chef', 'chef', 2)
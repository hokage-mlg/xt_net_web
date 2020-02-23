use master;

drop database if exists task11;

create database task11;

use task11;

create table users (
	Id int primary key identity(1,1),
	Name nvarchar(50) not null,
	DateOfBirth date not null,
	UserImage nvarchar(MAX) not null
);

create table awards (
	Id int primary key identity(1,1),
	Title nvarchar(50) not null,
	AwardImage nvarchar(MAX) not null
);

create table users_awards (
	UserId int not null,
	AwardId int not null,
	constraint User_Award_Pair unique (UserId, AwardId),
	constraint FK_UserId foreign key (UserId) references users(Id) on delete cascade,
	constraint FK_AwardId foreign key (AwardId) references awards(Id) on delete cascade
);

create table web_users (
	Id int primary key identity(1,1),
	Login nvarchar(50) not null,
	Password nvarchar(50) not null,
	constraint Unique_Login unique (Login)
);

create table roles (
	Id int primary key identity(1,1),
	Name nvarchar(50) not null
);

create table web_users_roles (
	WebUserId int not null,
	RoleId int not null
	constraint WebUser_Role_Pair unique (WebUserId, RoleId),
	constraint FK_WebUserId foreign key (WebUserId) references web_users(Id) on delete cascade,
	constraint FK_RoleId foreign key (RoleId) references roles(Id) on delete cascade
);

insert into web_users(Login, Password) values ('admin','admin');

insert into roles (Name) values ('User');

insert into web_users_roles (WebUserId, RoleId) values (1,1);
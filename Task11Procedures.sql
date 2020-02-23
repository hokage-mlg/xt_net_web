--Users

create procedure [dbo].[procedure_InsertUser]
	@Name nvarchar(50),
	@DateOfBirth date,
	@UserImage nvarchar(MAX)
as
	insert into users (Name, DateOfBirth, UserImage) 
	output inserted.Id
	values (@Name, @DateOfBirth, @UserImage)
go

create procedure [dbo].[procedure_GetUserById]
	@Id int
as
	select Id, Name, DateOfBirth, UserImage 
	from users where Id=@Id
go

create procedure [dbo].[procedure_GetAllUsers]
as
	select Id, Name, DateOfBirth, UserImage from users
go

create procedure [dbo].[procedure_RemoveUserById]
	@Id int
as
	delete from users where Id = @Id
go

create procedure [dbo].[procedure_GiveAward]
	@UserId int,
	@AwardId int
as
	insert into users_awards
	(UserId, AwardId) values (@UserId, @AwardId)
go

create procedure [dbo].[procedure_TakeAward]
	@UserId int,
	@AwardId int
as
	delete from users_awards
	where UserId = @UserId and AwardId = @AwardId
go

create procedure [dbo].[procedure_UpdateUser]
	@Id int,
	@Name nvarchar(50),
	@DateOfBirth date,
	@UserImage nvarchar(MAX)
as
	update users
	set Name = @Name, DateOfBirth = @DateOfBirth,
		UserImage = @UserImage
	where Id = @Id
go

create procedure [dbo].[procedure_AddUserImage]
	@Id int,
	@UserImage nvarchar(MAX)
as
	update users
	set UserImage = @UserImage
	where Id = @Id
go

create procedure [dbo].[procedure_GetUserImage]
	@Id int
as
	select UserImage from users
	where Id = @Id
go

create procedure [dbo].[procedure_RemoveUserImage]
	@Id int,
	@UserImage nvarchar(MAX)
as
	update users
	set UserImage = @UserImage
	where Id = @Id
go

--Awards

create procedure [dbo].[procedure_InsertAward]
	@Title nvarchar(50),
	@AwardImage nvarchar(MAX)
as
	insert into awards(Title, AwardImage) 
	output inserted.Id
	values (@Title, @AwardImage)
go

create procedure [dbo].[procedure_GetAllAwards]
as
	select Id, Title, AwardImage from awards
go

create procedure [dbo].[procedure_GetAwardById]
	@Id int
as
	select Id, Title, AwardImage 
	from awards where Id=@Id
go

create procedure [dbo].[procedure_RemoveAwardById]
	@Id int
as
	delete from awards where Id = @Id
go

create procedure [dbo].[procedure_GetAwardsByUserId]
	@Id int
as
	select Id, Title, AwardImage from users_awards 
	join awards on AwardId = Id 
	where UserId = @Id
go

create procedure [dbo].[procedure_UpdateAward]
	@Id int,
	@Title nvarchar(50),
	@AwardImage nvarchar(MAX)
as
	update awards
	set Title = @Title, AwardImage = @AwardImage
	where Id = @Id
go

--WebUsers

create procedure [dbo].[procedure_GiveRole]
	@Login nvarchar(50),
	@RoleName nvarchar(50)
as
	insert into web_users_roles
	(WebUserId, RoleId)
	values((select Id from web_users where Login = @Login),
	(select Id from roles where Name = @RoleName))
go

create procedure [dbo].[procedure_InsertWebUser]
	@Login nvarchar(50),
	@Password nvarchar(50)
as
	insert into web_users 
	(Login, Password)
	values (@Login, @Password)
go

create procedure [dbo].[procedure_GetAllWebUsers]
as
	select Login, Password, Name from web_users 
	join web_users_roles on WebUserId = Id
	join roles on RoleId = roles.Id
go

create procedure [dbo].[procedure_RemoveRole]
	@Login nvarchar(50),
	@RoleName nvarchar(50)
as
	delete from web_users_roles
	where 
	WebUserId = 
	(select Id from web_users where Login = @Login) and
	RoleId = 
	(select Id from roles where Name = @RoleName)
go
--User
create procedure [dbo].[procedure_InsertUser]
	@Login nvarchar(50),
	@Password nvarchar(50)
as
	insert into users 
	(Login, Password)
	values (@Login, @Password)
go

create procedure [dbo].[procedure_GiveRole]
	@Login nvarchar(50),
	@RoleName nvarchar(50)
as
	insert into users_roles
	(IdUser, IdRole)
	values((select Id from users where Login = @Login),
	(select Id from roles where Name = @RoleName))
go

create procedure [dbo].[procedure_GetAllUsers]
as
	select Login, Password, Name from users 
	join users_roles on IdUser = Id
	join roles on IdRole = roles.Id
go

create procedure [dbo].[procedure_RemoveRole]
	@Login nvarchar(50),
	@RoleName nvarchar(50)
as
	delete from users_roles
	where 
	IdUser = 
	(select Id from users where Login = @Login) and
	IdRole = 
	(select Id from roles where Name = @RoleName)
go

create procedure [dbo].[procedure_GetUsersByPurchaseId]
	@Id int
as
	select Id, Login from users_purchases
	join users on IdUser = Id 
	where IdPurchase = @Id
go

create procedure [dbo].[procedure_MakePurchase]
	@IdUser int,
	@IdPurchase int
as
	insert into users_purchases
	(IdUser, IdPurchase) values (@IdUser, @IdPurchase)
go

create procedure [dbo].[procedure_CancelPurchase]
	@IdUser int,
	@IdPurchase int
as
	delete from users_purchases
	where IdUser = @IdUser and IdPurchase = @IdPurchase
go

create procedure [dbo].[procedure_GetUserById]
	@Id int
as
	select Id, Login 
	from users where Id=@Id
go

create procedure [dbo].[procedure_GetUserByLogin]
	@Login nvarchar(50)
as
	select Id, Login 
	from users where Login=@Login
go

create procedure [dbo].[procedure_RemoveUserById]
	@Id int
as
	delete from users where Id = @Id
go

create procedure [dbo].[procedure_ChangePassword]
	@Id int,
	@Password nvarchar(50)
as
	update users
	set Password=@Password
	where Id=@Id
go

create procedure [dbo].[procedure_UpdateUser]
	@Id int,
	@Login nvarchar(50),
	@Password nvarchar(50)	
as
	update users
	set Login = @Login, Password = @Password
	where Id = @Id
go

--Books

create procedure [dbo].[procedure_InsertBook]
	@Author nvarchar(MAX),
	@Title nvarchar(MAX),
	@Genre nvarchar(50),
	@BookImage nvarchar(MAX),
	@ReleaseDate int,
	@Price decimal(18,0),
	@Quantity int
as
	insert into books(Author,Title,Genre, BookImage, ReleaseDate, Price, Quantity) 
	output inserted.Id
	values (@Author, @Title, @Genre, @BookImage, @ReleaseDate, @Price, @Quantity)
go

create procedure [dbo].[procedure_GetAllBooks]
as
	select Id, Author, Title, Genre, BookImage, ReleaseDate, Price, Quantity from books
go

create procedure [dbo].[procedure_ChangeQuantity]
	@Id int,
	@Quantity int
as
	update books
	set Quantity=@Quantity
	where Id=@Id
go

create procedure [dbo].[procedure_ChangePrice]
	@Id int,
	@Price int
as
	update books
	set Price=@Price
	where Id=@Id
go

create procedure [dbo].[procedure_GetBookById]
	@Id int
as
	select Id, Author, Title, Genre, BookImage, ReleaseDate, Price, Quantity 
	from books where Id=@Id
go

create procedure [dbo].[procedure_GetBookByAuthor]
	@Author nvarchar(MAX)
as
	select Id, Author, Title, Genre, BookImage, ReleaseDate, Price, Quantity 
	from books where Author=@Author
go

create procedure [dbo].[procedure_GetBookByGenre]
	@Genre nvarchar(50)
as
	select Id, Author, Title, Genre, BookImage, ReleaseDate, Price, Quantity 
	from books where Genre=@Genre
go

create procedure [dbo].[procedure_GetBookByTitle]
	@Title nvarchar(MAX)
as
	select Id, Author, Title, Genre, BookImage, ReleaseDate, Price, Quantity 
	from books where Title=@Title
go

create procedure [dbo].[procedure_RemoveBookById]
	@Id int
as
	delete from books where Id = @Id
go

create procedure [dbo].[procedure_GetBooksByPurchaseId]
	@Id int
as
	select Id, Author, Title, Genre, BookImage, ReleaseDate, Price, Quantity from books_purchases 
	join books on IdBook = Id 
	where IdPurchase = @Id
go

create procedure [dbo].[procedure_AddBookToPurchase]
	@IdBook int,
	@IdPurchase int
as
	insert into books_purchases
	(IdBook, IdPurchase) values (@IdBook, @IdPurchase)
go

create procedure [dbo].[procedure_RemoveBookFromPurchase]
	@IdBook int,
	@IdPurchase int
as
	delete from books_purchases
	where IdBook = @IdBook and IdPurchase = @IdPurchase
go

create procedure [dbo].[procedure_UpdateBooks]
	@Id int,
	@Author nvarchar(MAX),
	@Title nvarchar(MAX),
	@Genre nvarchar(50),
	@BookImage nvarchar(MAX),
	@ReleaseDate int,
	@Price decimal(18,0),
	@Quantity int
as
	update books
	set Author = @Author, Title = @Title, Genre = @Genre, BookImage = @BookImage,
	ReleaseDate = @ReleaseDate,Price=@Price,Quantity=@Quantity
	where Id = @Id
go

--Purchases

create procedure [dbo].[procedure_InsertPurchase]
	@FullName nvarchar(MAX),
	@PhoneNumber nvarchar(20),
	@Address nvarchar(MAX)
as
	insert into purchases(FullName,PhoneNumber, Address) 
	output inserted.Id
	values (@FullName, @PhoneNumber,@Address)
go

create procedure [dbo].[procedure_GetAllPurchases]
as
	select Id, FullName, PhoneNumber, Address from purchases
go

create procedure [dbo].[procedure_GetPurchaseById]
	@Id int
as
	select Id, FullName, PhoneNumber, Address 
	from purchases where Id=@Id
go

create procedure [dbo].[procedure_RemovePurchaseById]
	@Id int
as
	delete from purchases where Id = @Id
go

create procedure [dbo].[procedure_GetPurchasesByUserId]
	@Id int
as
	select Id, FullName,PhoneNumber, Address from users_purchases 
	join purchases on IdPurchase = Id 
	where IdUser = @Id
go

create procedure [dbo].[procedure_ChangeFullname]
	@Id int,
	@FullName nvarchar(MAX)
as
	update purchases
	set FullName=@FullName
	where Id=@Id
go

create procedure [dbo].[procedure_ChangePhoneNumber]
	@Id int,
	@PhoneNumber nvarchar(20)
as
	update purchases
	set PhoneNumber=@PhoneNumber
	where Id=@Id
go

create procedure [dbo].[procedure_ChangeAddress]
	@Id int,
	@Address nvarchar(MAX)
as
	update purchases
	set Address=@Address
	where Id=@Id
go

create procedure [dbo].[procedure_UpdatePurchase]
	@Id int,
	@FullName nvarchar(MAX),
	@PhoneNumber nvarchar(20),
	@Address nvarchar(MAX)
as
	update purchases
	set FullName = @FullName, PhoneNumber = @PhoneNumber, Address = @Address
	where Id = @Id
go
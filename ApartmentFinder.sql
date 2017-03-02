Create Database [ApartmentFinder]
go
Use [ApartmentFinder]
go
Create Table[Apartment](
[ApartmentID] int IDENTITY(1,1) NOT NULL,
[ApartmentName] varchar(45),
[Street Address] varchar(45),
[ContactEmail] varchar(45),
[ContactPhone] varchar(45),
[CityID] int,
[Active] bit Not Null Default(1)
CONSTRAINT PK_ApartmentID Primary Key Clustered (ApartmentID)
CONSTRAINT FK_CityID Foreign Key (CityID) REFERENCES [City](CityID)
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)
go
Create Table[Room](
[RoomID] int IDENTITY(1,1) NOT NULL,
[NumberOfBeds] int,
[RoomNumber] varchar(45),
[isFilled] bit Not Null Default(0),
[price] money,
[ApartmentID] int,
[Active] bit Not Null Default(1)
CONSTRAINT PK_RoomID Primary Key Clustered ([RoomID])
CONSTRAINT FK_ApartmentID Foreign Key (ApartmentID) REFERENCES [Apartment](ApartmentID)
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)
go
Create Table[City](
[CityID] int IDENTITY(1,1) NOT NULL,
[Name] varchar(45),
[Zip Code] varchar(45),
[StateID] int,
[Active] bit Not Null Default(1)
CONSTRAINT PK_CityID Primary Key Clustered ([CityID]),
CONSTRAINT FK_StateID Foreign Key ([StateID]) REFERENCES [State]([StateID])
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)
go

Create Table[State](
[StateID] int IDENTITY(1,1) NOT NULL,
[StateName] varchar(45),
CONSTRAINT PK_StateID Primary Key Clustered ([StateID])
)
go

Create Table[User](
[UserID] int IDENTITY(1,1) NOT NULL,
[FirstName] varchar(45),
[LastName] varchar(45),
[Username] varchar(45),
[Password] varchar(45),
[Email] varchar(45),
CONSTRAINT PK_UserID Primary Key Clustered ([UserID])
)

go
Create Table[FavoritedRooms](
[UserID] int,
[RoomID] int
CONSTRAINT PK_FavoritedRoomsID Primary Key Clustered ([UserID], [RoomID]),
CONSTRAINT FK_FavoritedRooms_UserID Foreign Key ([UserID]) REFERENCES [User]([UserID]),   
CONSTRAINT FK_FavoritedRooms_RoomID Foreign Key ([ROomID]) REFERENCES [Room]([RoomID])
    ON DELETE CASCADE    
    ON UPDATE CASCADE 
)
go

CREATE VIEW [AllUsersFavoritedRooms] AS
Select [User].UserID,[user].[firstname],[User].[LastName],[user].[Username],Room.RoomID,[Room].NumberOfBeds,[Room].RoomNumber,[Room].isFilled,[Room].price,[Apartment].ApartmentID,[Apartment].ApartmentName,[Apartment].[Street Address],[City].CityId,[city].[name] as 'CityName',
[City].[Zip Code],[State].StateID,[State].StateName,[Apartment].ContactEmail,[Apartment].ContactPhone
From [FavoritedRooms]
inner join [User] on [User].UserID = [FavoritedRooms].UserID
inner join [room] on [room].RoomID = [FavoritedRooms].RoomID
inner join [Apartment] on [Apartment].ApartmentID = [Room].ApartmentID  
inner join [City] on [Apartment].CityID = [City].CityID
inner join [State] on [City].StateID = [State].StateID
Select * From AllUsersFavoritedRooms

CREATE VIEW [ApartmentInformation] AS
Select [Apartment].ApartmentID,[Apartment].ApartmentName,[Apartment].[Street Address],[City].CityId,[city].[name] as 'CityName',
[City].[Zip Code],[State].StateID,[State].StateName,[Apartment].ContactEmail,[Apartment].ContactPhone From [Apartment]
inner join [city] on [City].CityID = [Apartment].CityID
inner join [State] on [State].StateID = City.StateID

Create View [RoomInformation] AS
Select [Room].RoomID,[Room].NumberOfBeds,[Room].RoomNumber,[Room].isFilled,[Room].price, [ApartmentInformation].ApartmentID,[ApartmentInformation].ApartmentName,[ApartmentInformation].[Street Address],[ApartmentInformation].CityId,[ApartmentInformation].[CityName],
[ApartmentInformation].[Zip Code],[ApartmentInformation].StateID,[ApartmentInformation].StateName,[ApartmentInformation].ContactEmail,[ApartmentInformation].ContactPhone From [Room]
inner join ApartmentInformation on [Room].ApartmentID = [ApartmentInformation].ApartmentID
select  dbo.ApartmentIDFromName('1','1')

Go
CREATE FUNCTION RoomsInApartment(@apartmentname varchar(45),@zipcode varchar(5))
returns table
AS 
	Return  Select * From RoomInformation where apartmentID = dbo.ApartmentIDFromName(@apartmentname,@zipcode)

	Select * From Apartment
Go
CREATE FUNCTION AvailableRoomsinApartment(@apartmentname varchar(45),@zipcode varchar(5))
returns table
AS 
		Return  Select * From RoomInformation where apartmentID = dbo.ApartmentIDFromName(@apartmentname,@zipcode) And isFilled=0
Go
--
CREATE FUNCTION UserFavorites(@username varchar(45))
returns table
AS 
	Return Select * From AllUsersFavoritedRooms where username = @username 
Go
CREATE FUNCTION FavoritedRoom(@RoomNumber varchar(45),@ApartmentName varchar(45), @zipcode varchar(5))
returns table
AS 
	Return Select * From AllUsersFavoritedRooms where roomID = dbo.getRoomID(@RoomNumber,@ApartmentName,@zipcode) 
Go
--
CREATE FUNCTION AllRoomsByZip(@zip_code int)
returns table
AS 
	Return Select * From RoomInformation where [Zip Code]= @zip_code
	Go
CREATE FUNCTION AllRoomsByCity(@CityName Varchar(45))
returns table
AS 
	Return Select * From RoomInformation where [CityName] = @CityName
Go
CREATE FUNCTION AllRoomsByState(@StateName varchar(45))
returns table
AS 
	Return Select * From RoomInformation where [StateName] = @StateName  
Go
CREATE FUNCTION AvailableRoomsByZip(@zip_code int)
returns table
AS 
	Return Select * From RoomInformation where [Zip Code]= @zip_code AND isFilled=0
Go
CREATE FUNCTION AvailableRoomsByCity(@CityName varchar(45))
returns table
AS 
	Return Select * From RoomInformation where [CityName] = @CityName AND isFilled=0
Go
CREATE FUNCTION AvailableRoomsByState(@StateName varchar(45))
returns table
AS 
	Return Select * From RoomInformation where [StateName] = @StateName AND isFilled=0  
Go
--
CREATE FUNCTION NumRoomsInApartment(@apartmentname varchar(45),@zipcode varchar(5))
RETURNS int
as 
BEGIN
	declare @total int;
	 Select @total = COUNT(ApartmentID)From RoomInformation where ApartmentID=dbo.ApartmentIDFromName(@apartmentname,@zipcode)
	 return @total
end
go

CREATE FUNCTION NumRoomsInState(@Statename varchar(45))
RETURNS int
as 
BEGIN
	declare @total int;
	 Select @total = COUNT(StateID)From RoomInformation where StateName=@Statename
	 return @total
end
go

CREATE FUNCTION NumRoomsInZip(@zip_code int)
RETURNS int
as 
BEGIN
	declare @total int;
	 Select @total = COUNT([Zip Code])From RoomInformation where [Zip Code]=@zip_code
	 return @total
end
go

CREATE FUNCTION NumAvailableRoomsInApartment(@apartmentname varchar(45),@zipcode varchar(5))
RETURNS int
as 
BEGIN
	declare @total int;
	 Select @total = COUNT(ApartmentID)From RoomInformation where ApartmentID=dbo.ApartmentIDFromName(@apartmentname,@zipcode) and isFilled=0
	 return @total
end
go

CREATE FUNCTION NumAvailableRoomsByState(@StateName varchar(45))
RETURNS int
as 
BEGIN
	declare @total int;
	 Select @total = COUNT(StateID)From RoomInformation where StateName=@StateName and isFilled=0
	 return @total
end
go


CREATE FUNCTION NumAvailableRoomsByZip(@zip_code int)
RETURNS int
as 
BEGIN
	declare @total int;
	 Select @total = COUNT([Zip Code])From RoomInformation where [Zip Code]=@zip_code and isFilled=0
	 return @total
end
go

CREATE FUNCTION AvgRoomCostByApartment(@apartmentname varchar(45),@zipcode varchar(5))
Returns money
As
BEGIn
	declare @total money;
	select @total = Avg(price)From RoomInformation where [ApartmentID] = dbo.ApartmentIDFromName(@apartmentname,@zipcode)
	return @total
END
Go
CREATE FUNCTION AvgRoomCostByZip(@zip_code int)
Returns money
As
BEGIn
	declare @total money;
	select @total = Avg(price)From RoomInformation where [Zip Code]= @zip_code
	return @total
END
Go
CREATE FUNCTION AvgRoomCostByCity(@cityID int)
Returns money
As
BEGIn
	declare @total money;
	select @total = Avg(price)From RoomInformation where CityID= @cityID
	return @total
END

Go
CREATE FUNCTION AvgRoomCostByState(@StateID int)
Returns money
As
BEGIn
	declare @total money;
	select @total = Avg(price)From RoomInformation where StateId= @StateID
	return @total
END
Go
CREATE FUNCTION AvgRoomCostOverall()
Returns money
As
BEGIn
	declare @total money;
	select @total = Avg(price)From RoomInformation
	return @total
END

GO
CREATE PROCEDURE CreateApartment
@ApartmentName varchar(45),
@Street  varchar(45),
@ContactEmail varchar(45),
@ContactPhone varchar(45),
@CityID int
AS
INSERT INTO Apartment ([ApartmentName],[Street Address],[ContactEmail],
[ContactPhone],[CityID]) Values (@ApartmentName,@Street,@ContactEmail,
@ContactPhone, @CityID)
GO
CREATE PROCEDURE CreateRoom
@NumberOfBeds varchar(45),
@RoomNumber  varchar(45),
@isFilled bit,
@price money,
@ApartmentID int
AS
INSERT INTO Room ([NumberOfBeds],[RoomNumber],[isFilled],
[price],[ApartmentID]) Values (@NumberOfBeds,@RoomNumber,@isFilled,
@price, @ApartmentID)
GO
select* From Room
go
CREATE PROCEDURE CreateUser
@firstname varchar(45),
@lastname varchar(45),
@username  varchar(45),
@password varchar(45),
@email varchar(45)
AS
INSERT INTO [User] ([FirstName],[LastName],[username],[password],
[email]) Values (@firstname,@lastname,@username,@password,
@email)
GO

CREATE PROCEDURE CreateCity
@name varchar(45),
@zipcode  int,
@stateid int
AS
INSERT INTO [City] ([name],[zip code],[stateid]) 
Values (@name,@zipcode,@stateid)
GO

Create Procedure DeleteRoom
@RoomNumber varchar(45),
@ApartmentName Varchar(45),
@ZipCOde Varchar(45) 
AS
Delete From Room Where RoomID=dbo.GetRoomID(@RoomNumber,@ApartmentName,@ZipCode)

Create Procedure DeleteUser
@username varchar(45)
AS
Delete From [User] Where username=@username

Create Procedure DeleteApartment
@ApartmentName varchar(45),
@ZipCode varchar(5)
AS
Delete From [Apartment] Where apartmentID = dbo.ApartmentIDFromName(@ApartmentName,@ZipCode)

Create Procedure UpdateApartment
@OldApartmentName varchar(45),
@OldZipCode varchar(5),
@NewApartmentName varchar(45),
@NewZipCode varchar(5),
@StreetAddress varchar(45),
@ContactEmail varchar(45),
@ContactPhone varchar(45)
As
UPDATE Apartment SET ApartmentName=@NewApartmentName, [Street Address]= @StreetAddress,ContactEmail =@ContactEmail,ContactPhone=@ContactPhone,
CityID= dbo.GetCityID(@NewZipCode)

 where apartmentID = dbo.ApartmentIDFromName(@OldApartmentName,@OldZipCode)
Select* From Room
Drop Procedure UpdateApartment	
Create Function GetCityID
(@Zipcode varchar(5))
returns int
AS
BEGIN
	Declare @cityid int
	Select @cityid = [cityID] From City where [Zip Code]=@ZipCode
	return @cityid 
END

Create Function GetUserID
(@username varchar(45))
returns int
AS
BEGIN
	Declare @userid int
	Select @userid = [userID] From [User] where username=@username
	return @userid 
END

Create Procedure UpdateUser
@OldUserName varchar(45),
@NewUserName varchar(45),
@password varchar(45),
@Email varchar(45),
@Firstname varchar(45),
@Lastname varchar(45)
As
Update [User] Set Username=@NewUserName,[Password]=@password,Email=@Email, FirstName=@Firstname,LastName=@Lastname
where [username]=@OldUserName

Create Procedure UpdateRoom
@NumberOfBeds as int,
@OldRoomNumber varchar(45),
@NewRoomNumber as varchar(45),
@IsFilled as bit,
@price as money,
@ApartmentName as varchar(45),
@ZipCode varchar(5)
as
UPDATE Room Set NumberOfBeds=@NumberofBeds, RoomNumber=@NewRoomNumber,isFilled=@IsFilled,
price=@price,ApartmentID=dbo.ApartmentIDFromName(@ApartmentName,@ZipCode) where RoomID = dbo.GetRoomID(@OldRoomNumber,@ApartmentName,@ZipCode)

create procedure AddFavorite
@username varchar(45),
@RoomNumber varchar(45),
@ApartmentName varchar(45),
@ZipCode varchar(5)
AS
Insert Into FavoritedRooms ([UserID],[RoomID]) Values (dbo.GetUserID(@username),dbo.getRoomID(@RoomNumber,@ApartmentName,@ZipCode))

Create Procedure RemoveFavorite
@username varchar(45),
@RoomNumber varchar(45),
@ApartmentName varchar(45),
@ZipCode varchar(5)
AS
Delete From FavoritedRooms where userID=dbo.GetUserID(@username) and RoomID = dbo.GetRoomID(@ROomNumber,@ApartmentName,@ZipCode)

Select *From [User]


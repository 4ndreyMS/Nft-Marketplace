﻿--Company Table
CREATE TABLE Company(
Id NVARCHAR(100) NOT NULL PRIMARY KEY,
Name NVARCHAR(100) NOT NULL,
Status NVARCHAR(50) NOT NULL,
CreationDate DATETIME NOT NULL,
Email NVARCHAR(75) NOT NULL
)

CREATE PROCEDURE CRE_COMPANY_PR
@P_Id NVARCHAR(100),
@P_Name NVARCHAR(100),
@P_Email NVARCHAR(75),
@P_Status NVARCHAR(50),
@P_CreationDate DATETIME
AS
INSERT INTO Company (Id, Name, Email, Status, CreationDate)
VALUES (@P_Id, @P_Name, @P_Email, @P_Status, @P_CreationDate)
GO 
CREATE PROCEDURE DEL_COMPANY_PR
@P_Id NVARCHAR(100)
AS
	DELETE FROM Company
	WHERE Id = @P_Id

CREATE PROCEDURE RET_ALL_COMPANY_PR
AS
	SELECT *
	FROM Company


CREATE PROCEDURE RET_COMPANY_BY_NAME_PR
@P_Name NVARCHAR(100)
AS
	SELECT * 
	FROM Company
	WHERE Name = @P_Name

CREATE PROCEDURE RET_COMPANY_PR
@P_Id NVARCHAR(100)
AS
	SELECT * 
	FROM Company
	WHERE Id = @P_Id

CREATE PROCEDURE UPD_STATUS_COMPANY_PR
	@P_Id NVARCHAR(100),
	@P_Status NVARCHAR(50)
AS
	UPDATE Company
	SET Status = @P_Status
	WHERE Id = @P_Id

CREATE PROCEDURE UPD_COMPANY_PR
	@P_Id NVARCHAR(100),
	@P_Name NVARCHAR(100),
	@P_Email NVARCHAR(75)
AS
	UPDATE Company
	SET Name= @P_Name, Email =  @P_Email
	WHERE Id = @P_Id



GO
--Wallet Table
CREATE TABLE Wallet(
Identifier NVARCHAR(100) NOT NULL PRIMARY KEY,
Amount Decimal(10,3) NOT NULL,
CoinName NVARCHAR(50) NOT NULL,
CompanyId NVARCHAR(100) NOT NULL,
CONSTRAINT FK_Company_Wallet FOREIGN KEY (CompanyId) REFERENCES Company(Id)
)
GO

CREATE PROCEDURE CRE_WALLET_PR
	@P_Identifier NVARCHAR(100),
	@P_Amount DECIMAL(10,3),
	@P_CoinName NVARCHAR(50),
	@P_CompanyId NVARCHAR(100)
AS
	INSERT INTO Wallet(Identifier, Amount, CoinName, CompanyId)
	VALUES(@P_Identifier,@P_Amount,@P_CoinName, @P_CompanyId)

	DROP PROCEDURE CRE_WALLET_PR
GO
CREATE PROCEDURE DEL_WALLET_PR
	@P_Identifier NVARCHAR(100)
AS
	DELETE FROM Wallet WHERE  Identifier = @P_Identifier;
GO
CREATE PROCEDURE UPD_WALLET_PR
	@P_CompanyId NVARCHAR(100),
	@P_Identifier NVARCHAR(100)
AS
	UPDATE Wallet
	SET CompanyId = @P_CompanyId
	WHERE Identifier=@P_Identifier;
GO
CREATE PROCEDURE ADD_AMOUNT_WALLET_PR
	@P_Amount DECIMAL(10,3),
	@P_Identifier NVARCHAR(100)
AS
	DECLARE @ret_amount Decimal(10,3)= (SELECT Amount FROM Wallet WHERE Identifier = @P_Identifier);
	UPDATE Wallet
	SET Amount = @ret_amount + @P_Amount
	WHERE Identifier = @P_Identifier;
GO
CREATE PROCEDURE REST_AMOUNT_WALLET_PR
	@P_Amount DECIMAL(10,3),
	@P_Identifier NVARCHAR(100)
AS
	DECLARE @ret_amount Decimal(10,3)= (SELECT Amount FROM Wallet WHERE Identifier = @P_Identifier);
	UPDATE Wallet
	SET Amount = @ret_amount - @P_Amount
	WHERE Identifier = @P_Identifier;
GO
CREATE PROCEDURE RET_WALLET_PR
	@P_CompanyId NVARCHAR(100)
AS
	SELECT *
	FROM Wallet
	WHERE CompanyId = @P_CompanyId
	RETURN;
GO

--Transaction Table
CREATE TABLE [Transaction](
Id SMALLINT identity(1,1) NOT NULL PRIMARY KEY,
Amount DECIMAL(10,3) NOT NULL,
TransType NVARCHAR(50) NOT NULL,
WalletReceive NVARCHAR(100) NOT NULL,
WalletSend NVARCHAR(100) NOT NULL,
CONSTRAINT FK_wallet_trans FOREIGN KEY (WalletSend) REFERENCES Wallet(Identifier)
)
GO
CREATE PROCEDURE CRE_TRANSACTION_PR
	@P_Id NVARCHAR(100),
	@P_Amount DECIMAL(10,3),
	@P_TransType NVARCHAR(50),
	@P_WalletReceive NVARCHAR(100),
	@P_WalletSend NVARCHAR(100)

AS
	INSERT INTO [Transaction](Id, Amount, TransType, WalletReceive, WalletSend)
	VALUES(@P_Id,@P_Amount,@P_TransType, @P_WalletReceive, @P_WalletSend)
GO
CREATE PROCEDURE DEL_TRANSACTION_PR
	@P_Id NVARCHAR(100)
AS
	DELETE FROM [Transaction] WHERE  Id = @P_Id;
GO
CREATE PROCEDURE UPD_TRANSACTION_PR
	@P_Id NVARCHAR(100),
	@P_Amount DECIMAL(10,3),
	@P_TransType NVARCHAR(50),
	@P_WalletReceive NVARCHAR(100),
	@P_WalletSend NVARCHAR(100)
AS
	UPDATE [Transaction]
	SET Amount=@P_Amount,Transtype=@P_TransType,WalletReceive=@P_WalletReceive, WalletSend=@P_WalletSend
	WHERE Id=@P_Id;
GO

--User_Roler Table

CREATE TABLE User_Role(
RoleId SMALLINT NOT NULL FOREIGN KEY REFERENCES Role(Id),
UserId NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES [User](IdentificationCard),
PRIMARY KEY(RoleId,UserId)
)

CREATE PROCEDURE RET_SPFC_USER_ROLE_PR
@P_RoleId SMALLINT
AS
SELECT ur.* , u.*
FROM User_Role as ur
INNER JOIN [User] as u ON ur.UserId = u.IdentificationCard
WHERE ur.RoleId = @P_RoleId



--User Document Table
CREATE TABLE UserDocument(
Id SMALLINT NOT NULL identity(1,1) PRIMARY KEY,
IdPic NVARCHAR(150),
ProfilePic NVARCHAR(150),
SamplePic NVARCHAR(150)
)

ALTER TABLE UserDocument
ADD UserId NVARCHAR(100) NOT NULL,
CONSTRAINT FK_User_Docs FOREIGN KEY (UserId) REFERENCES [User](IdentificationCard)

GO

--RESPONSABLE: Alison Yeung
--FECHA: 27/Abril/22
--TABLA User
CREATE TABLE [dbo].[TBL_User](
	[Cedula] NVARCHAR(50) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Surnames] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(75) NOT NULL,
	[Phone] NVARCHAR(30) NOT NULL,
	[Nickname] NVARCHAR(50) NOT NULL,
	[Contrasenia] NVARCHAR(50) NULL, 
	[OTP_Email] NVARCHAR(50)  NULL,
	[OTP_Phone] NVARCHAR(50)  NULL,
	[Status] NVARCHAR(30) NULL,
)
ALTER TABLE [User]

	ADD Birth_Day DATE  NULL, 
	OTP_Email NVARCHAR(50)  NULL,
	OTP_Phone NVARCHAR(50)  NULL,
	[Status] NVARCHAR(30) NULL;
GO

ALTER PROCEDURE [dbo].[CRE_USER_PR]
@P_Cedula NVARCHAR(100),
@P_Name NVARCHAR(100),
@P_Email NVARCHAR(75),
@P_Status NVARCHAR(50),
@P_Phone NVARCHAR(30),
@P_Nickname NVARCHAR(50),
@P_SureNames NVARCHAR(100),
@P_Otp NVARCHAR(100),
@P_IdOrganization NVARCHAR(100),
@P_UserPic NVARCHAR(150)
AS
INSERT INTO [User] (IdentificationCard, Name, Email, Status, Phone, Nickname, SureNames, Otp, IdOrganization, UserPic )
VALUES (@P_Cedula, @P_Name, @P_Email, @P_Status, @P_Phone, @P_Nickname, @P_SureNames, @P_Otp, @P_IdOrganization,@P_UserPic )

GO

CREATE PROCEDURE RET_USER_BY_ID_PR
@P_Cedula NVARCHAR(100)
AS
	SELECT IdentificationCard as Cedula,Name,Status,SureNames,Email,Phone,Otp,IdOrganization,Nickname
	FROM [USER]
	WHERE IdentificationCard = @P_Cedula
GO
CREATE PROCEDURE RET_USER_BY_MAIL_PR
@P_Email NVARCHAR(100)
AS
	SELECT IdentificationCard as Cedula,Name,Status,SureNames,Email,Phone,Otp,IdOrganization,Nickname
	FROM [USER]
	WHERE Email = @P_Email
GO
CREATE PROCEDURE DEL_USER_PR
	@P_Cedula NVARCHAR(100)
AS
	DELETE FROM [User]
	WHERE IdentificationCard = @P_Cedula
GO
CREATE PROCEDURE UPD_OTP_USER_PR
	@P_Cedula NVARCHAR(100),
	@P_Otp INT
AS
	UPDATE [User]
	SET Otp = @P_Otp
	WHERE IdentificationCard = @P_Cedula
GO
CREATE PROCEDURE UPD_STATUS_USER_PR
	@P_Cedula NVARCHAR(100),
	@P_Status NVARCHAR(30)
AS
	UPDATE [User]
	SET Status = @P_Status
	WHERE IdentificationCard = @P_Cedula


GO
CREATE PROCEDURE UPD_USER_PR
	@P_Cedula NVARCHAR(100),
	@P_Name NVARCHAR(50),
	@P_SureNames NVARCHAR(100),
	@P_Email NVARCHAR(100),
	@P_Phone NVARCHAR(30),
	@P_Nickname NVARCHAR(50)
AS
	UPDATE [User]
	SET [Name] = @P_Name , SureNames= @P_SureNames, Email= @P_Email, Phone= @P_Phone, Nickname= @P_Nickname
	WHERE IdentificationCard = @P_Cedula




--RESPONSABLE: Alison Yeung
--FECHA: 27/Abril/22
--procedimiento de inicio usuario*********************************************************
CREATE PROCEDURE [dbo].[RET_USUARIO_LOGIN_PR]
	@P_Email NVARCHAR(50),
	@P_Contrasenia NVARCHAR(50)
AS
	SELECT Cedula,Name,Surnames,Email,Fecha_Nacimiento,Phone,Nickname,OTP_Email,OTP_Phone,Status  FROM TBL_User WHERE Email=@P_Email AND Contrasenia=@P_Contrasenia;
RETURN 0
GO

--RESPONSABLE: Alison Yeung
--FECHA: 27/Abril/22
--TABLA HISTORIAL_CONTRASENIA

CREATE TABLE [dbo].[Password_History]
(
	[ID_Historial_Contrasenia] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Usuario_Cedula] NVARCHAR(100) NOT NULL CONSTRAINT FK_CONTRASENIA_USUARIO_CEDULA FOREIGN KEY (Usuario_Cedula) REFERENCES [User](IdentificationCard),
	[Fecha_Creacion] DATETIME NOT NULL, 
	[Contrasenia] NVARCHAR(50) NOT NULL,	
	[Status] NVARCHAR(50) NOT NULL
)
GO

--INSERT/CREATE EN HISTORIAL_CONTRASENIA

CREATE PROCEDURE [dbo].[CRE_HISTORIAL_CONTRASENIA_PR]
	@P_CEDULA NVARCHAR(50),
	@P_FECHA_CREACION DATETIME,
	@P_CONTRASENIA NVARCHAR(50),
	@P_ESTADO NVARCHAR(50)
AS
	INSERT INTO [dbo].[TBL_HISTORIAL_CONTRASENIA] VALUES(@P_CEDULA,@P_FECHA_CREACION,@P_CONTRASENIA,@P_ESTADO);
GO

--Table PaymentMethod
CREATE TABLE Payment_Method(
Id SMALLINT NOT NULL identity(1,1) PRIMARY KEY,
PaypalAccnt NVARCHAR(100) NOT NULL,
Pin NVARCHAR(20) NOT NULL,
Expiration DATE NOT NULL,
OwnerName NVARCHAR(100),
CompanyId NVARCHAR(100)
CONSTRAINT FK_company_payment FOREIGN KEY (CompanyId) REFERENCES Company(Id)
)

--Table Invoice
CREATE TABLE Invoice(
Id SMALLINT NOT NULL identity(1,1) PRIMARY KEY,
ChargeDate DATETIME NOT NULL,
Type NVARCHAR(30) NOT NULL,
CompanyId NVARCHAR(100) NOT NULL,
CONSTRAINT FK_company_Invoice FOREIGN KEY (CompanyId) REFERENCES Company(Id)
)

--table action log

CREATE TABLE Action_Log(
Id SMALLINT NOT NULL identity(1,1) PRIMARY KEY,
ActionName NVARCHAR(50) NOT NULL, 
ActionDate DATETIME NOT NULL,
UserType NVARCHAR(50) NOT NULL,
UserId NVARCHAR(100) NOT NULL,
CONSTRAINT FK_User_Action FOREIGN KEY (UserId) REFERENCES [User](IdentificationCard)
)

CREATE PROCEDURE CRE_ACTION_LOG_PR
@P_ActionName NVARCHAR(50),
@P_ActionDate DATETIME,
@P_UserRole SMALLINT,
@P_IdUser NVARCHAR(100)
AS
	INSERT INTO Action_Log(ActionName,ActionDate,UserType,UserId)
	VALUES(@P_ActionName,@P_ActionDate,@P_UserRole,@P_IdUser)
go
CREATE PROCEDURE RET_ACTIONS_BY_USER_PR
@P_IdUser NVARCHAR(100)
AS
SELECT * FROM Action_Log
WHERE UserId = @P_IdUser
RETURN;
go
CREATE PROCEDURE RET_ACTIONS_BY_USER_ROLE_PR
@P_UserRole SMALLINT
AS
SELECT * FROM Action_Log
WHERE UserType = @P_UserRole
RETURN;

--table notification
CREATE TABLE Notification(
Id SMALLINT NOT NULL identity(1,1) PRIMARY KEY,
Type NVARCHAR(30) NOT NULL,
Msj NVARCHAR(150) NOT NULL
)

--table reports
CREATE TABLE Reports(
Id SMALLINT NOT NULL identity(1,1) PRIMARY KEY,
Msj NVARCHAR(150) NOT NULL,
ReportDate DATETIME NOT NULL,
IdOffender NVARCHAR(100) NOT NULL,
IdReporter NVARCHAR(100) NOT NULL,
CONSTRAINT FK_User_Offend_Action FOREIGN KEY (IdOffender) REFERENCES [User](IdentificationCard),
CONSTRAINT FK_User_Reporter_Action FOREIGN KEY (IdReporter) REFERENCES [User](IdentificationCard)
)
--RESPONSABLE: Alison Yeung
--FECHA: 6/Abril/22
--TABLA NFT
CREATE TABLE [dbo].[TBL_NFT](
	[Id] INT NOT NULL identity(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Amount] DECIMAL(10,3),
	[CreationDate] DATETIME NOT NULL,
	CONSTRAINT FK_IdCollection_NFT FOREIGN KEY (IdCollection) REFERENCES [Collection](Id),
	CONSTRAINT FK_IdOwner_NFT FOREIGN KEY (IdOwner) REFERENCES [User](Cedula),
	CONSTRAINT FK_IdCreator_NFT FOREIGN KEY (IdCreator) REFERENCES [User](Cedula)
	)
GO
CREATE PROCEDURE UPD_NFT_STATE_PR
@P_Id NVARCHAR(100),
@P_SaleState NVARCHAR(50)
AS
UPDATE NFT
SET SaleState = @P_SaleState
WHERE Id = @P_Id
--upd collection nft
CREATE PROCEDURE UPD_NFT_COLLECTION_PR
	@P_Id NVARCHAR(100),
	@P_IdCollection SMALLINT
AS
	UPDATE NFT
	SET IdCollection = @P_IdCollection
	WHERE Id = @P_Id

--retsale by nft
CREATE PROCEDURE RET_NFT_SALESTATE_PR
@P_SaleState NVARCHAR(50)
AS
	SELECT N.Id, N.NftName, N.Price, N.CreationDate, N.IdCollection, N.IdCreator, N.IdOwner, N.Image, N.SaleState, C.CategoryName, U.Name as OwnerName, US.UserPic
	FROM NFT as N
	INNER JOIN NFT_Category as NC on N.Id = NC.NFTId
	INNER JOIN Category as C on C.Id = NC.CategoryId
	INNER JOIN [Company] as U on N.IdOwner = U.Id
	INNER JOIN [User] as US on US.IdOrganization = U.Id
	WHERE SaleState = @P_SaleState
RETURN 0;
--Insert NFT
ALTER procedure [dbo].[CRE_NFT_PR] 
	@P_Id nvarchar(100),
	@P_NftName nvarchar(100),
	@P_Price decimal(10,3),
	@P_CreationDate datetime,
	@P_IdCollection smallint,
	@P_IdCreator nvarchar(100),
	@P_IdOwner nvarchar(100),
	@P_Image nvarchar(250),
	@P_SaleState nvarchar(100)

	as
	insert into [dbo].[NFT] (Id, NftName, Price, CreationDate, IdCollection, IdCreator, IdOwner, Image, SaleState) 
	values (@P_Id, @P_NftName, @P_Price, @P_CreationDate, @P_IdCollection, @P_IdCreator, @P_IdOwner, @P_Image, @P_SaleState);
GO
--Delete NFT
CREATE PROCEDURE DEL_NFT_PR
	@P_Id INT
AS
	DELETE FROM NFT WHERE  Id = @P_Id;
GO
--Update NFT
CREATE PROCEDURE UPD_NFT_PR
	@P_Id INT,
	@P_Name NVARCHAR(50),
	@P_Amount DECIMAL(10,3)
AS
	UPDATE NFT
	SET Id = @P_Id, Name=@P_Name, Amount=@P_Amount
	WHERE Id=@P_Id;
GO
--Retrieve NFT
CREATE PROCEDURE RET_NFT_PR
	@P_Id INT
AS
	SELECT *
	FROM NFT
	WHERE Id = @P_Id
	RETURN;
GO
--Retrive All NFT
CREATE PROCEDURE [dbo].[RET_ALL_NFT_PR]
AS
	SELECT Id, Name, Amount, CreationDate
		   FROM TBL_NFT;
RETURN 0
GO

CREATE PROCEDURE RET_ALL_NFT_WITH_OWNER_PR
AS
	SELECT N.Id, N.NftName, N.Price, N.CreationDate, N.IdCollection, N.IdCreator, N.IdOwner, N.Image, C.CategoryName, U.Name as OwnerName
	FROM NFT as N
	INNER JOIN NFT_Category as NC on 
	N.Id = NC.NFTId
	INNER JOIN Category as C on
	C.Id = NC.CategoryId
	INNER JOIN [Company] as U on N.IdOwner = U.Id
RETURN 0;
RETURN 0;

--RESPONSABLE: Alison Yeung
--FECHA: 6/Abril/22
--TABLA NFT Image
CREATE TABLE [dbo].[TBL_NFTImage](
	[Id] SMALLINT NOT NULL identity(1,1) PRIMARY KEY,
	[Asset] NVARCHAR(50) NOT NULL,
	CONSTRAINT FK_IdNFT_NFTCategory FOREIGN KEY (IdNFT) REFERENCES [NFT](Id)
	)
GO
--Insert NFT Image
CREATE PROCEDURE CRE_NFTImage_PR
	@P_Id SMALLINT,
	@P_Asset NVARCHAR(50)
AS
	INSERT INTO TBL_NFTImage(Id, Name, Amount, CreationDate)
	VALUES(@P_Id, @P_Asser)
GO
--Delete NFT Image
CREATE PROCEDURE DEL_NFTImage_PR
	@P_Id SMALLINT(100)
AS
	DELETE FROM NFTCategory WHERE  Id = @P_Id;
GO
--Update NFT Image
CREATE PROCEDURE UPD_NFTImage_PR
	@P_Id SMALLINT,
	@P_Asset NVARCHAR(50)
AS
	UPDATE NFTCategory
	SET Id = @P_Id, Asset=@P_Asset
	WHERE Id=@P_Id;
GO
--Retrieve NFT Image
CREATE PROCEDURE RET_NFTImage_PR
	@P_Id NVARCHAR(100)
AS
	SELECT *
	FROM NFTCategory
	WHERE Id = @P_Id
	RETURN;
GO
--Retrive All NFT Image
CREATE PROCEDURE [dbo].[RET_ALL_NFTImage_PR]
AS
	SELECT Id, Asset
		   FROM TBL_NFTImage;
RETURN 0
GO

--UPDATE NFT WHEN BUY IT
CREATE PROCEDURE UPD_WHEN_BUY_NFT_PR
	@P_Id nvarchar(100),
	@P_Price decimal(10,3),
	@P_IdCollection smallint,
	@P_Owner nvarchar(100),
	@P_SaleState nvarchar(50)
AS
	update [dbo].[NFT]
	set Price = @P_Price, IdCollection = @P_IdCollection, IdOwner = @P_Owner, SaleState = @P_SaleState
	where Id = @P_Id


--table collection
CREATE TABLE Collection(
Id SMALLINT NOT NULL identity(1,1) PRIMARY KEY,
CollectionName NVARCHAR(100) NOT NULL,
CreationDate DATETIME NOT NULL,
CompanyId NVARCHAR(100) NOT NULL,
CONSTRAINT FK_Collection_Company FOREIGN KEY (CompanyId) REFERENCES Company(Id)
)

--table Category
CREATE TABLE Category(
Id SMALLINT NOT NULL identity(1,1) PRIMARY KEY,
CategoryName NVARCHAR(100) NOT NULL 
)

--table Collection_Category
CREATE TABLE Collection_Category(
IdCollection SMALLINT NOT NULL,
IdCategory SMALLINT NOT NULL,
PRIMARY KEY(IdCollection, IdCategory)
)

--tbl notifications
CREATE TABLE Notifications(
Id SMALLINT NOT NULL identity(1,1) PRIMARY KEY,
Msj NVARCHAR(150) NOT NULL,
SentDate DATETIME NOT NULL,
ReceiverId NVARCHAR(100) NOT NULL,
SenderId NVARCHAR(100) NOT NULL,
NftId NVARCHAR(100),
CONSTRAINT FK_ReceiverId_Notif FOREIGN KEY (ReceiverId) REFERENCES Company(Id),
CONSTRAINT FK_SenderId_Notif FOREIGN KEY (SenderId) REFERENCES Company(Id),
CONSTRAINT FK_NftId_Notif FOREIGN KEY (NftId) REFERENCES NFT(Id)
)

--Update profile
CREATE PROCEDURE UPD_INFO_USER_PR
	@P_Cedula NVARCHAR(100),
	@P_Name NVARCHAR(50),
	@P_SureNames NVARCHAR(100),
	@P_Phone NVARCHAR(30),
	@P_Nickname NVARCHAR(50),
	@P_UserPic NVARCHAR(150)
AS
	UPDATE [User]
	SET [Name] = @P_Name , SureNames= @P_SureNames,Phone= @P_Phone, Nickname= @P_Nickname, UserPic=@P_UserPic
	WHERE IdentificationCard = @P_Cedula

GO
--upd company name
CREATE PROCEDURE UPD_NAME_COMPANY_PR
	@P_Id NVARCHAR(100),
	@P_Name NVARCHAR(100)
AS
	UPDATE Company
	SET [Name] = @P_Name
	WHERE Id = @P_Id
GO
CREATE PROCEDURE UPD_WALLET_PIN_PR
	@P_WalletPin NVARCHAR(100),
	@P_CompanyId NVARCHAR(100)
AS
	UPDATE Wallet
	SET WalletPin = @P_WalletPin
	WHERE CompanyId = @P_CompanyId

--create notif
ALTER PROCEDURE [dbo].[CRE_NOTIF_PR]
@P_Msj NVARCHAR(150),
@P_SentDate DATETIME,
@P_ReceiverId NVARCHAR(100),
@P_SenderId NVARCHAR(100),
@P_NftId NVARCHAR(100)
AS
INSERT INTO Notifications(Msj, SentDate, ReceiverId, SenderId,NftId)
VALUES(@P_Msj,@P_SentDate,@P_ReceiverId,@P_SenderId,@P_NftId)


--ret all
ALTER PROCEDURE [dbo].[RET_ALL_NOTIF_RECIVER_PR]
	@P_ReceiverId NVARCHAR(100)
AS
	SELECT N.*, CO.Name as SenderName, NF.Image as NftImage
	FROM Notifications AS N
	INNER JOIN Company as CO on N.SenderId= CO.Id
	INNER JOIN NFT as NF on N.NftId = NF.Id
	WHERE ReceiverId = @P_ReceiverId

--ret notif offer
CREATE PROCEDURE RET_NOTIF_FROM_OFFER_PR
	@P_ReceiverId NVARCHAR(100)
AS
	SELECT o.Id, o.NFT AS NftId, o.BidderID as SenderId, o.OwnerID as ReceiverId ,o.CreationDate as SentDate, o.OwnerID as Msj,CO.Name as SenderName, NF.Image as NftImage, NF.NftName as NftName
	FROM Offer AS O
	INNER JOIN Company as CO on O.BidderID = CO.Id
	INNER JOIN NFT as NF on O.NFT = NF.Id
	WHERE OwnerID = @P_ReceiverId

--tbl Auction
CREATE TABLE Auction(
Id SMALLINT identity(1,1) NOT NULL PRIMARY KEY,
IdOwner NVARCHAR(100) NOT NULL,
IdBuyer NVARCHAR(100) NOT NULL,
Amount DECIMAL(10,3) NOT NULL,
Nft NVARCHAR(100) NOT NULL,
EndDate DATETIME,
CreationDate DATETIME,
CONSTRAINT FK_Nft_Auction FOREIGN KEY (Nft) REFERENCES NFT(Id),
CONSTRAINT FK_IdBuyer_Notif FOREIGN KEY (IdBuyer) REFERENCES Company(Id),
CONSTRAINT FK_IdOwner_Notif FOREIGN KEY (IdOwner) REFERENCES Company(Id),
)
GO
CREATE PROCEDURE CRE_AUCTION_PR
	@P_IdBuyer NVARCHAR(100),
	@P_IdOwner NVARCHAR(100),
	@P_Amount DECIMAL(10,3),
	@P_Nft NVARCHAR(100),
	@P_EndDate DATETIME,
	@P_CreationDate DATETIME
AS
	INSERT INTO Auction(IdOwner,IdBuyer,Amount,Nft,EndDate,CreationDate)
	VALUES(@P_IdOwner,@P_IdBuyer,@P_Amount,@P_Nft,@P_EndDate,@P_CreationDate)
GO

ALTER PROCEDURE [dbo].[RET_NFT_AUCTION_PR]
	@P_Nft NVARCHAR(100)
AS

	BEGIN 
	Declare @Collection smallint
	select @Collection = IdCollection from NFT where Id = @P_Nft
	
	IF @Collection is null

	BEGIN 
	SELECT a.Id, a.IdOwner, a.IdBuyer, a.Amount, a.EndDate, a.CreationDate, n.Id as NftId,n.NftName,n.Image,n.Price, n.CreationDate as CreationDateNft, 'Without Collection' as CollectionName, co.Name as CreatorName,u.UserPic as CreatorImage
	FROM Auction AS a
	INNER JOIN NFT AS n On a.Nft = n.Id
	INNER JOIN Company as co on n.IdOwner = co.Id
	INNER JOIN [User] as u on u.IdOrganization = co.Id
	WHERE Nft = @P_Nft
	END

	ELSE

	BEGIN

	SELECT a.Id, a.IdOwner, a.IdBuyer, a.Amount, a.EndDate, a.CreationDate, n.Id as NftId,n.NftName,n.Image,n.Price, n.CreationDate as CreationDateNft, c.CollectionName,co.Name as CreatorName,u.UserPic as CreatorImage
	FROM Auction AS a
	INNER JOIN NFT AS n On a.Nft = n.Id
	INNER JOIN Company as co on n.IdOwner = co.Id
	INNER JOIN [User] as u on u.IdOrganization = co.Id
	INNER JOIN Collection as c on N.IdCollection = c.Id
	WHERE Nft = @P_Nft
	END

	END
RETURN 0;

CREATE PROCEDURE UPD_AUCTION_BID_PR
@P_IdBuyer NVARCHAR(100),
@P_Amount DECIMAL(10,3),
@P_Nft NVARCHAR(100)
AS
UPDATE AUCTION
SET Amount = @P_Amount, IdBuyer =@P_IdBuyer
WHERE Nft = @P_Nft


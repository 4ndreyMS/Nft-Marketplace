CREATE PROCEDURE CRE_NFTCollection_PR
	@P_Id SMALLINT,
	@P_CollectionName NVARCHAR(100),
	@P_CreationDate DATE,
	@P_CompanyId NVARCHAR(100)
AS
	INSERT INTO [Collection](Id, CollectionName, CreationDate, CompanyId)
	VALUES(@P_Id,@P_CollectionName,@P_CreationDate, @P_CompanyId)
GO
--Delete NFT
CREATE PROCEDURE DEL_NFTCollection_PR
	@P_Id INT
AS
	DELETE FROM [Collection] WHERE  Id = @P_Id;
GO
--Update NFT
CREATE PROCEDURE UPD_NFTCollection_PR
@P_Id SMALLINT,
	@P_CollectionName NVARCHAR(100),
	@P_CreationDate DATE,
	@P_CompanyId NVARCHAR(100)
AS
	UPDATE [Collection]
	SET CollectionName=@P_CollectionName, CompanyId= @P_CompanyId
	WHERE Id=@P_Id;
GO
--Retrieve NFT
CREATE PROCEDURE RET_NFTCollection_PR
	@P_Id INT
AS
	SELECT *
	FROM [Collection]
	WHERE Id = @P_Id
	RETURN;
GO
--Retrive All NFT
CREATE PROCEDURE [dbo].[RET_ALL_NFTCollection_PR]
AS
	SELECT Id, CollectionName, CreationDate, CompanyId
		   FROM [Collection];
RETURN 0
GO

CREATE PROCEDURE [dbo].[RET_COLLECTION_BY_NAME_PR]
	@P_Id NVARCHAR(100),
	@P_CollectionName NVARCHAR(100)
AS
	SELECT Id, Name
	from [Collection]
Return 0
GO
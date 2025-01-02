BEGIN TRY 
	BEGIN TRANSACTION;

		INSERT INTO [dbo].[Clients] (
				[Identification],
				[Name],
				[ClientType],
				[CreatedAt]
			) 
		VALUES (
		@IdentificationNumber,
		@Name, 
		@ClientType, 
		GETDATE())


	COMMIT TRANSACTION;
END TRY 
BEGIN CATCH 

	ROLLBACK TRANSACTION;

	THROW;

END CATCH;
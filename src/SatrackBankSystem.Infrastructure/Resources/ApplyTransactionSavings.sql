 BEGIN TRY 
	BEGIN TRANSACTION;

		UPDATE [dbo].[SavingsAccounts]
		   SET [Balance] = @Balance
		 WHERE ProductId = @ProductId

	COMMIT TRANSACTION;
END TRY 
BEGIN CATCH 

	ROLLBACK TRANSACTION;

	THROW;

END CATCH;
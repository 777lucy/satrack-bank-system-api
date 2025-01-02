BEGIN TRY 
    BEGIN TRANSACTION;

    INSERT INTO [dbo].[FinancialProducts]
           ([ProductId]
           ,[Identification]
           ,[ProductType]
           ,[CreatedAt])
     VALUES
           (@ProductId
           ,@IdentificationNumber
           ,@ProductType
           ,GETDATE())

    INSERT INTO [dbo].[CurrentAccounts]
           ([ProductId]
           ,[Balance])
     VALUES
           (@ProductId
           ,@Balance)

    COMMIT TRANSACTION;
END TRY 
BEGIN CATCH 
    ROLLBACK TRANSACTION;
    THROW;
END CATCH;


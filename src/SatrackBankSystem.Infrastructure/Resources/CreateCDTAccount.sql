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

    INSERT INTO [dbo].[CDTs]
           ([ProductId]
           ,[DepositAmount]
           ,[InterestRate]
           ,[MaturityDate])
     VALUES
           (@ProductId
           ,@DepositAmount
           ,@InterestRate
           ,@MaturityDate)

    COMMIT TRANSACTION;
END TRY 
BEGIN CATCH 
    ROLLBACK TRANSACTION;
    THROW;
END CATCH;

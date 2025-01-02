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
        GETDATE());

    INSERT INTO [dbo].[BusinessClients]
            ([Identification]
            ,[LegalRepresentativeId]
            ,[LegalRepresentativeName]
            ,[LegalRepresentativePhone])
    VALUES
        (@IdentificationNumber,
        @LegalRepresentativeId,
        @LegalRepresentativeName,
        @LegalRepresentativePhone);

    COMMIT TRANSACTION;
END TRY 
BEGIN CATCH 
    ROLLBACK TRANSACTION;
    THROW;
END CATCH;

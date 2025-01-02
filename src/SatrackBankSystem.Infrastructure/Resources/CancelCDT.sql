BEGIN TRY 
	BEGIN TRANSACTION;
		DECLARE @CDTBalance DECIMAL(18, 2);
		DECLARE @ProductId UNIQUEIDENTIFIER;
		DECLARE @Identification NVARCHAR(50);
		DECLARE @SavingsProductId UNIQUEIDENTIFIER;

		SELECT @ProductId = ProductId, @CDTBalance = DepositAmount
		FROM CDTs
		WHERE ProductId = @AccountId;

		IF @ProductId IS NULL
		BEGIN
			ROLLBACK TRANSACTION;
			RAISERROR('El CDT no existe.', 16, 1);
			RETURN;
		END

		SELECT @Identification = Identification
		FROM FinancialProducts
		WHERE ProductId = @ProductId;

		IF @Identification IS NULL
		BEGIN
			ROLLBACK TRANSACTION;
			RAISERROR('Producto no encontrado en FinancialProducts.', 16, 1);
			RETURN;
		END

		SELECT @SavingsProductId = ProductId
		FROM SavingsAccounts
		WHERE ProductId IN (
			SELECT ProductId
			FROM FinancialProducts
			WHERE Identification = @Identification
		);

		IF @SavingsProductId IS NULL
		BEGIN
			ROLLBACK TRANSACTION;
			RAISERROR('La cuenta de ahorros no existe para este cliente.', 16, 1);
			RETURN;
		END

		DECLARE @SavingsBalance DECIMAL(18, 2);
    
		SELECT @SavingsBalance = Balance
		FROM SavingsAccounts
		WHERE ProductId = @SavingsProductId;

		UPDATE SavingsAccounts
		SET Balance = @SavingsBalance + @CDTBalance
		WHERE ProductId = @SavingsProductId;

		DELETE FROM CDTs
		WHERE ProductId = @ProductId;

		DELETE FROM FinancialProducts
		WHERE ProductId = @ProductId;

	COMMIT TRANSACTION;
END TRY 
BEGIN CATCH 

	ROLLBACK TRANSACTION;

	THROW;

END CATCH;
SELECT 
    fp.ProductId, 
    sa.Balance, 
	fp.Identification,
	fp.CreatedAt,
	fp.ProductType
FROM SavingsAccounts sa
INNER JOIN FinancialProducts fp on fp.ProductId = sa.ProductId
WHERE sa.ProductId = @AccountId;

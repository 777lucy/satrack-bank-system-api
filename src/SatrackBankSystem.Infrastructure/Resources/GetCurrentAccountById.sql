SELECT 
    fp.ProductId, 
    ca.Balance, 
	fp.Identification,
	fp.CreatedAt,
	fp.ProductType
FROM CurrentAccounts ca
INNER JOIN FinancialProducts fp on fp.ProductId = ca.ProductId
WHERE fp.ProductId = @AccountId;

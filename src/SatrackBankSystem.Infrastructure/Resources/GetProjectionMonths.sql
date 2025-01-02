SELECT 
    fp.ProductId AS AccountId,
    CASE 
        WHEN sa.ProductId IS NOT NULL THEN fp.ProductType
        WHEN cd.ProductId IS NOT NULL THEN fp.ProductType
        WHEN ca.ProductId IS NOT NULL THEN fp.ProductType
    END AS AccountType,
    CASE 
        WHEN sa.ProductId IS NOT NULL THEN sa.Balance + (sa.Balance * sa.InterestRate * @ProjectionMonths) 
        WHEN cd.ProductId IS NOT NULL THEN cd.DepositAmount + (cd.DepositAmount * cd.InterestRate * @ProjectionMonths)
        WHEN ca.ProductId IS NOT NULL THEN ca.Balance 
    END AS AmountProjection,
    @ProjectionMonths AS ProjectionPeriod
FROM 
    FinancialProducts fp
LEFT JOIN 
    SavingsAccounts sa ON sa.ProductId = fp.ProductId
LEFT JOIN 
    CDTs cd ON cd.ProductId = fp.ProductId
LEFT JOIN 
    CurrentAccounts ca ON ca.ProductId = fp.ProductId
WHERE fp.ProductId = @AccountId




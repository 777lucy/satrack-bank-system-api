SELECT 
    AVG(CAST(
        CASE WHEN c.ClientType = 1 THEN 
            COALESCE(sa.Balance, 0) + 
            COALESCE(cd.DepositAmount, 0) + 
            COALESCE(ca.Balance, 0) 
        END AS DECIMAL(18, 2)
    )) AS BusinessClientAverageBalance,
    
    AVG(CAST(
        CASE WHEN c.ClientType = 0 THEN 
            COALESCE(sa.Balance, 0) + 
            COALESCE(cd.DepositAmount, 0) + 
            COALESCE(ca.Balance, 0) 
        END AS DECIMAL(18, 2)
    )) AS IndividualClientAverageBalance
FROM 
    Clients c
INNER JOIN 
    FinancialProducts fp ON c.Identification = fp.Identification
LEFT JOIN 
    SavingsAccounts sa ON sa.ProductId = fp.ProductId
LEFT JOIN 
    CDTs cd ON cd.ProductId = fp.ProductId
LEFT JOIN 
    CurrentAccounts ca ON ca.ProductId = fp.ProductId;

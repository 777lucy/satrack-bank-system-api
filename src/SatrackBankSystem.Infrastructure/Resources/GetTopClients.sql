WITH RankedClients AS (
    SELECT 
        c.ClientType,
        c.Identification AS ClientIdentification,
        SUM(COALESCE(sa.Balance, 0) + COALESCE(cd.DepositAmount, 0) + COALESCE(ca.Balance, 0)) AS TotalBalance,
        ROW_NUMBER() OVER (PARTITION BY c.ClientType ORDER BY SUM(COALESCE(sa.Balance, 0) + COALESCE(cd.DepositAmount, 0) + COALESCE(ca.Balance, 0)) DESC) AS RowNum
    FROM Clients c
    INNER JOIN FinancialProducts fp ON c.Identification = fp.Identification
    LEFT JOIN SavingsAccounts sa ON sa.ProductId = fp.ProductId
    LEFT JOIN CDTs cd ON cd.ProductId = fp.ProductId
    LEFT JOIN CurrentAccounts ca ON ca.ProductId = fp.ProductId
    GROUP BY c.ClientType, c.Identification
)
SELECT 
    ClientType,
    ClientIdentification,
    TotalBalance
FROM RankedClients
WHERE RowNum <= 10
ORDER BY ClientType, TotalBalance DESC;

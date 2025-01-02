SELECT 
    CASE 
        WHEN EXISTS (
            SELECT 1
            FROM CDTs c
            INNER JOIN FinancialProducts fp_cdt ON fp_cdt.ProductId = c.ProductId
            INNER JOIN FinancialProducts fp_savings ON fp_savings.Identification = fp_cdt.Identification
            INNER JOIN SavingsAccounts sa ON sa.ProductId = fp_savings.ProductId
            WHERE c.ProductId = @CDTAccountId
        ) THEN 1
        ELSE 0
    END AS HasSavingsAccount;

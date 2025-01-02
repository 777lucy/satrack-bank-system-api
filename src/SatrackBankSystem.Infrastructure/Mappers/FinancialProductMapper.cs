using SatrackBankSystem.Domain.Entities;
using SatrackBankSystem.Domain.Enums;

namespace SatrackBankSystem.Infrastructure.Mappers
{
    public static class FinancialProductMapper
    {
        public static FinancialProduct MapToFinancialProduct(dynamic result)
        {
            Guid id = result.ProductId;
            string clientId = result.Identification;
            DateTime creationDate = result.CreatedAt;
            decimal balance = result.Balance;
            int productType = result.ProductType;

            return productType switch
            {
                (int)AccountType.Current => new CurrentAccount(id, clientId, balance),
                (int)AccountType.Savings => new SavingsAccount(id, clientId, balance),
                _ => throw new InvalidOperationException("Tipo de cuenta desconocida.")
            };
        }
    }
}

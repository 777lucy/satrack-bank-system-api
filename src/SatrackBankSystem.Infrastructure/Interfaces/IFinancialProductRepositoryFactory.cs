using SatrackBankSystem.Domain.Enums;

namespace SatrackBankSystem.Infrastructure.Interfaces
{
    public interface IFinancialProductRepositoryFactory
    {
        IFinancialProductRepositoryBase GetRepository(AccountType accountType);
    }
}

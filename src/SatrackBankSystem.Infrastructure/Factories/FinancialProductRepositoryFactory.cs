using SatrackBankSystem.Domain.Enums;
using SatrackBankSystem.Infrastructure.Interfaces;

namespace SatrackBankSystem.Infrastructure.Factories
{
    public class FinancialProductRepositoryFactory : IFinancialProductRepositoryFactory
    {
        private readonly Dictionary<AccountType, IFinancialProductRepositoryBase> _repositories;

        public FinancialProductRepositoryFactory(
            ISavingsAccountRepository savingsAccountRepository,
            ICDTAccountRepository cdtAccountRepository,
            ICurrentAccountRepository currentAccountRepository)
        {
            _repositories = new Dictionary<AccountType, IFinancialProductRepositoryBase>
            {
                { AccountType.Savings, savingsAccountRepository },
                { AccountType.CDT, cdtAccountRepository },
                { AccountType.Current, currentAccountRepository }
            };
        }

        public IFinancialProductRepositoryBase GetRepository(AccountType accountType)
        {
            if (_repositories.TryGetValue(accountType, out IFinancialProductRepositoryBase? repository))
            {
                return repository;
            }

            throw new ArgumentException("Tipo cuenta invalida.");
        }
    }
}

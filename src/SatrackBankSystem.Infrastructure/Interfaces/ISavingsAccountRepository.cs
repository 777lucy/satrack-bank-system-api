using MediatR;
using SatrackBankSystem.Domain.Entities;

namespace SatrackBankSystem.Infrastructure.Interfaces
{
    public interface ISavingsAccountRepository : IFinancialProductRepositoryBase
    {
        Task<Unit> ApplyTransaction(SavingsAccount savingsAccount);
        Task<FinancialProduct?> GetByIdentification(string identification);
    }
}

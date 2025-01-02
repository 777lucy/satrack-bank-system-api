using MediatR;
using SatrackBankSystem.Domain.Entities;

namespace SatrackBankSystem.Infrastructure.Interfaces
{
    public interface ICurrentAccountRepository : IFinancialProductRepositoryBase
    {
        Task<Unit> ApplyTransaction(CurrentAccount product);
    }
}

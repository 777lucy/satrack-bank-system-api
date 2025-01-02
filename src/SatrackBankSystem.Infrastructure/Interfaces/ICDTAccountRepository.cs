using MediatR;

namespace SatrackBankSystem.Infrastructure.Interfaces
{
    public interface ICDTAccountRepository : IFinancialProductRepositoryBase
    {
        Task<Unit> CancelCDT(Guid accountId);
    }
}

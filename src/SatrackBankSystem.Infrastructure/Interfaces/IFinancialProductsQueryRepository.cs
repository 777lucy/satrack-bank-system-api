using SatrackBankSystem.Infrastructure.Dtos;

namespace SatrackBankSystem.Infrastructure.Interfaces
{
    public interface IFinancialProductsQueryRepository
    {
        Task<InterestProjectionDto?> GetInterestProjection(Guid accountId, int projectionMonths);
    }
}

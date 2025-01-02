using MediatR;
using SatrackBankSystem.Domain.Entities;

namespace SatrackBankSystem.Infrastructure.Interfaces
{
    public interface IFinancialProductRepositoryBase
    {
        Task<Unit> CreateFinancialProduct(FinancialProduct product);
        Task<FinancialProduct?> GetById(Guid id);
    }
}

using SatrackBankSystem.Infrastructure.Dtos;

namespace SatrackBankSystem.Infrastructure.Interfaces
{
    public interface IClientQueryRepository
    {
        Task<AverageBalanceDto?> GetAverageBalance();
        Task<IEnumerable<GroupedTopClientsBalanceDto>> GetTopClients();
    }
}

using SatrackBankSystem.Infrastructure.Dtos;
using SatrackBankSystem.Infrastructure.Interfaces;
using SatrackBankSystem.Infrastructure.Mappers;
using SatrackBankSystem.Infrastructure.Resources;

namespace SatrackBankSystem.Infrastructure.Repositories
{
    public class ClientQueryRepository : IClientQueryRepository
    {
        private readonly ISqlServerBase<dynamic> _sqlServerBase;

        public ClientQueryRepository(ISqlServerBase<dynamic> sqlServerBase)
        {
            _sqlServerBase = sqlServerBase;
        }

        public async Task<AverageBalanceDto?> GetAverageBalance()
        {
            string sql = SqlResources.GetAverageBalance;

            dynamic? averageBalance = await _sqlServerBase.QueryFirstOrDefaultAsync(sql);

            return averageBalance == null ? null : AverageBalanceMapper.ToAverageBalanceDto(averageBalance);
        }

        public async Task<IEnumerable<GroupedTopClientsBalanceDto>> GetTopClients()
        {
            string sql = SqlResources.GetTopClients;

            IEnumerable<dynamic>? topClients = await _sqlServerBase.ExecuteQueryAsync(sql);

            return GroupedTopClientsBalanceMapper.ToGroupedTopClientsBalanceDtos(topClients);
        }
    }
}

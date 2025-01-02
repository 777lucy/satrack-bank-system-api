using SatrackBankSystem.Infrastructure.Dtos;

namespace SatrackBankSystem.Infrastructure.Mappers
{
    public static class AverageBalanceMapper
    {
        public static AverageBalanceDto ToAverageBalanceDto(dynamic averageBalance)
        {
            return new AverageBalanceDto
            {
                BusinessClientAverageBalance = averageBalance.BusinessClientAverageBalance ?? 0,
                IndividualClientAverageBalance = averageBalance.IndividualClientAverageBalance ?? 0
            };
        }
    }
}

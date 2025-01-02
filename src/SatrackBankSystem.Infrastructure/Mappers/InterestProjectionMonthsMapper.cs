using SatrackBankSystem.Domain.Enums;
using SatrackBankSystem.Infrastructure.Dtos;

namespace SatrackBankSystem.Infrastructure.Mappers
{
    public static class InterestProjectionMonthsMapper
    {
        public static InterestProjectionDto dynamicTointerestProjectionDto(dynamic projection)
        {
            return new InterestProjectionDto
            {
                AccountId = projection.AccountId,
                AccountType = (AccountType)projection.AccountType,
                AmountProjection = projection.AmountProjection
            };
        }
    }
}

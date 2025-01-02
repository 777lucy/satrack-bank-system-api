using SatrackBankSystem.Domain.Enums;

namespace SatrackBankSystem.Infrastructure.Dtos
{
    public class InterestProjectionDto
    {
        public Guid AccountId { get; set; }
        public AccountType AccountType { get; set; }
        public decimal AmountProjection { get; set; }
    }
}

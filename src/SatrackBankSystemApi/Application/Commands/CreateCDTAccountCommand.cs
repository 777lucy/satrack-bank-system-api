using MediatR;

namespace SatrackBankSystem.Api.Application.Commands
{
    public class CreateCDTAccountCommand : IRequest<Unit>
    {
        public string Identification { get; set; } = string.Empty;
        public DateTime MaturityDate { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal MonthlyInterest { get; set; }
    }
}

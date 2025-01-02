using MediatR;

namespace SatrackBankSystem.Api.Application.Commands
{
    public class ApplyTransactionSavingsCommand : IRequest<Unit>
    {
        public Guid AccountId { get; private set; }

        public decimal TransactionAmount { get; set; }

        public void SetAccountId(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}

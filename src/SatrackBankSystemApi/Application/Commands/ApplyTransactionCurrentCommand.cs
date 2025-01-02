using MediatR;

namespace SatrackBankSystem.Api.Application.Commands
{
    public class ApplyTransactionCurrentCommand : IRequest<Unit>
    {
        public Guid AccountId { get; private set; }

        public decimal TransactionAmount { get; set; }

        public void SetAccountId(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}

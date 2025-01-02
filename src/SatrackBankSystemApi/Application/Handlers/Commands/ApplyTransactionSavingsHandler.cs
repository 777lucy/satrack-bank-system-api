using MediatR;
using SatrackBankSystem.Api.Application.Commands;
using SatrackBankSystem.Domain.Entities;
using SatrackBankSystem.Infrastructure.Interfaces;

namespace SatrackBankSystem.Api.Application.Handlers.Commands
{
    public class ApplyTransactionSavingsHandler : IRequestHandler<ApplyTransactionSavingsCommand, Unit>
    {
        private readonly ISavingsAccountRepository _savingsAccountRepository;

        public ApplyTransactionSavingsHandler(ISavingsAccountRepository savingsAccountRepository)
        {
            _savingsAccountRepository = savingsAccountRepository;
        }

        public async Task<Unit> Handle(ApplyTransactionSavingsCommand request, CancellationToken cancellationToken)
        {
            FinancialProduct? product = await _savingsAccountRepository.GetById(request.AccountId);

            if (product == null || product is not SavingsAccount savingsAccount)
            {
                throw new ArgumentException("La cuenta no existe en el sistema o error consultando.");
            }

            savingsAccount.SetNewBalance(request.TransactionAmount);

            await _savingsAccountRepository.ApplyTransaction(savingsAccount);

            return Unit.Value;
        }
    }
}

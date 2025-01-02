using MediatR;
using SatrackBankSystem.Api.Application.Commands;
using SatrackBankSystem.Domain.Entities;
using SatrackBankSystem.Infrastructure.Interfaces;

namespace SatrackBankSystem.Api.Application.Handlers.Commands
{
    public class ApplyTransactionCurrentHandler : IRequestHandler<ApplyTransactionCurrentCommand, Unit>
    {
        private readonly ICurrentAccountRepository _currentAccountRepository;

        public ApplyTransactionCurrentHandler(ICurrentAccountRepository currentAccountRepository)
        {
            _currentAccountRepository = currentAccountRepository;
        }

        public async Task<Unit> Handle(ApplyTransactionCurrentCommand request, CancellationToken cancellationToken)
        {
            FinancialProduct? product = await _currentAccountRepository.GetById(request.AccountId);

            if (product == null || product is not CurrentAccount currentAccount)
            {
                throw new ArgumentException("La cuenta no existe en el sistema o error consultando.");
            }

            currentAccount.SetNewBalance(request.TransactionAmount);

            await _currentAccountRepository.ApplyTransaction(currentAccount);

            return Unit.Value;
        }
    }
}

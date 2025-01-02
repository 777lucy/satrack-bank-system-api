using MediatR;
using SatrackBankSystem.Api.Application.Commands;
using SatrackBankSystem.Domain.Entities;
using SatrackBankSystem.Domain.Enums;
using SatrackBankSystem.Infrastructure.Interfaces;

namespace SatrackBankSystem.Api.Application.Handlers.Commands
{
    public class CreateCurrentAccountHandler : IRequestHandler<CreateCurrentAccountCommand, Unit>
    {
        private readonly IFinancialProductRepositoryFactory _financialProductRepositoryFactory;
        private readonly IValidationService _validationService;

        public CreateCurrentAccountHandler(IFinancialProductRepositoryFactory financialProductRepositoryFactory, IValidationService validationService)
        {
            _financialProductRepositoryFactory = financialProductRepositoryFactory;
            _validationService = validationService;
        }

        public async Task<Unit> Handle(CreateCurrentAccountCommand request, CancellationToken cancellationToken)
        {
            await Validate(request.Identification);

            CurrentAccount currentAccount = new(Guid.NewGuid(), request.Identification, 0);

            IFinancialProductRepositoryBase repository = _financialProductRepositoryFactory.GetRepository(AccountType.Current);

            await repository.CreateFinancialProduct(currentAccount);

            return Unit.Value;
        }

        private async Task Validate(string identification)  // Make this method async
        {
            bool clientExist = await _validationService.ClientExist(identification);

            if (!clientExist)
            {
                throw new ArgumentException($"El cliente con identificación {identification} no existe en el sistema");
            }

            bool accountExist = await _validationService.AccountExistByIdentificationAndAccountType(identification, AccountType.Current);

            if (accountExist)
            {
                throw new ArgumentException($"El cliente con identificación {identification} ya tiene una cuenta corriente");
            }
        }
    }
}

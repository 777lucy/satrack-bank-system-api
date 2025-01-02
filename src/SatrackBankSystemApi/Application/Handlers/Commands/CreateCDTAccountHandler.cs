using MediatR;
using SatrackBankSystem.Api.Application.Commands;
using SatrackBankSystem.Domain.Entities;
using SatrackBankSystem.Domain.Enums;
using SatrackBankSystem.Infrastructure.Interfaces;

namespace SatrackBankSystem.Api.Application.Handlers.Commands
{
    public class CreateCDTAccountHandler : IRequestHandler<CreateCDTAccountCommand, Unit>
    {
        private readonly IFinancialProductRepositoryFactory _financialProductRepositoryFactory;
        private readonly IValidationService _validationService;

        public CreateCDTAccountHandler(IFinancialProductRepositoryFactory financialProductRepositoryFactory, IValidationService validationService)
        {
            _financialProductRepositoryFactory = financialProductRepositoryFactory;
            _validationService = validationService;
        }

        public async Task<Unit> Handle(CreateCDTAccountCommand request, CancellationToken cancellationToken)
        {
            await Validate(request.Identification);

            CDTAccount cdtAccount = new(Guid.NewGuid(), request.Identification, request.DepositAmount, request.MaturityDate, request.MonthlyInterest);

            IFinancialProductRepositoryBase repository = _financialProductRepositoryFactory.GetRepository(AccountType.CDT);

            await repository.CreateFinancialProduct(cdtAccount);

            return Unit.Value;
        }


        private async Task Validate(string identification)  // Make this method async
        {
            bool clientExist = await _validationService.ClientExist(identification);

            if (!clientExist)
            {
                throw new ArgumentException($"El cliente con identificación {identification} no existe en el sistema");
            }

            bool accountExist = await _validationService.AccountExistByIdentificationAndAccountType(identification, AccountType.CDT);

            if (accountExist)
            {
                throw new ArgumentException($"El cliente con identificación {identification} ya tiene una cuenta CDT");
            }
        }
    }
}

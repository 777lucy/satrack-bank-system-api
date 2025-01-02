using MediatR;
using SatrackBankSystem.Api.Application.Commands;
using SatrackBankSystem.Domain.Enums;
using SatrackBankSystem.Infrastructure.Interfaces;

namespace SatrackBankSystem.Api.Application.Handlers.Commands
{
    public class CancelCDTHandler : IRequestHandler<CancelCDTCommand, Unit>
    {
        private readonly IValidationService _validationService;
        private readonly ICDTAccountRepository _cdtAccountRepository;
        public CancelCDTHandler(IValidationService validationService, ICDTAccountRepository cdtAccountRepository)
        {
            _validationService = validationService;
            _cdtAccountRepository = cdtAccountRepository;
        }

        public async Task<Unit> Handle(CancelCDTCommand request, CancellationToken cancellationToken)
        {
            bool haveCDT = await _validationService.AccountExistByIdAndType(request.AccountId, AccountType.CDT);

            if (!haveCDT)
            {
                throw new ArgumentException("La cuenta CDT a cancelar no existe en el sistema.");
            }

            bool haveSavingsAccount = await _validationService.HaveSavingsAccountByCDTAccount(request.AccountId);

            if (!haveSavingsAccount)
            {
                throw new ArgumentException("Debe crear una cuenta de ahorros para cancelar el CDT.");
            }

            await _cdtAccountRepository.CancelCDT(request.AccountId);

            return Unit.Value;
        }
    }
}

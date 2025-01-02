using MediatR;
using SatrackBankSystem.Api.Application.Queries;
using SatrackBankSystem.Domain.Enums;
using SatrackBankSystem.Infrastructure.Dtos;
using SatrackBankSystem.Infrastructure.Interfaces;

namespace SatrackBankSystem.Api.Application.Handlers.Queries
{
    public class GetInterestProjectionHandler : IRequestHandler<GetInterestProjectionQuery, InterestProjectionDto>
    {
        private readonly IFinancialProductsQueryRepository _financialProductsQueryRepository;
        private readonly IValidationService _validationService;

        public GetInterestProjectionHandler(IFinancialProductsQueryRepository financialProductsQueryRepository, IValidationService validationService)
        {
            _financialProductsQueryRepository = financialProductsQueryRepository;
            _validationService = validationService;
        }

        public async Task<InterestProjectionDto> Handle(GetInterestProjectionQuery request, CancellationToken cancellationToken)
        {
            bool accountExist = await _validationService.AccountExistByAccountId(request.AccountId);

            if (!accountExist)
            {
                throw new ArgumentException("La cuenta a proyectar no existe en el sistema.");
            }

            bool isCurrent = await _validationService.AccountExistByIdAndType(request.AccountId, AccountType.Current);

            if (isCurrent)
            {
                throw new ArgumentException("La cuenta corriente no genera intereses.");
            }

            InterestProjectionDto? projection = await _financialProductsQueryRepository.GetInterestProjection(request.AccountId, request.ProjectionMonths);

            if (projection == null)
            {
                throw new ArgumentNullException("Error consultando la proyección del producto");
            }

            return projection;
        }
    }
}

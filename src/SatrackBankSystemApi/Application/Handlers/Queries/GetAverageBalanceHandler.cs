using MediatR;
using SatrackBankSystem.Api.Application.Queries;
using SatrackBankSystem.Infrastructure.Dtos;
using SatrackBankSystem.Infrastructure.Interfaces;

namespace SatrackBankSystem.Api.Application.Handlers.Queries
{
    public class GetAverageBalanceHandler : IRequestHandler<GetAverageBalanceQuery, AverageBalanceDto>
    {
        private readonly IClientQueryRepository _clientQueryRepository;

        public GetAverageBalanceHandler(IClientQueryRepository clientQueryRepository)
        {
            _clientQueryRepository = clientQueryRepository;
        }

        public async Task<AverageBalanceDto> Handle(GetAverageBalanceQuery request, CancellationToken cancellationToken)
        {
            AverageBalanceDto? averageBalance = await _clientQueryRepository.GetAverageBalance();

            if (averageBalance == null)
            {
                throw new ArgumentException("No se encontraron clientes para consultar el saldo promedio");
            }

            return averageBalance;
        }
    }
}

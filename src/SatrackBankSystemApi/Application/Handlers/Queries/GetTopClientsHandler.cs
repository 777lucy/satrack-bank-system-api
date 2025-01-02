using MediatR;
using SatrackBankSystem.Api.Application.Queries;
using SatrackBankSystem.Infrastructure.Dtos;
using SatrackBankSystem.Infrastructure.Interfaces;

namespace SatrackBankSystem.Api.Application.Handlers.Queries
{
    public class GetTopClientsHandler : IRequestHandler<GetTopClientsQuery, IEnumerable<GroupedTopClientsBalanceDto>>
    {
        private readonly IClientQueryRepository _clientQueryRepository;

        public GetTopClientsHandler(IClientQueryRepository clientQueryRepository)
        {
            _clientQueryRepository = clientQueryRepository;
        }

        public async Task<IEnumerable<GroupedTopClientsBalanceDto>> Handle(GetTopClientsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<GroupedTopClientsBalanceDto> topClients = await _clientQueryRepository.GetTopClients();

            if (!topClients.Any())
            {
                throw new ArgumentNullException("No hay clientes para consultar.");
            }

            return topClients;
        }
    }
}

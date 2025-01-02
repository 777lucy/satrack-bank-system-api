using MediatR;
using SatrackBankSystem.Infrastructure.Dtos;

namespace SatrackBankSystem.Api.Application.Queries
{
    public class GetTopClientsQuery : IRequest<IEnumerable<GroupedTopClientsBalanceDto>>
    {
    }
}

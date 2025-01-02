using MediatR;
using SatrackBankSystem.Infrastructure.Dtos;

namespace SatrackBankSystem.Api.Application.Queries
{
    public class GetAverageBalanceQuery : IRequest<AverageBalanceDto>
    {
    }
}

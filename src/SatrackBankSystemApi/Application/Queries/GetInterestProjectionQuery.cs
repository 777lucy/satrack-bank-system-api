using MediatR;
using SatrackBankSystem.Infrastructure.Dtos;

namespace SatrackBankSystem.Api.Application.Queries
{
    public class GetInterestProjectionQuery : IRequest<InterestProjectionDto>
    {
        public Guid AccountId { get; set; }
        public int ProjectionMonths { get; set; }
    }
}

using MediatR;

namespace SatrackBankSystem.Api.Application.Commands
{
    public class CancelCDTCommand : IRequest<Unit>
    {
        public Guid AccountId { get; set; }
    }
}

using MediatR;

namespace SatrackBankSystem.Api.Application.Commands
{
    public class CreateSavingsAccountCommand : IRequest<Unit>
    {
        public string Identification { get; set; } = string.Empty;
    }
}

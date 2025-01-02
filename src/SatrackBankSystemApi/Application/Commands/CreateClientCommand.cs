using MediatR;
using SatrackBankSystem.Domain.Enums;

namespace SatrackBankSystem.Api.Application.Commands
{
    public class CreateClientCommand : IRequest<Unit>
    {
        public string Identification { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ClientType ClientType { get; set; }
        public string? LegalRepresentativeIdentification { get; set; }
        public string? LegalRepresentativeName { get; set; }
        public string? LegalRepresentativePhone { get; set; }
    }
}

using SatrackBankSystem.Domain.Enums;

namespace SatrackBankSystem.Infrastructure.Dtos
{
    public class ClientDto
    {
        public string Identification { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ClientType ClientType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LegalRepresentativeIdentification { get; set; }
        public string? LegalRepresentativeName { get; set; }
        public string? LegalRepresentativePhone { get; set; }
    }
}

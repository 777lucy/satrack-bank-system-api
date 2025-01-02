using SatrackBankSystem.Api.Application.Commands;
using SatrackBankSystem.Infrastructure.Dtos;

namespace SatrackBankSystem.Api.Application.Mappers
{
    public static class ClientMapper
    {
        public static ClientDto ToDto(this CreateClientCommand command)
        {
            return new ClientDto
            {
                Identification = command.Identification,
                Name = command.Name,
                ClientType = command.ClientType,
                CreatedAt = DateTime.UtcNow,
                LegalRepresentativeIdentification = command.LegalRepresentativeIdentification,
                LegalRepresentativeName = command.LegalRepresentativeName,
                LegalRepresentativePhone = command.LegalRepresentativePhone
            };
        }
    }
}

using SatrackBankSystem.Domain.Enums;
using SatrackBankSystem.Domain.ValueObjects;
using SatrackBankSystem.Infrastructure.Dtos;
using SatrackBankSystem.Infrastructure.Interfaces;

namespace SatrackBankSystem.Infrastructure.Factories
{
    public class ClientFactory : IClientFactory
    {
        private readonly IBusinessClientRepository _businessClientRepository;
        private readonly IIndividualClientRepository _individualClientRepository;

        public ClientFactory(
            IBusinessClientRepository businessClientRepository,
            IIndividualClientRepository individualClientRepository)
        {
            _businessClientRepository = businessClientRepository;
            _individualClientRepository = individualClientRepository;
        }

        public Client BuildClient(ClientDto clientDto)
        {
            switch (clientDto.ClientType)
            {
                case ClientType.Business:
                    LegalRepresentative legalRepresentative = new LegalRepresentative(
                    clientDto.LegalRepresentativeIdentification!,
                    clientDto.LegalRepresentativeName!,
                    new Phone(clientDto.LegalRepresentativePhone!));

                    return new BusinessClient(clientDto.Identification, clientDto.Name, legalRepresentative, clientDto.ClientType);

                case ClientType.Individual:
                    return new IndividualClient(clientDto.Identification, clientDto.Name, clientDto.ClientType);
                default:
                    throw new ArgumentException($"Tipo de cliente inválido: {clientDto.ClientType}"); ;
            }
        }
    }
}

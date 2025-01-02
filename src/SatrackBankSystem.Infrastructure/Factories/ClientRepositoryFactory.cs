using SatrackBankSystem.Domain.Enums;
using SatrackBankSystem.Infrastructure.Interfaces;

namespace SatrackBankSystem.Infrastructure.Factories
{
    public class ClientRepositoryFactory : IClientRepositoryFactory
    {
        private readonly IBusinessClientRepository _businessClientRepository;
        private readonly IIndividualClientRepository _individualClientRepository;

        public ClientRepositoryFactory(
            IBusinessClientRepository businessClientRepository,
            IIndividualClientRepository individualClientRepository)
        {
            _businessClientRepository = businessClientRepository;
            _individualClientRepository = individualClientRepository;
        }

        public IClientRepositoryBase GetRepository(ClientType clientType)
        {
            return clientType switch
            {
                ClientType.Business => _businessClientRepository,
                ClientType.Individual => _individualClientRepository,
                _ => throw new ArgumentException("Tipo de cliente no soportado.", nameof(clientType))
            };
        }
    }
}

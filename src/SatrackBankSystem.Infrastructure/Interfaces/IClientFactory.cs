using SatrackBankSystem.Infrastructure.Dtos;

namespace SatrackBankSystem.Infrastructure.Interfaces
{
    public interface IClientFactory
    {
        Client BuildClient(ClientDto clientDto);
    }
}

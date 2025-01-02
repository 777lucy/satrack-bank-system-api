using SatrackBankSystem.Domain.Enums;

namespace SatrackBankSystem.Infrastructure.Interfaces
{
    public interface IClientRepositoryFactory
    {
        IClientRepositoryBase GetRepository(ClientType clientType);
    }
}

using MediatR;

namespace SatrackBankSystem.Infrastructure.Interfaces
{
    public interface IClientRepositoryBase
    {
        Task<Unit> CreateClient(Client client);
    }
}

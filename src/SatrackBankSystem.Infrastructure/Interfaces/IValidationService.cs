using SatrackBankSystem.Domain.Enums;

namespace SatrackBankSystem.Infrastructure.Interfaces
{
    public interface IValidationService
    {
        Task<bool> ClientExist(string identification);
        Task<bool> AccountExistByIdentificationAndAccountType(string identification, AccountType accountType);
        Task<bool> HaveSavingsAccountByCDTAccount(Guid cdtAccountId);
        Task<bool> AccountExistByAccountId(Guid accountId);
        Task<bool> AccountExistByIdAndType(Guid id, AccountType accountType);
    }
}
